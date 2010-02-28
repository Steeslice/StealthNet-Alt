//StealthNet
//Copyright (C) 2009 T.Norad

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
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    static class RegistryHelper
    {
        // some registry const
        private const string REG_STEALTHNET = "stealthnet";
        private const string REG_DEFAULT_ICON = "DefaultIcon";
        private const string REG_SHELL = "shell";
        private const string REG_OPEN = "open";
        private const string REG_COMMAND = "command";
        private const string REG_COLLECTION = ".sncollection";

        /// <summary>
        /// This method checks the registry for the URLHandler entries.
        /// The registry keys created if it not exist.
        /// 
        /// <remarks>
        /// We need the following keys and values
        /// 
        /// [HKEY_CLASSES_ROOT\stealthnet]
        /// @="URL:StealthNet Protocol"
        /// "URL Protocol"=""
        /// 
        /// [HKEY_CLASSES_ROOT\stealthnet\DefaultIcon]
        /// @="StealthNet.exe"
        /// 
        /// [HKEY_CLASSES_ROOT\stealthnet\shell]
        /// 
        /// [HKEY_CLASSES_ROOT\stealthnet\shell\open]
        /// 
        /// [HKEY_CLASSES_ROOT\stealthnet\shell\open\command]
        /// @="<pathToStealNet.exe>\\StealthNet.exe %1"
        /// </remarks>
        /// </summary>
        public static void checkOrCreateRegistryEntries()
        {
            try
            {
                RegistryKey stealthnet = Registry.ClassesRoot.OpenSubKey(REG_STEALTHNET, true);
                if (stealthnet == null)
                {
                    stealthnet = Registry.ClassesRoot.CreateSubKey(REG_STEALTHNET);
                }
                stealthnet.SetValue("", "URL:StealthNet Protocol");
                stealthnet.SetValue("URL Protocol", "");

                RegistryKey collection = Registry.ClassesRoot.OpenSubKey(REG_COLLECTION, true);
                if (collection == null)
                {
                    collection = Registry.ClassesRoot.CreateSubKey(REG_COLLECTION);
                }
                collection.SetValue("", REG_STEALTHNET);
                collection.SetValue("Content Type", "text/plain");

                RegistryKey defaultIcon = stealthnet.OpenSubKey(REG_DEFAULT_ICON, true);
                if (defaultIcon == null)
                {
                    defaultIcon = stealthnet.CreateSubKey(REG_DEFAULT_ICON);
                }
                defaultIcon.SetValue("", Application.ProductName + ".exe");

                RegistryKey shell = stealthnet.OpenSubKey(REG_SHELL, true);
                if (shell == null)
                {
                    shell = stealthnet.CreateSubKey(REG_SHELL);
                }

                RegistryKey open = shell.OpenSubKey(REG_OPEN, true);
                if (open == null)
                {
                    open = shell.CreateSubKey(REG_OPEN);
                }

                RegistryKey command = shell.OpenSubKey(REG_COMMAND, true);
                if (command == null)
                {
                    command = open.CreateSubKey(REG_COMMAND);
                }
                command.SetValue("", Application.ExecutablePath + " %1");

            }
            catch
            {
            }
        }
    }
}
