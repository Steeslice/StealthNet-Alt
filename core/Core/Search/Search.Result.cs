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

namespace Regensburger.RShare
{
    partial class Search
    {
        public sealed partial class Result
        {
            private string m_Album;

            private string m_Artist;

            //2009-01-29 Nochbaer
            private DateTime m_Date;

            private byte[] m_FileHash;

            private string m_FileHashString;

            private string m_FileName;

            private long m_FileSize;

            private string m_FileSizeString;

            //2009-01-25 Nochbaer
            private bool m_IsSearchDBResult;

            private SearchResultMetaDataCollection m_MetaData;

            private byte m_Rating;

            private SearchResultSourceCollection m_Sources;

            private string m_Title;

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

            //2009-01-29 Nochbaer
            public DateTime Date
            {
                get
                {
                    return m_Date;
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

            //2009-01-25 Nochbaer
            public bool IsSearchDBResult
            {
                get { return m_IsSearchDBResult; }
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

            public SearchResultSourceCollection Sources
            {
                get
                {
                    //2009-01-25 Nochbaer
                    if (m_IsSearchDBResult)
                    {
                        // T.Norad: BZ116.
                        // return no new object of SearchResultSourceCollection in case of searchDB result
                        // cause the previous lock is done on the m_Sources object
                        // so we use the same object and remove all sources from it
                        for (int i = 0; i < m_Sources.Count; i++)
                        {
                            m_Sources.RemoveAt(0);
                        }

                        return m_Sources;
                    }
                    else
                    {
                        return m_Sources;
                    }
                }
            }

            public string Title
            {
                get
                {
                    return m_Title;
                }
            }

            public void AddSource(byte[] id, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating)
            {
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

                try
                {
                    m_Sources.Lock();
                    string idString = Core.ByteArrayToString(id);
                    if (!m_Sources.ContainsKey(idString))
                        m_Sources.Add(idString, new Source(m_Sources, id, fileName, metaData, comment, rating));
                    else
                        m_Sources[idString].ReportReceived(fileName, comment, rating);
                    RIndexedHashtable<string, int> fileNames1 = new RIndexedHashtable<string, int>();
                    RIndexedHashtable<byte, int> ratings1 = new RIndexedHashtable<byte, int>();
                    foreach (Source source in m_Sources.Values)
                    {
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
                    m_FileName = fileNames2[0];
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
                }
                finally
                {
                    m_Sources.Unlock();
                }
            }

            //2009-01-25 Nochbaer
            public Result(SearchResultCollection parent, byte[] fileHash, long fileSize, byte[] id, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating)
                : this(parent, fileHash, fileSize, id, fileName, metaData, comment, rating, false, DateTime.Now)
            {
            }

            public Result(SearchResultCollection parent, byte[] fileHash, long fileSize, byte[] id, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating, bool isSearchDBResult, DateTime date)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");
                if (fileHash == null)
                    throw new ArgumentNullException("fileHash");
                if (fileHash.Length != 64)
                    throw new ArgumentException();
                if (fileSize < 0)
                    throw new ArgumentOutOfRangeException("fileSize");
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
                    throw new ArgumentNullException("rating");

                m_Sources = new SearchResultSourceCollection(parent);
                m_MetaData = new SearchResultMetaDataCollection(parent);
                m_FileHash = fileHash;
                m_FileHashString = Core.ByteArrayToString(m_FileHash);
                m_FileSize = fileSize;
                m_FileSizeString = Core.LengthToString(m_FileSize);
                //2009-01-25 Nochbaer
                m_IsSearchDBResult = isSearchDBResult;
                //2009-01-29 Nochbaer
                m_Date = date;

                AddSource(id, fileName, metaData, comment, rating);
            }
        }
    }
}