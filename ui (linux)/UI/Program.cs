//StealthNet
//Copyright (C) 2009 Lars Regensburger
//Copyright (C) 2009 Roland Moch

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
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace Regensburger.RShare
{
    internal static class Program
    {
        [STAThreadAttribute]
        private static void Main(string[] args)
        {
            // Reduziert die CPU-Auslastung, falls auf eine exklusive Sperre gewartet werden muss
            Regensburger.RCollections.ThreadHelpers.Timeout = 40;

            // initialize settings class
            Settings.Instance = new CoreSettings();

            Console.Title = String.Format(Constants.Software, Core.Version);

            Console.WriteLine(String.Format(Constants.Software, Core.Version));
            Console.WriteLine();
            Console.WriteLine("RShare Copyright © 2009 Lars Regensburger");
            Console.WriteLine("StealthNet Copyright © 2009 Lars Regensburger, The StealthNet Team");
            Console.WriteLine();

            // "Hack" für Mac OS X, da Mono hier nicht korrekt die Prozesse ermitteln kann...
            try
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("StealthNet is already running!");
                    Console.WriteLine("Press enter to exit StealthNet...");
                    Console.WriteLine();
                    Console.ReadLine();
                    return;
                }
            }
            catch
            {
            }

            Core.Load();

            if (Core.IsUpdateAvailable)
            {
                Console.WriteLine();
                Console.WriteLine("A newer version of StealthNet is available!");
                Console.WriteLine("Would you like to download it?");
                Console.WriteLine("Please visit http://board.planetpeer.de/index.php/board,68.0.html");
                Console.WriteLine("Press enter to start StealthNet...");
                Console.WriteLine();
                Console.ReadLine();
            }

            UI.DoCommandLoop();
        }
    }
}