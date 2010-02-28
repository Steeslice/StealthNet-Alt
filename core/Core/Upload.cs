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

namespace Regensburger.RShare
{
    public sealed class Upload
    {
        private byte[] m_FileHash;

        private string m_FileHashString;

        private bool m_IsActive = false;

        private DateTime m_LastRequest = DateTime.Now;

        private long m_LastRequestedSector = -1;

        private long m_LastSentSector = -1;

        private byte[] m_PeerID;

        private string m_PeerIDString;

        private long m_ReceivedSectors = -1;

        private long m_Sectors;

        private byte[] m_SectorsMap;

        private string m_SourceDownloadIDString;

        private int m_Uploaded = 0;

        private byte[] m_UploadID;

        private string m_UploadIDString;

        private RList<int> m_UploadStatistics = new RList<int>(60);

        private int m_Upstream = 0;

        private string m_UpstreamString = Core.TransferVolumeToString(0);

        private bool m_UseDownloadAsSource;

        public long Completed
        {
            get
            {
                if (m_UseDownloadAsSource)
                {
                    Download download;
                    if (Core.DownloadsAndQueue.TryGetValue(m_SourceDownloadIDString, out download))
                    {
                        long completed = (m_ReceivedSectors + 1) * 32768;
                        if (completed < 0)
                            return 0;
                        if (completed > download.FileSize)
                            return download.FileSize;
                        return completed;
                    }
                    return 0;
                }
                else
                {
                    SharedFile sharedFile;
                    if (Core.SharedFiles.TryGetValue(m_FileHashString, out sharedFile))
                    {
                        long completed = (m_ReceivedSectors + 1) * 32768;
                        if (completed < 0)
                            return 0;
                        if (completed > sharedFile.FileSize)
                            return sharedFile.FileSize;
                        return completed;
                    }
                    return 0;
                }
            }
        }

        public string CompletedString
        {
            get
            {
                return Core.LengthToString(Completed);
            }
        }

        public byte[] DownloadSectorsMap
        {
            get
            {
                Download download;
                if (Core.DownloadsAndQueue.TryGetValue(m_SourceDownloadIDString, out download))
                    return download.SectorsMap;
                return null;
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

        public bool IsActive
        {
            get
            {
                return m_IsActive;
            }
            set
            {
                m_IsActive = value;
            }
        }

        public DateTime LastRequest
        {
            get
            {
                return m_LastRequest;
            }
        }

        public long LastRequestedSector
        {
            get
            {
                return m_LastRequestedSector;
            }
        }

        public long LastSentSector
        {
            get
            {
                return m_LastSentSector;
            }
        }

        public byte[] PeerID
        {
            get
            {
                return m_PeerID;
            }
        }

        public string PeerIDString
        {
            get
            {
                return m_PeerIDString;
            }
        }

        public float Progress
        {
            get
            {
                return ((float)(m_ReceivedSectors + 1) * 100) / (float)(m_Sectors + 1);
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

        public string SourceDownloadIDString
        {
            get
            {
                return m_SourceDownloadIDString;
            }
        }

        public byte[] UploadID
        {
            get
            {
                return m_UploadID;
            }
        }

        public string UploadIDString
        {
            get
            {
                return m_UploadIDString;
            }
        }

        public int Upstream
        {
            get
            {
                return m_Upstream;
            }
        }

        public string UpstreamString
        {
            get
            {
                return m_UpstreamString;
            }
        }

        public void Process()
        {
            if (m_UploadStatistics.Count == 60)
                m_UploadStatistics.RemoveAt(59);
            m_UploadStatistics.Insert(0, m_Uploaded);
            m_Uploaded = 0;
            long upstream = 0;
            foreach (int n in m_UploadStatistics)
                upstream += n;
            m_Upstream = (int)(upstream / m_UploadStatistics.Count);
            m_UpstreamString = Core.TransferVolumeToString(m_Upstream);
        }

        public void ReportRequest()
        {
            m_LastRequest = DateTime.Now;
        }

        public void ReportRequest(long sector)
        {
            if ((m_SectorsMap[sector / 8] & (1 << (int)(sector % 8))) == 0)
            {
                m_SectorsMap[(int)(sector / 8)] |= (byte)(1 << (int)(sector % 8));
                m_ReceivedSectors++;
            }
            m_LastSentSector = m_LastRequestedSector;
            m_LastRequestedSector = sector;
            m_LastRequest = DateTime.Now;
            m_Uploaded += 32768;
        }

        public Upload(byte[] peerID, byte[] uploadID, byte[] fileHash)
            : this(peerID, uploadID, fileHash, false, String.Empty)
        {
        }

        public Upload(byte[] peerID, byte[] uploadID, byte[] fileHash, bool useDownloadAsSource, string sourceDownloadIDString)
        {
            if (peerID == null)
                throw new ArgumentNullException("peerID");
            if (peerID.Length != 48)
                throw new ArgumentException();
            if (uploadID == null)
                throw new ArgumentNullException("uploadID");
            if (uploadID.Length != 48)
                throw new ArgumentException();
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();

            m_PeerID = peerID;
            m_PeerIDString = Core.ByteArrayToString(m_PeerID);
            m_UploadID = uploadID;
            m_UploadIDString = Core.ByteArrayToString(m_UploadID);
            m_FileHash = fileHash;
            m_FileHashString = Core.ByteArrayToString(m_FileHash);
            m_UseDownloadAsSource = useDownloadAsSource;
            m_SourceDownloadIDString = sourceDownloadIDString;

            if (m_UseDownloadAsSource)
            {
                Download download;
                if (Core.DownloadsAndQueue.TryGetValue(m_SourceDownloadIDString, out download))
                {
                    m_Sectors = download.Sectors;
                    m_SectorsMap = new byte[(m_Sectors / 8) + 1];
                }
            }
            else
            {
                SharedFile sharedFile;
                if (Core.SharedFiles.TryGetValue(m_FileHashString, out sharedFile))
                {
                    m_Sectors = sharedFile.Sectors;
                    m_SectorsMap = new byte[(m_Sectors / 8) + 1];
                }
            }
        }
    }
}