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
    public sealed partial class SharedFileCollection
        : IRIndexedDictionary<string, SharedFile>
    {
        private RIndexedHashtable<string, SharedFile> m_FileHash = new RIndexedHashtable<string, SharedFile>();

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
                    return m_FileHash.Count;
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
                    return m_FileHash.IsEmpty;
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
                    return m_FileHash.IsReadOnly;
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
                    return m_FileHash.IsSynchronized;
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
                    return m_FileHash.Keys;
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
                return m_FileHash.SyncRoot;
            }
        }

        public SharedFile this[string fileHash]
        {
            get
            {
                return this[fileHash, KeyAccess.FileHash];
            }
            set
            {
                this[fileHash, KeyAccess.FileHash] = value;
            }
        }

        public SharedFile this[string key, KeyAccess access]
        {
            get
            {
                try
                {
                    Lock();
                    switch (access)
                    {
                        case KeyAccess.OnceHashedFileHash:
                            return m_FileHash[m_OnceHashedFileHash[key]];
                        case KeyAccess.TwiceHashedFileHash:
                            return m_FileHash[m_TwiceHashedFileHash[key]];
                        case KeyAccess.ThriceHashedFileHash:
                            return m_FileHash[m_ThriceHashedFileHash[key]];
                        default:
                            return m_FileHash[key];
                    }
                }
                finally
                {
                    Unlock();
                }
            }
            set
            {
                try
                {
                    Lock();
                    if (access != KeyAccess.FileHash)
                        throw new NotSupportedException();
                    m_FileHash[key] = value;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public KeyValuePair<string, SharedFile> this[int index]
        {
            get
            {
                try
                {
                    Lock();
                    return m_FileHash[index];
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public IRCollection<SharedFile> Values
        {
            get
            {
                try
                {
                    Lock();
                    return m_FileHash.Values;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public void Add(SharedFile sharedFile)
        {
            try
            {
                Lock();
                m_FileHash.Add(sharedFile.FileHashString, sharedFile);
                m_OnceHashedFileHash.Add(sharedFile.OnceHashedFileHashString, sharedFile.FileHashString);
                m_TwiceHashedFileHash.Add(sharedFile.TwiceHashedFileHashString, sharedFile.FileHashString);
                m_ThriceHashedFileHash.Add(sharedFile.ThriceHashedFileHashString, sharedFile.FileHashString);
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

        public bool ContainsKey(string fileHash)
        {
            return ContainsKey(fileHash, KeyAccess.FileHash);
        }

        public bool ContainsKey(string key, KeyAccess access)
        {
            try
            {
                Lock();
                switch (access)
                {
                    case KeyAccess.OnceHashedFileHash:
                        return m_OnceHashedFileHash.ContainsKey(key);
                    case KeyAccess.TwiceHashedFileHash:
                        return m_TwiceHashedFileHash.ContainsKey(key);
                    case KeyAccess.ThriceHashedFileHash:
                        return m_ThriceHashedFileHash.ContainsKey(key);
                    default:
                        return m_FileHash.ContainsKey(key);
                }
            }
            finally
            {
                Unlock();
            }
        }

        public bool ContainsValue(SharedFile sharedFile)
        {
            try
            {
                Lock();
                return m_FileHash.ContainsValue(sharedFile);
            }
            finally
            {
                Unlock();
            }
        }

        public void CopyTo(KeyValuePair<string, SharedFile>[] array, int arrayIndex)
        {
            try
            {
                Lock();
                m_FileHash.CopyTo(array, arrayIndex);
            }
            finally
            {
                Unlock();
            }
        }

        public IEnumerator<KeyValuePair<string, SharedFile>> GetEnumerator()
        {
            try
            {
                Lock();
                return m_FileHash.GetEnumerator();
            }
            finally
            {
                Unlock();
            }
        }

        public int IndexOfKey(string fileHash)
        {
            return IndexOfKey(fileHash, KeyAccess.FileHash);
        }

        public int IndexOfKey(string key, KeyAccess access)
        {
            try
            {
                Lock();
                string fileHash;
                switch (access)
                {
                    case KeyAccess.OnceHashedFileHash:
                        if (m_OnceHashedFileHash.TryGetValue(key, out fileHash))
                            return m_FileHash.IndexOfKey(fileHash);
                        return -1;
                    case KeyAccess.TwiceHashedFileHash:
                        if (m_TwiceHashedFileHash.TryGetValue(key, out fileHash))
                            return m_FileHash.IndexOfKey(fileHash);
                        return -1;
                    case KeyAccess.ThriceHashedFileHash:
                        if (m_ThriceHashedFileHash.TryGetValue(key, out fileHash))
                            return m_FileHash.IndexOfKey(fileHash);
                        return -1;
                    default:
                        return m_FileHash.IndexOfKey(key);
                }
            }
            finally
            {
                Unlock();
            }
        }

        public int IndexOfValue(SharedFile sharedFile)
        {
            try
            {
                Lock();
                return m_FileHash.IndexOfValue(sharedFile);
            }
            finally
            {
                Unlock();
            }
        }

        public void Insert(int index, SharedFile sharedFile)
        {
            try
            {
                Lock();
                m_FileHash.Insert(index, sharedFile.FileHashString, sharedFile);
                m_OnceHashedFileHash.Add(sharedFile.OnceHashedFileHashString, sharedFile.FileHashString);
                m_TwiceHashedFileHash.Add(sharedFile.TwiceHashedFileHashString, sharedFile.FileHashString);
                m_ThriceHashedFileHash.Add(sharedFile.ThriceHashedFileHashString, sharedFile.FileHashString);
            }
            finally
            {
                Unlock();
            }
        }

        public void Lock()
        {
            m_FileHash.Lock();
        }

        void Regensburger.RCollections.IRIndexedDictionary<string, SharedFile>.Add(string key, SharedFile value)
        {
            throw new NotSupportedException();
        }

        void Regensburger.RCollections.IRIndexedDictionary<string, SharedFile>.Insert(int index, string key, SharedFile value)
        {
            throw new NotSupportedException();
        }

        bool Regensburger.RCollections.IRIndexedDictionary<string, SharedFile>.Remove(string key)
        {
            throw new NotSupportedException();
        }

        public bool Remove(SharedFile sharedFile)
        {
            try
            {
                Lock();
                m_ThriceHashedFileHash.Remove(sharedFile.ThriceHashedFileHashString);
                m_TwiceHashedFileHash.Remove(sharedFile.TwiceHashedFileHashString);
                m_OnceHashedFileHash.Remove(sharedFile.OnceHashedFileHashString);
                return m_FileHash.Remove(sharedFile.FileHashString);
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
                SharedFile sharedFile = m_FileHash[index].Value;
                m_ThriceHashedFileHash.Remove(sharedFile.ThriceHashedFileHashString);
                m_TwiceHashedFileHash.Remove(sharedFile.TwiceHashedFileHashString);
                m_OnceHashedFileHash.Remove(sharedFile.OnceHashedFileHashString);
                m_FileHash.Remove(sharedFile.FileHashString);
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

        public bool TryGetValue(string fileHash, out SharedFile sharedFile)
        {
            return TryGetValue(fileHash, KeyAccess.FileHash, out sharedFile);
        }

        public bool TryGetValue(string key, KeyAccess access, out SharedFile sharedFile)
        {
            try
            {
                Lock();
                string fileHash;
                switch (access)
                {
                    case KeyAccess.OnceHashedFileHash:
                        if (m_OnceHashedFileHash.TryGetValue(key, out fileHash))
                            return m_FileHash.TryGetValue(fileHash, out sharedFile);
                        sharedFile = null;
                        return false;
                    case KeyAccess.TwiceHashedFileHash:
                        if (m_TwiceHashedFileHash.TryGetValue(key, out fileHash))
                            return m_FileHash.TryGetValue(fileHash, out sharedFile);
                        sharedFile = null;
                        return false;
                    case KeyAccess.ThriceHashedFileHash:
                        if (m_ThriceHashedFileHash.TryGetValue(key, out fileHash))
                            return m_FileHash.TryGetValue(fileHash, out sharedFile);
                        sharedFile = null;
                        return false;
                    default:
                        return m_FileHash.TryGetValue(key, out sharedFile);
                }
            }
            finally
            {
                Unlock();
            }
        }

        public void Unlock()
        {
            m_FileHash.Unlock();
        }

        public SharedFileCollection()
        {
        }

        public enum KeyAccess
        {
            FileHash,
            OnceHashedFileHash,
            TwiceHashedFileHash,
            ThriceHashedFileHash
        }
    }
}