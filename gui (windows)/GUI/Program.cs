//StealthNet
//Copyright (C) 2009 Lars Regensburger, T.Norad

//This program is free software; you can redistribute it and/or
//modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2
//of the License, or (at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal static class Program
    {
        // instance of the logger
        // Added on 2007-05-05 by T.Norad
        private static Logger m_Logger = Logger.Instance;

        /// <summary>
        /// parse the passed args. send the first entry of the array to the running instance.
        /// the entry is send through win32 api and handled in the MainForm.
        /// 
        /// 2007-10-02 T.Norad: added
        /// </summary>
        /// <param name="args">program arguments. maybe a stealthnet link</param>
        /// <returns>true, if the message was sent to running stealthnet instance</returns>
        public static Boolean SendStealthNetLinkToOpenClient(String[] args)
        {
            Boolean messageSent = false;
            if (args != null && args.Length > 0)
            {
                // get handle of the stealthnet main window to send the link to
                int handle = Win32APIWrapper.FindWindow(null, String.Format(Constants.Software, Core.Version));
                if (handle != 0)
                {
                    // if a whitespace contained in the link the argument array
                    // is splitted at this whitespace. so we must combine the array
                    // to one string
                    String messageToSent = null;
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (i != 0) { messageToSent += " "; }
                        messageToSent += args[i];
                    }
                    messageSent = Win32APIWrapper.SendArgs((IntPtr)handle, messageToSent);
                }
            }
            return messageSent;
        }

        [STAThreadAttribute]
        private static void Main(String[] args)
        {
            // Reduziert die CPU-Auslastung, falls auf eine exklusive Sperre gewartet werden muss
            Regensburger.RCollections.ThreadHelpers.Timeout = 40;

            // initialize settings class
            Settings.Instance = new CoreSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // "Hack" für Mac OS X, da Mono hier nicht korrekt die Prozesse ermitteln kann...
            if (!UtilitiesForMono.IsRunningOnMono)
            {
                try
                {
                    // check if another instance of this client is running
                    if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                    {
                        // 2008-10-21 Eroli: Mono-Fix
                        // 2007-10-02 T.Norad send stealthnet link to running instance of stealthnet
                        if (!SendStealthNetLinkToOpenClient(args))
                        {
                            // only if the message was not send we inform the user about the running instance
                            MessageBox.Show(string.Format("{0} is already running!", String.Format(Constants.Software, Core.Version)), String.Format(Constants.Software, Core.Version), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        return;
                    }
                    // check the registry for the stealthnet link
                    // if no entries found in registry, we create them
                    RegistryHelper.checkOrCreateRegistryEntries();
                }
                catch
                {
                }
            }

            new SplashProvider(args);
            Application.Run(SplashProvider.Instance);
        }
    }
}