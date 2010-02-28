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

using System;

namespace Regensburger.RShare
{
    partial class ShareManager
    {
        private class SharedFileEntry
        {
            private byte[] m_FileHash;

            private string m_FilePath;

            private DateTime m_LastWriteTime;

            public byte[] FileHash
            {
                get
                {
                    return m_FileHash;
                }
            }

            public string FilePath
            {
                get
                {
                    return m_FilePath;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");

                    m_FilePath = value;
                }
            }

            public DateTime LastWriteTime
            {
                get
                {
                    return m_LastWriteTime;
                }
            }

            public SharedFileEntry(string filePath, byte[] fileHash, DateTime lastWriteTime)
            {
                if (filePath == null)
                    throw new ArgumentNullException("filePath");
                if (fileHash == null)
                    throw new ArgumentNullException("fileHash");
                if (fileHash.Length != 64)
                    throw new ArgumentException();

                m_FilePath = filePath;
                m_FileHash = fileHash;
                m_LastWriteTime = lastWriteTime;
            }
        }
    }
}