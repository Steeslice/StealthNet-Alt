//RShare
//Copyright (C) 2006 Lars Regensburger

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
    partial class Search
    {
        partial class Result
        {
            public sealed class Source
            {
                volatile private string m_Comment;

                volatile private string m_FileName;

                volatile private byte[] m_ID;

                volatile private string m_IDString;

                volatile private SearchResultSourceMetaDataCollection m_MetaData;

                volatile private byte m_Rating;

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

                public byte[] ID
                {
                    get
                    {
                        return m_ID;
                    }
                }

                public string IDString
                {
                    get
                    {
                        return m_IDString;
                    }
                }

                public SearchResultSourceMetaDataCollection MetaData
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

                public void ReportReceived(string fileName, string comment, byte rating)
                {
                    if (fileName == null)
                        throw new ArgumentNullException("fileName");
                    if (comment == null)
                        throw new ArgumentNullException("comment");
                    if (rating > 3)
                        throw new ArgumentOutOfRangeException("rating");

                    m_FileName = fileName;
                    m_Comment = comment;
                    m_Rating = rating;
                }

                public Source(SearchResultSourceCollection sources, byte[] id, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating)
                {
                    if (sources == null)
                        throw new ArgumentNullException("sources");
                    if (id == null)
                        throw new ArgumentNullException("id");
                    if (id.Length != 48)
                        throw new ArgumentException();
                    if (fileName == null)
                        throw new ArgumentNullException("fileName");
                    if (metaData == null)
                        throw new ArgumentNullException("metaData");
                    if (comment == null)
                        throw new ArgumentNullException("comment");
                    if (rating > 3)
                        throw new ArgumentOutOfRangeException("rating");

                    m_MetaData = new SearchResultSourceMetaDataCollection(sources, metaData);
                    m_ID = id;
                    m_IDString = Core.ByteArrayToString(m_ID);
                    m_FileName = fileName;
                    m_Comment = comment;
                    m_Rating = rating;
                }
            }
        }
    }
}