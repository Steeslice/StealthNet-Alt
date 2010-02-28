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
    public partial class Command23
    {
        public sealed class SearchResult
        {
            private string m_Comment;

            private byte[] m_FileHash;

            private string m_FileName;

            private uint m_FileSize;

            private RIndexedHashtable<string, string> m_MetaData;

            private byte m_Rating;

            public string Comment
            {
                get
                {
                    return m_Comment;
                }
            }

            public byte[] FileHash
            {
                get
                {
                    return m_FileHash;
                }
            }

            public string FileName
            {
                get
                {
                    return m_FileName;
                }
            }

            public uint FileSize
            {
                get
                {
                    return m_FileSize;
                }
            }

            public RIndexedHashtable<string, string> MetaData
            {
                get
                {
                    return m_MetaData;
                }
            }

            public byte Rating
            {
                get
                {
                    return m_Rating;
                }
            }

            public SearchResult(byte[] fileHash, uint fileSize, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating)
            {
                if (fileHash == null)
                    throw new ArgumentNullException("fileHash");
                if (fileHash.Length != 64)
                    throw new ArgumentException();
                if (fileName == null)
                    throw new ArgumentNullException("fileName");
                if (metaData == null)
                    throw new ArgumentNullException("metaData");
                if (comment == null)
                    throw new ArgumentNullException("comment");
                if (rating > 3)
                    throw new ArgumentOutOfRangeException("rating");

                m_FileHash = fileHash;
                m_FileSize = fileSize;
                m_FileName = fileName;
                m_MetaData = metaData;
                m_Comment = comment;
                m_Rating = rating;
            }
        }
    }
}