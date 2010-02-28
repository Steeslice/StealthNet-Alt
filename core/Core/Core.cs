//RShare
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

using Regensburger.RCollections.ArrayBased;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using StealthNet.Core;
using System.Globalization;

namespace Regensburger.RShare
{
    public static partial class Core
    {
        private static RList<int> m_AverageDownloadStatistics = new RList<int>();

        private static RList<int> m_AverageUploadStatistics = new RList<int>();

        private static string m_CommentsFilePath = "comments.xml";

        private static RIndexedHashtable<IPAddress, Connection> m_Connections = new RIndexedHashtable<IPAddress, Connection>();

        private static RList<int> m_ConnectionsStatistics = new RList<int>();

        private static long m_CumulativeDownloaded = 0;

        private static long m_CumulativeUploaded = 0;

        private static TimeSpan m_CumulativeUptime = TimeSpan.Zero;

        private static int m_CurrentDownstream = 0;

        private static int m_CurrentUpstream = 0;

        private static long m_Downloaded = 0;

        private static DownloadCollection m_DownloadsAndQueue = new DownloadCollection();

        private static string m_DownloadsFilePath = "downloads.xml";

        private static int m_Downstream = 0;

        private static int m_DropChainTailCount;

        private static bool m_IsAccessible = false;

        private static bool m_IsClosing = false;

        private static bool m_IsUpdateAvailable = false;

        private static RSAParameters m_Keys;

        private static RIndexedHashtable<string, DateTime> m_LastCommandID = new RIndexedHashtable<string, DateTime>();

        private static Logger m_Logger = Logger.Instance;

        private static string m_MetaDataFilePath = "metadata.xml";

        private static RList<int> m_MinuteAverageDownloadStatistics = new RList<int>();

        private static RList<int> m_MinuteAverageUploadStatistics = new RList<int>();

        private static byte[] m_PeerID;

        private static RIndexedHashtable<string, Peer> m_Peers = new RIndexedHashtable<string, Peer>();

        private static string m_RatingsFilePath = "ratings.xml";

        private static string m_SearchDBFilePath = "searchdb.dat";

        private static SearchDBManager m_SearchDBManager = null;

        private static RIndexedHashtable<string, Search> m_Searches = new RIndexedHashtable<string, Search>();

        private static string m_SharedDirectoriesFilePath = "shareddirectories.xml";

        private static string m_SharedFilesFilePath = "sharedfiles.xml";

        private static string m_SharedFilesStatsFilePath = "sharedfilesstats.xml";

        private static ShareManager m_ShareManager = null;

        private static string m_StatisticsFilePath = "statistics.xml";

        private static long m_Uploaded = 0;

        private static RIndexedHashtable<string, Upload> m_Uploads = new RIndexedHashtable<string, Upload>();

        private static int m_Upstream = 0;

        private static TimeSpan m_Uptime = TimeSpan.Zero;

        private static RList<string> m_WebCaches = new RList<string>();

        private static string m_WebCachesFilePath = "webcaches.xml";

        public static RList<int> AverageDownloadStatistics
        {
            get
            {
                return m_AverageDownloadStatistics;
            }
        }

        public static RList<int> AverageUploadStatistics
        {
            get
            {
                return m_AverageUploadStatistics;
            }
        }

        public static RIndexedHashtable<IPAddress, Connection> Connections
        {
            get
            {
                return m_Connections;
            }
        }

        public static RList<int> ConnectionsStatistics
        {
            get
            {
                return m_ConnectionsStatistics;
            }
        }

        public static long CumulativeDownloaded
        {
            get
            {
                return m_CumulativeDownloaded;
            }
        }

        public static long CumulativeUploaded
        {
            get
            {
                return m_CumulativeUploaded;
            }
        }

        public static TimeSpan CumulativeUptime
        {
            get
            {
                return m_CumulativeUptime;
            }
        }

        public static long Downloaded
        {
            get
            {
                return m_Downloaded;
            }
        }

        public static DownloadCollection DownloadsAndQueue
        {
            get
            {
                return m_DownloadsAndQueue;
            }
        }

        public static bool IsAccessible
        {
            get
            {
                return m_IsAccessible;
            }
        }

        public static bool IsClosing
        {
            get
            {
                return m_IsClosing;
            }
        }

        public static bool IsUpdateAvailable
        {
            get
            {
                return m_IsUpdateAvailable;
            }
        }

        public static bool IsWorldReachable
        {
            get
            {
                if (m_Connections.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public static RList<int> MinuteAverageDownloadStatistics
        {
            get
            {
                return m_MinuteAverageDownloadStatistics;
            }
        }

        public static RList<int> MinuteAverageUploadStatistics
        {
            get
            {
                return m_MinuteAverageUploadStatistics;
            }
        }

        public static RIndexedHashtable<string, Search> Searches
        {
            get
            {
                return m_Searches;
            }
        }

        public static RList<string> SharedDirectories
        {
            get
            {
                return m_ShareManager.SharedDirectories;
            }
        }

        public static SharedFileCollection SharedFiles
        {
            get
            {
                return m_ShareManager.SharedFiles;
            }
        }

        public static ShareManager ShareManager
        {
            get
            {
                return m_ShareManager;
            }
        }

        public static long Uploaded
        {
            get
            {
                return m_Uploaded;
            }
        }

        public static RIndexedHashtable<string, Upload> Uploads
        {
            get
            {
                return m_Uploads;
            }
        }

        public static TimeSpan Uptime
        {
            get
            {
                return m_Uptime;
            }
        }

        public static string Version
        {
            get
            {
                string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                if (version.EndsWith(".0"))
                {
                    version = version.Substring(0, version.Length - 2);
                }
                return version;
            }
        }

        public static void AddConnection(IPEndPoint endPoint)
        {
            if (endPoint == null)
                throw new ArgumentNullException("endPoint");

            Thread connectThread = new Thread(delegate()
            {
                try
                {
                    if (m_Connections.ContainsKey(endPoint.Address))
                        return;
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(endPoint);
                    Connection connection = new Connection(socket);
                    try
                    {
                        m_Connections.Lock();
                        if (!m_Connections.ContainsKey(endPoint.Address))
                            m_Connections.Add(connection.RemoteEndPoint.Address, connection);
                        else
                            connection.Disconnect();
                    }
                    finally
                    {
                        m_Connections.Unlock();
                    }
                }
                catch
                {
                }
            });
            connectThread.Name = "connectThread";
            connectThread.IsBackground = true;
            connectThread.Start();
        }

        public static void AddDownload(byte[] fileHash, string fileName, long fileSize, string subFolder)
        {
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (fileSize < 0)
                throw new ArgumentOutOfRangeException("fileSize");

            try
            {
                m_DownloadsAndQueue.Lock();
                if (m_DownloadsAndQueue.ContainsKey(ByteArrayToString(fileHash), DownloadCollection.KeyAccess.FileHash))
                    return;
                Download download = new Download(fileHash, fileName, fileSize);
                if (m_DownloadsAndQueue.Count >= Constants.MaximumDownloadsCount)
                {
                    download.SetSubFolderAndTime(subFolder, null);
                    download.RemoveSources();
                    if (bool.Parse(Settings.Instance["NewDownloadsToBeginngingOfQueue"]))
                        m_DownloadsAndQueue.Insert(Constants.MaximumDownloadsCount, download);
                    else
                        m_DownloadsAndQueue.Add(download);
                }
                else
                {
                    download.SetSubFolderAndTime(subFolder, DateTime.Now);
                    m_DownloadsAndQueue.Add(download);
                }
            }
            finally
            {
                m_DownloadsAndQueue.Unlock();
            }
            DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);
        }

        public static void AddDownload(Search.Result result, string subFolder)
        {
            if (result == null)
                throw new ArgumentNullException("result");

            try
            {
                m_DownloadsAndQueue.Lock();
                if (m_DownloadsAndQueue.ContainsKey(ByteArrayToString(result.FileHash), DownloadCollection.KeyAccess.FileHash))
                    return;
                Download download = new Download(result);
                if (m_DownloadsAndQueue.Count >= Constants.MaximumDownloadsCount)
                {
                    download.SetSubFolderAndTime(subFolder, null);
                    download.RemoveSources();
                    if (bool.Parse(Settings.Instance["NewDownloadsToBeginngingOfQueue"]))
                        m_DownloadsAndQueue.Insert(Constants.MaximumDownloadsCount, download);
                    else
                        m_DownloadsAndQueue.Add(download);
                }
                else
                {
                    download.SetSubFolderAndTime(subFolder, DateTime.Now);
                    m_DownloadsAndQueue.Add(download);
                }
            }
            finally
            {
                m_DownloadsAndQueue.Unlock();
            }
            DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);
        }

        public static void AddSearch(string pattern, FileType fileTypeFilter)
        {
            if (pattern == null)
                throw new ArgumentNullException("pattern");
            if (pattern.Trim().Length < 3)
                throw new ArgumentException();

            AddSearch(pattern, fileTypeFilter, Search.SearchType.Auto);
        }

        public static void AddSearch(string pattern, FileType fileTypeFilter, Search.SearchType searchType)
        {
            if (pattern == null)
                throw new ArgumentNullException("pattern");
            if (pattern.Trim().Length < 3)
                throw new ArgumentException();

            try
            {
                m_Searches.Lock();
                if (m_Searches.Count >= Constants.MaximumSearchesCount)
                    throw new InvalidOperationException();
                {
                    pattern = pattern.Trim().ToLower();
                    foreach (Search search in m_Searches.Values)
                        if (search.SearchPattern.Equals(pattern))
                            return;
                }
                {
                    // 2007-05-28
                    Search search = new Search(pattern, fileTypeFilter, searchType);
                    m_Searches.Add(search.SearchIDString, search);
                }
            }
            finally
            {
                m_Searches.Unlock();
            }
        }

        public static void AddSearchDBSearch(string searchID, string searchPattern)
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                m_SearchDBManager.AddSearch(searchID, searchPattern);
            }
        }

        public static string ByteArrayToString(byte[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in array)
                stringBuilder.AppendFormat("{0:X2}", b);
            return stringBuilder.ToString();
        }

        private static bool CheckCommand(Connection connection, IRequestCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (connection == null)
                throw new ArgumentNullException("clientConnection");

            Peer peer;
            try
            {
                m_Peers.Lock();
                string idString = ByteArrayToString(command.SenderPeerID);
                if (!m_Peers.TryGetValue(idString, out peer))
                    m_Peers.Add(idString, peer = new Peer());
            }
            finally
            {
                m_Peers.Unlock();
            }
            peer.ReportReceived(connection.RemoteEndPoint.Address);
            string commandIDString = ByteArrayToString(command.CommandID);
            try
            {
                m_LastCommandID.Lock();
                if (m_LastCommandID.ContainsKey(commandIDString))
                {
                    m_LastCommandID[commandIDString] = DateTime.Now;
                    return false;
                }
                m_LastCommandID.Add(commandIDString, DateTime.Now);
            }
            finally
            {
                m_LastCommandID.Unlock();
            }
            peer.ReportReceived();
            return true;
        }

        public static void Close()
        {
            m_IsClosing = true;

            m_Logger.Log("{0} will be closed", String.Format(Constants.Software, Core.Version));

            Thread.Sleep(2000);

            try
            {
                m_ShareManager.SaveConfiguration(m_SharedDirectoriesFilePath, m_SharedFilesFilePath, m_SharedFilesStatsFilePath, m_MetaDataFilePath, m_CommentsFilePath, m_RatingsFilePath);
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while closing shared files!");
            }

            try
            {
                if (m_SearchDBManager != null)
                    m_SearchDBManager.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while closing searching database!");
            }

            try
            {
                StatisticsXmlWriter.write(m_StatisticsFilePath, m_CumulativeDownloaded.ToString(), m_CumulativeUploaded.ToString(), m_CumulativeUptime.ToString());
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while closing statistics!");
            }

            DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);

