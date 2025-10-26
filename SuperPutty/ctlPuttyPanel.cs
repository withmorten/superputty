/*
 * Copyright (c) 2009 - 2015 Jim Radford http://www.jimradford.com
 * Copyright (c) 2012 John Peterson
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions: 
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using log4net;
using System.Diagnostics;
using System.Web;
using System.Collections.Specialized;
using SuperPutty.Data;
using WeifenLuo.WinFormsUI.Docking;
using SuperPutty.Utils;
using System.Threading;
using System.Configuration;
using SuperPutty.Gui;
using log4net.Core;
using DarkModeForms;


namespace SuperPutty
{
    /// <summary>A control that hosts a putty window</summary>
    public partial class ctlPuttyPanel : ToolWindowDocument
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ctlPuttyPanel));

        private static int RefocusAttempts = Convert.ToInt32(ConfigurationManager.AppSettings["SuperPuTTY.RefocusAttempts"] ?? "5");
        private static int RefocusIntervalMs = Convert.ToInt32(ConfigurationManager.AppSettings["SuperPuTTY.RefocusIntervalMs"] ?? "80");

        private PuttyStartInfo m_puttyStartInfo;
        private PuttyClosedCallback m_ApplicationExit;

        public ctlPuttyPanel(SessionData session, PuttyClosedCallback callback)
        {
            Session = session;
            m_ApplicationExit = callback;
            m_puttyStartInfo = new PuttyStartInfo(session);

            InitializeComponent();

            this.Text = session.SessionName;
            this.TabText = session.SessionName;
            this.TextOverride = session.SessionName;

            CreatePanel();
            AdjustMenu();

            aboutPuttyToolStripMenuItem.Text = "About " + SuperPuTTY.PuTTYAppName;
        }

        /// <summary>Gets or sets the text displayed on a tab.</summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                this.TabText = value != null ? value.Replace("&", "&&") : null;
                base.Text = value;

                if (Log.Logger.IsEnabledFor(Level.Trace))
                {
                    Log.DebugFormat("SetText: text={0}", value);
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.ToolTipText = this.Text;
        }

        private void CreatePanel()
        {
            this.AppPanel = new ApplicationPanel(this.Session.Proto);
            this.SuspendLayout();            
            this.AppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppPanel.ApplicationName = this.m_puttyStartInfo.Executable;
            this.AppPanel.ApplicationParameters = this.m_puttyStartInfo.Args;
            this.AppPanel.ApplicationWorkingDirectory = this.m_puttyStartInfo.WorkingDir;
            this.AppPanel.ApplicationCloseWithDestroy = this.Session.Proto == ConnectionProtocol.Mintty ? false : true;
            if (this.Session.Proto == ConnectionProtocol.Mintty) this.AppPanel.mintty = this.m_puttyStartInfo.Mintty;
            this.AppPanel.Location = new System.Drawing.Point(0, 0);
            this.AppPanel.Name = this.Session.SessionId; // "applicationControl1";
            this.AppPanel.Size = new System.Drawing.Size(this.Width, this.Height);
            this.AppPanel.TabIndex = 0;            
            this.AppPanel.m_CloseCallback = this.m_ApplicationExit;
            this.Controls.Add(this.AppPanel);

            this.ResumeLayout();
        }

        void AdjustMenu()
        {
            // For certain protocols, disable the putty menu items
            if (Session.Proto == ConnectionProtocol.VNC ||
                Session.Proto == ConnectionProtocol.Mintty ||
                Session.Proto == ConnectionProtocol.RDP ||
                Session.Proto == ConnectionProtocol.WINCMD ||
                Session.Proto == ConnectionProtocol.PS ||
                Session.Proto == ConnectionProtocol.WSL)
            {
                toolStripPuttySep1.Visible = false;
                eventLogToolStripMenuItem.Visible = false;
                toolStripPuttySep2.Visible = false;
                changeSettingsToolStripMenuItem.Visible = false;
                copyAllToClipboardToolStripMenuItem.Visible = false;
                restartSessionToolStripMenuItem.Visible = false;
                clearScrollbackToolStripMenuItem.Visible = false;
                resetTerminalToolStripMenuItem.Visible = false;
                resetAndClearScrollbackToolStripMenuItem.Visible = false;
                aboutPuttyToolStripMenuItem.Visible = false;
                toolStripSeparator4.Visible = false;
            }
        }

        private void InitNewSessionToolStripMenuItems()
        {
            List<ToolStripMenuItem> tsmi = new List<ToolStripMenuItem>();
            foreach (SessionData session in SuperPuTTY.GetAllSessions())
            {
                ToolStripMenuItem tsmiParent = null;
                foreach (string part in SessionData.GetSessionNameParts(session.SessionId))
                {
                    if (part == session.SessionName)
                    {
                        ToolStripMenuItem newSessionTSMI = new ToolStripMenuItem
                        {
                            Tag = session,
                            Text = session.SessionName
                        };
                        newSessionTSMI.Click += new System.EventHandler(newSessionTSMI_Click);
                        newSessionTSMI.ToolTipText = session.ToString();
                        if (tsmiParent == null)
                            tsmi.Add(newSessionTSMI);
                        else
                            tsmiParent.DropDownItems.Add(newSessionTSMI);
                    }
                    else
                    {
                        if (tsmiParent == null)
                        {
                            tsmiParent = tsmi.FirstOrDefault((item) => string.Equals(item.Name, part));
                            if (tsmiParent == null)
                            {
                                tsmiParent = new ToolStripMenuItem(part) { Name = part };
                                tsmi.Add(tsmiParent);
                            }
                        }
                        else
                        {
                            if (tsmiParent.DropDownItems.ContainsKey(part))
                            {
                                tsmiParent = (ToolStripMenuItem)tsmiParent.DropDownItems[part];
                            }
                            else
                            {
                                ToolStripMenuItem newSessionFolder = new ToolStripMenuItem(part) { Name = part };
                                tsmiParent.DropDownItems.Add(newSessionFolder);
                                tsmiParent = newSessionFolder;
                            }
                        }
                    }
                }
            }

            if (InvokeRequired)
                Invoke(new Action(() => {
                    if (newSessionToolStripMenuItem.DropDownItems.Count == 0)
                        newSessionToolStripMenuItem.DropDownItems.AddRange(tsmi.ToArray());
                }));
            else
                if (newSessionToolStripMenuItem.DropDownItems.Count == 0)
                    newSessionToolStripMenuItem.DropDownItems.AddRange(tsmi.ToArray());
        }

        void CreateMenu()
        {
            this.newSessionToolStripMenuItem.Enabled = SuperPuTTY.Settings.PuttyPanelShowNewSessionMenu;
            if (SuperPuTTY.Settings.PuttyPanelShowNewSessionMenu)
            {
                newSessionToolStripMenuItem.DropDownItems.Clear();

                new Thread(InitNewSessionToolStripMenuItems).Start();
            }

            DockPane pane = GetDockPane();
            if (pane != null)
            {
                this.closeOthersToTheRightToolStripMenuItem.Enabled =
                    pane.Contents.IndexOf(this) != pane.Contents.Count - 1;
            }
            this.closeOthersToolStripMenuItem.Enabled = this.DockPanel.DocumentsCount > 1;
            this.closeAllToolStripMenuItem.Enabled = this.DockPanel.DocumentsCount > 1;
        }

        private void closeSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docs = from doc in this.DockPanel.DocumentsToArray()
                       where doc is ToolWindowDocument && doc != this
                       select doc as ToolWindowDocument;
            CloseDocs("Close Others", docs);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docs = from doc in this.DockPanel.DocumentsToArray()
                       where doc is ToolWindowDocument
                       select doc as ToolWindowDocument;
            CloseDocs("Close All", docs);
        }

        private void closeOthersToTheRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // find the dock pane with this window
            DockPane pane = GetDockPane();
            if (pane != null)
            {
                // found the pane
                List<ToolWindowDocument> docsToClose = new List<ToolWindowDocument>();
                bool close = false;
                foreach (IDockContent content in new List<IDockContent>(pane.Contents))
                {
                    if (content == this)
                    {
                        close = true;
                        continue;
                    }
                    if (close)
                    {
                        ToolWindowDocument win = content as ToolWindowDocument;
                        if (win != null)
                        {
                            docsToClose.Add(win);
                        }
                    }
                }
                if (docsToClose.Count > 0)
                {
                    CloseDocs("Close Other To the Right", docsToClose);
                }
            }
        }

        void CloseDocs(string source, IEnumerable<ToolWindowDocument> docsToClose)
        {
            int n = docsToClose.Count();
            Log.InfoFormat("Closing mulitple docs: source={0}, count={1}, conf={2}", source, n, SuperPuTTY.Settings.MultipleTabCloseConfirmation);

            bool okToClose = true;
            if (SuperPuTTY.Settings.MultipleTabCloseConfirmation && n > 1)
            {
                okToClose = DialogResult.Yes == Messenger.MessageBox(string.Format("Close {0} Tabs?", n), source, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (okToClose)
            {
                foreach (ToolWindowDocument doc in docsToClose)
                {
                    doc.Close();
                }
            }
        }

        DockPane GetDockPane()
        {
            return this.DockPanel.Panes.FirstOrDefault(pane => pane.Contents.Contains(this));
        }

        /// <summary>
        /// Reset the focus to the child application window
        /// </summary>
        internal void SetFocusToChildApplication(string caller)
        {
            if (!this.AppPanel.ExternalProcessCaptured) { return; }

            bool success = false;
            for (int i = 0; i < RefocusAttempts; i++)
            {
                Thread.Sleep(RefocusIntervalMs);
                if (this.AppPanel.ReFocusPuTTY(caller))
                {
                    if (i > 0)
                    {
                        Log.DebugFormat("SetFocusToChildApplication success after {0} attempts", i + 1);
                    }
                    success = true;
                    break;
                }
            }

            if (!success)
            {
                Log.WarnFormat("Unable to SetFocusToChildApplication, {0}", this.Text);
            }
        }

        protected override string GetPersistString()
        {
            string str = String.Format("{0}?SessionId={1}&TabName={2}", 
                this.GetType().FullName, 
                HttpUtility.UrlEncode(this.Session.SessionId), 
                HttpUtility.UrlEncode(this.TextOverride));
            return str;
        }

        /// <summary>Restore sessions from a string containing previous sessions</summary>
        /// <param name="persistString">A string containing the sessions to restore</param>
        /// <returns>The <seealso cref="ctlPuttyPanel"/> object which is the parent of the hosted putty application, null if unable to start session</returns>
        public static ctlPuttyPanel FromPersistString(String persistString)
        {
            ctlPuttyPanel panel = null;
            if (persistString.StartsWith(typeof(ctlPuttyPanel).FullName))
            {
                int idx = persistString.IndexOf("?");
                if (idx != -1)
                {
                    NameValueCollection data = HttpUtility.ParseQueryString(persistString.Substring(idx + 1));
                    string sessionId = data["SessionId"] ?? data["SessionName"];
                    string tabName = data["TabName"];

                    Log.InfoFormat("Restoring putty session, sessionId={0}, tabName={1}", sessionId, tabName);

                    SessionData session = SuperPuTTY.GetSessionById(sessionId);
                    if (session != null)
                    {
                        panel = SuperPuTTY.OpenProtoSession(session);
                        if (panel == null)
                        {
                            Log.WarnFormat("Could not restore putty session, sessionId={0}", sessionId);
                        }
                        else
                        {
                            panel.Icon = SuperPuTTY.GetIconForSession(session);
                            panel.Text = tabName;
                            panel.TextOverride = tabName;
                        }
                    }
                    else
                    {
                        Log.WarnFormat("Session not found, sessionId={0}", sessionId);
                    }
                }
                else
                {
                    idx = persistString.IndexOf(":");
                    if (idx != -1)
                    {
                        string sessionId = persistString.Substring(idx + 1);
                        Log.InfoFormat("Restoring putty session, sessionId={0}", sessionId);
                        SessionData session = SuperPuTTY.GetSessionById(sessionId);
                        if (session != null)
                        {
                            panel = SuperPuTTY.OpenProtoSession(session);
                        }
                        else
                        {
                            Log.WarnFormat("Session not found, sessionId={0}", sessionId);
                        }
                    }
                }
            }
            return panel;
        }

        private void aboutPuttyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SuperPuTTY.PuTTYAppName == "PuTTY Plus")
            {
                Process.Start("https://github.com/SilverGreen93/putty");
            }
            else if (SuperPuTTY.PuTTYAppName == "KiTTY")
            {
                Process.Start("https://www.9bis.net/kitty/index.html");
            }
            else if (SuperPuTTY.PuTTYAppName == "PuTTY")
            {
                Process.Start("http://www.chiark.greenend.org.uk/~sgtatham/putty/");
            }
            else
            {
                Messenger.MessageBox("No information available.", "About " + SuperPuTTY.PuTTYAppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

 
        private void duplicateSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperPuTTY.OpenProtoSession(this.Session);
        }

        private void renameTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgRenameItem dialog = new dlgRenameItem
            {
                ItemName = this.Text,
                DetailName = this.Session.SessionId,
                Text = "Rename tab"
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Text = dialog.ItemName;
                this.TextOverride = dialog.ItemName;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AppPanel != null)
            {
                this.AppPanel.RefreshAppWindow();
            }
        }

        public SessionData Session { get; set; }
        public ApplicationPanel AppPanel { get; private set; }
        public ctlPuttyPanel previousPanel { get; set; }
        public ctlPuttyPanel nextPanel { get; set; }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            CreateMenu();
        }

        private void newSessionTSMI_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem) sender;
            SessionData session = menuItem.Tag as SessionData;
            if (session != null)
            {
                SuperPuTTY.OpenProtoSession(session);
            }
        }

        private void puTTYMenuTSMI_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem) sender;
            string[] tags = ((ToolStripMenuItem)sender).Tag.ToString().Split(';');

            for (int i = 0; i < tags.Length; ++i)
            {
                uint command = Convert.ToUInt32(tags[i], 16);
                Log.DebugFormat("Sending Putty Command from: menu={2}, tag={0}, command={1}", tags[i], command, menuItem.Text);
                SendPuttyCommand(command);
            }
        }

        internal void SendPuttyCommand(uint command)
        {
            Log.DebugFormat("Sending Putty Command: command={0}", command);

            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    SetFocusToChildApplication("SendPuttyCommand");
                    NativeMethods.SendMessage(AppPanel.AppWindowHandle, (uint)NativeMethods.WM.SYSCOMMAND, command, 0);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("Error sending putty command to embedded putty", ex);
                }
            });
        }

        public bool AcceptCommands
        {
            get { return this.acceptCommandsToolStripMenuItem.Checked;  }
            set { this.acceptCommandsToolStripMenuItem.Checked = value; }
        }

        public string TextOverride { get; set; }

        private void copyHostNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.Port != 0)
            {
                Clipboard.SetText(Session.Host + " " + Session.Port);
            }
            else
            {
                Clipboard.SetText(Session.Host);
            }
        }

        private void saveSessionAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionData session = (SessionData)Session.Clone();
            session.SessionName = Text;
            // Get an instance of the SessionTreeview to call the non-static method  
            var mainForm = Application.OpenForms.OfType<frmSuperPutty>().FirstOrDefault();
            if (mainForm != null)
            {
                var sessionTree = mainForm.SessionTreeviewInstance;
                sessionTree?.CreateOrEditSession(1, session);
            }
        }
    }
}
