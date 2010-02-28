//StealthNet
//Copyright (C) 2009 Lars Regensburger
//Copyright (C) 2009 Roland Moch
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
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Regensburger.RShare
{
    public static class UI
    {
        private static void AddSharedDirectory1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.ShareManager.SharedDirectories.Lock();
                string sharedDirectory = Regex.Split(command, @"^add shared directory ""(.*)""$", RegexOptions.IgnoreCase)[1];
                if (Directory.Exists(sharedDirectory))
                {
                    if (!Core.ShareManager.SharedDirectories.Contains(sharedDirectory))
                    {
                        Core.ShareManager.AddDirectory(sharedDirectory);
                        Console.WriteLine("The directory has been added...");
                    }
                    else
                        Console.WriteLine("The directory is already shared!");
                }
                else
                    Console.WriteLine("The directory does not exists!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while adding the shared directory!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.ShareManager.SharedDirectories.Unlock();
            }
            Console.WriteLine();
        }

        private static void AddSharedDirectory2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.ShareManager.SharedDirectories.Lock();
                string sharedDirectory = Regex.Split(command, @"^add shared directory (.*)$", RegexOptions.IgnoreCase)[1];
                if (Directory.Exists(sharedDirectory))
                {
                    if (!Core.ShareManager.SharedDirectories.Contains(sharedDirectory))
                    {
                        Core.ShareManager.AddDirectory(sharedDirectory);
                        Console.WriteLine("The directory has been added...");
                    }
                    else
                        Console.WriteLine("The directory is already shared!");
                }
                else
                    Console.WriteLine("The directory does not exists!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while adding the shared directory!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.ShareManager.SharedDirectories.Unlock();
            }
            Console.WriteLine();
        }

        private static string AlignString(string input, int chars, StringAlign stringAlign)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (chars < 0)
                throw new ArgumentOutOfRangeException("chars");

            if (input.Length < chars)
                switch (stringAlign)
                {
                    default:
                    case StringAlign.Left:
                        return string.Concat(input, new string(' ', chars - input.Length));
                    case StringAlign.CenterLeft:
                        return string.Concat(new string(' ', (chars - input.Length) / 2), input, new string(' ', chars - input.Length - (chars - input.Length) / 2));
                    case StringAlign.CenterRight:
                        return string.Concat(new string(' ', chars - input.Length - (chars - input.Length) / 2), input, new string(' ', (chars - input.Length) / 2));
                    case StringAlign.Right:
                        return string.Concat(new string(' ', chars - input.Length), input);
                }
            else if (input.Length > chars && chars >= 3)
            {
                string output = string.Concat(input.Substring(0, (chars - 3) / 2), "...", input.Substring(input.Length - (chars - 3) / 2, (chars - 3) / 2));
                switch (stringAlign)
                {
                    default:
                    case StringAlign.Left:
                    case StringAlign.CenterLeft:
                        return string.Concat(output, new string(' ', chars - output.Length));
                    case StringAlign.CenterRight:
                    case StringAlign.Right:
                        return string.Concat(new string(' ', chars - output.Length), output);
                }
            }
            else if (input.Length > chars && chars < 3)
                switch (stringAlign)
                {
                    default:
                    case StringAlign.Left:
                    case StringAlign.CenterLeft:
                        return input.Substring(0, chars);
                    case StringAlign.CenterRight:
                    case StringAlign.Right:
                        return input.Substring(input.Length - chars, chars);
                }
            else
                return input;
        }

        private static void CancelDownload1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^cancel download (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    string fileName = download.FileName;
                    Console.WriteLine("Type in \"y\" to cancel the download of \"{0}\"...", fileName);
                    if (Regex.IsMatch(Console.ReadLine(), @"^y$", RegexOptions.IgnoreCase))
                    {
                        download.Cancel();
                        Console.WriteLine("The download has been cancelled...");
                    }
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while cancelling the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void CancelDownload2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^cd (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    string fileName = download.FileName;
                    Console.WriteLine("Type in \"y\" to cancel the download of \"{0}\"...", fileName);
                    if (Regex.IsMatch(Console.ReadLine(), @"^y$", RegexOptions.IgnoreCase))
                    {
                        download.Cancel();
                        Console.WriteLine("The download has been cancelled...");
                    }
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while cancelling the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void Connect1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string[] parameters = Regex.Split(command, @"^connect ((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)) (\d{1,})$", RegexOptions.IgnoreCase);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(parameters[1]), int.Parse(parameters[6]));
                Core.AddConnection(endPoint);
                Console.WriteLine("StealthNet is trying to connect with {0}...", endPoint);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while connecting!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void Connect2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string[] parameters = Regex.Split(command, @"^connect ((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)):(\d{1,})$", RegexOptions.IgnoreCase);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(parameters[1]), int.Parse(parameters[6]));
                Core.AddConnection(endPoint);
                Console.WriteLine("StealthNet is trying to connect with {0}...", endPoint);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while connecting!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void Connect3(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string[] parameters = Regex.Split(command, @"^connect (\S{1,}) (\d{1,})$", RegexOptions.IgnoreCase);
                Console.WriteLine("StealthNet is resolving the hostname \"{0}\"... ", parameters[1]);
                IPAddress ipAddress;
                try
                {
                    ipAddress = Dns.GetHostEntry(parameters[1]).AddressList[0];
                }
                catch
                {
                    Console.WriteLine("StealthNet could not resolve the hostname!");
                    Console.WriteLine();
                    return;
                }
                IPEndPoint endPoint = new IPEndPoint(ipAddress, int.Parse(parameters[2]));
                Core.AddConnection(endPoint);
                Console.WriteLine("StealthNet is trying to connect with {0}...", endPoint);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while connecting!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void Connect4(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string[] parameters = Regex.Split(command, @"^connect (\S{1,}):(\d{1,})$", RegexOptions.IgnoreCase);
                Console.WriteLine("StealthNet is resolving the hostname \"{0}\"... ", parameters[1]);
                IPAddress ipAddress;
                try
                {
                    ipAddress = Dns.GetHostEntry(parameters[1]).AddressList[0];
                }
                catch
                {
                    Console.WriteLine("StealthNet could not resolve the hostname!");
                    Console.WriteLine();
                    return;
                }
                IPEndPoint endPoint = new IPEndPoint(ipAddress, int.Parse(parameters[2]));
                Core.AddConnection(endPoint);
                Console.WriteLine("StealthNet is trying to connect with {0}...", endPoint);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while connecting!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        internal static void DoCommandLoop()
        {
            Console.WriteLine("To see all possible commands, just type \"help\" and press enter...");
            Console.WriteLine();

            while (!Core.IsClosing)
            {
                Console.Write("StealthNet> ");
                try
                {
                    string command = Console.ReadLine();
                    if (Regex.IsMatch(command, @"^add shared directory "".*""$", RegexOptions.IgnoreCase))
                        AddSharedDirectory1(command);
                    else if (Regex.IsMatch(command, @"^add shared directory .*$", RegexOptions.IgnoreCase))
                        AddSharedDirectory2(command);
                    else if (Regex.IsMatch(command, @"^cancel download \d{1,}$", RegexOptions.IgnoreCase))
                        CancelDownload1(command);
                    else if (Regex.IsMatch(command, @"^cd \d{1,}$", RegexOptions.IgnoreCase))
                        CancelDownload2(command);
                    else if (Regex.IsMatch(command, @"^connect (25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?) \d{1,}$", RegexOptions.IgnoreCase))
                        Connect1(command);
                    else if (Regex.IsMatch(command, @"^connect (25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?):\d{1,}$", RegexOptions.IgnoreCase))
                        Connect2(command);
                    else if (Regex.IsMatch(command, @"^connect \S{1,} \d{1,}$", RegexOptions.IgnoreCase))
                        Connect3(command);
                    else if (Regex.IsMatch(command, @"^connect \S{1,}:\d{1,}$", RegexOptions.IgnoreCase))
                        Connect4(command);
                    else if (Regex.IsMatch(command, @"^exit$", RegexOptions.IgnoreCase))
                    {
                        Exit();
                        break;
                    }
                    else if (Regex.IsMatch(command, @"^(help|\?)$", RegexOptions.IgnoreCase))
                        Help();
                    else if (Regex.IsMatch(command, @"^list connections$", RegexOptions.IgnoreCase))
                        ListConnections();
                    else if (Regex.IsMatch(command, @"^list connections unformatted$", RegexOptions.IgnoreCase))
                        ListConnectionsUnformatted();
                    else if (Regex.IsMatch(command, @"^list downloads$", RegexOptions.IgnoreCase) ||
                             Regex.IsMatch(command, @"^ld$", RegexOptions.IgnoreCase))
                        ListDownloads();
                    else if (Regex.IsMatch(command, @"^list downloads unformatted$", RegexOptions.IgnoreCase))
                        ListDownloadsUnformatted();
                    else if (Regex.IsMatch(command, @"^list results \d{1,}$", RegexOptions.IgnoreCase))
                        ListResults(command);
                    else if (Regex.IsMatch(command, @"^list results \d{1,} unformatted$", RegexOptions.IgnoreCase))
                        ListResultsUnformatted(command);
                    else if (Regex.IsMatch(command, @"^list searches$", RegexOptions.IgnoreCase))
                        ListSearches();
                    else if (Regex.IsMatch(command, @"^list searches unformatted$", RegexOptions.IgnoreCase))
                        ListSearchesUnformatted();
                    else if (Regex.IsMatch(command, @"^list shared directories$", RegexOptions.IgnoreCase))
                        ListSharedDirectories();
                    else if (Regex.IsMatch(command, @"^list shared directories unformatted$", RegexOptions.IgnoreCase))
                        ListSharedDirectoriesUnformatted();
                    else if (Regex.IsMatch(command, @"^list shared files$", RegexOptions.IgnoreCase))
                        ListSharedFiles();
                    else if (Regex.IsMatch(command, @"^list shared files unformatted$", RegexOptions.IgnoreCase))
                        ListSharedFilesUnformatted();
                    else if (Regex.IsMatch(command, @"^list uploads$", RegexOptions.IgnoreCase) ||
                             Regex.IsMatch(command, @"^lu$", RegexOptions.IgnoreCase))
                        ListUploads();
                    else if (Regex.IsMatch(command, @"^list uploads unformatted$", RegexOptions.IgnoreCase))
                        ListUploadsUnformatted();
                    else if (Regex.IsMatch(command, @"^movedownloadtoqueue \d{1,}$", RegexOptions.IgnoreCase))
                        MoveDownloadToQueue1(command);
                    else if (Regex.IsMatch(command, @"^mdtq \d{1,}$", RegexOptions.IgnoreCase))
                        MoveDownloadToQueue2(command);
                    else if (Regex.IsMatch(command, @"^movetobottomofqueue \d{1,}$", RegexOptions.IgnoreCase))
                        MoveToBottomOfQueue1(command);
                    else if (Regex.IsMatch(command, @"^mtbq \d{1,}$", RegexOptions.IgnoreCase))
                        MoveToBottomOfQueue2(command);
                    else if (Regex.IsMatch(command, @"^movetotopofqueue \d{1,}$", RegexOptions.IgnoreCase))
                        MoveToTopOfQueue1(command);
                    else if (Regex.IsMatch(command, @"^mttq \d{1,}$", RegexOptions.IgnoreCase))
                        MoveToTopOfQueue2(command);
                    else if (Regex.IsMatch(command, @"^parse collection ([\w\W]+)\.sncollection$", RegexOptions.IgnoreCase))
                        ParseCollection(command);
                    else if (Regex.IsMatch(command, @"^remove search \d{1,}$", RegexOptions.IgnoreCase))
                        RemoveSearch(command);
                    else if (Regex.IsMatch(command, @"^remove shared directory \d{1,}$", RegexOptions.IgnoreCase))
                        RemoveSharedDirectory(command);
                    else if (Regex.IsMatch(command, @"^restart search \d{1,}$", RegexOptions.IgnoreCase))
                        RestartSearch(command);
                    else if (Regex.IsMatch(command, @"^show log$", RegexOptions.IgnoreCase))
                        ShowLog();
                    else if (Regex.IsMatch(command, @"^show log unformatted$", RegexOptions.IgnoreCase))
                        ShowLogUnformatted();
                    else if (Regex.IsMatch(command, @"^show settings$", RegexOptions.IgnoreCase))
                        ShowSettings();
                    else if (Regex.IsMatch(command, @"^show statistics$", RegexOptions.IgnoreCase) ||
                             Regex.IsMatch(command, @"^ss$", RegexOptions.IgnoreCase))
                        ShowStatistics();
                    else if (Regex.IsMatch(command, @"^show statistics unformatted$", RegexOptions.IgnoreCase))
                        ShowStatisticsUnformatted();
                    else if (Regex.IsMatch(command, @"^start download [0-9A-Fa-f]{128}$", RegexOptions.IgnoreCase))
                        StartDownload1(command);
                    else if (Regex.IsMatch(command, @"^sd [0-9A-Fa-f]{128}$", RegexOptions.IgnoreCase))
                        StartDownload3(command);
                    else if (Regex.IsMatch(command, @"^start download \d{1,} \d{1,}$", RegexOptions.IgnoreCase))
                        StartDownload2(command);
                    else if (Regex.IsMatch(command, @"^sd \d{1,} \d{1,}$", RegexOptions.IgnoreCase))
                        StartDownload4(command);
                    else if (Regex.IsMatch(command, @"^start download stealthnet://\?hash=([0-9A-Fa-f]{128})&name=([\w\W]+)&size=(\d)+$", RegexOptions.IgnoreCase))
                        StartDownloadByLink1(command);
                    else if (Regex.IsMatch(command, @"^stealthnet://\?hash=([0-9A-Fa-f]{128})&name=([\w\W]+)&size=(\d)+$", RegexOptions.IgnoreCase))
                        StartDownloadByLink2(command);
                    else if (Regex.IsMatch(command, @"^start search only network ""\S.{1,}\S""$", RegexOptions.IgnoreCase))
                        StartSearch1(command, Search.SearchType.OnlyNetwork);
                    else if (Regex.IsMatch(command, @"^start search only network \S.{1,}\S$", RegexOptions.IgnoreCase))
                        StartSearch2(command, Search.SearchType.OnlyNetwork);
                    else if (Regex.IsMatch(command, @"^start search only database ""\S.{1,}\S""$", RegexOptions.IgnoreCase))
                        StartSearch1(command, Search.SearchType.OnlyDatabase);
                    else if (Regex.IsMatch(command, @"^start search only database \S.{1,}\S$", RegexOptions.IgnoreCase))
                        StartSearch2(command, Search.SearchType.OnlyDatabase);
                    else if (Regex.IsMatch(command, @"^start search ""\S.{1,}\S""$", RegexOptions.IgnoreCase))
                        StartSearch1(command, Search.SearchType.Auto);
                    else if (Regex.IsMatch(command, @"^start search \S.{1,}\S$", RegexOptions.IgnoreCase))
                        StartSearch2(command, Search.SearchType.Auto);
                    else if (Regex.IsMatch(command, @"^stop search \d{1,}$", RegexOptions.IgnoreCase))
                        StopSearch(command);
                    else if (Regex.IsMatch(command, @"^update settings$", RegexOptions.IgnoreCase))
                        UpdateSettings();
                    else if (!Regex.IsMatch(command, @"^$"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid command!");
                        Console.WriteLine();
                        Console.WriteLine("To see all possible commands, just type \"help\" and press enter...");
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    string s = "An exception was thrown while doing command loop!";
                    Console.WriteLine(s);
                    Logger.Instance.Log(ex, s);
                    Console.WriteLine();
                }
            }
        }

        private static void Exit()
        {
            Console.WriteLine();
            try
            {
                Core.Close();
                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while exiting!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void Help()
        {
            Console.WriteLine();
            try
            {
                Console.WriteLine("All possible shortcut commands:");
                Console.WriteLine();
                Console.WriteLine("cd   DOWNLOADID         (cancel download)");
                Console.WriteLine("ld                      (list downloads)");
                Console.WriteLine("lu                      (list uploads)");
                Console.WriteLine("mdtq DOWNLOADID         (movedownloadtoqueue)");
                Console.WriteLine("mtbq DOWNLOADID         (movetobottomofqueue)");
                Console.WriteLine("mttq DOWNLOADID         (movetotopofqueue)");
                Console.WriteLine("ss                      (show statistics)");
                Console.WriteLine("sd   FILEHASH           (start download)");
                Console.WriteLine("sd   SEARCHID RESULTID  (start download)");
                Console.WriteLine("STEALTHNETLINK          (start download)");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Placeholders:");
                Console.WriteLine();
                Console.WriteLine("DOWNLOADID is the number which is shown before each download");
                Console.WriteLine("FILEHASH is a SHA-512 hash of a shared file in StealthNet");
                Console.WriteLine("SEARCHID is the number which is shown before each search");
                Console.WriteLine("RESULTID is the number which is shown before each result");
                Console.WriteLine("STEALTHNETLINK is a valid StealthNetLink");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press enter to continue... (Or type in \"c\" to cancel!)");
                if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                    return;
                Console.WriteLine("All possible commands: (Page 1 of 2)");
                Console.WriteLine();
                Console.WriteLine("add shared directory \"SHAREDDIRECTORY\" | add shared directory SHAREDDIRECTORY");
                Console.WriteLine("cancel download DOWNLOADID");
                Console.WriteLine("connect HOSTNAME PORT | connect HOSTNAME:PORT");
                Console.WriteLine("connect IP-ADDRESS PORT | connect IP-ADDRESS:PORT");
                Console.WriteLine("exit");
                Console.WriteLine("help | ?");
                Console.WriteLine("list connections | list connections unformatted");
                Console.WriteLine("list downloads | list downloads unformatted");
                Console.WriteLine("list results SEARCHID | list results SEARCHID unformatted");
                Console.WriteLine("list searches | list searches unformatted");
                Console.WriteLine("list shared files | list shared files unformatted");
                Console.WriteLine("list shared directories | list shared directories unformatted");
                Console.WriteLine("list uploads | list uploads unformatted");
                Console.WriteLine("movedownloadtoqueue DOWNLOADID");
                Console.WriteLine("movetobottomofqueue DOWNLOADID");
                Console.WriteLine("movetotopofqueue DOWNLOADID");
                Console.WriteLine("parse collection FILENAME");
                Console.WriteLine("remove search SEARCHID");
                Console.WriteLine("remove shared directory SHAREDDIRECTORYID");
                Console.WriteLine("restart search SEARCHID");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue... (Or type in \"c\" to cancel!)");
                if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                    return;
                Console.WriteLine("All possible commands: (Page 2 of 3)");
                Console.WriteLine();
                Console.WriteLine("show log | show log unformatted");
                Console.WriteLine("show settings");
                Console.WriteLine("show statistics | show statistics unformatted");
                Console.WriteLine("start download FILEHASH");
                Console.WriteLine("start download STEALTHNETLINK");
                Console.WriteLine("start download SEARCHID RESULTID");
                Console.WriteLine("start search \"SEARCHPATTERN\" | start search SEARCHPATTERN");
                Console.WriteLine("start search only network \"SEARCHPATTERN\" |");
                Console.WriteLine("start search only network SEARCHPATTERN");
                Console.WriteLine("start search only database \"SEARCHPATTERN\" |");
                Console.WriteLine("start search only database SEARCHPATTERN");
                Console.WriteLine("stop search SEARCHID");
                Console.WriteLine("update settings");
                for (int n = 0; n < 8; n++)
                    Console.WriteLine();
                Console.WriteLine("Press enter to continue... (Or type in \"c\" to cancel!)");
                if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                    return;
                Console.WriteLine("All possible commands: (Page 3 of 3)");
                Console.WriteLine();
                Console.WriteLine("Placeholders:");
                Console.WriteLine();
                Console.WriteLine("SHAREDDIRECTORY is the path to the directory which should be shared");
                Console.WriteLine("DOWNLOADID is the number which is shown before each download");
                Console.WriteLine("FILENAME is the path to a file");
                Console.WriteLine("HOSTNAME is a dns entry for a machine which runs SteathNet");
                Console.WriteLine("PORT is a number between 0 and 65535");
                Console.WriteLine("IP-ADDRESS is a ip address for a machine which runs StealthNet");
                Console.WriteLine("SEARCHID is the number which is shown before each search");
                Console.WriteLine("SHAREDDIRECTORYID is the number which is shown before each shared directory");
                Console.WriteLine("STEALTHNETLINK is a valid StealthNetLink");
                Console.WriteLine("FILEHASH is a SHA-512 hash of a shared file in StealthNet");
                Console.WriteLine("RESULTID is the number which is shown before each result");
                Console.WriteLine("SEARCHPATTERN is the phrase which should be searched for");
                Console.WriteLine("(It must not start or end with space(s) AND");
                Console.WriteLine("it must have at least three characters!)");
                for (int n = 0; n < 5; n++)
                    Console.WriteLine();
                Console.WriteLine("Press enter to continue... (Or type in \"c\" to cancel!)");
                if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                    return;
                Console.WriteLine("Progress bar lengend:");
                Console.WriteLine();
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
                Console.WriteLine("Already received sectors (downloads/uploads)");
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
                Console.WriteLine("Current sector (downloads/uploads)");
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
                Console.WriteLine("Sectors with one or more source(s) (downloads)");
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
                Console.WriteLine("Sectors without any sources (downloads)");
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
                Console.WriteLine("Not yet received sectors (uploads)");
                for (int n = 0; n < 16; n++)
                    Console.WriteLine();
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while helping!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListConnections()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.Connections.Lock();
                        count = Core.Connections.Count;
                        if (index == 0)
                            if (count == 1)
                                Console.WriteLine("1 Connection");
                            else
                                Console.WriteLine("{0} Connections", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("IP-Address", 15, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("Port", 5, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("Sent", 10, StringAlign.Right));
                            Console.Write(" ");
                            Console.Write(AlignString("Received", 10, StringAlign.Right));
                            Console.Write(" ");
                            Console.Write(AlignString("Sent", 10, StringAlign.Right));
                            Console.Write(" ");
                            Console.Write(AlignString("Received", 10, StringAlign.Right));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("Enqueued", 10, StringAlign.Right));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                Connection connection = Core.Connections[index].Value;
                                Console.Write(AlignString(connection.RemoteEndPoint.Address.ToString(), 15, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(connection.RemoteEndPoint.Port.ToString(), 5, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(connection.SentString, 10, StringAlign.Right));
                                Console.Write(" ");
                                Console.Write(AlignString(connection.ReceivedString, 10, StringAlign.Right));
                                Console.Write(" ");
                                Console.Write(AlignString(connection.SentCommands.ToString(), 10, StringAlign.Right));
                                Console.Write(" ");
                                Console.Write(AlignString(connection.ReceivedCommands.ToString(), 10, StringAlign.Right));
                                Console.Write(" ");
                                Console.WriteLine(AlignString(connection.EnqueuedCommandsCount.ToString(), 10, StringAlign.Right));
                            }
                        }
                    }
                    finally
                    {
                        Core.Connections.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more connection...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more connections...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the connections!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListConnectionsUnformatted()
        {
            try
            {
                Core.Connections.Lock();
                Console.WriteLine("IP-Address;Port;Sent;Received;Sent;Received;Enqueued");
                foreach (Connection connection in Core.Connections.Values)
                    Console.WriteLine("{0};{1};{2};{3};{4};{5};{6}", TrimStringForCSV(connection.RemoteEndPoint.Address.ToString()), TrimStringForCSV(connection.RemoteEndPoint.Port.ToString()), TrimStringForCSV(connection.Sent.ToString()), TrimStringForCSV(connection.Received.ToString()), TrimStringForCSV(connection.SentCommands.ToString()), TrimStringForCSV(connection.ReceivedCommands.ToString()), TrimStringForCSV(connection.EnqueuedCommandsCount.ToString()));
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the connections unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Connections.Unlock();
            }
        }

        private static void ListDownloads()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.DownloadsAndQueue.Lock();
                        count = Core.DownloadsAndQueue.Count;
                        if (index == 0)
                            if (count == 1)
                                Console.WriteLine("1 Download");
                            else
                                Console.WriteLine("{0} Downloads", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("ID", 2, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("R", 1, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("File Name", 39, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("File Size", 10, StringAlign.Right));
                            Console.Write(" ");
                            Console.Write(AlignString("Progress", 12, StringAlign.CenterRight));
                            Console.Write(" ");
                            Console.Write(AlignString("S", 2, StringAlign.Right));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("Status", 7, StringAlign.Left));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                Download download = Core.DownloadsAndQueue[index].Value;
                                Console.Write(AlignString((index + 1).ToString(), 2, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(download.HasInformation ? (download.Rating != 0 ? download.Rating.ToString() : " ") : "U", 1, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(download.FileName.Length > 0 ? download.FileName : download.FileHashString, 39, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(download.FileSizeString.Length > 0 ? download.FileSizeString : "Unknown", 10, StringAlign.Right));
                                Console.Write(" ");
                                bool isActive = false;
                                foreach (Download.Source source in download.Sources.Values)
                                    if (source.QueuePosition == 0)
                                    {
                                        isActive = true;
                                        break;
                                    }
                                if (download.HasInformation)
                                    WriteDownloadProgressBar(12, download.Progress, !download.Sources.IsEmpty, isActive);
                                else
                                    Console.Write(AlignString("Unknown", 12, StringAlign.CenterRight));
                                Console.Write(" ");
                                Console.Write(AlignString(download.Sources.Count.ToString(), 2, StringAlign.Right));
                                Console.Write(" ");
                                Console.WriteLine(AlignString(isActive ? "Active" : "Passive", 7, StringAlign.Left));
                            }
                        }
                    }
                    finally
                    {
                        Core.DownloadsAndQueue.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more download...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more downloads...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the downloads!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListDownloadsUnformatted()
        {
            try
            {
                Core.DownloadsAndQueue.Lock();
                Console.WriteLine("ID;Rating;File Name;File Size;Progress;Sources;Status;LastSeen;LastReception;Status");
                for (int n = 0; n < Core.DownloadsAndQueue.Count; n++)
                {
                    Download download = Core.DownloadsAndQueue[n].Value;
                    bool isActive = false;
                    foreach (Download.Source source in download.Sources.Values)
                        if (source.QueuePosition == 0)
                        {
                            isActive = true;
                            break;
                        }
                    Console.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", TrimStringForCSV((n + 1).ToString()), TrimStringForCSV(download.HasInformation ? download.Rating.ToString() : "Unknown"), TrimStringForCSV(download.FileName.Length > 0 ? download.FileName : download.FileHashString), TrimStringForCSV(download.FileSizeString.Length > 0 ? download.FileSize.ToString() : "Unknown"), TrimStringForCSV(download.HasInformation ? download.Progress.ToString() : "Unknown"), TrimStringForCSV(download.Sources.Count.ToString()), TrimStringForCSV(isActive ? "Active" : "Passive"), TrimStringForCSV(download.HasInformation ? download.LastSeen.ToString() : "Unknown"), TrimStringForCSV(download.HasInformation ? download.LastReception.ToString() : "Unknown"), TrimStringForCSV(download.IsActive ? "Started" : "Queued"));
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the downloads unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.DownloadsAndQueue.Unlock();
            }
        }

        private static void ListResults(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.Searches.Lock();
                        Search search = null;
                        int searchIndex = int.Parse(Regex.Split(command, @"^list results (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                        if (searchIndex >= 0 && searchIndex < Core.Searches.Count)
                            search = Core.Searches[searchIndex].Value;
                        else
                        {
                            Console.WriteLine("Unkown search id!");
                            break;
                        }
                        try
                        {
                            search.Results.Lock();
                            count = search.Results.Count;
                            if (index == 0)
                                if (count == 1)
                                    Console.WriteLine("1 Result");
                                else
                                    Console.WriteLine("{0} Results", count);
                            if (count > 0)
                            {
                                Console.WriteLine();
                                Console.Write(AlignString("ID", 4, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString("R", 1, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString("File Name", 58, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString("File Size", 10, StringAlign.Right));
                                Console.Write(" ");
                                Console.WriteLine(AlignString("S", 2, StringAlign.Right));
                                for (int n = 0; n < 20 && index < count; n++, index++)
                                {
                                    Search.Result result = search.Results[index].Value;
                                    Console.Write(AlignString((index + 1).ToString(), 4, StringAlign.Left));
                                    Console.Write(" ");
                                    Console.Write(AlignString(result.Rating != 0 ? result.Rating.ToString() : " ", 1, StringAlign.Left));
                                    Console.Write(" ");
                                    Console.Write(AlignString(result.FileName, 58, StringAlign.Left));
                                    Console.Write(" ");
                                    Console.Write(AlignString(result.FileSizeString, 10, StringAlign.Right));
                                    Console.Write(" ");
                                    Console.WriteLine(AlignString(result.Sources.Count.ToString(), 2, StringAlign.Right));
                                }
                            }
                        }
                        finally
                        {
                            search.Results.Unlock();
                        }
                    }
                    finally
                    {
                        Core.Searches.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more result...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more results...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the results!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListResultsUnformatted(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            try
            {
                Core.Searches.Lock();
                int searchIndex = int.Parse(Regex.Split(command, @"^list results (\d{1,}) unformatted$", RegexOptions.IgnoreCase)[1]) - 1;
                if (searchIndex >= 0 && searchIndex < Core.Searches.Count)
                {
                    Search search = Core.Searches[searchIndex].Value;
                    try
                    {
                        search.Results.Lock();
                        Console.WriteLine("ID;Rating;File Name;File Size;Sources;Album;Artist;Title");
                        for (int n = 0; n < search.Results.Count; n++)
                        {
                            Search.Result result = search.Results[n].Value;
                            Console.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7}", TrimStringForCSV((n + 1).ToString()), TrimStringForCSV(result.Rating.ToString()), TrimStringForCSV(result.FileName), TrimStringForCSV(result.FileSize.ToString()), TrimStringForCSV(result.Sources.Count.ToString()), TrimStringForCSV(result.Album), TrimStringForCSV(result.Artist), TrimStringForCSV(result.Title));
                        }
                    }
                    finally
                    {
                        search.Results.Unlock();
                    }
                }
                else
                    Console.WriteLine("Unkown search id!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the results unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
        }

        private static void ListSearches()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.Searches.Lock();
                        count = Core.Searches.Count;
                        if (index == 0)
                            if (count == 1)
                                Console.WriteLine("1 Search");
                            else
                                Console.WriteLine("{0} Searches", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("ID", 2, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("Search Pattern", 60, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("Status", 7, StringAlign.Left));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("Results", 7, StringAlign.Right));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                Search search = Core.Searches[index].Value;
                                Console.Write(AlignString((index + 1).ToString(), 2, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(search.SearchPattern, 60, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(search.IsActive ? "Active" : "Passive", 7, StringAlign.Left));
                                Console.Write(" ");
                                Console.WriteLine(AlignString(search.Results.Count.ToString(), 7, StringAlign.Right));
                            }
                        }
                    }
                    finally
                    {
                        Core.Searches.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more search...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more searches...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the searches!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListSearchesUnformatted()
        {
            try
            {
                Core.Searches.Lock();
                Console.WriteLine("ID;Search Pattern;Status;Results");
                for (int n = 0; n < Core.Searches.Count; n++)
                {
                    Search search = Core.Searches[n].Value;
                    Console.WriteLine("{0};{1};{2};{3}", TrimStringForCSV((n + 1).ToString()), TrimStringForCSV(search.SearchPattern), TrimStringForCSV(search.IsActive ? "Active" : "Passive"), TrimStringForCSV(search.Results.Count.ToString()));
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the searches unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
        }

        private static void ListSharedDirectories()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.ShareManager.SharedDirectories.Lock();
                        count = Core.ShareManager.SharedDirectories.Count;
                        if (index == 0)
                            if (count == 1)
                                Console.WriteLine("1 Shared Directory");
                            else
                                Console.WriteLine("{0} Shared Directories", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("ID", 2, StringAlign.Left));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("Path", 76, StringAlign.Left));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                Console.Write(AlignString((index + 1).ToString(), 2, StringAlign.Left));
                                Console.Write(" ");
                                Console.WriteLine(AlignString(Core.ShareManager.SharedDirectories[index], 76, StringAlign.Left));
                            }
                        }
                    }
                    finally
                    {
                        Core.ShareManager.SharedDirectories.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more shared directory...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more shared directories...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the shared files!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListSharedDirectoriesUnformatted()
        {
            try
            {
                Core.ShareManager.SharedDirectories.Lock();
                Console.WriteLine("ID;Path");
                for (int n = 0; n < Core.ShareManager.SharedDirectories.Count; n++)
                    Console.WriteLine("{0};{1}", TrimStringForCSV((n + 1).ToString()), TrimStringForCSV(Core.ShareManager.SharedDirectories[n]));
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the shared files unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.ShareManager.SharedDirectories.Unlock();
            }
        }

        private static void ListSharedFiles()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.ShareManager.SharedFiles.Lock();
                        count = Core.ShareManager.SharedFiles.Count;
                        if (index == 0)
                            if (count == 1)
                                Console.WriteLine("1 Shared File");
                            else
                                Console.WriteLine("{0} Shared Files", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("R", 1, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("File Name", 66, StringAlign.Left));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("File Size", 10, StringAlign.Right));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                SharedFile sharedFile = Core.ShareManager.SharedFiles[index].Value;
                                Console.Write(AlignString(sharedFile.Rating != 0 ? sharedFile.Rating.ToString() : " ", 1, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(sharedFile.FileName, 66, StringAlign.Left));
                                Console.Write(" ");
                                Console.WriteLine(AlignString(sharedFile.FileSizeString, 10, StringAlign.Right));
                            }
                        }
                    }
                    finally
                    {
                        Core.ShareManager.SharedFiles.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more shared file...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more shared files...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the shared files!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListSharedFilesUnformatted()
        {
            try
            {
                Core.ShareManager.SharedFiles.Lock();
                Console.WriteLine("Rating;File Name;File Size;Album;Artist;Title;File Path");
                foreach (SharedFile sharedFile in Core.ShareManager.SharedFiles.Values)
                    Console.WriteLine("{0};{1};{2};{3};{4};{5};{6}", TrimStringForCSV(sharedFile.Rating.ToString()), TrimStringForCSV(sharedFile.FileName), TrimStringForCSV(sharedFile.FileSize.ToString()), TrimStringForCSV(sharedFile.Album), TrimStringForCSV(sharedFile.Artist), TrimStringForCSV(sharedFile.Title), TrimStringForCSV(sharedFile.FilePath));
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the shared files unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.ShareManager.SharedFiles.Unlock();
            }
        }

        private static void ListUploads()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Core.Uploads.Lock();
                        count = Core.Uploads.Count;
                        if (count == 1)
                            Console.WriteLine("1 Upload");
                        else
                            Console.WriteLine("{0} Uploads", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("File Name", 47, StringAlign.Left));
                            Console.Write(" ");
                            Console.Write(AlignString("File Size", 10, StringAlign.Right));
                            Console.Write(" ");
                            Console.Write(AlignString("Progress", 12, StringAlign.CenterRight));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("Status", 7, StringAlign.Left));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                Upload upload = Core.Uploads[index].Value;
                                // get display values from shared files or (swarming) download
                                String fileName;
                                String fileSizeString;
                                SharedFile sharedFile;
                                if (Core.SharedFiles.TryGetValue(upload.FileHashString, out sharedFile))
                                {
                                    fileName = sharedFile.FileName;
                                    fileSizeString = sharedFile.FileSizeString;
                                }
                                else
                                {
                                    Download download;
                                    if (Core.DownloadsAndQueue.TryGetValue(upload.SourceDownloadIDString, out download))
                                    {
                                        fileName = download.FileName;
                                        fileSizeString = download.FileSizeString;
                                    }
                                    else
                                        continue;
                                }
                                Console.Write(AlignString(fileName, 47, StringAlign.Left));
                                Console.Write(" ");
                                Console.Write(AlignString(fileSizeString != null ? fileSizeString : "Unknown", 10, StringAlign.Right));
                                Console.Write(" ");
                                WriteUploadProgressBar(12, upload.Progress, index < Constants.MaximumUploadsCount);
                                Console.Write(" ");
                                Console.WriteLine(AlignString(index < Constants.MaximumUploadsCount ? "Active" : "Passive", 7, StringAlign.Left));
                            }
                        }
                    }
                    finally
                    {
                        Core.Uploads.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more upload...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more uploads...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the uploads!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ListUploadsUnformatted()
        {
            try
            {
                Core.Uploads.Lock();
                Console.WriteLine("File Name;File Size;Progress;Status");
                for (int n = 0; n < Core.Uploads.Count; n++)
                {
                    Upload upload = Core.Uploads[n].Value;
                    // get display values from shared files or (swarming) download
                    String fileName;
                    String fileSizeString;
                    SharedFile sharedFile;
                    if (Core.SharedFiles.TryGetValue(upload.FileHashString, out sharedFile))
                    {
                        fileName = sharedFile.FileName;
                        fileSizeString = sharedFile.FileSizeString;
                    }
                    else
                    {
                        Download download;
                        if (Core.DownloadsAndQueue.TryGetValue(upload.SourceDownloadIDString, out download))
                        {
                            fileName = download.FileName;
                            fileSizeString = download.FileSizeString;
                        }
                        else
                            continue;
                    }
                    Core.SharedFiles.TryGetValue(upload.FileHashString, out sharedFile);
                    Console.WriteLine("{0};{1};{2};{3}", TrimStringForCSV(fileName), TrimStringForCSV(fileSizeString != null ? fileSizeString : "Unknown"), TrimStringForCSV(upload.Progress.ToString()), TrimStringForCSV(n < Constants.MaximumUploadsCount ? "Active" : "Passive"));
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while listing the uploads unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Uploads.Unlock();
            }
        }

        private static void MoveDownloadToQueue1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^movedownloadtoqueue (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    Core.MoveDownloadToQueue(download.DownloadIDString);
                    Console.WriteLine("The download has been moved...");
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while moving the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void MoveDownloadToQueue2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^mdtq (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    Core.MoveDownloadToQueue(download.DownloadIDString);
                    Console.WriteLine("The download has been moved...");
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while moving the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void MoveToBottomOfQueue1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^movetobottomofqueue (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    Core.MoveToBottomOfQueue(download.DownloadIDString);
                    Console.WriteLine("The download has been moved...");
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while moving the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void MoveToBottomOfQueue2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^mtbq (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    Core.MoveToBottomOfQueue(download.DownloadIDString);
                    Console.WriteLine("The download has been moved...");
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while moving the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void MoveToTopOfQueue1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^movetotopofqueue (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    Core.MoveToTopOfQueue(download.DownloadIDString);
                    Console.WriteLine("The download has been moved...");
                }

            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while moving the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void MoveToTopOfQueue2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Download download = null;
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    int index = int.Parse(Regex.Split(command, @"^mttq (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.DownloadsAndQueue.Count)
                        download = Core.DownloadsAndQueue[index].Value;
                    else
                        Console.WriteLine("Unkown download id!");
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
                if (download != null)
                {
                    Core.MoveToTopOfQueue(download.DownloadIDString);
                    Console.WriteLine("The download has been moved...");
                }

            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while moving the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ParseCollection(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            try
            {
                string filename = Regex.Split(command, @"^parse collection ([\w\W]+)$", RegexOptions.IgnoreCase)[1];

                if (System.IO.File.Exists(filename))
                {
                    Core.ParseStealthNetCollection(filename);
                    Console.WriteLine("The collection has been parsed...");
                }
                else
                {
                    Console.WriteLine(String.Format("{0} not found!", filename));
                }

            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while parsing the collection!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void RemoveSearch(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                int index = int.Parse(Regex.Split(command, @"^remove search (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                if (index >= 0 && index < Core.Searches.Count)
                {
                    Search search = Core.Searches[index].Value;
                    Core.RemoveSearch(search.SearchID);
                    Console.WriteLine("The search of \"{0}\" has been removed...", search.SearchPattern);
                }
                else
                    Console.WriteLine("Unkown search id!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while removing the search!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static void RemoveSharedDirectory(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string sharedDirectory = null;
                try
                {
                    Core.ShareManager.SharedDirectories.Lock();
                    int index = int.Parse(Regex.Split(command, @"^remove shared directory (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                    if (index >= 0 && index < Core.ShareManager.SharedDirectories.Count)
                        sharedDirectory = Core.ShareManager.SharedDirectories[index];
                    else
                        Console.WriteLine("Unknown shared directory id!");
                }
                finally
                {
                    Core.ShareManager.SharedDirectories.Unlock();
                }
                if (sharedDirectory != null)
                {
                    Console.WriteLine("Type in \"y\" to remove the shared directory \"{0}\"...", sharedDirectory);
                    if (Regex.IsMatch(Console.ReadLine(), @"^y$", RegexOptions.IgnoreCase))
                    {
                        Core.ShareManager.RemoveDirectory(sharedDirectory);
                        Console.WriteLine("The shared directory has been removed...");
                    }
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while removing the shared directory!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void RestartSearch(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                int index = int.Parse(Regex.Split(command, @"^restart search (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                if (index >= 0 && index < Core.Searches.Count)
                {
                    Search search = Core.Searches[index].Value;
                    if (!search.IsActive)
                    {
                        search.Restart();
                        Console.WriteLine("The search of \"{0}\" has been restarted...", search.SearchPattern);
                    }
                    else
                        Console.WriteLine("The search of \"{0}\" is already started!", search.SearchPattern);
                }
                else
                    Console.WriteLine("Unkown search id!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while restarting the search!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static void ShowLog()
        {
            Console.WriteLine();
            try
            {
                int index = 0;
                int count = 0;
                for (; ; )
                {
                    try
                    {
                        Logger.Instance.LogEntries.Lock();
                        count = Logger.Instance.LogEntries.Count;
                        if (index == 0)
                            if (count == 1)
                                Console.WriteLine("1 Entry");
                            else
                                Console.WriteLine("{0} Entries", count);
                        if (count > 0)
                        {
                            Console.WriteLine();
                            Console.Write(AlignString("Timestamp", 19, StringAlign.Left));
                            Console.Write(" ");
                            Console.WriteLine(AlignString("Text", 59, StringAlign.Left));
                            for (int n = 0; n < 20 && index < count; n++, index++)
                            {
                                LogEntry logEntry = Logger.Instance.LogEntries[count - 1 - index];
                                Console.Write(AlignString(logEntry.TimeStamp.ToString("s"), 19, StringAlign.Left));
                                Console.Write(" ");
                                Console.WriteLine(AlignString(logEntry.Text, 59, StringAlign.Left));
                            }
                        }
                    }
                    finally
                    {
                        Logger.Instance.LogEntries.Unlock();
                    }
                    if (index < count)
                    {
                        Console.WriteLine();
                        if (count - index == 1)
                        {
                            Console.WriteLine("There is 1 more entry...");
                            Console.WriteLine("Press enter to list it... (Or type in \"c\" to cancel!)");
                        }
                        else
                        {
                            Console.WriteLine("There are {0} more entries...", count - index);
                            Console.WriteLine("Press enter to list them... (Or type in \"c\" to cancel!)");
                        }
                        if (Regex.IsMatch(Console.ReadLine(), @"^c$", RegexOptions.IgnoreCase))
                            break;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while showing the log!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ShowLogUnformatted()
        {
            try
            {
                Logger.Instance.LogEntries.Lock();
                Console.WriteLine("Timestamp;Text");
                for (int n = Logger.Instance.LogEntries.Count - 1; n >= 0; n--)
                {
                    LogEntry logEntry = Logger.Instance.LogEntries[n];
                    Console.WriteLine("{0};{1}", TrimStringForCSV(logEntry.TimeStamp.ToString("s")), TrimStringForCSV(logEntry.Text));
                }
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while showing the log unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Logger.Instance.LogEntries.Unlock();
            }
        }

        private static void ShowSettings()
        {
            Console.WriteLine();
            try
            {
                //2008-07-24 Nochbaer: BZ 45
                Console.WriteLine("Add new downloads to beginnging of queue:");
                Console.WriteLine(Settings.Instance["NewDownloadsToBeginngingOfQueue"]);
                Console.WriteLine("AverageConnectionsCount:");
                Console.WriteLine(Settings.Instance["AverageConnectionsCount"]);
                //2008-04-11 Nochbaer
                Console.WriteLine("AutoMoveDownloads:");
                Console.WriteLine(Settings.Instance["AutoMoveDownloads"]);
                //2008-06-17 Nochbaer
                Console.WriteLine("AutoMoveDownloadsIntervall (in minutes):");
                Console.WriteLine(Settings.Instance["AutoMoveDownloadsIntervall"]);
                Console.WriteLine("CorruptDirectory:");
                Console.WriteLine(Settings.Instance["CorruptDirectory"]);
                Console.WriteLine("DownloadLimit:");
                Console.WriteLine(bool.Parse(Settings.Instance["HasDownloadLimit"]) ? string.Format("{0} KiBits/s", uint.Parse(Settings.Instance["DownloadLimit"]) * 8 / 1024) : false.ToString());
                Console.WriteLine("IncomingDirectory:");
                Console.WriteLine(Settings.Instance["IncomingDirectory"]);
                Console.WriteLine("LogDirectory:");
                Console.WriteLine(Settings.Instance["LogDirectory"]);
                //2008-06-17 Nochbaer
                Console.WriteLine("Activate OnlineSignature:");
                Console.WriteLine(Settings.Instance["ActivateOnlineSignature"]);
                Console.WriteLine("OnlineSignature update intervall (in minutes):");
                Console.WriteLine(Settings.Instance["OnlineSignatureUpdateIntervall"]);
                //2008-03-19 Nochbaer
                Console.WriteLine("ParseCollections:");
                Console.WriteLine(Settings.Instance["ParseCollections"]);
                Console.WriteLine("Port:");
                Console.WriteLine(Settings.Instance["Port"]);
                Console.WriteLine("PreferencesDirectory:");
                Console.WriteLine(Settings.Instance["PreferencesDirectory"]);
                //2009-01-25 Nochbaer
                Console.WriteLine("Activate database for searchresults:");
                Console.WriteLine(Settings.Instance["ActivateSearchDB"]);
                Console.WriteLine("Save searchresults which are younger than (in days):");
                Console.WriteLine(Settings.Instance["SearchDBCleanUpDays"]);
                //2008-03-19 Nochbaer
                Console.WriteLine("SubFoldersForCollections:");
                Console.WriteLine(Settings.Instance["SubFoldersForCollections"]);
                Console.WriteLine("SynchronizeWebCaches:");
                Console.WriteLine(Settings.Instance["SynchronizeWebCaches"]);
                Console.WriteLine("TemporaryDirectory:");
                Console.WriteLine(Settings.Instance["TemporaryDirectory"]);
                Console.WriteLine("UploadLimit:");
                Console.WriteLine(bool.Parse(Settings.Instance["HasUploadLimit"]) ? string.Format("{0} KiBits/s", uint.Parse(Settings.Instance["UploadLimit"]) * 8 / 1024) : false.ToString());
                Console.WriteLine("UseBytesInsteadOfBits:");
                Console.WriteLine(Settings.Instance["UseBytesInsteadOfBits"]);
                Console.WriteLine("WriteLogfile:");
                Console.WriteLine(Settings.Instance["WriteLogfile"]);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while showing the settings!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ShowStatistics()
        {
            Console.WriteLine();
            try
            {
                Console.WriteLine("Download:");
                Console.WriteLine("  Downstream: {0}", TransferVolumeToString(Core.MinuteAverageDownloadStatistics[0], Core.AverageDownloadStatistics[0]));
                Console.WriteLine("  Session:");
                Console.WriteLine("    Downloaded: {0}", Core.LengthToString(Core.Downloaded));
                Console.WriteLine("    Count of Downloads: {0}", Core.DownloadsAndQueue.Count);
                Console.WriteLine("  Cumulative:");
                Console.WriteLine("    Downloaded: {0}", Core.LengthToString(Core.CumulativeDownloaded));
                Console.WriteLine("Upload:");
                Console.WriteLine("  Upstream: {0}", TransferVolumeToString(Core.MinuteAverageUploadStatistics[0], Core.AverageUploadStatistics[0]));
                Console.WriteLine("  Session:");
                Console.WriteLine("    Uploaded: {0}", Core.LengthToString(Core.Uploaded));
                Console.WriteLine("    Count of Uploads: {0}", Core.Uploads.Count);
                Console.WriteLine("  Cumulative:");
                Console.WriteLine("    Uploaded: {0}", Core.LengthToString(Core.CumulativeUploaded));
                Console.WriteLine("Connections:");
                Console.WriteLine("  Count of Connections: {0}", Core.Connections.Count);
                Console.WriteLine("Time Statistics:");
                Console.WriteLine("  Session:");
                Console.WriteLine("    Uptime: {0} days, {1} hours, {2} minutes, {3} seconds", Core.Uptime.Days, Core.Uptime.Hours, Core.Uptime.Minutes, Core.Uptime.Seconds);
                Console.WriteLine("  Cumulative:");
                Console.WriteLine("    Uptime: {0} days, {1} hours, {2} minutes, {3} seconds", Core.CumulativeUptime.Days, Core.CumulativeUptime.Hours, Core.CumulativeUptime.Minutes, Core.CumulativeUptime.Seconds);
                Console.WriteLine("Searchdatabase:");
                Console.WriteLine("  Entries: {0}", Core.GetSearchDBResultCount());
                ulong t = Core.GetSearchDBFileSizeOfEntries();
                if (t > long.MaxValue)
                {
                    t = long.MaxValue;
                }
                Console.WriteLine("  Filesize of Entries: {0}", Core.LengthToString((long)t));
                Console.WriteLine("  Last CleanUp: {0}", Core.GetSearchDBLastCleanUp());
                Console.WriteLine("  Entries deleted: {0}", Core.GetSearchDBLastCleanUpCount());
                Console.WriteLine("  Filesize: {0}", Core.LengthToString(Core.GetSearchDBFileSize()));

            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while showing the statistics!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void ShowStatisticsUnformatted()
        {
            try
            {
                Console.WriteLine("Key;Value");
                Console.WriteLine("Downstream Minute Average;{0}", TrimStringForCSV(Core.MinuteAverageDownloadStatistics[0].ToString()));
                Console.WriteLine("Downstream Average;{0}", TrimStringForCSV(Core.AverageDownloadStatistics[0].ToString()));
                Console.WriteLine("Session Downloaded;{0}", TrimStringForCSV(Core.Downloaded.ToString()));
                Console.WriteLine("Count of Downloads;{0}", TrimStringForCSV(Core.DownloadsAndQueue.Count.ToString()));
                Console.WriteLine("Cumulative Downloaded;{0}", TrimStringForCSV(Core.CumulativeDownloaded.ToString()));
                Console.WriteLine("Upstream Minute Average;{0}", TrimStringForCSV(Core.MinuteAverageUploadStatistics[0].ToString()));
                Console.WriteLine("Upstream Average;{0}", TrimStringForCSV(Core.AverageUploadStatistics[0].ToString()));
                Console.WriteLine("Session Uploaded;{0}", TrimStringForCSV(Core.Uploaded.ToString()));
                Console.WriteLine("Count of Uploads;{0}", TrimStringForCSV(Core.Uploads.Count.ToString()));
                Console.WriteLine("Cumulative Uploaded;{0}", TrimStringForCSV(Core.CumulativeUploaded.ToString()));
                Console.WriteLine("Count of Connections;{0}", TrimStringForCSV(Core.Connections.Count.ToString()));
                Console.WriteLine("Session Uptime Days;{0}", TrimStringForCSV(Core.Uptime.Days.ToString()));
                Console.WriteLine("Session Uptime Hours;{0}", TrimStringForCSV(Core.Uptime.Hours.ToString()));
                Console.WriteLine("Session Uptime Minutes;{0}", TrimStringForCSV(Core.Uptime.Minutes.ToString()));
                Console.WriteLine("Session Uptime Seconds;{0}", TrimStringForCSV(Core.Uptime.Seconds.ToString()));
                Console.WriteLine("Cumulative Uptime Days;{0}", TrimStringForCSV(Core.CumulativeUptime.Days.ToString()));
                Console.WriteLine("Cumulative Uptime Hours;{0}", TrimStringForCSV(Core.CumulativeUptime.Hours.ToString()));
                Console.WriteLine("Cumulative Uptime Minutes;{0}", TrimStringForCSV(Core.CumulativeUptime.Minutes.ToString()));
                Console.WriteLine("Cumulative Uptime Seconds;{0}", TrimStringForCSV(Core.CumulativeUptime.Seconds.ToString()));
                Console.WriteLine("Searchdatabase Entries;{0}", Core.GetSearchDBResultCount());
                ulong t = Core.GetSearchDBFileSizeOfEntries();
                if (t > long.MaxValue)
                {
                    t = long.MaxValue;
                }
                Console.WriteLine("Searchdatabase Filesize of Entries;{0}", Core.LengthToString((long)t));
                Console.WriteLine("Searchdatabase Last CleanUp;{0}", Core.GetSearchDBLastCleanUp());
                Console.WriteLine("Searchdatabase Entries deleted during last CleanUp;{0}", Core.GetSearchDBLastCleanUpCount());
                Console.WriteLine("Searchdatabase Filesize;{0}", Core.LengthToString(Core.GetSearchDBFileSize()));
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while showing the statistics unformatted!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
        }

        private static void StartDownload1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string fileHashString = Regex.Split(command, "^start download ([0-9A-Fa-f]{128})$", RegexOptions.IgnoreCase)[1];
                Core.AddDownload(Core.FileHashStringToFileHash(fileHashString), fileHashString, 0, "");
                if (Core.DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    Console.WriteLine("The download has been started...");
                else
                    Console.WriteLine("The download has been queued...");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void StartDownload2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                string[] parameters = Regex.Split(command, @"^start download (\d{1,}) (\d{1,})$", RegexOptions.IgnoreCase);
                int searchIndex = int.Parse(parameters[1]) - 1;
                if (searchIndex >= 0 && searchIndex < Core.Searches.Count)
                {
                    Search search = Core.Searches[searchIndex].Value;
                    try
                    {
                        search.Results.Lock();
                        int resultIndex = int.Parse(parameters[2]) - 1;
                        if (resultIndex >= 0 && resultIndex < search.Results.Count)
                        {
                            Search.Result result = search.Results[resultIndex].Value;
                            Core.AddDownload(result, "");
                            if (Core.DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                                Console.WriteLine("The download of \"{0}\" has been started...", result.FileName);
                            else
                                Console.WriteLine("The download of \"{0}\" has been queued...", result.FileName);
                        }
                        else
                            Console.WriteLine("Unknown result id!");
                    }
                    finally
                    {
                        search.Results.Unlock();
                    }
                }
                else
                    Console.WriteLine("Unkown search id!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static void StartDownload3(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                string fileHashString = Regex.Split(command, "^sd ([0-9A-Fa-f]{128})$", RegexOptions.IgnoreCase)[1];
                Core.AddDownload(Core.FileHashStringToFileHash(fileHashString), fileHashString, 0, "");
                if (Core.DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    Console.WriteLine("The download has been started...");
                else
                    Console.WriteLine("The download has been queued...");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void StartDownload4(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                string[] parameters = Regex.Split(command, @"^sd (\d{1,}) (\d{1,})$", RegexOptions.IgnoreCase);
                int searchIndex = int.Parse(parameters[1]) - 1;
                if (searchIndex >= 0 && searchIndex < Core.Searches.Count)
                {
                    Search search = Core.Searches[searchIndex].Value;
                    try
                    {
                        search.Results.Lock();
                        int resultIndex = int.Parse(parameters[2]) - 1;
                        if (resultIndex >= 0 && resultIndex < search.Results.Count)
                        {
                            Search.Result result = search.Results[resultIndex].Value;
                            Core.AddDownload(result, "");
                            if (Core.DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                                Console.WriteLine("The download of \"{0}\" has been started...", result.FileName);
                            else
                                Console.WriteLine("The download of \"{0}\" has been queued...", result.FileName);
                        }
                        else
                            Console.WriteLine("Unknown result id!");
                    }
                    finally
                    {
                        search.Results.Unlock();
                    }
                }
                else
                    Console.WriteLine("Unkown search id!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static void StartDownloadByLink1(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                StealthNetLink link = new StealthNetLink(command.Remove(0, 15));
                Core.AddDownload(link.FileHash, link.FileName, link.FileSize, string.Empty);
                if (Core.DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    Console.WriteLine("The download has been started...");
                else
                    Console.WriteLine("The download has been queued...");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void StartDownloadByLink2(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                StealthNetLink link = new StealthNetLink(command);
                Core.AddDownload(link.FileHash, link.FileName, link.FileSize, string.Empty);
                if (Core.DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    Console.WriteLine("The download has been started...");
                else
                    Console.WriteLine("The download has been queued...");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the download!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void StartSearch1(string command, Search.SearchType searchType)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                string searchPattern;
                if (searchType == Search.SearchType.OnlyDatabase)
                {
                    searchPattern = Regex.Split(command, @"^start search only database""(\S.{1,}\S)""$", RegexOptions.IgnoreCase)[1];
                }
                else if (searchType == Search.SearchType.OnlyNetwork)
                {
                    searchPattern = Regex.Split(command, @"^start search only network""(\S.{1,}\S)""$", RegexOptions.IgnoreCase)[1];
                }
                else
                {
                    searchPattern = Regex.Split(command, @"^start search ""(\S.{1,}\S)""$", RegexOptions.IgnoreCase)[1];
                }

                if (Core.Searches.Count < Constants.MaximumSearchesCount)
                {
                    Core.AddSearch(searchPattern, new AnyFileType(), searchType);
                    Console.WriteLine("The search of \"{0}\" has been started...", searchPattern);
                }
                else
                    Console.WriteLine("You have already {0} searches!", Core.Searches.Count);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the search!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static void StartSearch2(string command, Search.SearchType searchType)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                string searchPattern;
                if (searchType == Search.SearchType.OnlyDatabase)
                {
                    searchPattern = Regex.Split(command, @"^start search only database (\S.{1,}\S)$", RegexOptions.IgnoreCase)[1];
                }
                else if (searchType == Search.SearchType.OnlyNetwork)
                {
                    searchPattern = Regex.Split(command, @"^start search only network (\S.{1,}\S)$", RegexOptions.IgnoreCase)[1];
                }
                else
                {
                    searchPattern = Regex.Split(command, @"^start search (\S.{1,}\S)$", RegexOptions.IgnoreCase)[1];
                }

                if (Core.Searches.Count < Constants.MaximumSearchesCount)
                {
                    Core.AddSearch(searchPattern, new AnyFileType(), searchType);
                    Console.WriteLine("The search of \"{0}\" has been started...", searchPattern);
                }
                else
                    Console.WriteLine("You have already {0} searches!", Core.Searches.Count);
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while starting the search!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static void StopSearch(string command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Console.WriteLine();
            try
            {
                Core.Searches.Lock();
                int index = int.Parse(Regex.Split(command, @"^stop search (\d{1,})$", RegexOptions.IgnoreCase)[1]) - 1;
                if (index >= 0 && index < Core.Searches.Count)
                {
                    Search search = Core.Searches[index].Value;
                    if (search.IsActive)
                    {
                        search.Stop();
                        Console.WriteLine("The search of \"{0}\" has been stopped...", search.SearchPattern);
                    }
                    else
                        Console.WriteLine("The search of \"{0}\" is already stopped!", search.SearchPattern);
                }
                else
                    Console.WriteLine("Unkown search id!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while stopping the search!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            finally
            {
                Core.Searches.Unlock();
            }
            Console.WriteLine();
        }

        private static string TransferVolumeToString(int minuteAverage, int average)
        {
            if (minuteAverage < 0)
                throw new ArgumentOutOfRangeException("minuteAverage");
            if (average < 0)
                throw new ArgumentOutOfRangeException("average");

            float minuteAverageSingle = (float)minuteAverage;
            string minuteAverageString;
            if (Convert.ToBoolean(Settings.Instance["UseBytesInsteadOfBits"]))
                if (minuteAverageSingle <= 1024)
                    minuteAverageString = string.Format("{0:F0} B/s", minuteAverageSingle);
                else if (minuteAverageSingle <= 1048576)
                    minuteAverageString = string.Format("{0:F1} KiB/s", minuteAverageSingle / 1024);
                else if (minuteAverageSingle <= 1073741824)
                    minuteAverageString = string.Format("{0:F1} MiB/s", minuteAverageSingle / 1048576);
                else
                    minuteAverageString = string.Format("{0:F1} GiB/s", minuteAverageSingle / 1073741824);
            else
            {
                minuteAverageSingle *= 8;
                if (minuteAverageSingle <= 1024)
                    minuteAverageString = string.Format("{0:F0} b/s", minuteAverageSingle);
                else if (minuteAverageSingle <= 1048576)
                    minuteAverageString = string.Format("{0:F1} Kib/s", minuteAverageSingle / 1024);
                else if (minuteAverageSingle <= 1073741824)
                    minuteAverageString = string.Format("{0:F1} Mib/s", minuteAverageSingle / 1048576);
                else
                    minuteAverageString = string.Format("{0:F1} Gib/s", minuteAverageSingle / 1073741824);
            }
            float averageSingle = (float)average;
            string averageString;
            if (Convert.ToBoolean(Settings.Instance["UseBytesInsteadOfBits"]))
                if (averageSingle <= 1024)
                    averageString = string.Format("{0:F0} B/s", averageSingle);
                else if (averageSingle <= 1048576)
                    averageString = string.Format("{0:F1} KiB/s", averageSingle / 1024);
                else if (averageSingle <= 1073741824)
                    averageString = string.Format("{0:F1} MiB/s", averageSingle / 1048576);
                else
                    averageString = string.Format("{0:F1} GiB/s", averageSingle / 1073741824);
            else
            {
                averageSingle *= 8;
                if (averageSingle <= 1024)
                    averageString = string.Format("{0:F0} b/s", averageSingle);
                else if (averageSingle <= 1048576)
                    averageString = string.Format("{0:F1} Kib/s", averageSingle / 1024);
                else if (averageSingle <= 1073741824)
                    averageString = string.Format("{0:F1} Mib/s", averageSingle / 1048576);
                else
                    averageString = string.Format("{0:F1} Gib/s", averageSingle / 1073741824);
            }
            return string.Format("{0} ({1})", minuteAverageString, averageString);
        }

        private static string TrimStringForCSV(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            input.Trim();
            if (input.Contains("\"") || input.Contains(";"))
                return string.Format("\"{0}\"", input.Replace("\"", "\"\""));
            else
                return input;
        }

        private static void UpdateSettings()
        {
            Console.WriteLine();
            try
            {
                byte byteValue;
                uint uintValue;
                bool boolValue;
                //2008-07-24 Nochbaer BZ 45
                Console.WriteLine("Add new downloads to beginnging of queue: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["NewDownloadsToBeginngingOfQueue"] = boolValue.ToString();
                Console.WriteLine("AverageConnectionsCount: (1 - 10)");
                if (byte.TryParse(Console.ReadLine(), out byteValue))
                {
                    if (byteValue < 1)
                        byteValue = 1;
                    else if (byteValue > 10)
                        byteValue = 10;
                    Settings.Instance["AverageConnectionsCount"] = byteValue.ToString();
                }
                //2008-04-11 Nochbaer 
                Console.WriteLine("AutoMove downloads without sources: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["AutoMoveDownloads"] = boolValue.ToString();
                Console.WriteLine("AutoMoveIntervall (in minutes):");
                if (uint.TryParse(Console.ReadLine(), out uintValue))
                {
                    if (uintValue < 60) uintValue = 60;
                    Settings.Instance["AutoMoveDownloadsIntervall"] = uintValue.ToString();
                }
                Console.WriteLine("CorruptDirectory: (valid directory path)");
                string stringValue = Console.ReadLine();
                if (Directory.Exists(stringValue))
                    Settings.Instance["CorruptDirectory"] = stringValue;
                Console.WriteLine("DownloadLimit: (false | value in KBits/s)");
                stringValue = Console.ReadLine();
                if (uint.TryParse(stringValue, out uintValue))
                {
                    Settings.Instance["DownloadLimit"] = (uintValue * 1024 / 8).ToString();
                    Settings.Instance["HasDownloadLimit"] = true.ToString();
                }
                else if (bool.TryParse(stringValue, out boolValue) && !boolValue)
                    Settings.Instance["HasDownloadLimit"] = boolValue.ToString();
                Console.WriteLine("IncomingDirectory: (valid directory path)");
                stringValue = Console.ReadLine();
                if (Directory.Exists(stringValue))
                    Settings.Instance["IncomingDirectory"] = stringValue;
                Console.WriteLine("LogDirectory: (valid directory path)");
                stringValue = Console.ReadLine();
                if (Directory.Exists(stringValue))
                    Settings.Instance["LogDirectory"] = stringValue;
                Console.WriteLine("Activate OnlineSignature: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["ActivateOnlineSignature"] = boolValue.ToString();
                Console.WriteLine("OnlineSignature update intervall (in minutes):");
                ushort ushortValue;
                if (ushort.TryParse(Console.ReadLine(), out ushortValue))
                    Settings.Instance["OnlineSignatureUpdateIntervall"] = ushortValue.ToString();
                Console.WriteLine("Port: (0 - 65535)");
                if (ushort.TryParse(Console.ReadLine(), out ushortValue))
                    Settings.Instance["Port"] = ushortValue.ToString();
                //2008-03-19 Nochbaer
                Console.WriteLine("ParseCollections: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["ParseCollections"] = boolValue.ToString();
                Console.WriteLine("PreferencesDirectory: (valid directory path)");
                stringValue = Console.ReadLine();
                if (Directory.Exists(stringValue))
                    Settings.Instance["PreferencesDirectory"] = stringValue;
                //2009-01-25 Nochbaer
                Console.WriteLine("Activate database for searchresults:  (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["ActivateSearchDB"] = boolValue.ToString();
                Console.WriteLine("Save searchresults which are younger than (in days): (>1)");
                if (uint.TryParse(Console.ReadLine(), out uintValue))
                {
                    if (uintValue < 1) uintValue = 1;
                    if (uintValue > 120) uintValue = 120;
                    Settings.Instance["SearchDBCleanUpDays"] = uintValue.ToString();
                }
                //2008-03-19 Nochbaer
                Console.WriteLine("SubFoldersForCollections: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["SubFoldersForCollections"] = boolValue.ToString();
                Console.WriteLine("SynchronizeWebCaches: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["SynchronizeWebCaches"] = boolValue.ToString();
                Console.WriteLine("TemporaryDirectory: (valid directory path)");
                stringValue = Console.ReadLine();
                if (Directory.Exists(stringValue))
                    Settings.Instance["TemporaryDirectory"] = stringValue;
                Console.WriteLine("UploadLimit: (false | value in KBits/s)");
                stringValue = Console.ReadLine();
                if (uint.TryParse(stringValue, out uintValue))
                {
                    Settings.Instance["UploadLimit"] = (uintValue * 1024 / 8).ToString();
                    Settings.Instance["HasUploadLimit"] = true.ToString();
                }
                else if (bool.TryParse(stringValue, out boolValue) && !boolValue)
                    Settings.Instance["HasUploadLimit"] = boolValue.ToString();
                Console.WriteLine("UseBytesInsteadOfBits: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["UseBytesInsteadOfBits"] = boolValue.ToString();
                Console.WriteLine("WriteLogfile: (true | false)");
                if (bool.TryParse(Console.ReadLine(), out boolValue))
                    Settings.Instance["WriteLogfile"] = boolValue.ToString();
                Console.WriteLine();
                Console.WriteLine("You should restart StealthNet, so that made changes will be applied!");
            }
            catch (Exception ex)
            {
                string s = "An exception was thrown while updating the settings!";
                Console.WriteLine(s);
                Logger.Instance.Log(ex, s);
            }
            Console.WriteLine();
        }

        private static void WriteDownloadProgressBar(int chars, float progress, bool hasSources, bool isActive)
        {
            if (chars < 0)
                throw new ArgumentOutOfRangeException("chars");

            string progressString = AlignString(string.Format("{0:F1}%", progress), chars, StringAlign.CenterRight);
            int completed = (int)((progress / 100F) * (float)progressString.Length);
            for (int n = 0; n < progressString.Length; n++)
            {
                if (n < completed)
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (isActive && n == completed)
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hasSources)
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(progressString[n]);
            }
            Console.ResetColor();
        }

        private static void WriteUploadProgressBar(int chars, float progress, bool isActive)
        {
            if (chars < 0)
                throw new ArgumentOutOfRangeException("chars");

            string progressString = AlignString(string.Format("{0:F1}%", progress), chars, StringAlign.CenterRight);
            int completed = (int)((progress / 100F) * (float)progressString.Length);
            for (int n = 0; n < progressString.Length; n++)
            {
                if (n < completed)
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (isActive && n == completed)
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(progressString[n]);
            }
            Console.ResetColor();
        }

        private enum StringAlign
        {
            Left,
            CenterLeft,
            CenterRight,
            Right
        }
    }
}