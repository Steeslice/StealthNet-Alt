//RShare
//Copyright (C) 2009 Lars Regensburger
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
using System.Diagnostics;

namespace Regensburger.RShare
{
    // Added 2007-05-01 by T.Norad
    public static class ProcessStarter
    {
        // const for the name of a process
        // Added 2007-05-01 by T.Norad
        private static String EXLORER_PROCESS = "explorer.exe";

        // const for the name of a process
        // Added 2007-05-01 by T.Norad
        public readonly static String SYNDIE_PROCESS = "syndie.exe";

        /*
         * Starts a new sysdie process in the passed startFolder.
         * 
         * Added 2007-05-01 by T.Norad
         */
        public static void startSyndieProcess(String startFolder)
        {
            ProcessStarter.startProcess(startFolder + SYNDIE_PROCESS);
        }

        /*
         * Starts a new explorer process with passed arguments.
         * 
         * Added 2007-05-01 by T.Norad
         * 2009-02-27 Nochbaer: Edited to select the file in the explorer window and call the standard shell on mono
         */
        public static void startExplorerProcess(String path, String filename)
        {
            if (!UtilitiesForMono.IsRunningOnMono)
            {
                string arguments;
                if (filename.Length > 0)
                {
                    string secondStringArgument = "";
                    if (!path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                    {
                        secondStringArgument =  System.IO.Path.DirectorySeparatorChar.ToString();
                    }
                    arguments = String.Format("/e,/select,\"{0}{1}{2}\"", path,secondStringArgument, filename);
                }
                else
                {
                    arguments = String.Format("/e,{0}", path);
                }
                ProcessStarter.startProcess(EXLORER_PROCESS, arguments);
            }
            else
            {
                if (!path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                {
                    path = path + System.IO.Path.DirectorySeparatorChar.ToString();
                    ProcessStarter.startProcess(path);
                }
            }    
        }



        /*
         * Starts a new system process without arguments.
         * 
         * Added 2007-05-01 by T.Norad
         */
        public static void startProcess(String uri)
        {
            ProcessStarter.startProcess(uri, null);
        }

        /*
         * Starts a new system process.
         * 
         * Added 2007-05-01 by T.Norad
         */
        private static void startProcess(String uri, String arguments)
        {
            // call a new process
            try
            {
                Process.Start(uri, arguments);
            }
            catch
            { 
            }
        }
    }
}
