/*
 * Copyright (c) 2009 - 2015 Jim Radford http://www.jimradford.com
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
using log4net;
using SuperPutty.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace SuperPutty.Utils
{

    /// <summary>
    /// Helper class for MinTTY support
    /// </summary>
    public class MinttyStartInfo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MinttyStartInfo));

        private SessionData session;

        public MinttyStartInfo(SessionData session)
        {
            this.session = session;
            this.Args = "--nodaemon ";

            if (session.Host.Contains(@":\") && Directory.Exists(session.Host))
            {
                this.StartingDir = session.Host;
                this.MSystem = session.Username;
                this.MSysCon = "mintty.exe";
            }

            // Handle any extra args
            this.Args += session.ExtraArgs;

			if (session.Port != 0)
			{
				this.Args += " /usr/bin/sh -cl \"\"$@\"\" sh ssh -p " + session.Port + " " + session.Host;
			}
            else
            {
                this.Args += " -";
            }
		}

        public string Args { get; set; }
        public string StartingDir { get; set; }
        public string MSystem { get; set; }
        public string MSysCon { get; set; }

    }
}
