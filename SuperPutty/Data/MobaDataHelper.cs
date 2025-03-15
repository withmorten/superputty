using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Web;
using log4net;
using System.Xml;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SuperPutty.Data
{
    /// <summary>Helper methods used mostly for importing settings and session data from other applications</summary>
    public class MobaDataHelper
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(MobaDataHelper));

        public const string SessionDefaultSettings = "Default Settings";
        public const string SessionEmptySettings = "";


        public static List<SessionData> GetAllSessionsFromMoba(string filename)
        {
            var sessions = new List<SessionData>();
            string data = File.ReadAllText(filename);
            var sections = Regex.Split(data, "\\[Bookmarks[^]]*\\]");

            foreach (var section in sections)
            {
                var lines = section.Trim().Split('\n');
                string subrep = null;

                foreach (var line in lines)
                {
                    if (line.StartsWith("SubRep="))
                    {
                        subrep = line.Split('=')[1].Trim();
                        continue;
                    }
                    if (line.StartsWith("ImgNum="))
                        continue;

                    var entry = ParseEntry(line, subrep);
                    if (entry != null)
                        sessions.Add(entry);
                }
            }
            return sessions;
        }

        private static SessionData ParseEntry(string entry, string subrep)
        {
            var match = Regex.Match(entry, "(.*?)=#(\\d+)#(.*?)%([^%]+)%([^%]*)%([^%]*)%");
            if (!match.Success)
                return null;

            string sessionName = match.Groups[1].Value;
            int protoId = int.Parse(match.Groups[2].Value);
            string host = match.Groups[4].Value;
            int port = 0;
            if (!string.IsNullOrEmpty(match.Groups[5].Value))
            {
                if (!int.TryParse(match.Groups[5].Value, out port))
                {
                    port = 0;
                }
            }
            string username = match.Groups[6].Value.Trim();
            string extraArgs = ""; // no extraArgs for now

            string imageKey;
            ConnectionProtocol proto;

            // Supported MobaXterm protocol IDs
            switch (protoId)
            {
                case 98:
                    proto = ConnectionProtocol.Telnet;
                    imageKey = "application_xp_terminal";
                    break;
                case 109:
                    proto = ConnectionProtocol.SSH;
                    imageKey = "computer";
                    break;
                case 128:
                    proto = ConnectionProtocol.VNC;
                    imageKey = "map";
                    if (username == "-1")
                        username = "";
                    break;
                case 131:
                    proto = ConnectionProtocol.Serial;
                    imageKey = "telephone";
                    host = sessionName.Split(' ')[0];
                    username = "";
                    // serial port speed start with 1, remove that.
                    port -= 1000000;
                    break;
                default:
                    proto = ConnectionProtocol.SSH;
                    imageKey = "computer";
                    break;
            }

            string sessionId = !string.IsNullOrEmpty(subrep) ? $"{subrep}/{sessionName}" : sessionName;

            return new SessionData
            {
                SessionId = sessionId,
                SessionName = sessionName,
                ImageKey = imageKey,
                Host = host,
                Port = port,
                Proto = proto,
                Username = username,
                ExtraArgs = extraArgs
            };
        }

    }
}
