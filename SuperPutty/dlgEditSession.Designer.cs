namespace SuperPutty
{
    partial class dlgEditSession
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxProto = new System.Windows.Forms.ComboBox();
            this.textBoxExtraArgs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPuttyProfile = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonImageSelect = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxSPSLScriptFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonClearSPSLFile = new System.Windows.Forms.Button();
            this.groupBoxFileTransferOptions = new System.Windows.Forms.GroupBox();
            this.textBoxRemotePathSesion = new System.Windows.Forms.TextBox();
            this.lbRemotePath = new System.Windows.Forms.Label();
            this.buttonBrowseLocalPath = new System.Windows.Forms.Button();
            this.textBoxLocalPathSesion = new System.Windows.Forms.TextBox();
            this.lbLocalPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSessionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHostname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBoxFileTransferOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxProto
            // 
            this.comboBoxProto.FormattingEnabled = true;
            this.comboBoxProto.Location = new System.Drawing.Point(121, 63);
            this.comboBoxProto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxProto.Name = "comboBoxProto";
            this.comboBoxProto.Size = new System.Drawing.Size(96, 23);
            this.comboBoxProto.TabIndex = 1;
            this.comboBoxProto.SelectedIndexChanged += new System.EventHandler(this.comboBoxProto_SelectedIndexChanged);
            this.comboBoxProto.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxPuttyProfile_Validating);
            // 
            // textBoxExtraArgs
            // 
            this.textBoxExtraArgs.Location = new System.Drawing.Point(121, 173);
            this.textBoxExtraArgs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxExtraArgs.Name = "textBoxExtraArgs";
            this.textBoxExtraArgs.Size = new System.Drawing.Size(390, 23);
            this.textBoxExtraArgs.TabIndex = 6;
            this.textBoxExtraArgs.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxExtraArgs_Validating);
            this.textBoxExtraArgs.Validated += new System.EventHandler(this.textBoxExtraArgs_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Extra arguments:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(360, 495);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 30);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(455, 495);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 30);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "PuTTY session profile:";
            // 
            // comboBoxPuttyProfile
            // 
            this.comboBoxPuttyProfile.FormattingEnabled = true;
            this.comboBoxPuttyProfile.Location = new System.Drawing.Point(356, 63);
            this.comboBoxPuttyProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPuttyProfile.Name = "comboBoxPuttyProfile";
            this.comboBoxPuttyProfile.Size = new System.Drawing.Size(155, 23);
            this.comboBoxPuttyProfile.TabIndex = 4;
            this.comboBoxPuttyProfile.SelectedIndexChanged += new System.EventHandler(this.comboBoxPuttyProfile_SelectedIndexChanged);
            this.comboBoxPuttyProfile.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxPuttyProfile_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Login username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(121, 134);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(390, 23);
            this.textBoxUsername.TabIndex = 5;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // buttonImageSelect
            // 
            this.buttonImageSelect.Location = new System.Drawing.Point(479, 23);
            this.buttonImageSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonImageSelect.Name = "buttonImageSelect";
            this.buttonImageSelect.Size = new System.Drawing.Size(32, 32);
            this.buttonImageSelect.TabIndex = 7;
            this.buttonImageSelect.UseVisualStyleBackColor = true;
            this.buttonImageSelect.Click += new System.EventHandler(this.buttonImageSelect_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(423, 211);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(88, 23);
            this.buttonBrowse.TabIndex = 15;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxSPSLScriptFile
            // 
            this.textBoxSPSLScriptFile.Location = new System.Drawing.Point(121, 211);
            this.textBoxSPSLScriptFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSPSLScriptFile.Name = "textBoxSPSLScriptFile";
            this.textBoxSPSLScriptFile.Size = new System.Drawing.Size(198, 23);
            this.textBoxSPSLScriptFile.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "SPSL script:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "spsl";
            this.openFileDialog1.Filter = "script files (*.spsl)|*.spsl|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Open SPSL Script";
            // 
            // buttonClearSPSLFile
            // 
            this.buttonClearSPSLFile.Location = new System.Drawing.Point(327, 211);
            this.buttonClearSPSLFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClearSPSLFile.Name = "buttonClearSPSLFile";
            this.buttonClearSPSLFile.Size = new System.Drawing.Size(88, 23);
            this.buttonClearSPSLFile.TabIndex = 18;
            this.buttonClearSPSLFile.Text = "Clear";
            this.buttonClearSPSLFile.UseVisualStyleBackColor = true;
            this.buttonClearSPSLFile.Click += new System.EventHandler(this.buttonClearSPSLFile_Click);
            // 
            // groupBoxFileTransferOptions
            // 
            this.groupBoxFileTransferOptions.Controls.Add(this.textBoxRemotePathSesion);
            this.groupBoxFileTransferOptions.Controls.Add(this.lbRemotePath);
            this.groupBoxFileTransferOptions.Controls.Add(this.buttonBrowseLocalPath);
            this.groupBoxFileTransferOptions.Controls.Add(this.textBoxLocalPathSesion);
            this.groupBoxFileTransferOptions.Controls.Add(this.lbLocalPath);
            this.groupBoxFileTransferOptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxFileTransferOptions.Location = new System.Drawing.Point(12, 384);
            this.groupBoxFileTransferOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxFileTransferOptions.Name = "groupBoxFileTransferOptions";
            this.groupBoxFileTransferOptions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxFileTransferOptions.Size = new System.Drawing.Size(531, 103);
            this.groupBoxFileTransferOptions.TabIndex = 19;
            this.groupBoxFileTransferOptions.TabStop = false;
            this.groupBoxFileTransferOptions.Text = "File transfer options";
            // 
            // textBoxRemotePathSesion
            // 
            this.textBoxRemotePathSesion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRemotePathSesion.Location = new System.Drawing.Point(121, 65);
            this.textBoxRemotePathSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRemotePathSesion.Name = "textBoxRemotePathSesion";
            this.textBoxRemotePathSesion.Size = new System.Drawing.Size(390, 23);
            this.textBoxRemotePathSesion.TabIndex = 18;
            // 
            // lbRemotePath
            // 
            this.lbRemotePath.AutoSize = true;
            this.lbRemotePath.Location = new System.Drawing.Point(16, 68);
            this.lbRemotePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRemotePath.Name = "lbRemotePath";
            this.lbRemotePath.Size = new System.Drawing.Size(78, 15);
            this.lbRemotePath.TabIndex = 17;
            this.lbRemotePath.Text = "Remote path:";
            // 
            // buttonBrowseLocalPath
            // 
            this.buttonBrowseLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseLocalPath.Location = new System.Drawing.Point(423, 24);
            this.buttonBrowseLocalPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBrowseLocalPath.Name = "buttonBrowseLocalPath";
            this.buttonBrowseLocalPath.Size = new System.Drawing.Size(88, 23);
            this.buttonBrowseLocalPath.TabIndex = 16;
            this.buttonBrowseLocalPath.Text = "Browse...";
            this.buttonBrowseLocalPath.UseVisualStyleBackColor = true;
            this.buttonBrowseLocalPath.Click += new System.EventHandler(this.buttonBrowseLocalPath_Click);
            // 
            // textBoxLocalPathSesion
            // 
            this.textBoxLocalPathSesion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocalPathSesion.Location = new System.Drawing.Point(121, 24);
            this.textBoxLocalPathSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLocalPathSesion.Name = "textBoxLocalPathSesion";
            this.textBoxLocalPathSesion.Size = new System.Drawing.Size(294, 23);
            this.textBoxLocalPathSesion.TabIndex = 1;
            // 
            // lbLocalPath
            // 
            this.lbLocalPath.AutoSize = true;
            this.lbLocalPath.Location = new System.Drawing.Point(16, 27);
            this.lbLocalPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocalPath.Name = "lbLocalPath";
            this.lbLocalPath.Size = new System.Drawing.Size(65, 15);
            this.lbLocalPath.TabIndex = 0;
            this.lbLocalPath.Text = "Local path:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 242);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Notes:";
            // 
            // textBoxNote
            // 
            this.textBoxNote.AcceptsReturn = true;
            this.textBoxNote.Location = new System.Drawing.Point(19, 261);
            this.textBoxNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNote.Size = new System.Drawing.Size(492, 77);
            this.textBoxNote.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Session name:";
            // 
            // textBoxSessionName
            // 
            this.textBoxSessionName.Location = new System.Drawing.Point(121, 29);
            this.textBoxSessionName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSessionName.Name = "textBoxSessionName";
            this.textBoxSessionName.Size = new System.Drawing.Size(288, 23);
            this.textBoxSessionName.TabIndex = 20;
            this.textBoxSessionName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSessionName_Validating);
            this.textBoxSessionName.Validated += new System.EventHandler(this.textBoxSessionName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Host name (or IP address):";
            // 
            // textBoxHostname
            // 
            this.textBoxHostname.Location = new System.Drawing.Point(170, 99);
            this.textBoxHostname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHostname.Name = "textBoxHostname";
            this.textBoxHostname.Size = new System.Drawing.Size(192, 23);
            this.textBoxHostname.TabIndex = 22;
            this.textBoxHostname.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHostname_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "TCP port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(436, 99);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(75, 23);
            this.textBoxPort.TabIndex = 24;
            this.textBoxPort.Text = "22";
            this.textBoxPort.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPort_Validating);
            this.textBoxPort.Validated += new System.EventHandler(this.textBoxPort_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "Connection type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Icon:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxNote);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.buttonImageSelect);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxProto);
            this.groupBox1.Controls.Add(this.textBoxExtraArgs);
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Controls.Add(this.textBoxUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxSessionName);
            this.groupBox1.Controls.Add(this.textBoxSPSLScriptFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPuttyProfile);
            this.groupBox1.Controls.Add(this.textBoxHostname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonClearSPSLFile);
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 365);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection details";
            // 
            // dlgEditSession
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(556, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFileTransferOptions);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgEditSession";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new session";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBoxFileTransferOptions.ResumeLayout(false);
            this.groupBoxFileTransferOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxProto;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPuttyProfile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxExtraArgs;
        private System.Windows.Forms.Button buttonImageSelect;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSPSLScriptFile;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonClearSPSLFile;
        private System.Windows.Forms.GroupBox groupBoxFileTransferOptions;
        private System.Windows.Forms.TextBox textBoxRemotePathSesion;
        private System.Windows.Forms.Label lbRemotePath;
        private System.Windows.Forms.Button buttonBrowseLocalPath;
        private System.Windows.Forms.TextBox textBoxLocalPathSesion;
        private System.Windows.Forms.Label lbLocalPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSessionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHostname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
