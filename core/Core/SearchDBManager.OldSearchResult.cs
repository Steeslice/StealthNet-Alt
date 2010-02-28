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
    public partial class SearchDBManager
    {
        public class OldSearchResult
        {
            private byte[] m_FileHash;

            private string m_FileHashString;

            private long m_FileSize;

            private string m_FileName;

            private string m_Album;

            private string m_Artist;

            private string m_Title;

            private byte m_Rating;

            private DateTime m_Date;

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

            public long FileSize
            {
                get
                {
                    return m_FileSize;
                }
            }

            public string FileName
            {
                get
                {
                    return m_FileName;
                }
            }

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

            public string Title
            {
                get
                {
                    return m_Title;
                }
            }

            public byte Rating
            {
                get
                {
                    return m_Rating;
                }
            }

            public DateTime Date
            {
                get
                {
                    return m_Date;
                }
            }

            public OldSearchResult(byte[] fileHash, long fileSize, string fileName, string album, string artist, string title, byte rating, DateTime date)
            {
                if (fileHash == null)
                    throw new ArgumentNullException("fileHash");
                if (fileHash.Length != 64)
                    throw new ArgumentException();
                if (fileSize < 0)
                    throw new ArgumentOutOfRangeException("fileSize");
                if (fileName == null)
                    throw new ArgumentNullException("fileName");
                if (album == null)
                    throw new ArgumentNullException("album");
                if (artist == null)
                    throw new ArgumentNullException("artist");
                if (title == null)
                    throw new ArgumentNullException("title");
                if (rating > 3)
                    throw new ArgumentOutOfRangeException("rating");
                
				// [MONO] date (System.DateTime) is compared with null always 'false' 
				/*
				if (date == null)
                    throw new ArgumentNullException("date");
                */

                m_FileHash = fileHash;
                m_FileHashString = Core.ByteArrayToString(m_FileHash);
                m_FileSize = fileSize;
                m_FileName = fileName;
                m_Album = album;
                m_Artist = artist;
                m_Title = title;
                m_Rating = rating;
                m_Date = date;
            }
        }
    }
}