            m_Logger.Log("{0} has been closed", String.Format(Constants.Software, Core.Version));
        }

        public static bool CompareByteArray(byte[] array1, byte[] array2)
        {
            if (array1 == null)
                throw new ArgumentNullException("array1");
            if (array2 == null)
                throw new ArgumentNullException("array2");
            if (array1.Length != array2.Length)
                throw new ArgumentException();

            for (int n = 0; n < array1.Length; n++)
                if (array1[n] != array2[n])
                    return false;
            return true;
        }

        public static bool CompareByteArray(byte[] array1, byte[] array2, int count)
        {
            if (array1 == null)
                throw new ArgumentNullException("array1");
            if (array2 == null)
                throw new ArgumentNullException("array2");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            if (count > array1.Length)
                throw new ArgumentException();
            if (count > array2.Length)
                throw new ArgumentException();

            for (int n = 0; n < count; n++)
                if (array1[n] != array2[n])
                    return false;
            return true;
        }

        public static byte[] FileHashStringToFileHash(string fileHashString)
        {
            if (fileHashString == null)
                throw new ArgumentNullException("fileHashString");
            if (!Regex.IsMatch(fileHashString, "^[0-9A-F]{128,128}$", RegexOptions.IgnoreCase))
                throw new ArgumentException();

            byte[] fileHash = new byte[64];
            for (int n = 0; n < 128; n += 2)
                fileHash[n / 2] = Convert.ToByte(fileHashString.Substring(n, 2), 16);
            return fileHash;
        }

        public static byte[] GenerateFloodingHash()
        {
            byte[] floodingHash = GenerateIDOrHash();
            while (floodingHash[47] <= 51)
                floodingHash = GenerateIDOrHash();
            return floodingHash;
        }

        public static byte[] GenerateIDOrHash()
        {
            return ComputeHashes.SHA384Compute(Guid.NewGuid().ToByteArray());
        }

        public static long GetSearchDBFileSize()
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                return m_SearchDBManager.FileSize;
            }
            else
            {
                return 0;
            }
        }

        public static ulong GetSearchDBFileSizeOfEntries()
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                return m_SearchDBManager.FileSizeOfEntries;
            }
            else
            {
                return 0;
            }
        }

        public static string GetSearchDBLastCleanUp()
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                return m_SearchDBManager.LastCleanUp.ToString();
            }
            else
            {
                return "?";
            }
        }

        public static string GetSearchDBLastCleanUpCount()
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                return m_SearchDBManager.LastCleanUpCount.ToString();
            }
            else
            {
                return "?";
            }
        }

        public static long GetSearchDBResultCount()
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                return m_SearchDBManager.ResultCount;
            }
            else
            {
                return 0;
            }
        }

        public static RIndexedHashtable<string, SearchDBManager.OldSearchResult> GetSearchDBResults(string searchID)
        {
            if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                return m_SearchDBManager.GetResults(searchID);
            }
            else
            {
                return new RIndexedHashtable<string, SearchDBManager.OldSearchResult>();
            }
        }

        public static string LengthToString(long length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("length");

            float singleSize = Convert.ToSingle(length);
            if (singleSize <= 1024)
                return String.Format("{0:F0} B", singleSize);
            else if (singleSize <= 1048576)
                return String.Format("{0:F1} KiB", singleSize / 1024);
            else if (singleSize <= 1073741824)
                return String.Format("{0:F1} MiB", singleSize / 1048576);
            else if (singleSize <= 1099511627776)
                return String.Format("{0:F1} GiB", singleSize / 1073741824);
            else if (singleSize <= 1125899906842624)
                return String.Format("{0:F1} TiB", singleSize / 1099511627776);
            else
                return String.Format("{0:F1} PiB", singleSize / 1125899906842624);
        }

        public static void Load()
        {
            SetUILanguage();

            m_ShareManager = new ShareManager();

            Constants.SetMaximumDownloadsCount(int.Parse(Settings.Instance["MaximumDownloadsCount"]));
            if (!Directory.Exists(Settings.Instance["PreferencesDirectory"]))
                Directory.CreateDirectory(Settings.Instance["PreferencesDirectory"]);
            Settings.Instance["PreferencesDirectory"] = new DirectoryInfo(Settings.Instance["PreferencesDirectory"]).FullName;
            if (!Directory.Exists(Settings.Instance["LogDirectory"]))
                Directory.CreateDirectory(Settings.Instance["LogDirectory"]);
            Settings.Instance["LogDirectory"] = new DirectoryInfo(Settings.Instance["LogDirectory"]).FullName;
            if (!Directory.Exists(Settings.Instance["IncomingDirectory"]))
                Directory.CreateDirectory(Settings.Instance["IncomingDirectory"]);
            Settings.Instance["IncomingDirectory"] = new DirectoryInfo(Settings.Instance["IncomingDirectory"]).FullName;
            if (!Directory.Exists(Settings.Instance["TemporaryDirectory"]))
                Directory.CreateDirectory(Settings.Instance["TemporaryDirectory"]);
            Settings.Instance["TemporaryDirectory"] = new DirectoryInfo(Settings.Instance["TemporaryDirectory"]).FullName;
            if (!Directory.Exists(Settings.Instance["CorruptDirectory"]))
                Directory.CreateDirectory(Settings.Instance["CorruptDirectory"]);
            Settings.Instance["CorruptDirectory"] = new DirectoryInfo(Settings.Instance["CorruptDirectory"]).FullName;
            m_WebCachesFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_WebCachesFilePath);
            //2009-01-25 Nochbaer
            m_SearchDBFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_SearchDBFilePath);
            m_SharedDirectoriesFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_SharedDirectoriesFilePath);
            m_SharedFilesFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_SharedFilesFilePath);
            m_SharedFilesStatsFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_SharedFilesStatsFilePath);
            m_MetaDataFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_MetaDataFilePath);
            m_CommentsFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_CommentsFilePath);
            m_RatingsFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_RatingsFilePath);
            m_StatisticsFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_StatisticsFilePath);
            m_DownloadsFilePath = Path.Combine(Settings.Instance["PreferencesDirectory"], m_DownloadsFilePath);

            // initialize logger with log directory
            // Changed 2007-05-06 by T.Norad
            if (bool.Parse(Settings.Instance["WriteLogfile"]))
            {
                Logger.Instance.initialize(Settings.Instance["LogDirectory"]);
            }

            // 2007-05-16 T.Norad
            ResumeDownloads();

            m_Logger.Log(Properties.Resources_Core.StealthNetLoading, String.Format(Constants.Software, Core.Version));
            m_Logger.Log(Properties.Resources_Core.DownloadSourcesAllowed, Constants.MaximumDownloadsCount, Constants.MaximumSourcesCount);
            m_Logger.Log(Properties.Resources_Core.NETFrameworkVersion, Environment.Version.ToString());
            m_Logger.Log(Properties.Resources_Core.OSVersion, Environment.OSVersion.ToString());

            m_DropChainTailCount = 0;
            if (GenerateIDOrHash()[47] > 192)
                while (GenerateIDOrHash()[47] <= 128)
                    m_DropChainTailCount++;

            m_PeerID = GenerateIDOrHash();

            try
            {
                UpdateWebServiceProxy update = new UpdateWebServiceProxy();
                if (bool.Parse(Settings.Instance["SynchronizeWebCaches"]))
                {
                    string webCaches = update.GetWebCaches();
                    if (File.Exists(m_WebCachesFilePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", m_WebCachesFilePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(m_WebCachesFilePath, backupFilePath);
                    }
                    StreamWriter webCachesFileStreamWriter = new StreamWriter(new FileStream(m_WebCachesFilePath, FileMode.Create, FileAccess.Write, FileShare.None));
                    webCachesFileStreamWriter.Write(webCaches);
                    webCachesFileStreamWriter.Flush();
                    webCachesFileStreamWriter.Close();
                }
                m_IsUpdateAvailable = update.IsUpdateAvailable(String.Format(Constants.Software, Core.Version));
                update.Dispose();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while updating the list of WebCaches!");
            }

            m_Keys = RSAGenerateKeys();

            try
            {
                if (File.Exists(m_WebCachesFilePath))
                {
                    XmlDocument webCachesXmlDocument = new XmlDocument();
                    webCachesXmlDocument.Load(m_WebCachesFilePath);
                    foreach (XmlNode webCacheNode in webCachesXmlDocument.SelectSingleNode("webcaches").SelectNodes("webcache"))
                        m_WebCaches.Add(webCacheNode.Attributes["url"].Value);
                }
                else if (bool.Parse(Settings.Instance["SynchronizeWebCaches"]))
                {
                    m_WebCaches.Add("http://rshare.de/rshare.asmx");
                    m_WebCaches.Add("http://webcache.stealthnet.at/rwpmws.php");
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading WebCaches file!");
            }
            m_ShareManager.LoadConfiguration(m_SharedDirectoriesFilePath, m_SharedFilesFilePath, m_SharedFilesStatsFilePath, m_MetaDataFilePath, m_CommentsFilePath, m_RatingsFilePath);

            //2009-01-25 Nochbaer
            if (bool.Parse(Settings.Instance["ActivateSearchDB"]))
            {
                m_SearchDBManager = new SearchDBManager(m_SearchDBFilePath);
            }

            try
            {
                if (File.Exists(m_StatisticsFilePath))
                {
                    XmlDocument statisticsXmlDocument = new XmlDocument();
                    statisticsXmlDocument.Load(m_StatisticsFilePath);
                    XmlNode statisticsXmlNode = statisticsXmlDocument.SelectSingleNode("statistics");
                    m_CumulativeDownloaded = long.Parse(statisticsXmlNode.SelectSingleNode("downloaded").InnerText);
                    m_CumulativeUploaded = long.Parse(statisticsXmlNode.SelectSingleNode("uploaded").InnerText);
                    m_CumulativeUptime = TimeSpan.Parse(statisticsXmlNode.SelectSingleNode("uptime").InnerText);
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading statistics file!");
            }

			// [MONO] the variable 'downloadsXmlNode' seems to be never used
			/*
            try
            {
                if (File.Exists(m_DownloadsFilePath))
                {
                    XmlDocument downloadsXmlDocument = new XmlDocument();
                    downloadsXmlDocument.Load(m_DownloadsFilePath);
                    XmlNode downloadsXmlNode = downloadsXmlDocument.SelectSingleNode("downloads");
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading downloads file!");
            }
            */

            Thread statisticsThread = new Thread(delegate()
            {
                RList<int> downloadStatistics = new RList<int>();
                int downloadStatisticsRestCount = 0;
                long downloadStatisticsRest = 0;
                long averageDownloadStatistics;
                RList<int> uploadStatistics = new RList<int>();
                int uploadStatisticsRestCount = 0;
                long uploadStatisticsRest = 0;
                long averageUploadStatistics;
                while (!m_IsClosing)
                {
                    m_Downstream = m_CurrentDownstream;
                    m_CurrentDownstream = 0;
                    m_Upstream = m_CurrentUpstream;
                    m_CurrentUpstream = 0;

                    int downstream = m_Downstream;
                    int upstream = m_Upstream;
                    m_Downloaded += downstream;
                    m_Uploaded += upstream;
                    m_CumulativeDownloaded += downstream;
                    m_CumulativeUploaded += upstream;
                    m_Uptime = m_Uptime.Add(TimeSpan.FromSeconds(1));
                    m_CumulativeUptime = m_CumulativeUptime.Add(TimeSpan.FromSeconds(1));

                    if (downloadStatistics.Count == 300)
                    {
                        downloadStatisticsRestCount++;
                        downloadStatisticsRest += downloadStatistics[downloadStatistics.Count - 1];
                        downloadStatistics.RemoveAt(downloadStatistics.Count - 1);
                    }
                    downloadStatistics.Insert(0, downstream);
                    if (m_MinuteAverageDownloadStatistics.Count != 0)
                    {
                        averageDownloadStatistics = 0;
                        for (int n = 0; n < Math.Min(60, downloadStatistics.Count); n++)
                            averageDownloadStatistics += downloadStatistics[n];
                        if (m_MinuteAverageDownloadStatistics.Count == 300)
                            m_MinuteAverageDownloadStatistics.RemoveAt(m_MinuteAverageDownloadStatistics.Count - 1);
                        m_MinuteAverageDownloadStatistics.Insert(0, (int)(averageDownloadStatistics / Math.Min(60, m_MinuteAverageDownloadStatistics.Count)));
                    }
                    else
                        m_MinuteAverageDownloadStatistics.Insert(0, 0);
                    averageDownloadStatistics = 0;
                    foreach (int item in downloadStatistics)
                        averageDownloadStatistics += item;
                    if (m_AverageDownloadStatistics.Count == 300)
                        m_AverageDownloadStatistics.RemoveAt(m_AverageDownloadStatistics.Count - 1);
                    m_AverageDownloadStatistics.Insert(0, (int)((averageDownloadStatistics + downloadStatisticsRest) / (downloadStatistics.Count + downloadStatisticsRestCount)));

                    if (uploadStatistics.Count == 300)
                    {
                        uploadStatisticsRestCount++;
                        uploadStatisticsRest += uploadStatistics[uploadStatistics.Count - 1];
                        uploadStatistics.RemoveAt(uploadStatistics.Count - 1);
                    }
                    uploadStatistics.Insert(0, upstream);
                    if (m_MinuteAverageUploadStatistics.Count != 0)
                    {
                        averageUploadStatistics = 0;
                        for (int n = 0; n < Math.Min(60, uploadStatistics.Count); n++)
                            averageUploadStatistics += uploadStatistics[n];
                        if (m_MinuteAverageUploadStatistics.Count == 300)
                            m_MinuteAverageUploadStatistics.RemoveAt(m_MinuteAverageUploadStatistics.Count - 1);
                        m_MinuteAverageUploadStatistics.Insert(0, (int)(averageUploadStatistics / Math.Min(60, m_MinuteAverageUploadStatistics.Count)));
                    }
                    else
                        m_MinuteAverageUploadStatistics.Insert(0, 0);
                    averageUploadStatistics = 0;
                    foreach (int item in uploadStatistics)
                        averageUploadStatistics += item;
                    if (m_AverageUploadStatistics.Count == 300)
                        m_AverageUploadStatistics.RemoveAt(m_AverageUploadStatistics.Count - 1);
                    m_AverageUploadStatistics.Insert(0, (int)((averageUploadStatistics + uploadStatisticsRest) / (uploadStatistics.Count + uploadStatisticsRestCount)));

                    if (m_ConnectionsStatistics.Count == 300)
                        m_ConnectionsStatistics.RemoveAt(m_ConnectionsStatistics.Count - 1);
                    m_ConnectionsStatistics.Insert(0, m_Connections.Count);

                    Thread.Sleep(1000);
                }
            });
            statisticsThread.Name = "statisticsThread";
            statisticsThread.IsBackground = true;
            statisticsThread.Start();

            Thread lastCommandIDThread = new Thread(delegate()
            {
                while (!m_IsClosing)
                {
                    try
                    {
                        m_LastCommandID.Lock();
                        for (int n = m_LastCommandID.Count - 1; n >= 0; n--)
                            if (DateTime.Now.Subtract(m_LastCommandID[n].Value).TotalSeconds >= Constants.LastCommandIDTimeout)
                                m_LastCommandID.RemoveAt(n);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        m_LastCommandID.Unlock();
                    }
                    Thread.Sleep(1000);
                }
            });
            lastCommandIDThread.Name = "lastCommandIDThread";
            lastCommandIDThread.IsBackground = true;
            lastCommandIDThread.Start();

            Thread connectionsThread = new Thread(delegate()
            {
                while (!m_IsClosing)
                {
                    try
                    {
                        m_Connections.Lock();
                        Connection connection;

                        /* Sum up the total bandwidth used during the last second and
                         * calculate an adjustment, so that the predicted bandwidth for this second
                         * will not exceeded the allowed bandwidth limit.
                         */
                        int uploadAdjustment = 0;
                        int downloadAdjustment = 0;

                        if ((bool.Parse(Settings.Instance["HasUploadLimit"]) ||
                            bool.Parse(Settings.Instance["HasDownloadLimit"])) &&
                            Core.Connections.Count != 0)
                        {
                            int totalUp = 0;
                            int totalDown = 0;
                            for (int n = m_Connections.Count - 1; n >= 0; n--)
                            {
                                connection = m_Connections[n].Value;
                                totalUp += connection.UploadLimitUsed;
                                totalDown += connection.DownloadLimitUsed;
                            }
                            uploadAdjustment = (int)((float)(int.Parse(Settings.Instance["UploadLimit"]) - totalUp) / Core.Connections.Count);
                            downloadAdjustment = (int)((float)(int.Parse(Settings.Instance["DownloadLimit"]) - totalDown) / Core.Connections.Count);
                        }

                        for (int n = m_Connections.Count - 1; n >= 0; n--)
                        {
                            connection = m_Connections[n].Value;
                            if (connection.IsDisconnected)
                                m_Connections.RemoveAt(n);
                            else
                            {
                                connection.UploadAdjustment = uploadAdjustment;
                                connection.DownloadAdjustment = downloadAdjustment;
                                connection.Process();
                            }
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        m_Connections.Unlock();
                    }
                    Thread.Sleep(1000);
                }
            });
            connectionsThread.Name = "connectionsThread";
            connectionsThread.IsBackground = true;
            connectionsThread.Start();

            Thread peersThread = new Thread(delegate()
            {
                while (!m_IsClosing)
                {
                    try
                    {
                        m_Peers.Lock();
                        Peer peer;
                        for (int n = m_Peers.Count - 1; n >= 0; n--)
                        {
                            peer = m_Peers[n].Value;
                            if (DateTime.Now.Subtract(peer.LastReceived).TotalSeconds >= Constants.PeerTimeout)
                                m_Peers.RemoveAt(n);
                            else
                                peer.Process();
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        m_Peers.Unlock();
                    }
                    Thread.Sleep(1000);
                }
            });
            peersThread.Name = "peersThread";
            peersThread.IsBackground = true;
            peersThread.Start();

            Thread searchesThread = new Thread(delegate()
            {
                while (!m_IsClosing)
                {
                    try
                    {
                        foreach (Search search in m_Searches.Values)
                            search.Process();
                    }
                    catch
                    {
                    }
                    Thread.Sleep(1000);
                }
            });
            searchesThread.Name = "searchesThread";
            searchesThread.IsBackground = true;
            searchesThread.Start();

            // 06.07.2009 Auto-Move re-implemented (Lars)
            Thread downloadsThread = new Thread(delegate()
            {
                int moveIntervall = 60;
                bool moveDownloads = false;
                try
                {
                    moveIntervall = Int32.Parse(Settings.Instance["AutoMoveDownloadsIntervall"]);
                    if (moveIntervall < 60)
                        moveIntervall = 60;
                    moveDownloads = bool.Parse(Settings.Instance["AutoMoveDownloads"]);
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown while initializing Auto-Move!");
                }
                while (!m_IsClosing)
                {
                    try
                    {
                        m_DownloadsAndQueue.Lock();
                        Download download;
                        for (int n = Math.Min(m_DownloadsAndQueue.Count, Constants.MaximumDownloadsCount) - 1; n >= 0; n--)
                        {
                            download = m_DownloadsAndQueue[n].Value;
                            if (moveDownloads)
                            {
                                // Wir verschieben Downloads
                                if ((download.LastReception == null || !download.LastReception.HasValue || DateTime.Now.Subtract(download.LastReception.Value).TotalMinutes >= moveIntervall) &&
                                    (download.QueueStart != null && download.QueueStart.HasValue && DateTime.Now.Subtract(download.QueueStart.Value).TotalMinutes >= moveIntervall))
                                {
                                    // Unser Download hat länger als moveIntervall nichts empfangen und
                                    // ist bereits länger als moveIntervall gestartet
                                    bool flag = false;
                                    foreach (Download.Source source in download.Sources.Values)
                                        if (source.State == Download.SourceState.Active || source.State == Download.SourceState.Requested)
                                        {
                                            flag = true;
                                            break;
                                        }
                                    if (!flag && m_DownloadsAndQueue.Count > Constants.MaximumDownloadsCount)
                                    {
                                        // Der Download wird in die Queue verschoben
                                        MoveDownloadToQueue(download.DownloadIDString);
                                        m_Logger.Log("Auto-Move: The download of \"{0}\" has been moved to the queue!", download.FileName);
                                    }
                                    else
                                    {
                                        // Der Download hat geeignete Quellen und wird daher nicht verschoben
                                        download.Process();
                                    }
                                }
                                else
                                {
                                    // Unser Download empfängt oder das moveIntervall wurde noch nicht erreicht
                                    download.Process();
                                }
                            }
                            else
                            {
                                // Wir verschieben keine Downloads
                                download.Process();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Log(ex, "An exception was thrown while processing downloads!");
                    }
                    finally
                    {
                        m_DownloadsAndQueue.Unlock();
                    }
                    Thread.Sleep(1000);
                }
            });
            downloadsThread.Name = "downloadsThread";
            downloadsThread.IsBackground = true;
            downloadsThread.Start();

            Thread uploadsThread = new Thread(delegate()
            {
                while (!m_IsClosing)
                {
                    try
                    {
                        m_Uploads.Lock();
                        Upload upload;
                        for (int n = m_Uploads.Count - 1; n >= 0; n--)
                        {
                            upload = m_Uploads[n].Value;
                            if (DateTime.Now.Subtract(upload.LastRequest).TotalSeconds >= Constants.UploadTimeout)
                                m_Uploads.RemoveAt(n);
                            upload.Process();
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        m_Uploads.Unlock();
                    }
                    Thread.Sleep(1000);
                }
            });
            uploadsThread.Name = "uploadsThread";
            uploadsThread.IsBackground = true;
            uploadsThread.Start();

            Thread listeningThread = new Thread(delegate()
            {
                try
                {
                    Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    listeningSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(Settings.Instance["Port"])));
                    listeningSocket.Listen(5);
                    while (!m_IsClosing)
                    {
                        try
                        {
                            Connection connection = new Connection(listeningSocket.Accept());
                            m_IsAccessible = true;
                            //2008-09-17 : Nochbaer
                            int avgConCount = int.Parse(Settings.Instance["AverageConnectionsCount"]);
                            if (avgConCount > 10) avgConCount = 10;
                            if (m_Connections.Count < (int)((float)avgConCount * 1.25F) && !m_Connections.ContainsKey(connection.RemoteEndPoint.Address))
                            {
                                m_Connections.Add(connection.RemoteEndPoint.Address, connection);
                                (new Command10(m_Keys)).Send(connection);
                            }
                            else
                                connection.Disconnect();
                        }
                        catch
                        {
                        }
                    }
                    try
                    {
                        listeningSocket.Shutdown(SocketShutdown.Both);
                    }
                    catch
                    {
                    }
                    try
                    {
                        listeningSocket.Close();
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown while binding socket at port {0}!", Settings.Instance["Port"]);
                }
            });
            listeningThread.Name = "listeningThread";
            listeningThread.IsBackground = true;
            listeningThread.Start();

            if (!m_WebCaches.IsEmpty)
            {
                try
                {
                    WebCacheProvider webCacheProvider = new WebCacheProvider(m_WebCaches);
                    try
                    {
                        webCacheProvider.RemovePeer();
                    }
                    catch
                    {
                    }
                    Thread webCacheAddOrRemovePeerThread = new Thread(delegate()
                    {
                        while (!m_IsClosing)
                        {
                            try
                            {
                                //2009-06-02 : Lars
                                int avgConCount = int.Parse(Settings.Instance["AverageConnectionsCount"]);
                                if (avgConCount > 10) avgConCount = 10;
                                if (m_Connections.Count < avgConCount)
                                    webCacheProvider.AddPeer(int.Parse(Settings.Instance["Port"]));
                            }
                            catch
                            {
                            }
                            for (int n = 0; !m_IsClosing && n < 120; n++)
                                Thread.Sleep(500);
                        }
                        try
                        {
                            webCacheProvider.RemovePeer();
                        }
                        catch
                        {
                        }
                    });
                    webCacheAddOrRemovePeerThread.Name = "webCacheAddOrRemovePeerThread";
                    webCacheAddOrRemovePeerThread.Start();
                    Thread webCacheGetPeerThread = new Thread(delegate()
                    {
                        while (!m_IsClosing)
                        {
                            try
                            {
                                //2008-09-17 : Nochbaer
                                int avgConCount = int.Parse(Settings.Instance["AverageConnectionsCount"]);
                                if (avgConCount > 10) avgConCount = 10;
                                while (m_Connections.Count < avgConCount && !m_IsClosing)
                                {
                                    string node = webCacheProvider.GetPeer();
                                    if (node == string.Empty)
                                        break;
                                    string[] endPoint = node.Split(':');
                                    AddConnection(new IPEndPoint(IPAddress.Parse(endPoint[0]), Convert.ToInt32(endPoint[1])));
                                    if (m_Connections.Count < avgConCount - 1)
                                        Thread.Sleep(15000);
                                    else
                                        break;
                                }
                            }
                            catch
                            {
                            }
                            Thread.Sleep(60000);
                        }
                    });
                    webCacheGetPeerThread.Name = "webCacheGetPeerThread";
                    webCacheGetPeerThread.IsBackground = true;
                    webCacheGetPeerThread.Start();
                }
                catch (Exception ex)
                {
                    m_Logger.Log("The WebCache's client could not be initialized properly!", ex);
                }
            }

            Thread OnlineSignatureThread = new Thread(delegate()
            {
                SetUILanguage();
                while (bool.Parse(Settings.Instance["ActivateOnlineSignature"]))
                {
                    try
                    {
                        XmlWriterSettings onlineSignatureXmlWriterSettings = new XmlWriterSettings();
                        onlineSignatureXmlWriterSettings.CloseOutput = true;
                        onlineSignatureXmlWriterSettings.Indent = true;
                        MemoryStream memoryStream = new MemoryStream();
                        XmlWriter onlineSignatureXmlWriter = XmlWriter.Create(memoryStream, onlineSignatureXmlWriterSettings);
                        onlineSignatureXmlWriter.WriteStartDocument();
                        onlineSignatureXmlWriter.WriteStartElement("onlinesignature");
                        onlineSignatureXmlWriter.WriteStartElement("software");
                        onlineSignatureXmlWriter.WriteValue(String.Format(Constants.Software, Core.Version));
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("connections");
                        onlineSignatureXmlWriter.WriteValue(m_Connections.Count);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("downloads");
                        onlineSignatureXmlWriter.WriteValue(m_DownloadsAndQueue.Count);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("downloadqueue");
                        onlineSignatureXmlWriter.WriteValue("0");
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("activeuploads");
                        onlineSignatureXmlWriter.WriteValue(m_Uploads.Count > Constants.MaximumUploadsCount ? Constants.MaximumUploadsCount : m_Uploads.Count);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("uploads");
                        onlineSignatureXmlWriter.WriteValue(m_Uploads.Count);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("sharedfiles");
                        onlineSignatureXmlWriter.WriteValue(m_ShareManager.SharedFiles.Count);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("downloadcapacity");
                        onlineSignatureXmlWriter.WriteValue(Settings.Instance["DownloadCapacity"]);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("uploadcapacity");
                        onlineSignatureXmlWriter.WriteValue(Settings.Instance["UploadCapacity"]);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("downloadlimit");
                        onlineSignatureXmlWriter.WriteValue(bool.Parse(Settings.Instance["HasDownloadLimit"]) ? Settings.Instance["DownloadLimit"] : "0");
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("uploadlimit");
                        onlineSignatureXmlWriter.WriteValue(bool.Parse(Settings.Instance["HasUploadLimit"]) ? Settings.Instance["UploadLimit"] : "0");
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("language");
                        onlineSignatureXmlWriter.WriteValue(Settings.Instance["UICulture"]);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("cumulativedownloaded");
                        onlineSignatureXmlWriter.WriteValue(m_CumulativeDownloaded);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("cumulativeuploaded");
                        onlineSignatureXmlWriter.WriteValue(m_CumulativeUploaded);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("downloaded");
                        onlineSignatureXmlWriter.WriteValue(m_Downloaded);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("uploaded");
                        onlineSignatureXmlWriter.WriteValue(m_Uploaded);
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("downstream");
                        onlineSignatureXmlWriter.WriteValue(m_MinuteAverageDownloadStatistics[0].ToString());
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("upstream");
                        onlineSignatureXmlWriter.WriteValue(m_MinuteAverageUploadStatistics[0].ToString());
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("cumulativeuptime");
                        onlineSignatureXmlWriter.WriteValue(m_CumulativeUptime.ToString());
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteStartElement("uptime");
                        onlineSignatureXmlWriter.WriteValue(m_Uptime.ToString());
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.WriteEndElement();
                        onlineSignatureXmlWriter.Flush();
                        FileStream fileStream = new FileStream(Path.Combine(Settings.Instance["PreferencesDirectory"], "onlinesignature.xml"), FileMode.Create, FileAccess.Write, FileShare.Read);
                        byte[] buffer = memoryStream.ToArray();
                        fileStream.Write(buffer, 0, buffer.Length);
                        onlineSignatureXmlWriter.Close();
                        fileStream.Flush();
                        fileStream.Close();
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Log(ex, Properties.Resources_Core.Exception_OnlineSignature);
                    }
                    Thread.Sleep(int.Parse(Settings.Instance["OnlineSignatureUpdateIntervall"]) * 60 * 1000);
                }
            });
            OnlineSignatureThread.Name = "onlineSignatureThread";
            OnlineSignatureThread.IsBackground = true;
            OnlineSignatureThread.Start();

            //2008-05-22-Eroli: Writing downloads.xml every 5 minutes to prevent loosing the sectorsMap if StealthNet crashes
            //2009-02-16 Nochbaer: Also statistics.xml
            Thread backupThread = new Thread(delegate()
            {
                DateTime lastDownloads = DateTime.MinValue;
                DateTime lastStatistics = DateTime.MinValue;
                while (!m_IsClosing)
                {
                    if (DownloadsXmlWriter.IsReady && DateTime.Now.Subtract(lastDownloads).TotalMinutes >= 5)
                    {
                        DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);
                        lastDownloads = DateTime.Now;
                    }
                    if (DateTime.Now.Subtract(lastStatistics).TotalMinutes >= 5)
                    {
                        try
                        {
                            StatisticsXmlWriter.write(m_StatisticsFilePath, m_CumulativeDownloaded.ToString(), m_CumulativeUploaded.ToString(), m_CumulativeUptime.ToString());
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while writing statistics.xml!");
                        }
                        if (m_ShareManager.IsReady)
                        {
                            try
                            {
                                m_ShareManager.SaveConfiguration(m_SharedDirectoriesFilePath, m_SharedFilesFilePath, m_SharedFilesStatsFilePath, m_MetaDataFilePath, m_CommentsFilePath, m_RatingsFilePath);
                            }
                            catch (Exception ex)
                            {
                                m_Logger.Log(ex, "An exception was thrown while writing shared files index!");
                            }
                        }
                        lastStatistics = DateTime.Now;
                    }
                    Thread.Sleep(60000);
                }
            });
            backupThread.Name = "backupThread";
            backupThread.IsBackground = true;
            backupThread.Start();

            Thread collectingThread = new Thread(delegate()
            {
                while (!m_IsClosing)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Thread.Sleep(60000);
                }
            });
            collectingThread.Name = "collectingThread";
            collectingThread.IsBackground = true;
            collectingThread.Start();

            m_Logger.Log(Properties.Resources_Core.StealthNetLoaded, String.Format(Constants.Software, Core.Version));
        }

        public static void MoveDownloadToQueue(params string[] downloadids)
        {
            if (downloadids == null)
                throw new ArgumentNullException("downloadids");

            try
            {
                m_DownloadsAndQueue.Lock();
                // Um Fehlbedienungen zu verhindern, bei keiner Warteschlange nicht ermöglichen!
                if (m_DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    return;
                foreach (string downloadid in downloadids)
                {
                    Download download;
                    if (m_DownloadsAndQueue.TryGetValue(downloadid, out download))
                    {
                        m_DownloadsAndQueue.Remove(download);
                        download.SetTime(null);
                        download.RemoveSources();
                        m_DownloadsAndQueue.Add(download);
                    }
                }
            }
            finally
            {
                m_DownloadsAndQueue.Unlock();
            }
            DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);
        }

        public static void MoveToBottomOfQueue(params string[] downloadids)
        {
            if (downloadids == null)
                throw new ArgumentNullException("downloadids");

            try
            {
                m_DownloadsAndQueue.Lock();
                // Um Fehlbedienungen zu verhindern, bei keiner Warteschlange nicht ermöglichen!
                if (m_DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    return;
                foreach (string downloadid in downloadids)
                {
                    Download download;
                    if (m_DownloadsAndQueue.TryGetValue(downloadid, out download))
                    {
                        m_DownloadsAndQueue.Remove(download);
                        download.SetTime(null);
                        download.RemoveSources();
                        m_DownloadsAndQueue.Add(download);
                    }
                }
            }
            finally
            {
                m_DownloadsAndQueue.Unlock();
            }
            DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);
        }

        public static void MoveToTopOfQueue(params string[] downloadids)
        {
            if (downloadids == null)
                throw new ArgumentNullException("downloadids");

            try
            {
                m_DownloadsAndQueue.Lock();
                // Um Fehlbedienungen zu verhindern, bei keiner Warteschlange nicht ermöglichen!
                if (m_DownloadsAndQueue.Count <= Constants.MaximumDownloadsCount)
                    return;
                foreach (string downloadid in downloadids)
                {
                    Download download;
                    if (m_DownloadsAndQueue.TryGetValue(downloadid, out download))
                    {
                        m_DownloadsAndQueue.Remove(download);
                        download.SetTime(null);
                        download.RemoveSources();
                        m_DownloadsAndQueue.Insert(Constants.MaximumDownloadsCount, download);
                    }
                }
            }
            finally
            {
                m_DownloadsAndQueue.Unlock();
            }
            DownloadsXmlWriter.Write(m_DownloadsFilePath, m_DownloadsAndQueue);
        }

        public static void ParseMetaData(RIndexedHashtable<string, string> metaData, out string album, out string artist, out string title)
        {
            if (metaData == null)
                throw new ArgumentNullException("metaData");

            if (!metaData.TryGetValue("TALB", out album))
                if (!metaData.TryGetValue("Album", out album))
                    album = string.Empty;
            if (!metaData.TryGetValue("TPE1", out artist))
                if (!metaData.TryGetValue("Artist", out artist))
                    if (!metaData.TryGetValue("CompanyName", out artist))
                        artist = string.Empty;
            if (!metaData.TryGetValue("TIT2", out title))
                if (!metaData.TryGetValue("Title", out title))
                    if (!metaData.TryGetValue("ProductName", out title))
                        title = string.Empty;
        }

        public static void ParseStealthNetCollection(string filepath)
        {
            try
            {
                String subfolder = "";
                if (bool.Parse(Settings.Instance["SubFoldersForCollections"]))
                {
                    subfolder = Path.GetFileNameWithoutExtension(filepath);
                }
                String line = "";
                if (File.Exists(filepath))
                {
                    System.IO.StreamReader sr = new StreamReader(filepath);
                    while ((line = sr.ReadLine()) != null)
                    {
                        StealthNetLink link = new StealthNetLink(line);
                        Core.AddDownload(link.FileHash, link.FileName, link.FileSize, subfolder);
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while parsing {0}!", filepath);
            }
        }

        public static void ProcessCommand(Connection connection, byte[] buffer)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            try
            {
                Command command = CommandBuilder.Receive(connection, buffer);
                if (command is Command10)
                {
                    Command10 command10 = (Command10)command;
                    connection.PublicKey = command10.Keys;
                    if (connection.PublicKey.Modulus.Length == m_Keys.Modulus.Length && CompareByteArray(connection.PublicKey.Modulus, m_Keys.Modulus) && connection.PublicKey.Exponent.Length == m_Keys.Exponent.Length && CompareByteArray(connection.PublicKey.Exponent, m_Keys.Exponent))
                        connection.Disconnect();
                    else
                        (new Command11(m_Keys)).Send(connection);
                }
                else if (command is Command11)
                {
                    Command11 command11 = (Command11)command;
                    connection.PublicKey = command11.Keys;
                    connection.SendingKey = RijndaelGenerateKeys();
                    (new Command12(connection.SendingKey)).Send(connection);
                }
                else if (command is Command12)
                {
                    Command12 command12 = (Command12)command;
                    connection.ReceivingKey = command12.Keys;
                    connection.SendingKey = RijndaelGenerateKeys();
                    (new Command13(connection.SendingKey)).Send(connection);
                    connection.IsEstablished = true;
                }
                else if (command is Command13)
                {
                    Command13 command13 = (Command13)command;
                    connection.ReceivingKey = command13.Keys;
                    connection.IsEstablished = true;
                }
                else if (command is Command20)
                {
                    Command20 command20 = (Command20)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (command20.FloodingHash[47] > 51)
                        {
                            byte[] floodingHash = ComputeHashes.SHA384Compute(command20.FloodingHash);
                            if (floodingHash[47] <= 51)
                                SendBroadcast(new Command21(command20.CommandID, 0, 0, command20.SenderPeerID, command20.SearchID, command20.SearchPattern), connection.RemoteEndPoint.Address);
                            else
                                SendBroadcast(new Command20(command20.CommandID, floodingHash, command20.SenderPeerID, command20.SearchID, command20.SearchPattern), connection.RemoteEndPoint.Address);
                            SendSearchResults(command20.SenderPeerID, command20.SearchID, command20.SearchPattern);
                        }
                    }
                }
                else if (command is Command21)
                {
                    Command21 command21 = (Command21)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (command21.HopCount < Constants.MaximumHopCount)
                        {
                            SendBroadcast(new Command21(command21.CommandID, 0, (ushort)(command21.HopCount + 1), command21.SenderPeerID, command21.SearchID, command21.SearchPattern), connection.RemoteEndPoint.Address);
                            SendSearchResults(command21.SenderPeerID, command21.SearchID, command21.SearchPattern);
                        }
                        else if (m_DropChainTailCount > 0)
                        {
                            SendBroadcast(new Command22(command21.CommandID, command21.SenderPeerID, command21.SearchID, command21.SearchPattern), connection.RemoteEndPoint.Address, m_DropChainTailCount);
                            SendSearchResults(command21.SenderPeerID, command21.SearchID, command21.SearchPattern);
                        }
                    }
                }
                else if (command is Command22)
                {
                    Command22 command22 = (Command22)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (m_DropChainTailCount > 0)
                        {
                            SendBroadcast(command22, connection.RemoteEndPoint.Address, m_DropChainTailCount);
                            SendSearchResults(command22.SenderPeerID, command22.SearchID, command22.SearchPattern);
                        }
                    }
                }
                else if (command is Command23)
                {
                    Command23 command23 = (Command23)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (m_SearchDBManager != null && bool.Parse(Settings.Instance["ActivateSearchDB"]))
                            m_SearchDBManager.AddResult(command23.SearchResults);
                        foreach (Command23.SearchResult searchResult in command23.SearchResults)
                        {
                            string fileHashString = ByteArrayToString(searchResult.FileHash);
                            try
                            {
                                m_DownloadsAndQueue.Lock();
                                int index = m_DownloadsAndQueue.IndexOfKey(fileHashString, DownloadCollection.KeyAccess.FileHash);
                                if (index > -1)
                                {
                                    Download download = m_DownloadsAndQueue[index].Value;
                                    if (index < Constants.MaximumDownloadsCount)
                                        download.AddSource(command23.SenderPeerID, searchResult.FileSize, searchResult.FileName, searchResult.MetaData, searchResult.Comment, searchResult.Rating, null);
                                    else
                                        download.SetLastSeen(DateTime.Now);
                                }
                            }
                            finally
                            {

                                m_DownloadsAndQueue.Unlock();
                            }
                        }
                        bool found = false;
                        foreach (Search search in m_Searches.Values)
                            if (CompareByteArray(command23.ReceiverPeerID, search.SearchPeerID))
                            {
                                if (CompareByteArray(search.SearchID, command23.SearchID))
                                    foreach (Command23.SearchResult searchResult in command23.SearchResults)
                                        search.AddResult(searchResult.FileHash, searchResult.FileSize, command23.SenderPeerID, searchResult.FileName, searchResult.MetaData, searchResult.Comment, searchResult.Rating);
                                found = true;
                                break;
                            }
                        if (!found)
                            Send(command23, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command40)
                {
                    Command40 command40 = (Command40)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command40, connection.RemoteEndPoint.Address);
                }
                else if (command is Command41)
                {
                    Command41 command41 = (Command41)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command41, connection.RemoteEndPoint.Address);
                }
                else if (command is Command42)
                {
                    Command42 command42 = (Command42)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command42, connection.RemoteEndPoint.Address);
                }
                else if (command is Command43)
                {
                    Command43 command43 = (Command43)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command43, connection.RemoteEndPoint.Address);
                }
                else if (command is Command44)
                {
                    Command44 command44 = (Command44)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command44, connection.RemoteEndPoint.Address);
                }
                else if (command is Command45)
                {
                    Command45 command45 = (Command45)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command45, connection.RemoteEndPoint.Address);
                }
                else if (command is Command46)
                {
                    Command46 command46 = (Command46)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                        Send(command46, connection.RemoteEndPoint.Address);
                }
                else if (command is Command50)
                {
                    Command50 command50 = (Command50)command;
                    if (CheckCommand(connection, (IRequestCommand)command) && command50.FloodingHash[47] > 51)
                    {
                        byte[] floodingHash = ComputeHashes.SHA384Compute(command50.FloodingHash);
                        if (floodingHash[47] <= 51)
                            SendBroadcast(new Command51(command50.CommandID, 0, 0, command50.SenderPeerID, command50.SourceSearchID, command50.HashedFileHash), connection.RemoteEndPoint.Address);
                        else
                            SendBroadcast(new Command50(command50.CommandID, floodingHash, command50.SenderPeerID, command50.SourceSearchID, command50.HashedFileHash), connection.RemoteEndPoint.Address);
                        string onceHashedFileHashString = ByteArrayToString(command50.HashedFileHash);
                        SharedFile sharedFile;
                        if (SharedFiles.TryGetValue(onceHashedFileHashString, SharedFileCollection.KeyAccess.OnceHashedFileHash, out sharedFile))
                        {
                            byte[] commandID = GenerateIDOrHash();
                            Send(new Command53(commandID, m_PeerID, command50.SenderPeerID, command50.SourceSearchID, (uint)sharedFile.FileSize, sharedFile.FileName, sharedFile.MetaData, sharedFile.Comment, sharedFile.Rating));
                            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                        }
                        Download download;
                        if (m_DownloadsAndQueue.TryGetValue(onceHashedFileHashString, DownloadCollection.KeyAccess.OnceHashedFileHash, out download))
                        {
                            byte[] commandID = GenerateIDOrHash();
                            Send(new Command54(commandID, download.SourceSearchResponsePeerID, command50.SenderPeerID, command50.SourceSearchID, (uint)download.FileSize, download.FileName, new RIndexedHashtable<String, String>(), String.Empty, 0, download.SectorsMap));
                            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                        }
                    }
                }
                else if (command is Command51)
                {
                    Command51 command51 = (Command51)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (command51.HopCount < Constants.MaximumHopCount)
                        {
                            SendBroadcast(new Command51(command51.CommandID, 0, (ushort)(command51.HopCount + 1), command51.SenderPeerID, command51.SourceSearchID, command51.HashedFileHash), connection.RemoteEndPoint.Address);
                            string onceHashedFileHashString = ByteArrayToString(command51.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(onceHashedFileHashString, SharedFileCollection.KeyAccess.OnceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command53(commandID, m_PeerID, command51.SenderPeerID, command51.SourceSearchID, (uint)sharedFile.FileSize, sharedFile.FileName, sharedFile.MetaData, sharedFile.Comment, sharedFile.Rating));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(onceHashedFileHashString, DownloadCollection.KeyAccess.OnceHashedFileHash, out download))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command54(commandID, download.SourceSearchResponsePeerID, command51.SenderPeerID, command51.SourceSearchID, (uint)download.FileSize, download.FileName, new RIndexedHashtable<String, String>(), String.Empty, 0, download.SectorsMap));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                        else if (m_DropChainTailCount > 0)
                        {
                            SendBroadcast(new Command52(command51.CommandID, command51.SenderPeerID, command51.SourceSearchID, command51.HashedFileHash), connection.RemoteEndPoint.Address, m_DropChainTailCount);
                            string onceHashedFileHashString = ByteArrayToString(command51.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(onceHashedFileHashString, SharedFileCollection.KeyAccess.OnceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command53(commandID, m_PeerID, command51.SenderPeerID, command51.SourceSearchID, (uint)sharedFile.FileSize, sharedFile.FileName, sharedFile.MetaData, sharedFile.Comment, sharedFile.Rating));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(onceHashedFileHashString, DownloadCollection.KeyAccess.OnceHashedFileHash, out download))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command54(commandID, download.SourceSearchResponsePeerID, command51.SenderPeerID, command51.SourceSearchID, (uint)download.FileSize, download.FileName, new RIndexedHashtable<String, String>(), String.Empty, 0, download.SectorsMap));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                    }
                }
                else if (command is Command52)
                {
                    Command52 command52 = (Command52)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (m_DropChainTailCount > 0)
                        {
                            SendBroadcast(command52, connection.RemoteEndPoint.Address, m_DropChainTailCount);
                            string onceHashedFileHashString = ByteArrayToString(command52.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(onceHashedFileHashString, SharedFileCollection.KeyAccess.OnceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command53(commandID, m_PeerID, command52.SenderPeerID, command52.SourceSearchID, (uint)sharedFile.FileSize, sharedFile.FileName, sharedFile.MetaData, sharedFile.Comment, sharedFile.Rating));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(onceHashedFileHashString, DownloadCollection.KeyAccess.OnceHashedFileHash, out download))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command54(commandID, download.SourceSearchResponsePeerID, command52.SenderPeerID, command52.SourceSearchID, (uint)download.FileSize, download.FileName, new RIndexedHashtable<String, String>(), String.Empty, 0, download.SectorsMap));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                    }
                }
                else if (command is Command53)
                {
                    Command53 command53 = (Command53)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                            if (CompareByteArray(command53.ReceiverPeerID, download.SourceSearchPeerID))
                            {
                                if (CompareByteArray(download.SourceSearchID, command53.SourceSearchID))
                                    download.AddSource(command53.SenderPeerID, command53.FileSize, command53.FileName, command53.MetaData, command53.Comment, command53.Rating, null);
                                found = true;
                                break;
                            }
                        if (!found)
                            Send(command53, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command54)
                {
                    Command54 command54 = (Command54)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                            if (CompareByteArray(command54.ReceiverPeerID, download.SourceSearchPeerID))
                            {
                                if (CompareByteArray(download.SourceSearchID, command54.SourceSearchID))
                                    download.AddSource(command54.SenderPeerID, command54.FileSize, command54.FileName, command54.MetaData, command54.Comment, command54.Rating, command54.SectorsMap);
                                found = true;
                                break;
                            }
                        if (!found)
                            Send(command54, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command60)
                {
                    Command60 command60 = (Command60)command;
                    if (CheckCommand(connection, (IRequestCommand)command) && command60.FloodingHash[47] > 51)
                    {
                        byte[] floodingHash = ComputeHashes.SHA384Compute(command60.FloodingHash);
                        if (floodingHash[47] <= 51)
                            SendBroadcast(new Command61(command60.CommandID, 0, 0, command60.SenderPeerID, command60.SourceSearchID, command60.HashedFileHash), connection.RemoteEndPoint.Address);
                        else
                            SendBroadcast(new Command60(command60.CommandID, floodingHash, command60.SenderPeerID, command60.SourceSearchID, command60.HashedFileHash), connection.RemoteEndPoint.Address);
                        string twiceHashedFileHashString = ByteArrayToString(command60.HashedFileHash);
                        SharedFile sharedFile;
                        if (SharedFiles.TryGetValue(twiceHashedFileHashString, SharedFileCollection.KeyAccess.TwiceHashedFileHash, out sharedFile))
                        {
                            byte[] commandID = GenerateIDOrHash();
                            Send(new Command63(commandID, m_PeerID, command60.SenderPeerID, command60.SourceSearchID));
                            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                        }
                        Download download;
                        if (m_DownloadsAndQueue.TryGetValue(twiceHashedFileHashString, DownloadCollection.KeyAccess.TwiceHashedFileHash, out download))
                        {
                            byte[] commandID = GenerateIDOrHash();
                            Send(new Command64(commandID, download.SourceSearchResponsePeerID, command60.SenderPeerID, command60.SourceSearchID, download.SectorsMap));
                            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                        }
                    }
                }
                else if (command is Command61)
                {
                    Command61 command61 = (Command61)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (command61.HopCount < Constants.MaximumHopCount)
                        {
                            SendBroadcast(new Command61(command61.CommandID, 0, (ushort)(command61.HopCount + 1), command61.SenderPeerID, command61.SourceSearchID, command61.HashedFileHash), connection.RemoteEndPoint.Address);
                            string twiceHashedFileHashString = ByteArrayToString(command61.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(twiceHashedFileHashString, SharedFileCollection.KeyAccess.TwiceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command63(commandID, m_PeerID, command61.SenderPeerID, command61.SourceSearchID));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(twiceHashedFileHashString, DownloadCollection.KeyAccess.TwiceHashedFileHash, out download))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command64(commandID, download.SourceSearchResponsePeerID, command61.SenderPeerID, command61.SourceSearchID, download.SectorsMap));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                        else if (m_DropChainTailCount > 0)
                        {
                            SendBroadcast(new Command62(command61.CommandID, command61.SenderPeerID, command61.SourceSearchID, command61.HashedFileHash), connection.RemoteEndPoint.Address, m_DropChainTailCount);
                            string twiceHashedFileHashString = ByteArrayToString(command61.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(twiceHashedFileHashString, SharedFileCollection.KeyAccess.TwiceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command63(commandID, m_PeerID, command61.SenderPeerID, command61.SourceSearchID));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(twiceHashedFileHashString, DownloadCollection.KeyAccess.TwiceHashedFileHash, out download))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command64(commandID, download.SourceSearchResponsePeerID, command61.SenderPeerID, command61.SourceSearchID, download.SectorsMap));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                    }
                }
                else if (command is Command62)
                {
                    Command62 command62 = (Command62)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (m_DropChainTailCount > 0)
                        {
                            SendBroadcast(command62, connection.RemoteEndPoint.Address, m_DropChainTailCount);
                            string twiceHashedFileHashString = ByteArrayToString(command62.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(twiceHashedFileHashString, SharedFileCollection.KeyAccess.TwiceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command63(commandID, m_PeerID, command62.SenderPeerID, command62.SourceSearchID));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(twiceHashedFileHashString, DownloadCollection.KeyAccess.TwiceHashedFileHash, out download))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command64(commandID, download.SourceSearchResponsePeerID, command62.SenderPeerID, command62.SourceSearchID, download.SectorsMap));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                    }
                }
                else if (command is Command63)
                {
                    Command63 command63 = (Command63)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                            if (CompareByteArray(command63.ReceiverPeerID, download.SourceSearchPeerID))
                            {
                                if (CompareByteArray(download.SourceSearchID, command63.SourceSearchID))
                                    download.AddSource(command63.SenderPeerID, null);
                                found = true;
                                break;
                            }
                        if (!found)
                            Send(command63, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command64)
                {
                    Command64 command64 = (Command64)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                            if (CompareByteArray(command64.ReceiverPeerID, download.SourceSearchPeerID))
                            {
                                if (CompareByteArray(download.SourceSearchID, command64.SourceSearchID))
                                    download.AddSource(command64.SenderPeerID, command64.SectorsMap);
                                found = true;
                                break;
                            }
                        if (!found)
                            Send(command64, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command70)
                {
                    Command70 command70 = (Command70)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (CompareByteArray(command70.ReceiverPeerID, m_PeerID))
                        {
                            string thriceHashedFileHashString = ByteArrayToString(command70.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(thriceHashedFileHashString, SharedFileCollection.KeyAccess.ThriceHashedFileHash, out sharedFile))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command71(commandID, m_PeerID, command70.SenderPeerID, command70.FeedbackID, (uint)m_Uploads.Count));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                            }
                        }
                        else
                        {
                            bool found = false;
                            string thriceHashedFileHashString = ByteArrayToString(command70.HashedFileHash);
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(thriceHashedFileHashString, DownloadCollection.KeyAccess.ThriceHashedFileHash, out download) &&
                                CompareByteArray(command70.ReceiverPeerID, download.SourceSearchResponsePeerID))
                            {
                                byte[] commandID = GenerateIDOrHash();
                                Send(new Command71(commandID, download.SourceSearchResponsePeerID, command70.SenderPeerID, command70.FeedbackID, (uint)m_Uploads.Count));
                                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                found = true;
                            }
                            if (!found)
                                Send(command70, connection.RemoteEndPoint.Address);
                        }
                    }
                }
                else if (command is Command71)
                {
                    Command71 command71 = (Command71)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                        {
                            if (!CompareByteArray(command71.ReceiverPeerID, download.DownloadPeerID))
                                continue;
                            if (CompareByteArray(command71.FeedbackID, download.DownloadID))
                            {
                                Download.Source source;
                                if (download.Sources.TryGetValue(ByteArrayToString(command71.SenderPeerID), out source))
                                    source.Report71Received((int)command71.QueueLength);
                            }
                            found = true;
                            break;
                        }
                        if (!found)
                            Send(command71, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command72)
                {
                    Command72 command72 = (Command72)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                        {
                            if (!CompareByteArray(command72.ReceiverPeerID, download.DownloadPeerID))
                                continue;
                            if (CompareByteArray(command72.FeedbackID, download.DownloadID))
                            {
                                Download.Source source;
                                if (download.Sources.TryGetValue(ByteArrayToString(command72.SenderPeerID), out source))
                                    source.Report72Received();
                            }
                            found = true;
                            break;
                        }
                        if (!found)
                            Send(command72, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command74)
                {
                    Command74 command74 = (Command74)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (CompareByteArray(command74.ReceiverPeerID, m_PeerID))
                        {
                            string thriceHashedFileHashString = ByteArrayToString(command74.HashedFileHash);
                            SharedFile sharedFile;
                            if (SharedFiles.TryGetValue(thriceHashedFileHashString, SharedFileCollection.KeyAccess.ThriceHashedFileHash, out sharedFile))
                            {
                                string uploadIDString = ByteArrayToString(command74.DownloadID);
                                Upload upload;
                                if (m_Uploads.TryGetValue(uploadIDString, out upload))
                                {
                                    if (CompareByteArray(command74.SenderPeerID, upload.PeerID))
                                    {
                                        upload.ReportRequest();
                                        int index = m_Uploads.IndexOfKey(uploadIDString) + 1;
                                        byte[] commandID = GenerateIDOrHash();
                                        Send(new Command75(commandID, m_PeerID, command74.SenderPeerID, command74.DownloadID, (uint)(index - Constants.MaximumUploadsCount < 0 ? 0 : index - Constants.MaximumUploadsCount)));
                                        m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                    }
                                }
                                else
                                {
                                    sharedFile.LastRequest = DateTime.Now;
                                    m_Uploads.Add(uploadIDString, new Upload(command74.SenderPeerID, command74.DownloadID, sharedFile.FileHash));
                                    int index = m_Uploads.Count + 1;
                                    byte[] commandID = GenerateIDOrHash();
                                    Send(new Command75(commandID, m_PeerID, command74.SenderPeerID, command74.DownloadID, (uint)(index - Constants.MaximumUploadsCount < 0 ? 0 : index - Constants.MaximumUploadsCount)));
                                    m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            bool found = false;
                            string thriceHashedFileHashString = ByteArrayToString(command74.HashedFileHash);
                            Download download;
                            if (m_DownloadsAndQueue.TryGetValue(thriceHashedFileHashString, DownloadCollection.KeyAccess.ThriceHashedFileHash, out download) &&
                                CompareByteArray(command74.ReceiverPeerID, download.SourceSearchResponsePeerID))
                            {
                                string uploadIDString = ByteArrayToString(command74.DownloadID);
                                Upload upload;
                                if (m_Uploads.TryGetValue(uploadIDString, out upload))
                                {
                                    if (CompareByteArray(command74.SenderPeerID, upload.PeerID))
                                    {
                                        upload.ReportRequest();
                                        int index = m_Uploads.IndexOfKey(uploadIDString) + 1;
                                        byte[] commandID = GenerateIDOrHash();
                                        Send(new Command75(commandID, download.SourceSearchResponsePeerID, command74.SenderPeerID, command74.DownloadID, (uint)(index - Constants.MaximumUploadsCount < 0 ? 0 : index - Constants.MaximumUploadsCount)));
                                        m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                    }
                                }
                                else
                                {
                                    m_Uploads.Add(uploadIDString, new Upload(command74.SenderPeerID, command74.DownloadID, download.FileHash, true, download.DownloadIDString));
                                    int index = m_Uploads.Count + 1;
                                    byte[] commandID = GenerateIDOrHash();
                                    Send(new Command75(commandID, download.SourceSearchResponsePeerID, command74.SenderPeerID, command74.DownloadID, (uint)(index - Constants.MaximumUploadsCount < 0 ? 0 : index - Constants.MaximumUploadsCount)));
                                    m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                }
                                found = true;
                            }
                            if (!found)
                                Send(command74, connection.RemoteEndPoint.Address);
                        }
                    }
                }
                else if (command is Command75)
                {
                    Command75 command75 = (Command75)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                        {
                            if (!CompareByteArray(command75.ReceiverPeerID, download.DownloadPeerID))
                                continue;
                            if (CompareByteArray(command75.DownloadID, download.DownloadID))
                            {
                                Download.Source source;
                                if (download.Sources.TryGetValue(ByteArrayToString(command75.SenderPeerID), out source))
                                    source.Report75Received((int)command75.QueuePosition);
                            }
                            found = true;
                            break;
                        }
                        if (!found)
                            Send(command75, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command76)
                {
                    Command76 command76 = (Command76)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                        {
                            if (!CompareByteArray(command76.ReceiverPeerID, download.DownloadPeerID))
                                continue;
                            if (CompareByteArray(command76.DownloadID, download.DownloadID))
                            {
                                Download.Source source;
                                if (download.Sources.TryGetValue(ByteArrayToString(command76.SenderPeerID), out source))
                                    source.Report76Received();
                            }
                            found = true;
                            break;
                        }
                        if (!found)
                            Send(command76, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command78)
                {
                    Command78 command78 = (Command78)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (CompareByteArray(command78.ReceiverPeerID, m_PeerID, 48))
                        {
                            Upload upload;
                            SharedFile sharedFile;
                            if (m_Uploads.TryGetValue(ByteArrayToString(command78.DownloadID), out upload) && CompareByteArray(command78.SenderPeerID, upload.PeerID) && SharedFiles.TryGetValue(upload.FileHashString, out sharedFile))
                            {
                                int index = m_Uploads.IndexOfKey(upload.FileHashString) + 1;
                                if (index <= Constants.MaximumUploadsCount && command78.Sector <= sharedFile.Sectors)
                                {
                                    byte[] sectorData;
                                    byte[] sectorHash;
                                    byte[] sectorHashCodeResult;
                                    if (sharedFile.GetSectorData(command78.Sector, out sectorData, out sectorHash, out sectorHashCodeResult))
                                    {
                                        upload.ReportRequest(command78.Sector);
                                        byte[] commandID = GenerateIDOrHash();
                                        Send(new Command79(commandID, m_PeerID, command78.SenderPeerID, command78.DownloadID, command78.Sector, sectorData, sectorHashCodeResult));
                                        m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                        upload.IsActive = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool found = false;
                            foreach (Download download in m_DownloadsAndQueue.Values)
                            {
                                if (!CompareByteArray(command78.ReceiverPeerID, download.SourceSearchResponsePeerID))
                                    continue;
                                Upload upload;
                                if (m_Uploads.TryGetValue(ByteArrayToString(command78.DownloadID), out upload) && CompareByteArray(command78.SenderPeerID, upload.PeerID) && CompareByteArray(upload.FileHash, download.FileHash))
                                {
                                    int index = m_Uploads.IndexOfKey(upload.FileHashString) + 1;
                                    if (index <= Constants.MaximumUploadsCount && command78.Sector <= download.Sectors)
                                    {
                                        byte[] sectorData;
                                        byte[] sectorHash;
                                        byte[] sectorHashCodeResult;
                                        if (download.GetSectorData(command78.Sector, out sectorData, out sectorHash, out sectorHashCodeResult))
                                        {
                                            upload.ReportRequest(command78.Sector);
                                            byte[] commandID = GenerateIDOrHash();
                                            Send(new Command79(commandID, download.SourceSearchResponsePeerID, command78.SenderPeerID, command78.DownloadID, command78.Sector, sectorData, sectorHashCodeResult));
                                            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
                                            upload.IsActive = true;
                                        }
                                    }
                                }
                                found = true;
                                break;
                            }
                            if (!found)
                                Send(command78, connection.RemoteEndPoint.Address);
                        }
                    }
                }
                else if (command is Command79)
                {
                    Command79 command79 = (Command79)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        bool found = false;
                        foreach (Download download in m_DownloadsAndQueue.Values)
                        {
                            if (!CompareByteArray(command79.ReceiverPeerID, download.DownloadPeerID, 48))
                                continue;
                            if (CompareByteArray(download.DownloadID, command79.DownloadID))
                            {
                                Download.Source source;
                                if (download.Sources.TryGetValue(ByteArrayToString(command79.SenderPeerID), out source))
                                    download.SetSectorData(command79.Sector, command79.SectorData, command79.SectorHashCodeResult, source);
                            }
                            found = true;
                            break;
                        }
                        if (!found)
                            Send(command79, connection.RemoteEndPoint.Address);
                    }
                }
                else if (command is Command7A)
                {
                    Command7A command7A = (Command7A)command;
                    if (CheckCommand(connection, (IRequestCommand)command))
                    {
                        if (CompareByteArray(command7A.ReceiverPeerID, m_PeerID, 48))
                        {
                            Upload upload;
                            if (m_Uploads.TryGetValue(ByteArrayToString(command7A.DownloadID), out upload) && CompareByteArray(command7A.SenderPeerID, upload.PeerID))
                            {
                                // Sicherer Hash-Vergleich ANFANG
                                byte[] hashCodeResult = new byte[64];
                                for (int n = 0; n < 64; n++)
                                    hashCodeResult[n] = (byte)~upload.FileHash[n];
                                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                if (!Core.CompareByteArray(command7A.FileHashCodeResult, hashCodeResult))
                                {
                                    m_Logger.Log("A manipulated request was received!");
                                    return;
                                }
                                // Sicherer Hash-Vergleich ENDE
                                m_Uploads.Remove(upload.UploadIDString);
                            }
                        }
                        else
                        {
                            bool found = false;
                            foreach (Download download in m_DownloadsAndQueue.Values)
                            {
                                if (!CompareByteArray(command7A.ReceiverPeerID, download.SourceSearchResponsePeerID))
                                    continue;
                                Upload upload;
                                if (m_Uploads.TryGetValue(ByteArrayToString(command7A.DownloadID), out upload) && CompareByteArray(command7A.SenderPeerID, upload.PeerID))
                                {
                                    // Sicherer Hash-Vergleich ANFANG
                                    byte[] hashCodeResult = new byte[64];
                                    for (int n = 0; n < 64; n++)
                                        hashCodeResult[n] = (byte)~upload.FileHash[n];
                                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                                    if (!Core.CompareByteArray(command7A.FileHashCodeResult, hashCodeResult))
                                    {
                                        m_Logger.Log("A manipulated request was received!");
                                        return;
                                    }
                                    // Sicherer Hash-Vergleich ENDE
                                    m_Uploads.Remove(upload.UploadIDString);
                                }
                                found = true;
                                break;
                            }
                            if (!found)
                                Send(command7A, connection.RemoteEndPoint.Address);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void RemoveDownload(byte[] downloadID)
        {
            if (downloadID == null)
                throw new ArgumentNullException("downloadID");
            if (downloadID.Length != 48)
                throw new ArgumentException();

            try
            {
                m_DownloadsAndQueue.Lock();
                Download download;
                if (m_DownloadsAndQueue.TryGetValue(ByteArrayToString(downloadID), out download))
                    m_DownloadsAndQueue.Remove(download);
            }
            finally
            {
                m_DownloadsAndQueue.Unlock();
            }
        }

        public static void RemoveSearch(byte[] searchID)
        {
            if (searchID == null)
                throw new ArgumentNullException("searchID");
            if (searchID.Length != 48)
                throw new ArgumentException();

            m_Searches.Remove(ByteArrayToString(searchID));
        }

        public static void ReportDownstream(int downstream)
        {
            m_CurrentDownstream += downstream;
        }

        public static void ReportUpstream(int upstream)
        {
            m_CurrentUpstream += upstream;
        }

        /// <summary>
        /// Neue ResumeDownloads()
        /// 10.06.2009 Lars
        /// 03.07.2009 Lars (Neue Downloadwarteschlange)
        /// 04.07.2009 Lars (Einfacheres und besseres Handling)
        /// </summary>
        private static void ResumeDownloads()
        {
            try
            {
                // Alle gesicherten Downloads einlesen
                RIndexedHashtable<string, XmlNode> downloadsXml = new RIndexedHashtable<string, XmlNode>();
                if (File.Exists(m_DownloadsFilePath))
                {
                    XmlDocument downloadsXmlDocument = new XmlDocument();
                    downloadsXmlDocument.Load(m_DownloadsFilePath);
                    foreach (XmlNode downloadNode in downloadsXmlDocument.SelectSingleNode("downloads"))
                        try
                        {
                            downloadsXml.Add(downloadNode.Attributes["hash"].InnerText, downloadNode);
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "A download cannot be resumed due to non existent information about it!");
                            continue;
                        }
                }
                // Alle vorhandenen Dateien durchgehen
                RList<Download> temporary = new RList<Download>(downloadsXml.Count);
                foreach (string filePath in Directory.GetFiles(Settings.Instance["TemporaryDirectory"]))
                {
                    string fileName = new FileInfo(filePath).Name;
                    try
                    {
                        if (!Regex.IsMatch(fileName, "^[0-9A-F]{128,128}$", RegexOptions.IgnoreCase))
                        {
                            m_Logger.Log("The file \"{0}\" is no valid temporary download!", fileName);
                        }
                        XmlNode node;
                        if (!downloadsXml.TryGetValue(fileName, out node))
                        {
                            m_Logger.Log("The download of \"{0}\" cannot be resumed due to non existent information about it!", fileName);
                            continue;
                        }
                        bool hasInformation = true;
                        if ((node as XmlElement).HasAttribute("hasinformation") && (node as XmlElement).GetAttribute("hasinformation") == "none")
                            hasInformation = false;
                        string lastSeenString = null;
                        DateTime? lastSeen = null;
                        string lastReceptionString = null;
                        DateTime? lastReception = null;
                        String subfolder = string.Empty;
                        if (node.SelectSingleNode("lastseen") != null)
                        {
                            lastSeenString = node.SelectSingleNode("lastseen").InnerText;
                            if (lastSeenString != null && lastSeenString.Length > 0)
                                lastSeen = DateTime.Parse(lastSeenString);
                        }
                        if (node.SelectSingleNode("lastreception") != null)
                        {
                            lastReceptionString = node.SelectSingleNode("lastreception").InnerText;
                            if (lastReceptionString != null && lastReceptionString.Length > 0)
                                lastReception = DateTime.Parse(lastReceptionString);
                        }
                        if (node.SelectSingleNode("subfolder") != null)
                            subfolder = node.SelectSingleNode("subfolder").InnerText;
                        Download download = new Download(Core.FileHashStringToFileHash(fileName), node.SelectSingleNode("filename").InnerText, long.Parse(node.SelectSingleNode("filesize").InnerText), hasInformation, lastSeen, lastReception, hasInformation ? Convert.FromBase64String(node.SelectSingleNode("sectorsmap").InnerText) : null);
                        download.SetSubFolderAndTime(subfolder, null);
                        temporary.Add(download);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Log(ex, "An exception was thrown while resuming the download of \"{0}\"!", fileName);
                    }
                }
                // Wiederaufzunehmende Download sortieren
                for (int n = 1; n <= temporary.Count - 1; n++)
                    for (int m = 0; m < temporary.Count - n; m++)
                    {
                        Download a = temporary[m];
                        Download b = temporary[m + 1];
                        if (downloadsXml.IndexOfKey(a.FileHashString) > downloadsXml.IndexOfKey(b.FileHashString))
                        {
                            temporary[m] = b;
                            temporary[m + 1] = a;
                        }
                    }
                // Downloads wiederaufnehmen
                try
                {
                    m_DownloadsAndQueue.Lock();
                    foreach (Download download in temporary)
                        m_DownloadsAndQueue.Add(download);
                }
                finally
                {
                    m_DownloadsAndQueue.Unlock();
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while resuming downloads!");
            }
            finally
            {
                // Erst jetzt kann die downloads.xml wieder geschreiben werden...
                DownloadsXmlWriter.SetIsReady();
            }
        }

        public static byte[] RijndaelDecrypt(RijndaelParameters keys, byte[] encryptedData)
        {
            if (encryptedData == null)
                throw new ArgumentNullException("encryptedData");

            RijndaelManaged rijndael = keys.Export();
            MemoryStream memoryStream = new MemoryStream(encryptedData);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] decryptedData = new byte[encryptedData.Length];
            cryptoStream.Read(decryptedData, 0, decryptedData.Length);
            cryptoStream.Close();
            rijndael.Clear();
            return decryptedData;
        }

        public static byte[] RijndaelEncrypt(RijndaelParameters keys, byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            RijndaelManaged rijndael = keys.Export();
            MemoryStream memoryStream = new MemoryStream(Constants.MaximumCommandLength);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();
            byte[] encryptedData = memoryStream.ToArray();
            cryptoStream.Close();
            rijndael.Clear();
            return encryptedData;
        }

        private static RijndaelParameters RijndaelGenerateKeys()
        {
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.BlockSize = Constants.RijndaelBlockSize;
            rijndael.FeedbackSize = Constants.RijndaelFeedbackSize;
            rijndael.KeySize = Constants.RijndaelKeySize;
            rijndael.Mode = Constants.RijndaelMode;
            rijndael.Padding = Constants.RijndaelPadding;
            rijndael.GenerateIV();
            rijndael.GenerateKey();
            return new RijndaelParameters(rijndael);
        }

        public static byte[] RSADecrypt(byte[] encryptedData)
        {
            if (encryptedData == null)
                throw new ArgumentNullException("encryptedData");

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(m_Keys);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false);
            rsa.Clear();
            return decryptedData;
        }

        public static byte[] RSAEncrypt(RSAParameters publicKeys, byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(publicKeys);
            byte[] encryptedData = rsa.Encrypt(data, false);
            rsa.Clear();
            return encryptedData;
        }

        private static RSAParameters RSAGenerateKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(Constants.RSAKeySize);
            RSAParameters keys = rsa.ExportParameters(true);
            rsa.Clear();
            return keys;
        }

        public static void Send(IResponseCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Peer peer;
            string receiverPeerIDString = ByteArrayToString(command.ReceiverPeerID);
            IPAddress route = IPAddress.None;
            if (m_Peers.TryGetValue(receiverPeerIDString, out peer))
                route = peer.Route;
            Connection connection1;
            if (!route.Equals(IPAddress.None) && m_Connections.TryGetValue(route, out connection1))
                command.Send(connection1);
            /*else if (!(command is Command23) && !(command is Command53))
                foreach (Connection connection2 in m_Connections.Values)
                    if (connection2.IsEstablished)
                        command.Send(connection2);*/
        }

        private static void Send(IResponseCommand command, IPAddress excludedConnection)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            Peer peer;
            string receiverPeerIDString = ByteArrayToString(command.ReceiverPeerID);
            IPAddress route = IPAddress.None;
            if (m_Peers.TryGetValue(receiverPeerIDString, out peer))
                route = peer.Route;
            Connection connection1;
            if (!route.Equals(IPAddress.None) && !route.Equals(excludedConnection) && m_Connections.TryGetValue(route, out connection1))
                command.Send(connection1);
            /*else if (!(command is Command23) && !(command is Command53))
                foreach (Connection connection2 in m_Connections.Values)
                    if (connection2.IsEstablished && !connection2.RemoteEndPoint.Address.Equals(excludedConnection))
                        command.Send(connection2);*/
        }

        private static void SendBroadcast(IRequestCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            foreach (Connection connection in m_Connections.Values)
                if (connection.IsEstablished)
                    command.Send(connection);
        }

        private static void SendBroadcast(IRequestCommand command, IPAddress excludedConnection)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            foreach (Connection connection in m_Connections.Values)
                if (connection.IsEstablished && !connection.RemoteEndPoint.Address.Equals(excludedConnection))
                    command.Send(connection);
        }

        private static void SendBroadcast(IRequestCommand command, IPAddress excludedConnection, int dropChainTailCount)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            try
            {
                m_Connections.Lock();
                RList<Connection> connections = new RList<Connection>();
                foreach (Connection connection in m_Connections.Values)
                    if (connection.IsEstablished && !connection.RemoteEndPoint.Address.Equals(excludedConnection))
                        connections.Add(connection);
                dropChainTailCount = Math.Min(dropChainTailCount, connections.Count);
                for (int n = 0; n < dropChainTailCount; n++)
                {
                    int index = Randomizer.GenerateNumber(0, connections.Count);
                    command.Send(connections[index]);
                    connections.RemoveAt(index);
                }
            }
            finally
            {
                m_Connections.Unlock();
            }
        }

        public static void SendCommand20(byte[] floodingHash, byte[] senderPeerID, byte[] searchID, string searchPattern)
        {
            if (floodingHash == null)
                throw new ArgumentNullException("floodingHash");
            if (floodingHash.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (searchID == null)
                throw new ArgumentNullException("searchID");
            if (searchID.Length != 48)
                throw new ArgumentException();
            if (searchPattern == null)
                throw new ArgumentNullException("searchPattern");

            byte[] commandID = GenerateIDOrHash();
            SendBroadcast(new Command20(commandID, floodingHash, senderPeerID, searchID, searchPattern));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        public static void SendCommand50(byte[] floodingHash, byte[] senderPeerID, byte[] sourceSearchID, byte[] hashedFileHash)
        {
            if (floodingHash == null)
                throw new ArgumentNullException("floodingHash");
            if (floodingHash.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (sourceSearchID == null)
                throw new ArgumentNullException("sourceSearchID");
            if (sourceSearchID.Length != 48)
                throw new ArgumentException();
            if (hashedFileHash == null)
                throw new ArgumentNullException("hashedFileHash");
            if (hashedFileHash.Length != 64)
                throw new ArgumentException();

            byte[] commandID = GenerateIDOrHash();
            SendBroadcast(new Command50(commandID, floodingHash, senderPeerID, sourceSearchID, hashedFileHash));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        public static void SendCommand60(byte[] floodingHash, byte[] senderPeerID, byte[] sourceSearchID, byte[] hashedFileHash)
        {
            if (floodingHash == null)
                throw new ArgumentNullException("floodingHash");
            if (floodingHash.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (sourceSearchID == null)
                throw new ArgumentNullException("sourceSearchID");
            if (sourceSearchID.Length != 48)
                throw new ArgumentException();
            if (hashedFileHash == null)
                throw new ArgumentNullException("hashedFileHash");
            if (hashedFileHash.Length != 64)
                throw new ArgumentException();

            byte[] commandID = GenerateIDOrHash();
            SendBroadcast(new Command60(commandID, floodingHash, senderPeerID, sourceSearchID, hashedFileHash));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        public static void SendCommand70(byte[] senderPeerID, byte[] receiverPeerID, byte[] feedbackID, byte[] hashedFileHash)
        {
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (receiverPeerID == null)
                throw new ArgumentNullException("receiverPeerID");
            if (receiverPeerID.Length != 48)
                throw new ArgumentException();
            if (feedbackID == null)
                throw new ArgumentNullException("feedbackID");
            if (feedbackID.Length != 48)
                throw new ArgumentException();
            if (hashedFileHash == null)
                throw new ArgumentNullException("hashedFileHash");
            if (hashedFileHash.Length != 64)
                throw new ArgumentException();

            byte[] commandID = GenerateIDOrHash();
            Send(new Command70(commandID, senderPeerID, receiverPeerID, feedbackID, hashedFileHash));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        public static void SendCommand74(byte[] senderPeerID, byte[] receiverPeerID, byte[] downloadID, byte[] hashedFileHash)
        {
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (receiverPeerID == null)
                throw new ArgumentNullException("receiverPeerID");
            if (receiverPeerID.Length != 48)
                throw new ArgumentException();
            if (downloadID == null)
                throw new ArgumentNullException("downloadID");
            if (downloadID.Length != 48)
                throw new ArgumentException();
            if (hashedFileHash == null)
                throw new ArgumentNullException("hashedFileHash");
            if (hashedFileHash.Length != 64)
                throw new ArgumentException();

            byte[] commandID = GenerateIDOrHash();
            Send(new Command74(commandID, senderPeerID, receiverPeerID, downloadID, hashedFileHash));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        public static void SendCommand78(byte[] senderPeerID, byte[] receiverPeerID, byte[] downloadID, long sector)
        {
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (receiverPeerID == null)
                throw new ArgumentNullException("receiverPeerID");
            if (receiverPeerID.Length != 48)
                throw new ArgumentException();
            if (downloadID == null)
                throw new ArgumentNullException("downloadID");
            if (downloadID.Length != 48)
                throw new ArgumentException();
            if (sector < 0)
                throw new ArgumentOutOfRangeException("sector");

            byte[] commandID = GenerateIDOrHash();
            Send(new Command78(commandID, senderPeerID, receiverPeerID, downloadID, (uint)sector));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        public static void SendCommand7A(byte[] senderPeerID, byte[] receiverPeerID, byte[] downloadID, byte[] fileHashCodeResult)
        {
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (receiverPeerID == null)
                throw new ArgumentNullException("receiverPeerID");
            if (receiverPeerID.Length != 48)
                throw new ArgumentException();
            if (downloadID == null)
                throw new ArgumentNullException("downloadID");
            if (downloadID.Length != 48)
                throw new ArgumentException();
            if (fileHashCodeResult == null)
                throw new ArgumentNullException("fileHashCodeResult");
            if (fileHashCodeResult.Length != 64)
                throw new ArgumentException();

            byte[] commandID = GenerateIDOrHash();
            Send(new Command7A(commandID, senderPeerID, receiverPeerID, downloadID, fileHashCodeResult));
            m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
        }

        private static void SendSearchResults(byte[] senderPeerID, byte[] searchID, string searchPattern)
        {
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (searchID == null)
                throw new ArgumentNullException("searchID");
            if (searchID.Length != 48)
                throw new ArgumentException();
            if (searchPattern == null)
                throw new ArgumentNullException("searchPattern");

            searchPattern = searchPattern.ToLower();
            RList<Command23.SearchResult> searchResults = new RList<Command23.SearchResult>();
            int entriesLength = 0;
            foreach (SharedFile sharedFile in SharedFiles.Values)
            {
                bool found = false;
                if (sharedFile.FileName.ToLower().Contains(searchPattern))
                    found = true;
                if (!found && sharedFile.Album.ToLower().Contains(searchPattern))
                    found = true;
                if (!found && sharedFile.Artist.ToLower().Contains(searchPattern))
                    found = true;
                if (!found && sharedFile.Title.ToLower().Contains(searchPattern))
                    found = true;
                if (found)
                {
                    int entryLength = sharedFile.GetEntryLength();
                    if (entriesLength + entryLength <= Constants.MaximumDataLength)
                    {
                        searchResults.Add(new Command23.SearchResult(sharedFile.FileHash, (uint)sharedFile.FileSize, sharedFile.FileName, sharedFile.MetaData, sharedFile.Comment, sharedFile.Rating));
                        entriesLength += entryLength;
                    }
                    else
                        break;
                }
            }
            if (!searchResults.IsEmpty)
            {
                byte[] commandID = GenerateIDOrHash();
                Send(new Command23(commandID, m_PeerID, senderPeerID, searchID, searchResults));
                m_LastCommandID[ByteArrayToString(commandID)] = DateTime.Now;
            }
        }

        public static string TransferVolumeToString(int minuteAverage)
        {
            if (minuteAverage < 0)
                throw new ArgumentOutOfRangeException("minuteAverage");

            float minuteAverageSingle = (float)minuteAverage;
            string minuteAverageString;
            if (bool.Parse(Settings.Instance["UseBytesInsteadOfBits"]))
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
            return minuteAverageString;
        }

        public static void SetUILanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Instance["UICulture"]);
        }
    }
}
