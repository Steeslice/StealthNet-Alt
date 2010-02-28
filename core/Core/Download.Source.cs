//RShare
//Copyright (C) 2009 Lars Regensburger

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
    partial class Download
    {
        /// <summary>
        /// Diese Klasse repräsentiert eine Quelle des Downloads.
        /// 
        /// Alle Informationen wie bekannte Daten über die Quelle oder auch
        /// Informationen über die empfangenen oder versendeten Kommandos sind
        /// hier zusammengefasst.
        /// </summary>
        public sealed class Source
        {
            private int m_Command70Sent = 0;

            private int m_Command74Sent = 0;

            private int m_Command78Sent = 0;

            private string m_Comment = string.Empty;

            private string m_FileName = string.Empty;

            private bool m_HasInformation = false;

            private bool m_IsQueueFull = false;

            private DateTime m_LastCommand70Sent = DateTime.MinValue;

            private DateTime m_LastCommand74Sent = DateTime.MinValue;

            private DateTime m_LastCommand78Sent = DateTime.MinValue;

            private DateTime m_LastReceived = DateTime.Now;

            private long m_LastReceivedSector = -1;

            private long m_LastRequestedSector = -1;

            private DownloadSourceMetaDataCollection m_MetaData;

            private byte[] m_PeerID;

            private string m_PeerIDString;

            private int m_QueueLength = -1;

            private int m_QueuePosition = -1;

            private byte m_Rating = 0;

            private long m_ReceivedCommands = 0;

            private byte[] m_SectorsMap;

            private long m_SentCommands = 0;

            private SourceState m_State = SourceState.Verifying;

            public int Command70Sent
            {
                get
                {
                    return m_Command70Sent;
                }
            }

            public int Command74Sent
            {
                get
                {
                    return m_Command74Sent;
                }
            }

            public int Command78Sent
            {
                get
                {
                    return m_Command78Sent;
                }
            }

            public string Comment
            {
                get
                {
                    return m_Comment;
                }
            }

            public string FileName
            {
                get
                {
                    return m_FileName;
                }
            }

            public bool HasInformation
            {
                get
                {
                    return m_HasInformation;
                }
            }

            public bool IsComplete
            {
                get
                {
                    return m_SectorsMap == null;
                }
            }

            public bool IsQueueFull
            {
                get
                {
                    return m_IsQueueFull;
                }
            }

            public DateTime LastCommand70Sent
            {
                get
                {
                    return m_LastCommand70Sent;
                }
            }

            public DateTime LastCommand74Sent
            {
                get
                {
                    return m_LastCommand74Sent;
                }
            }

            public DateTime LastCommand78Sent
            {
                get
                {
                    return m_LastCommand78Sent;
                }
            }

            public DateTime LastReceived
            {
                get
                {
                    return m_LastReceived;
                }
            }

            public long LastReceivedSector
            {
                get
                {
                    return m_LastReceivedSector;
                }
            }

            public long LastRequestedSector
            {
                get
                {
                    return m_LastRequestedSector;
                }
            }

            public RIndexedHashtable<string, string> MetaData
            {
                get
                {
                    return m_MetaData;
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

            public int QueueLength
            {
                get
                {
                    return m_QueueLength;
                }
            }

            public int QueuePosition
            {
                get
                {
                    return m_QueuePosition;
                }
            }

            public byte Rating
            {
                get
                {
                    return m_Rating;
                }
            }

            public long ReceivedCommands
            {
                get
                {
                    return m_ReceivedCommands;
                }
            }

            public byte[] SectorsMap
            {
                get
                {
                    return m_SectorsMap;
                }
            }

            public long SentCommands
            {
                get
                {
                    return m_SentCommands;
                }
            }

            public SourceState State
            {
                get
                {
                    return m_State;
                }
            }

            public bool HasSector(long sector)
            {
                if (m_SectorsMap != null)
                    return ((m_SectorsMap[(sector / 8)] & (1 << (int)(sector % 8))) != 0);
                return true;
            }

            public void Report5354Received(string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating, byte[] sectorsMap)
            {
                if (fileName == null)
                    throw new ArgumentNullException("fileName");
                if (metaData == null)
                    throw new ArgumentNullException("metaData");
                if (comment == null)
                    throw new ArgumentNullException("comment");
                if (rating > 3)
                    throw new ArgumentOutOfRangeException("rating");

                m_FileName = fileName;
                m_MetaData = new DownloadSourceMetaDataCollection(m_MetaData.Parent, metaData);
                m_Comment = comment;
                m_Rating = rating;
                m_SectorsMap = sectorsMap;
                m_HasInformation = true;
                m_LastReceived = DateTime.Now;
            }

            public void Report6364Received(byte[] sectorsMap)
            {
                m_SectorsMap = sectorsMap;
                m_LastReceived = DateTime.Now;
            }

            public void Report70Sent()
            {
                m_SentCommands++;
                m_Command70Sent++;
                m_LastCommand70Sent = DateTime.Now;
            }

            public void Report71Received(int queueLength)
            {
                if (queueLength < 0)
                    throw new ArgumentOutOfRangeException("queueLength");

                if (m_State == SourceState.Verifying)
                    SetState(SourceState.Verified);
                m_ReceivedCommands++;
                m_QueueLength = queueLength;
                m_IsQueueFull = false;
                m_LastReceived = DateTime.Now;
                m_Command70Sent = 0;
            }

            public void Report72Received()
            {
                if (m_State == SourceState.Verifying)
                    SetState(SourceState.Verified);
                m_ReceivedCommands++;
                m_QueueLength = -1;
                m_IsQueueFull = true;
                m_LastReceived = DateTime.Now;
                m_Command70Sent = 0;
            }

            public void Report74Sent()
            {
                if (m_State == SourceState.Verified)
                    SetState(SourceState.Requesting);
                m_SentCommands++;
                m_Command74Sent++;
                m_LastCommand74Sent = DateTime.Now;
            }

            public void Report75Received(int queuePosition)
            {
                if (queuePosition < 0)
                    throw new ArgumentOutOfRangeException("queuePosition");

                if (m_State == SourceState.Requesting || m_State == SourceState.Active)
                    SetState(SourceState.Requested);
                m_ReceivedCommands++;
                m_QueuePosition = queuePosition;
                m_IsQueueFull = false;
                m_LastReceived = DateTime.Now;
                m_Command74Sent = 0;
            }

            public void Report76Received()
            {
                if (m_State == SourceState.Requesting || m_State == SourceState.Active)
                    SetState(SourceState.Verified);
                m_ReceivedCommands++;
                m_QueuePosition = -1;
                m_IsQueueFull = true;
                m_LastReceived = DateTime.Now;
                m_Command74Sent = 0;
            }

            public void Report78Sent(long sector)
            {
                if (sector < 0)
                    throw new ArgumentOutOfRangeException("sector");

                if (m_State == SourceState.Requested)
                    SetState(SourceState.Active);
                m_SentCommands++;
                m_LastRequestedSector = sector;
                m_Command78Sent++;
                m_LastCommand78Sent = DateTime.Now;
            }

            public void Report79Received(long sector)
            {
                if (sector < 0)
                    throw new ArgumentOutOfRangeException("sector");

                m_ReceivedCommands++;
                m_LastReceivedSector = sector;
                m_LastReceived = DateTime.Now;
                m_Command78Sent = 0;
            }

            public void ReportTimeout()
            {
                SetState(SourceState.Verifying);
            }

            public void SetState(SourceState state)
            {
                if (m_State == state)
                    return;
                m_State = state;
                switch (m_State)
                {
                    case SourceState.Verifying:
                        m_LastReceivedSector = m_LastRequestedSector = -1;
                        m_LastCommand74Sent = m_LastCommand78Sent = DateTime.MinValue;
                        m_Command74Sent = m_Command78Sent = 0;
                        m_QueueLength = m_QueuePosition = -1;
                        m_IsQueueFull = false;
                        break;
                    case SourceState.Verified:
                    case SourceState.Requesting:
                        m_LastReceivedSector = m_LastRequestedSector = -1;
                        m_LastCommand74Sent = m_LastCommand78Sent = DateTime.MinValue;
                        m_Command74Sent = m_Command78Sent = 0;
                        m_QueuePosition = -1;
                        break;
                    case SourceState.Requested:
                        m_LastReceivedSector = m_LastRequestedSector = -1;
                        m_LastCommand78Sent = DateTime.MinValue;
                        m_Command78Sent = 0;
                        break;
                    case SourceState.NotNeeded:
                        m_LastReceivedSector = m_LastRequestedSector = -1;
                        m_LastCommand70Sent = m_LastCommand74Sent = m_LastCommand78Sent = DateTime.MinValue;
                        m_Command70Sent = m_Command74Sent = m_Command78Sent = 0;
                        m_QueueLength = m_QueuePosition = -1;
                        m_IsQueueFull = false;
                        break;
                }
            }

            public Source(DownloadSourceCollection parent, byte[] peerID, byte[] sectorsMap)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");
                if (peerID == null)
                    throw new ArgumentNullException("peerID");
                if (peerID.Length != 48)
                    throw new ArgumentException();

                m_MetaData = new DownloadSourceMetaDataCollection(parent);
                m_PeerID = peerID;
                m_PeerIDString = Core.ByteArrayToString(m_PeerID);
                m_SectorsMap = sectorsMap;
            }

            public Source(DownloadSourceCollection parent, byte[] peerID, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating, byte[] sectorsMap)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");
                if (peerID == null)
                    throw new ArgumentNullException("peerID");
                if (peerID.Length != 48)
                    throw new ArgumentException();
                if (fileName == null)
                    throw new ArgumentNullException("fileName");
                if (metaData == null)
                    throw new ArgumentNullException("metaData");
                if (comment == null)
                    throw new ArgumentNullException("comment");
                if (rating > 3)
                    throw new ArgumentOutOfRangeException("rating");

                m_MetaData = new DownloadSourceMetaDataCollection(parent, metaData);
                m_PeerID = peerID;
                m_PeerIDString = Core.ByteArrayToString(m_PeerID);
                m_FileName = fileName;
                m_MetaData = new DownloadSourceMetaDataCollection(parent, metaData);
                m_Comment = comment;
                m_Rating = rating;
                m_SectorsMap = sectorsMap;
                m_HasInformation = true;
            }
        }
    }
}