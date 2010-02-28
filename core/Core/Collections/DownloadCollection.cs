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

using Regensburger.RCollections;
using Regensburger.RCollections.ArrayBased;
using System;
using System.Collections.Generic;

namespace Regensburger.RShare
{
    public sealed partial class DownloadCollection
        : IRIndexedDictionary<string, Download>
    {
        private RIndexedHashtable<string, Download> m_DownloadID = new RIndexedHashtable<string, Download>();

        private RHashtable<string, string> m_FileHash = new RHashtable<string, string>();

        private RHashtable<string, string> m_OnceHashedFileHash = new RHashtable<string, string>();

        private RHashtable<string, string> m_ThriceHashedFileHash = new RHashtable<string, string>();

        private RHashtable<string, string> m_TwiceHashedFileHash = new RHashtable<string, string>();

        public int Count
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID.Count;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public bool IsEmpty
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID.IsEmpty;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public bool IsReadOnly
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID.IsReadOnly;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public bool IsSynchronized
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID.IsSynchronized;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public IRCollection<string> Keys
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID.Keys;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public object SyncRoot
        {
            get
            {
                return m_DownloadID.SyncRoot;
            }
        }

        public Download this[string downloadID]
        {
            get
            {
                return this[downloadID, KeyAccess.DownloadID];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public Download this[string key, KeyAccess access]
        {
            get
            {
                try
                {
                    Lock();
                    switch (access)
                    {
                        case KeyAccess.FileHash:
                            return m_DownloadID[m_FileHash[key]];
                        case KeyAccess.OnceHashedFileHash:
                            return m_DownloadID[m_OnceHashedFileHash[key]];
                        case KeyAccess.TwiceHashedFileHash:
                            return m_DownloadID[m_TwiceHashedFileHash[key]];
                        case KeyAccess.ThriceHashedFileHash:
                            return m_DownloadID[m_ThriceHashedFileHash[key]];
                        default:
                            return m_DownloadID[key];
                    }
                }
                finally
                {
                    Unlock();
                }
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public KeyValuePair<string, Download> this[int index]
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID[index];
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public IRCollection<Download> Values
        {
            get
            {
                try
                {
                    Lock();
                    return m_DownloadID.Values;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public void Add(Download download)
        {
            try
            {
                Lock();
                m_DownloadID.Add(download.DownloadIDString, download);
                m_FileHash.Add(download.FileHashString, download.DownloadIDString);
                m_OnceHashedFileHash.Add(download.OnceHashedFileHashString, download.DownloadIDString);
                m_TwiceHashedFileHash.Add(download.TwiceHashedFileHashString, download.DownloadIDString);
                m_ThriceHashedFileHash.Add(download.ThriceHashedFileHashString, download.DownloadIDString);
            }
            finally
            {
                Unlock();
            }
        }

        public void Clear()
        {
            try
            {
                Lock();
                m_DownloadID.Clear();
                m_FileHash.Clear();
                m_OnceHashedFileHash.Clear();
                m_TwiceHashedFileHash.Clear();
                m_ThriceHashedFileHash.Clear();
            }
            finally
            {
                Unlock();
            }
        }

        public bool ContainsKey(string downloadID)
        {
            return ContainsKey(downloadID, KeyAccess.DownloadID);
        }

        public bool ContainsKey(string key, KeyAccess access)
        {
            try
            {
                Lock();
                switch (access)
                {
                    case KeyAccess.FileHash:
                        return m_FileHash.ContainsKey(key);
                    case KeyAccess.OnceHashedFileHash:
                        return m_OnceHashedFileHash.ContainsKey(key);
                    case KeyAccess.TwiceHashedFileHash:
                        return m_TwiceHashedFileHash.ContainsKey(key);
                    case KeyAccess.ThriceHashedFileHash:
                        return m_ThriceHashedFileHash.ContainsKey(key);
                    default:
                        return m_DownloadID.ContainsKey(key);
                }
            }
            finally
            {
                Unlock();
            }
        }

        public bool ContainsValue(Download download)
        {
            try
            {
                Lock();
                return m_DownloadID.ContainsValue(download);
            }
            finally
            {
                Unlock();
            }
        }

        public void CopyTo(KeyValuePair<string, Download>[] array, int arrayIndex)
        {
            try
            {
                Lock();
                m_DownloadID.CopyTo(array, arrayIndex);
            }
            finally
            {
                Unlock();
            }
        }

        public IEnumerator<KeyValuePair<string, Download>> GetEnumerator()
        {
            try
            {
                Lock();
                return m_DownloadID.GetEnumerator();
            }
            finally
            {
                Unlock();
            }
        }

        public int IndexOfKey(string downloadID)
        {
            return IndexOfKey(downloadID, KeyAccess.DownloadID);
        }

        public int IndexOfKey(string key, KeyAccess access)
        {
            try
            {
                Lock();
                string downloadID;
                switch (access)
                {
                    case KeyAccess.FileHash:
                        if (m_FileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.IndexOfKey(downloadID);
                        return -1;
                    case KeyAccess.OnceHashedFileHash:
                        if (m_OnceHashedFileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.IndexOfKey(downloadID);
                        return -1;
                    case KeyAccess.TwiceHashedFileHash:
                        if (m_TwiceHashedFileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.IndexOfKey(downloadID);
                        return -1;
                    case KeyAccess.ThriceHashedFileHash:
                        if (m_ThriceHashedFileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.IndexOfKey(downloadID);
                        return -1;
                    default:
                        return m_DownloadID.IndexOfKey(key);
                }
            }
            finally
            {
                Unlock();
            }
        }

        public int IndexOfValue(Download download)
        {
            try
            {
                Lock();
                return m_DownloadID.IndexOfValue(download);
            }
            finally
            {
                Unlock();
            }
        }

        public void Insert(int index, Download download)
        {
            try
            {
                Lock();
                m_DownloadID.Insert(index, download.DownloadIDString, download);
                m_FileHash.Add(download.FileHashString, download.DownloadIDString);
                m_OnceHashedFileHash.Add(download.OnceHashedFileHashString, download.DownloadIDString);
                m_TwiceHashedFileHash.Add(download.TwiceHashedFileHashString, download.DownloadIDString);
                m_ThriceHashedFileHash.Add(download.ThriceHashedFileHashString, download.DownloadIDString);
            }
            finally
            {
                Unlock();
            }
        }

        public void Lock()
        {
            m_DownloadID.Lock();
        }

        void Regensburger.RCollections.IRIndexedDictionary<string, Download>.Add(string key, Download value)
        {
            throw new NotSupportedException();
        }

        void Regensburger.RCollections.IRIndexedDictionary<string, Download>.Insert(int index, string key, Download value)
        {
            throw new NotSupportedException();
        }

        bool Regensburger.RCollections.IRIndexedDictionary<string, Download>.Remove(string key)
        {
            throw new NotSupportedException();
        }

        public bool Remove(Download download)
        {
            try
            {
                Lock();
                m_ThriceHashedFileHash.Remove(download.ThriceHashedFileHashString);
                m_TwiceHashedFileHash.Remove(download.TwiceHashedFileHashString);
                m_OnceHashedFileHash.Remove(download.OnceHashedFileHashString);
                m_FileHash.Remove(download.FileHashString);
                return m_DownloadID.Remove(download.DownloadIDString);
            }
            finally
            {
                Unlock();
            }
        }

        public void RemoveAt(int index)
        {
            try
            {
                Lock();
                Download download = m_DownloadID[index].Value;
                m_ThriceHashedFileHash.Remove(download.ThriceHashedFileHashString);
                m_TwiceHashedFileHash.Remove(download.TwiceHashedFileHashString);
                m_OnceHashedFileHash.Remove(download.OnceHashedFileHashString);
                m_FileHash.Remove(download.FileHashString);
                m_DownloadID.Remove(download.DownloadIDString);
            }
            finally
            {
                Unlock();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool TryGetValue(string downloadID, out Download download)
        {
            return TryGetValue(downloadID, KeyAccess.DownloadID, out download);
        }

        public bool TryGetValue(string key, KeyAccess access, out Download download)
        {
            try
            {
                Lock();
                string downloadID;
                switch (access)
                {
                    case KeyAccess.FileHash:
                        if (m_FileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.TryGetValue(downloadID, out download);
                        download = null;
                        return false;
                    case KeyAccess.OnceHashedFileHash:
                        if (m_OnceHashedFileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.TryGetValue(downloadID, out download);
                        download = null;
                        return false;
                    case KeyAccess.TwiceHashedFileHash:
                        if (m_TwiceHashedFileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.TryGetValue(downloadID, out download);
                        download = null;
                        return false;
                    case KeyAccess.ThriceHashedFileHash:
                        if (m_ThriceHashedFileHash.TryGetValue(key, out downloadID))
                            return m_DownloadID.TryGetValue(downloadID, out download);
                        download = null;
                        return false;
                    default:
                        return m_DownloadID.TryGetValue(key, out download);
                }
            }
            finally
            {
                Unlock();
            }
        }

        public void Unlock()
        {
            m_DownloadID.Unlock();
        }

        public DownloadCollection()
        {
        }

        public enum KeyAccess
        {
            DownloadID,
            FileHash,
            OnceHashedFileHash,
            TwiceHashedFileHash,
            ThriceHashedFileHash
        }
    }
}