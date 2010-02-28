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
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Regensburger.RShare
{
    public sealed partial class Download
    {
        private string m_Album = string.Empty;

        private string m_Artist = string.Empty;

        private int m_Downloaded = 0;

        private byte[] m_DownloadID;

        private string m_DownloadIDString;

        private byte[] m_DownloadPeerID;

        private RList<int> m_DownloadStatistics = new RList<int>(60);

        private int m_Downstream = 0;

        private string m_DownstreamString = Core.TransferVolumeToString(0);

        private byte[] m_FileHash;

        private string m_FileHashString;

        private string m_FileName = string.Empty;

        private long m_FileSize = 0;

        private string m_FileSizeString = Core.LengthToString(0);

        private FileStream m_FileStream;

        private bool m_HasInformation = true;

        private bool m_IsFilledWithZeros = false;

        private bool m_IsFillingWithZeros = false;

        private bool m_IsHashing = false;

        private DateTime m_LastBroadcastSent = DateTime.MinValue;

        private DateTime? m_LastReception = null;

        private DateTime? m_LastSeen = null;

        private static Logger m_Logger = Logger.Instance;

        private DownloadMetaDataCollection m_MetaData;

        private bool m_NoAvailableDiscSpace = false;

        private byte[] m_OnceHashedFileHash;

        private string m_OnceHashedFileHashString;

        private DateTime? m_QueueStart = null;

        private byte m_Rating = 0;

        private long m_ReceivedSectors = -1;

        private DateTime? m_RequestingDelay = null;

        private long m_Sectors = 0;

        private byte[] m_SectorsMap;

        private ICoreSettings m_Settings = Settings.Instance;

        private DownloadSourceCollection m_Sources;

        private byte[] m_SourceSearchFloodingHash;

        private byte[] m_SourceSearchID;

        private byte[] m_SourceSearchPeerID;

        private byte[] m_SourceSearchResponsePeerID;

        private string m_SubFolder = "";

        private string m_TempFilePath;

        private byte[] m_ThriceHashedFileHash;

        private string m_ThriceHashedFileHashString;

        private DateTime m_TimeStarted;

        private string m_Title = string.Empty;

        private byte[] m_TwiceHashedFileHash;

        private string m_TwiceHashedFileHashString;

        public string Album
        {
            get
            {
                return m_Album;
            }
        }

        public string Artist
        {
            get
            {
                return m_Artist;
            }
        }

        public long Completed
        {
            get
            {
                long completed = (m_ReceivedSectors + 1) * 32768;
                if (completed < 0)
                    return 0;
                if (completed > m_FileSize)
                    return m_FileSize;
                return completed;
            }
        }

        public string CompletedString
        {
            get
            {
                return Core.LengthToString(Completed);
            }
        }

        public byte[] DownloadID
        {
            get
            {
                return m_DownloadID;
            }
        }

        public string DownloadIDString
        {
            get
            {
                return m_DownloadIDString;
            }
        }

        public byte[] DownloadPeerID
        {
            get
            {
                return m_DownloadPeerID;
            }
        }

        public int Downstream
        {
            get
            {
                return m_Downstream;
            }
        }

        public string DownstreamString
        {
            get
            {
                return m_DownstreamString;
            }
        }

        public byte[] FileHash
        {
            get
            {
                return m_FileHash;
            }
        }

        public string FileHashString
        {
            get
            {
                return m_FileHashString;
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
        }

        public long FileSize
        {
            get
            {
                return m_FileSize;
            }
        }

        public string FileSizeString
        {
            get
            {
                return m_FileSizeString;
            }
        }

        public bool HasInformation
        {
            get
            {
                return m_HasInformation;
            }
        }

        public bool IsActive
        {
            get
            {
                return Core.DownloadsAndQueue.IndexOfKey(m_DownloadIDString) < Constants.MaximumDownloadsCount;
            }
        }

        public bool IsFilledWithZeros
        {
            get
            {
                return m_IsFilledWithZeros;
            }
        }

        public bool IsFillingWithZeros
        {
            get
            {
                return m_IsFillingWithZeros;
            }
        }

        public bool IsHashing
        {
            get
            {
                return m_IsHashing;
            }
        }

        public bool IsSourceSearchDelayActive
        {
            get
            {
                return !(m_IsFilledWithZeros && m_RequestingDelay.HasValue && DateTime.Now.Subtract(m_RequestingDelay.Value).TotalSeconds >= Constants.DownloadRequestingDelay);
            }
        }

        public DateTime? LastReception
        {
            get
            {
                return m_LastReception;
            }
        }

        public DateTime? LastSeen
        {
            get
            {
                return m_LastSeen;
            }
        }

        public RIndexedHashtable<string, string> MetaData
        {
            get
            {
                return m_MetaData;
            }
        }

        public bool NoAvailableDiscSpace
        {
            get
            {
                return m_NoAvailableDiscSpace;
            }
        }

        public byte[] OnceHashedFileHash
        {
            get
            {
                return m_OnceHashedFileHash;
            }
        }

        public string OnceHashedFileHashString
        {
            get
            {
                return m_OnceHashedFileHashString;
            }
        }

        public float Progress
        {
            get
            {
                return ((float)(m_ReceivedSectors + 1) * 100) / (float)(Sectors + 1);
            }
        }

        public int QueuePostition
        {
            get
            {
                return Core.DownloadsAndQueue.IndexOfKey(m_DownloadIDString);
            }
        }

        public DateTime? QueueStart
        {
            get
            {
                return m_QueueStart;
            }
        }

        public byte Rating
        {
            get
            {
                return m_Rating;
            }
        }

        public long ReceivedSectors
        {
            get
            {
                return m_ReceivedSectors;
            }
        }

        public long Remaining
        {
            get
            {
                long remaining = m_FileSize - (m_ReceivedSectors + 1) * 32768;
                if (remaining < 0)
                    return 0;
                if (remaining > m_FileSize)
                    return m_FileSize;
                return remaining;
            }
        }

        public string RemainingString
        {
            get
            {
                return Core.LengthToString(Remaining);
            }
        }

        public long Sectors
        {
            get
            {
                return m_Sectors;
            }
        }

        public byte[] SectorsMap
        {
            get
            {
                return m_SectorsMap;
            }
        }

        public DownloadSourceCollection Sources
        {
            get
            {
                return m_Sources;
            }
        }

        public byte[] SourceSearchID
        {
            get
            {
                return m_SourceSearchID;
            }
        }

        public byte[] SourceSearchPeerID
        {
            get
            {
                return m_SourceSearchPeerID;
            }
        }

        public byte[] SourceSearchResponsePeerID
        {
            get
            {
                return m_SourceSearchResponsePeerID;
            }
        }

        public string SubFolder
        {
            get
            {
                return m_SubFolder;
            }
        }

        public string TempFilePath
        {
            get
            {
                return m_TempFilePath;
            }
        }

        public byte[] ThriceHashedFileHash
        {
            get
            {
                return m_ThriceHashedFileHash;
            }
        }

        public string ThriceHashedFileHashString
        {
            get
            {
                return m_ThriceHashedFileHashString;
            }
        }

        public DateTime TimeStarted
        {
            get
            {
                return m_TimeStarted;
            }
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
        }

        public byte[] TwiceHashedFileHash
        {
            get
            {
                return m_TwiceHashedFileHash;
            }
        }

        public string TwiceHashedFileHashString
        {
            get
            {
                return m_TwiceHashedFileHashString;
            }
        }

        public void AddSource(byte[] id, byte[] sectorsMap)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (id.Length != 48)
                throw new ArgumentException();

            if (m_IsHashing)
                return;
            try
            {
                // 2007-10-02 T.Norad
                // set current time as last seen in this download
                m_LastSeen = DateTime.Now;
                m_Sources.Lock();
                string idString = Core.ByteArrayToString(id);
                if (!m_Sources.ContainsKey(idString))
                    m_Sources.Add(idString, new Source(m_Sources, id, sectorsMap));
                else
                    m_Sources[idString].Report6364Received(sectorsMap);
            }
            finally
            {
                m_Sources.Unlock();
            }
        }

        public void AddSource(byte[] id, long fileSize, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating, byte[] sectorsMap)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (id.Length != 48)
                throw new ArgumentException();
            if (fileSize < 0)
                throw new ArgumentOutOfRangeException("fileSize");
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (metaData == null)
                throw new ArgumentNullException("metaData");
            if (comment == null)
                throw new ArgumentNullException("comment");
            if (rating > 3)
                throw new ArgumentOutOfRangeException("rating");

            if (m_IsHashing)
                return;
            try
            {
                // 2007-06-14 T.Norad
                // set current time as last seen in this download
                m_LastSeen = DateTime.Now;
                m_Sources.Lock();
                string idString = Core.ByteArrayToString(id);
                if (!m_Sources.ContainsKey(idString))
                    m_Sources.Add(idString, new Source(m_Sources, id, fileName, metaData, comment, rating, sectorsMap));
                else
                    m_Sources[idString].Report5354Received(fileName, metaData, comment, rating, sectorsMap);
                RIndexedHashtable<string, int> fileNames1 = new RIndexedHashtable<string, int>();
                RIndexedHashtable<byte, int> ratings1 = new RIndexedHashtable<byte, int>();
                foreach (Source source in m_Sources.Values)
                {
                    if (!source.HasInformation)
                        continue;
                    if (!fileNames1.ContainsKey(source.FileName))
                        fileNames1.Add(source.FileName, 1);
                    else
                        fileNames1[source.FileName]++;
                    if (!ratings1.ContainsKey(source.Rating))
                        ratings1.Add(source.Rating, 1);
                    else
                        ratings1[source.Rating]++;
                }
                RList<string> fileNames2 = new RList<string>(fileNames1.Keys);
                for (int n = 1; n <= fileNames2.Count - 1; n++)
                    for (int m = 0; m < fileNames2.Count - n; m++)
                    {
                        if (fileNames1[fileNames2[m]] < fileNames1[fileNames2[m + 1]])
                        {
                            string temp;
                            temp = fileNames2[m];
                            fileNames2[m] = fileNames2[m + 1];
                            fileNames2[m + 1] = temp;
                        }
                    }
                fileNames2.Remove(string.Empty);
                if (!fileNames2.IsEmpty)
                {
                    m_FileName = fileNames2[0];
                }
                else
                {
                    m_FileName = m_FileHashString;
                }
                RList<byte> ratings2 = new RList<byte>(ratings1.Keys);
                for (int n = 1; n <= ratings2.Count - 1; n++)
                    for (int m = 0; m < ratings2.Count - n; m++)
                    {
                        if (ratings1[ratings2[m]] < ratings1[ratings2[m + 1]])
                        {
                            byte temp;
                            temp = ratings2[m];
                            ratings2[m] = ratings2[m + 1];
                            ratings2[m + 1] = temp;
                        }
                    }
                ratings2.Remove(0);
                if (!ratings2.IsEmpty)
                    m_Rating = ratings2[0];
                else
                    m_Rating = 0;
                foreach (KeyValuePair<string, string> metaDataItem in metaData)
                    if (!m_MetaData.ContainsKey(metaDataItem.Key))
                        m_MetaData.Add(metaDataItem.Key, metaDataItem.Value);
                Core.ParseMetaData(m_MetaData, out m_Album, out m_Artist, out m_Title);
                if (!m_HasInformation)
                {
                    m_FileSize = fileSize;
                    m_FileSizeString = Core.LengthToString(m_FileSize);
                    m_Sectors = m_FileSize / 32768;
                    m_SectorsMap = new byte[(m_Sectors / 8) + 1];
                    for (long n = m_Sectors + 1; n < m_SectorsMap.Length * 8; n++)
                        m_SectorsMap[n / 8] |= (byte)(1 << ((int)n % 8));
                    FillWithZeros();
                    m_HasInformation = true;
                }
            }
            finally
            {
                m_Sources.Unlock();
            }
        }

        public void Cancel()
        {
            if (m_IsFillingWithZeros && !m_IsFilledWithZeros)
            {
                m_Logger.Log("The download of \"{0}\" cannot be cancelled because it is still filling with zeros!", m_FileName);
                return;
            }
            if (m_IsHashing)
            {
                m_Logger.Log("The download of \"{0}\" cannot be cancelled because it is still hashing!", m_FileName);
            }
            try
            {
                m_Sources.Lock();
                foreach (Source source in m_Sources.Values)
                    if (source.State == SourceState.Active || source.State == SourceState.Requested || source.State == SourceState.Requesting)
                        SendCommand7A(source);
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while removing sources!");
            }
            finally
            {
                m_Sources.Clear();
                m_Sources.Unlock();
            }
            Core.RemoveDownload(m_DownloadID);
            try
            {
                m_FileStream.Close();
                File.Delete(m_TempFilePath);
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while deleting temporary file '{0}'!", m_TempFilePath);
            }
        }

        private void FillWithZeros()
        {
            if (!m_IsFillingWithZeros)
            {
                try
                {
                    if (!UtilitiesForMono.IsRunningOnMono)
                    {
                        DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(new FileInfo(m_TempFilePath).FullName));
                        if (driveInfo.AvailableFreeSpace < (long)(((float)m_FileSize) * 1.1F))
                        {
                            Logger.Instance.Log(Properties.Resources_Core.NoAvailableDiscSpace, m_FileName);
                            m_NoAvailableDiscSpace = true;
                            return;
                        }
                        else
                            m_NoAvailableDiscSpace = false;
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown while testing for available free space on the hard disk drive!");
                }
                m_IsFillingWithZeros = true;
                Thread fillWithZerosThread = new Thread(delegate()
                {
                    try
                    {
                        byte[] buffer = new byte[32768];
                        for (long i = m_FileStream.Length / 32768; i < m_Sectors; i++)
                        {
                            if (!m_FileStream.CanWrite)
                                return;
                            m_FileStream.Write(buffer, 0, 32768);
                        }
                        if (!m_FileStream.CanWrite)
                            return;
                        m_FileStream.Write(buffer, 0, (int)(m_FileSize - m_FileStream.Length));
                        m_IsFilledWithZeros = true;
                    }
                    catch (Exception ex)
                    {
                        // 2008-07-04 T.Norad: exception logging added
                        Logger.Instance.Log(ex, "An exception was thrown while zero file filling! Filename: {0}", new object[] { m_FileName });
                    }
                });
                fillWithZerosThread.Name = "fillWithZerosThread";
                fillWithZerosThread.IsBackground = true;
                fillWithZerosThread.Priority = ThreadPriority.Lowest;
                fillWithZerosThread.Start();
            }
        }
        
        public bool GetSectorData(long sector, out byte[] data, out byte[] hash, out byte[] hashCodeResult)
        {
            if (sector < 0)
                throw new ArgumentOutOfRangeException("sector");
            if (sector > m_Sectors)
                throw new ArgumentOutOfRangeException("sector");

            if ((m_SectorsMap[(sector / 8)] & (1 << (int)(sector % 8))) != 0)
            {
                if (!File.Exists(m_TempFilePath))
                {
                    data = null;
                    hash = null;
                    hashCodeResult = null;
                    return false;
                }
                try
                {
                    byte[] readData = new byte[32768];
                    m_FileStream.Position = sector * 32768;
                    int count;
                    if (m_FileStream.Position + 32768 <= m_FileStream.Length)
                        count = 32768;
                    else
                        count = (int)(m_FileStream.Length - m_FileStream.Position);
                    m_FileStream.Read(readData, 0, count);
                    data = readData;
                    hash = ComputeHashes.SHA512Compute(data);
                    // Sicherer Hash ANFANG
                    hashCodeResult = new byte[64];
                    for (int n = 0; n < 64; n++)
                        hashCodeResult[n] = (byte)(hash[n] ^ m_FileHash[n]);
                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                    hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                    // Sicherer Hash ENDE
                    return true;
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown while reading from temporary file '{0}'!", m_FileName);
                    data = null;
                    hash = null;
                    hashCodeResult = null;
                    return false;
                }
            }
            else
            {
                data = null;
                hash = null;
                hashCodeResult = null;
                return false;
            }
        }

        private void Initialize(byte[] fileHash)
        {
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();

            m_Sources = new DownloadSourceCollection(Core.DownloadsAndQueue);
            m_MetaData = new DownloadMetaDataCollection(Core.DownloadsAndQueue);
            m_FileHash = fileHash;
            m_FileHashString = Core.ByteArrayToString(m_FileHash);
            m_OnceHashedFileHash = ComputeHashes.SHA512Compute(m_FileHash);
            m_OnceHashedFileHashString = Core.ByteArrayToString(m_OnceHashedFileHash);
            m_TwiceHashedFileHash = ComputeHashes.SHA512Compute(m_OnceHashedFileHash);
            m_TwiceHashedFileHashString = Core.ByteArrayToString(m_TwiceHashedFileHash);
            m_ThriceHashedFileHash = ComputeHashes.SHA512Compute(m_TwiceHashedFileHash);
            m_ThriceHashedFileHashString = Core.ByteArrayToString(m_ThriceHashedFileHash);
            m_SourceSearchFloodingHash = Core.GenerateFloodingHash();
            m_SourceSearchPeerID = Core.GenerateIDOrHash();
            m_SourceSearchID = Core.GenerateIDOrHash();
            m_SourceSearchResponsePeerID = Core.GenerateIDOrHash();
            m_DownloadPeerID = Core.GenerateIDOrHash();
            m_DownloadID = Core.GenerateIDOrHash();
            m_DownloadIDString = Core.ByteArrayToString(m_DownloadID);
        }

        public void Process()
        {
            if (m_QueueStart == null || !m_QueueStart.HasValue)
                m_QueueStart = DateTime.Now;
            if (m_ReceivedSectors == m_Sectors)
            {
                if (m_IsHashing)
                    return;
                m_IsHashing = true;
                Thread hashingThread = new Thread(delegate()
                {
                    try
                    {
                        m_Logger.Log("The download of \"{0}\" is complete and will be hashed now!", m_FileName);
                        try
                        {
                            m_Sources.Lock();
                            foreach (Source source in m_Sources.Values)
                                if (source.State == SourceState.Active || source.State == SourceState.Requested || source.State == SourceState.Requesting)
                                    SendCommand7A(source);
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while removing sources!");
                        }
                        finally
                        {
                            m_Sources.Clear();
                            m_Sources.Unlock();
                        }
                        Core.RemoveDownload(m_DownloadID);
                        try
                        {
                            m_FileStream.Close();
                            FileStream fileStream = new FileStream(m_TempFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                            byte[] fileHash = ComputeHashes.SHA512Compute(fileStream);
                            fileStream.Close();
                            if (Core.CompareByteArray(fileHash, m_FileHash))
                            {
                                //2008-03-20 Nochbaer
                                if (Directory.Exists(Path.Combine(m_Settings["IncomingDirectory"], m_SubFolder)) == false)
                                {
                                    Directory.CreateDirectory(Path.Combine(m_Settings["IncomingDirectory"], m_SubFolder));
                                }
                                string filePath = Path.Combine(Path.Combine(m_Settings["IncomingDirectory"], m_SubFolder), m_FileName);
                                int n = 1;
                                while (File.Exists(filePath))
                                {
                                    filePath = Path.Combine(Path.Combine(m_Settings["IncomingDirectory"], m_SubFolder), string.Format("{0}({1}){2}", Path.GetFileNameWithoutExtension(m_FileName), n, Path.GetExtension(m_FileName)));
                                    n++;
                                }
                                Core.ShareManager.AddDownloadedFile(m_TempFilePath, filePath, m_FileHash);
                                File.Move(m_TempFilePath, filePath);
                                if (bool.Parse(m_Settings["ParseCollections"]) == true && Path.GetExtension(filePath) == ".sncollection")
                                {
                                    Core.ParseStealthNetCollection(filePath);
                                }
                            }
                            else
                            {
                                string filePath = Path.Combine(m_Settings["CorruptDirectory"], m_FileName);
                                int n = 1;
                                while (File.Exists(filePath))
                                {
                                    filePath = Path.Combine(m_Settings["CorruptDirectory"], string.Format("{0}({1}){2}", Path.GetFileNameWithoutExtension(m_FileName), n, Path.GetExtension(m_FileName)));
                                    n++;
                                }
                                File.Move(m_TempFilePath, filePath);
                                Core.AddDownload(m_FileHash, m_FileHashString, 0, null);
                                m_Logger.Log("The Download of '{0}' is corrupt", m_FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while moving temporary file '{0}'!", m_TempFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Log(ex, "An exception was thrown while hashing the download of \"{0}\"!", m_FileName);
                    }
                });
                hashingThread.Name = "hashingThread";
                hashingThread.IsBackground = true;
                hashingThread.Priority = ThreadPriority.Lowest;
                hashingThread.Start();
            }
            else
            {
                if (m_DownloadStatistics.Count == 60)
                    m_DownloadStatistics.RemoveAt(59);
                m_DownloadStatistics.Insert(0, m_Downloaded);
                m_Downloaded = 0;
                long downstream = 0;
                foreach (int n in m_DownloadStatistics)
                    downstream += n;
                m_Downstream = (int)(downstream / m_DownloadStatistics.Count);
                m_DownstreamString = Core.TransferVolumeToString(m_Downstream);

                if (DateTime.Now.Subtract(m_LastBroadcastSent).TotalSeconds >= Constants.Command30Interval)
                {
                    m_LastBroadcastSent = DateTime.Now;
                    if (!m_HasInformation)
                        Core.SendCommand50(m_SourceSearchFloodingHash, m_SourceSearchPeerID, m_SourceSearchID, m_OnceHashedFileHash);
                    else
                        Core.SendCommand60(m_SourceSearchFloodingHash, m_SourceSearchPeerID, m_SourceSearchID, m_TwiceHashedFileHash);
                }
                try
                {
                    m_Sources.Lock();
                    RList<Source> activeSources = new RList<Source>();
                    RList<Source> verifiedSources = new RList<Source>();
                    Source source;
                    for (int n = m_Sources.Count - 1; n >= 0; n--)
                    {
                        if (!m_RequestingDelay.HasValue)
                            m_RequestingDelay = DateTime.Now;
                        source = m_Sources[n].Value;
                        if (!source.IsComplete)
                        {
                            bool hasNeededSectors = false;
                            for (long i = 0; i < source.SectorsMap.Length; i++)
                                if ((~m_SectorsMap[i] & source.SectorsMap[i]) != 0)
                                {
                                    hasNeededSectors = true;
                                    break;
                                }
                            if (!hasNeededSectors && source.State != SourceState.NotNeeded)
                            {
                                source.SetState(SourceState.NotNeeded);
                                if (source.State == SourceState.Active || source.State == SourceState.Requested || source.State == SourceState.Requesting)
                                    SendCommand7A(source);
                            }
                            else if (source.State == SourceState.NotNeeded && hasNeededSectors)
                                source.SetState(SourceState.Verifying);
                        }
                        if (source.State == SourceState.NotNeeded)
                        {
                            if (DateTime.Now.Subtract(source.LastReceived).TotalSeconds >= Constants.PeerTimeout)
                                m_Sources.RemoveAt(n);
                        }
                        else if (source.State == SourceState.Verifying || source.State == SourceState.Verified)
                        {
                            if ((source.Command70Sent == 0 && DateTime.Now.Subtract(source.LastCommand70Sent).TotalSeconds >= Constants.Command70Interval) ||
                                (source.Command70Sent > 0 && source.Command70Sent < Constants.Command70ToSend && DateTime.Now.Subtract(source.LastCommand70Sent).TotalSeconds >= Constants.Command71Timeout))
                            {
                                if (source.Command70Sent > 0)
                                    source.ReportTimeout();
                                source.Report70Sent();
                                Core.SendCommand70(m_DownloadPeerID, source.PeerID, m_DownloadID, m_ThriceHashedFileHash);
                            }
                            else if (source.Command70Sent >= Constants.Command70ToSend && DateTime.Now.Subtract(source.LastCommand70Sent).TotalSeconds >= Constants.Command71Timeout)
                            {
                                m_Sources.RemoveAt(n);
                                continue;
                            }
                            if (source.State == SourceState.Verified && !source.IsQueueFull)
                                verifiedSources.Add(source);
                        }
                        else if (source.State == SourceState.Requesting || source.State == SourceState.Requested ||
                            (source.State == SourceState.Active && source.LastRequestedSector == -1))
                        {
                            if ((source.Command74Sent == 0 && DateTime.Now.Subtract(source.LastCommand74Sent).TotalSeconds >= Constants.Command74Interval) ||
                                (source.Command74Sent > 0 && source.Command74Sent < Constants.Command74ToSend && DateTime.Now.Subtract(source.LastCommand74Sent).TotalSeconds >= Constants.Command75Timeout))
                            {
                                source.Report74Sent();
                                Core.SendCommand74(m_DownloadPeerID, source.PeerID, m_DownloadID, m_ThriceHashedFileHash);
                            }
                            else if (source.Command74Sent >= Constants.Command74ToSend && DateTime.Now.Subtract(source.LastCommand74Sent).TotalSeconds >= Constants.Command75Timeout)
                            {
                                source.ReportTimeout();
                                continue;
                            }
                            activeSources.Add(source);
                        }
                        else if (source.State == SourceState.Active && source.LastRequestedSector > -1)
                        {
                            if ((source.Command78Sent == 0 && DateTime.Now.Subtract(source.LastCommand78Sent).TotalSeconds >= Constants.Command78Interval) ||
                                (source.Command78Sent > 0 && source.Command78Sent < Constants.Command78ToSend && DateTime.Now.Subtract(source.LastCommand78Sent).TotalSeconds >= Constants.Command79Timeout))
                            {
                                source.Report78Sent(source.LastRequestedSector);
                                Core.SendCommand78(m_DownloadPeerID, source.PeerID, m_DownloadID, source.LastRequestedSector);
                            }
                            else if (source.Command78Sent >= Constants.Command78ToSend && DateTime.Now.Subtract(source.LastCommand78Sent).TotalSeconds >= Constants.Command79Timeout)
                            {
                                source.ReportTimeout();
                                continue;
                            }
                            activeSources.Add(source);
                        }
                    }
                    if (m_IsFilledWithZeros && m_RequestingDelay.HasValue && DateTime.Now.Subtract(m_RequestingDelay.Value).TotalSeconds >= Constants.DownloadRequestingDelay)
                    {
                        if (activeSources.Count < Constants.MaximumSourcesCount && verifiedSources.Count > 0)
                        {
                            for (int n = 1; n <= verifiedSources.Count - 1; n++)
                                for (int m = 0; m < verifiedSources.Count - n; m++)
                                {
                                    if ((verifiedSources[m].IsComplete && !verifiedSources[m + 1].IsComplete &&
                                        verifiedSources[m + 1].QueueLength < Constants.MaximumUploadsCount) ||
                                        verifiedSources[m].QueueLength > verifiedSources[m + 1].QueueLength)
                                    {
                                        source = verifiedSources[m];
                                        verifiedSources[m] = verifiedSources[m + 1];
                                        verifiedSources[m + 1] = source;
                                    }
                                }
                            for (int n = 0; n < Math.Min(Constants.MaximumSourcesCount - activeSources.Count, verifiedSources.Count); n++)
                            {
                                source = verifiedSources[n];
                                source.Report74Sent();
                                Core.SendCommand74(m_DownloadPeerID, source.PeerID, m_DownloadID, m_ThriceHashedFileHash);
                                activeSources.Add(source);
                            }
                        }
                        for (int n = 0; n < Math.Min(Constants.MaximumSourcesCount, activeSources.Count); n++)
                        {
                            source = activeSources[n];
                            if (source.State == SourceState.Requested && source.QueuePosition == 0)
                            {
                                RList<long> sectorsToRequest = new RList<long>(m_SectorsMap.Length);
                                long sectorToRequest = -1;
                                if (!source.IsComplete)
                                {
                                    bool sectorCanBeRequested = false;
                                    for (int t = 0; t < 10 && !sectorCanBeRequested; t++)
                                    {
                                        for (long i = 0; i < m_SectorsMap.Length; i++)
                                            if ((~m_SectorsMap[i] & source.SectorsMap[i]) != 0)
                                                sectorsToRequest.Add(i);
                                        if (sectorsToRequest.Count > 0)
                                        {
                                            long d = sectorsToRequest[Randomizer.GenerateNumber(0, sectorsToRequest.Count)];
                                            byte e = m_SectorsMap[d];
                                            byte f = source.SectorsMap[d];
                                            int g;
                                            for (g = 0; g < 8; g++)
                                                if (((~e & f) & (1 << g)) != 0)
                                                    break;
                                            sectorToRequest = d * 8 + g;
                                            sectorCanBeRequested = true;
                                            foreach (Source activeSource in activeSources)
                                                if (activeSource.State == SourceState.Active && activeSource.LastRequestedSector == sectorToRequest)
                                                {
                                                    sectorCanBeRequested = false;
                                                    break;
                                                }
                                        }
                                        else
                                            sectorCanBeRequested = false;
                                    }
                                    if (sectorToRequest != -1)
                                    {
                                        source.Report78Sent(sectorToRequest);
                                        Core.SendCommand78(m_DownloadPeerID, source.PeerID, m_DownloadID, sectorToRequest);
                                    }
                                }
                                else
                                {
                                    bool sectorCanBeRequested = false;
                                    for (int t = 0; t < 10 && !sectorCanBeRequested; t++)
                                    {
                                        for (long i = 0; i < m_SectorsMap.Length; i++)
                                            if (m_SectorsMap[i] != 255)
                                                sectorsToRequest.Add(i);
                                        if (sectorsToRequest.Count > 0)
                                        {
                                            long d = sectorsToRequest[Randomizer.GenerateNumber(0, sectorsToRequest.Count)];
                                            byte e = m_SectorsMap[d];
                                            int g;
                                            for (g = 0; g < 8; g++)
                                                if ((e & (1 << g)) == 0)
                                                    break;
                                            sectorToRequest = d * 8 + g;
                                            sectorCanBeRequested = true;
                                            foreach (Source activeSource in activeSources)
                                                if (activeSource.State == SourceState.Active && activeSource.LastRequestedSector == sectorToRequest)
                                                {
                                                    sectorCanBeRequested = false;
                                                    break;
                                                }
                                        }
                                        else
                                            sectorCanBeRequested = false;
                                    }
                                    if (sectorToRequest != -1)
                                    {
                                        source.Report78Sent(sectorToRequest);
                                        Core.SendCommand78(m_DownloadPeerID, source.PeerID, m_DownloadID, sectorToRequest);
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    m_Sources.Unlock();
                }
            }
        }

        public void RemoveSources()
        {
            m_QueueStart = null;
            try
            {
                m_Sources.Lock();
                foreach (Source source in m_Sources.Values)
                    if (source.State == SourceState.Active || source.State == SourceState.Requested || source.State == SourceState.Requesting)
                        SendCommand7A(source);
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while removing sources!");
            }
            finally
            {
                m_Sources.Clear();
                m_Sources.Unlock();
            }
            m_RequestingDelay = null;
            if (DateTime.Now.Subtract(m_LastBroadcastSent).TotalSeconds < Constants.Command30Interval)
                m_LastBroadcastSent = DateTime.Now.Subtract(new TimeSpan(0, 0, (Constants.Command30Interval / 4) * 3));
            m_DownloadStatistics.Clear();
            m_Downloaded = 0;
            m_Downstream = 0;
            m_DownstreamString = Core.TransferVolumeToString(m_Downstream);
        }

        private void SendCommand7A(Source source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            // Sicherer Hash ANFANG
            byte[] hashCodeResult = new byte[64];
            for (int n = 0; n < 64; n++)
                hashCodeResult[n] = (byte)~m_FileHash[n];
            hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
            hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
            hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
            hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
            // Sicherer Hash ENDE
            Core.SendCommand7A(m_DownloadPeerID, source.PeerID, m_DownloadID, hashCodeResult);
        }

        public void SetLastSeen(DateTime dateTime)
        {
            m_LastSeen = dateTime;
        }

        public bool SetSectorData(long sector, byte[] data, byte[] hashCodeResult, Source source)
        {
            if (sector < 0)
                throw new ArgumentOutOfRangeException("sector");
            if (data == null)
                throw new ArgumentNullException("data");
            if (hashCodeResult == null)
                throw new ArgumentNullException("hashCodeResult");
            if (source == null)
                throw new ArgumentNullException("source");

            try
            {
                m_Sources.Lock();
                // 2007-06-14 T.Norad
                // set current time as last reception in this download
                m_LastReception = DateTime.Now;

                if ((m_SectorsMap[sector / 8] & (1 << (int)(sector % 8))) == 0)
                {
                    // Sicherer Hash-Vergleich ANFANG
                    byte[] hash = ComputeHashes.SHA512Compute(data);
                    byte[] hashCode = new byte[64];
                    for (int n = 0; n < 64; n++)
                        hashCode[n] = (byte)(hash[n] ^ m_FileHash[n]);
                    hashCode = ComputeHashes.SHA512Compute(hashCode);
                    hashCode = ComputeHashes.SHA512Compute(hashCode);
                    hashCode = ComputeHashes.SHA512Compute(hashCode);
                    hashCode = ComputeHashes.SHA512Compute(hashCode);
                    if (!Core.CompareByteArray(hashCode, hashCodeResult))
                    {
                        m_Logger.Log("A manipulated sector was received!");
                        return false;
                    }
                    // Sicherer Hash-Vergleich ENDE

                    // Sicherer Sektor-Vergleich ANFANG
                    if (sector != source.LastRequestedSector || m_IsHashing)
                    {
                        m_Logger.Log("An unrequested command was received!");
                        return false;
                    }
                    // Sicherer Sektor-Vergleich ENDE

                    // Filestream.Position setzen
                    m_FileStream.Position = sector * 32768;

                    int count;
                    if (m_FileStream.Position + 32768 <= m_FileSize)
                        count = 32768;
                    else
                        count = (int)(m_FileSize - m_FileStream.Position);
                    m_FileStream.Write(data, 0, count);
                    m_FileStream.Flush();
                    m_ReceivedSectors++;

                    //Update SectorsMap
                    m_SectorsMap[(int)(sector / 8)] |= (byte)(1 << (int)(sector % 8));
                    m_Downloaded += 32768;
                    source.Report79Received(sector);
                }
                else
                    return false;
                if (m_ReceivedSectors < m_Sectors)
                {
                    RList<long> sectorsToRequest = new RList<long>(m_SectorsMap.Length);
                    long sectorToRequest = -1;
                    if (!source.IsComplete)
                    {
                        bool sectorCanBeRequested = false;
                        for (int t = 0; t < 10 && !sectorCanBeRequested; t++)
                        {
                            for (long i = 0; i < m_SectorsMap.Length; i++)
                                if ((~m_SectorsMap[i] & source.SectorsMap[i]) != 0)
                                    sectorsToRequest.Add(i);
                            if (sectorsToRequest.Count > 0)
                            {
                                long d = sectorsToRequest[Randomizer.GenerateNumber(0, sectorsToRequest.Count)];
                                byte e = m_SectorsMap[d];
                                byte f = source.SectorsMap[d];
                                int g;
                                for (g = 0; g < 8; g++)
                                    if (((~e & f) & (1 << g)) != 0)
                                        break;
                                sectorToRequest = d * 8 + g;
                                sectorCanBeRequested = true;
                                foreach (Source activeSource in m_Sources.Values)
                                    if (activeSource.State == SourceState.Active && activeSource.LastRequestedSector == sectorToRequest)
                                    {
                                        sectorCanBeRequested = false;
                                        break;
                                    }
                            }
                            else
                                sectorCanBeRequested = false;
                        }
                        if (sectorToRequest != -1)
                        {
                            source.Report78Sent(sectorToRequest);
                            Core.SendCommand78(m_DownloadPeerID, source.PeerID, m_DownloadID, sectorToRequest);
                        }
                    }
                    else
                    {
                        bool sectorCanBeRequested = false;
                        for (int t = 0; t < 10 && !sectorCanBeRequested; t++)
                        {
                            for (long i = 0; i < m_SectorsMap.Length; i++)
                                if (m_SectorsMap[i] != 255)
                                    sectorsToRequest.Add(i);
                            if (sectorsToRequest.Count > 0)
                            {
                                long d = sectorsToRequest[Randomizer.GenerateNumber(0, sectorsToRequest.Count)];
                                byte e = m_SectorsMap[d];
                                int g;
                                for (g = 0; g < 8; g++)
                                    if ((e & (1 << g)) == 0)
                                        break;
                                sectorToRequest = d * 8 + g;
                                sectorCanBeRequested = true;
                                foreach (Source activeSource in m_Sources.Values)
                                    if (activeSource.State == SourceState.Active && activeSource.LastRequestedSector == sectorToRequest)
                                    {
                                        sectorCanBeRequested = false;
                                        break;
                                    }
                            }
                            else
                                sectorCanBeRequested = false;
                        }
                        if (sectorToRequest != -1)
                        {
                            source.Report78Sent(sectorToRequest);
                            Core.SendCommand78(m_DownloadPeerID, source.PeerID, m_DownloadID, sectorToRequest);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing in temporary file '{0}'!", m_TempFilePath);
                return false;
            }
            finally
            {
                m_Sources.Unlock();
            }
        }

        public void SetSubFolderAndTime(string subfolder, DateTime? timestarted)
        {
            SetTime(timestarted);
            if (subfolder == null)
            {
                // T.Norad: BZ 128: the path must always be emtpy
                m_SubFolder = string.Empty;
            }
            else
            {
                m_SubFolder = subfolder;
            }
        }

        public void SetTime(DateTime? timestarted)
        {
            if (timestarted != null && timestarted.HasValue)
                m_TimeStarted = timestarted.Value;
        }

        public Download(byte[] fileHash, String fileName, long fileSize, bool hasInformation, DateTime? lastSeen, DateTime? lastReception, byte[] sectorsMap)
        {
            // Konstruktor für das Download-Resuming
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (fileSize < 0)
                throw new ArgumentOutOfRangeException("fileSize");
            if (hasInformation)
            {
                if (sectorsMap == null)
                    throw new ArgumentNullException("sectorsMap");
                if (sectorsMap.Length < fileSize / 32768 / 8 + 1)
                    throw new ArgumentException();
            }

            Initialize(fileHash);
            m_HasInformation = hasInformation;
            m_FileSize = fileSize;
            m_FileSizeString = Core.LengthToString(m_FileSize);
            m_Sectors = m_FileSize / 32768;
            m_SectorsMap = new byte[(m_Sectors / 8) + 1];
            if (m_HasInformation)
            {
                for (int n = 0; n < m_SectorsMap.Length; n++)
                    m_SectorsMap[n] = sectorsMap[n];
                for (long n = 0; n <= m_Sectors; n++)
                    if ((m_SectorsMap[(n / 8)] & (1 << (int)(n % 8))) != 0)
                        m_ReceivedSectors++;
            }
            for (long n = m_Sectors + 1; n < m_SectorsMap.Length * 8; n++)
                m_SectorsMap[n / 8] |= (byte)(1 << ((int)n % 8));
            m_TempFilePath = Path.Combine(m_Settings["TemporaryDirectory"], m_FileHashString);
            if (m_HasInformation)
            {
                if (File.Exists(m_TempFilePath) && new FileInfo(m_TempFilePath).Length != m_FileSize)
                {
                    File.Delete(m_TempFilePath);
                    m_FileStream = new FileStream(m_TempFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    FillWithZeros();
                }
                else if (File.Exists(m_TempFilePath))
                {
                    m_FileStream = new FileStream(m_TempFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    m_IsFilledWithZeros = true;
                }
                else
                {
                    m_FileStream = new FileStream(m_TempFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    FillWithZeros();
                }
            }
            else
                m_FileStream = new FileStream(m_TempFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

            m_FileName = fileName;
            m_LastBroadcastSent = DateTime.Now.Subtract(new TimeSpan(0, 0, (Constants.Command30Interval / 4) * 3));
            m_LastReception = lastReception;
            m_LastSeen = lastSeen;
        }

        public Download(byte[] fileHash, String fileName, long fileSize)
        {
            // Konstruktor für den Download eines Links oder Hashes
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (fileSize < 0)
                throw new ArgumentOutOfRangeException("fileSize");

            Initialize(fileHash);
            m_HasInformation = false;
            m_FileSize = fileSize;
            m_FileSizeString = Core.LengthToString(m_FileSize);
            m_Sectors = m_FileSize / 32768;
            m_SectorsMap = new byte[(m_Sectors / 8) + 1];
            for (long n = m_Sectors + 1; n < m_SectorsMap.Length * 8; n++)
                m_SectorsMap[n / 8] |= (byte)(1 << ((int)n % 8));
            m_TempFilePath = Path.Combine(m_Settings["TemporaryDirectory"], m_FileHashString);
            m_FileStream = new FileStream(m_TempFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            m_FileName = fileName;
        }

        public Download(Search.Result result)
        {
            // Konstruktor für den Download eines Suchergebnisses
            if (result == null)
                throw new ArgumentNullException("result");

            Initialize(result.FileHash);
            m_FileSize = result.FileSize;
            m_FileSizeString = result.FileSizeString;
            m_Sectors = m_FileSize / 32768;
            m_SectorsMap = new byte[(m_Sectors / 8) + 1];
            for (long n = m_Sectors + 1; n < m_SectorsMap.Length * 8; n++)
                m_SectorsMap[n / 8] |= (byte)(1 << ((int)n % 8));
            m_TempFilePath = Path.Combine(m_Settings["TemporaryDirectory"], m_FileHashString);
            m_FileStream = new FileStream(m_TempFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            if (result.IsSearchDBResult)
            {
                m_FileName = result.FileName;
            }
            else
                foreach (Search.Result.Source source in result.Sources.Values)
                    AddSource(source.ID, m_FileSize, source.FileName, source.MetaData, source.Comment, source.Rating, null);
            FillWithZeros();
        }
    }
}
