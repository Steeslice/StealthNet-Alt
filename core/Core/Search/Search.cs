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

using Regensburger.RCollections;
using Regensburger.RCollections.ArrayBased;
using System;
using System.Collections.Generic;

namespace Regensburger.RShare
{
    public sealed partial class Search
    {
        //2009-01-31 Nochbaer
        public enum SearchType { Auto, OnlyDatabase, OnlyNetwork };

        //2009-01-25 Nochbaer
        private bool m_GotSearchDBResults = false;

        private FileType m_FileTypeFilter;

        private DateTime m_LastSent = DateTime.MinValue;

        private SearchResultCollection m_Results;

        private int m_SearchCommandsToSent = Constants.Command20ToSend;

        //2009-01-25 Nochbaer
        private bool m_SearchedInDatabase = false;

        private byte[] m_SearchFloodingHash;

        private byte[] m_SearchID;

        private string m_SearchIDString;

        private string m_SearchPattern;

        private byte[] m_SearchPeerID;

        //2009-01-31 Nochbaer
        private SearchType m_SearchType;

        //2009-05-21 Eroli
        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_TooManySearchDBResults = false;

        private int m_TotalSearchDBResults = 0;

        public bool IsActive
        {
            get
            {
                return m_SearchCommandsToSent > 0;
            }
        }

        public RIndexedHashtable<string, Result> Results
        {
            get
            {
                return m_Results;
            }
        }

        public byte[] SearchID
        {
            get
            {
                return m_SearchID;
            }
        }

        public string SearchIDString
        {
            get
            {
                return m_SearchIDString;
            }
        }

        public string SearchPattern
        {
            get
            {
                return m_SearchPattern;
            }
        }

        public byte[] SearchPeerID
        {
            get
            {
                return m_SearchPeerID;
            }
        }

        //2009-01-31 Nochbaer
        public bool TooManySearchDBResults
        {
            get
            {
                return m_TooManySearchDBResults;
            }
        }

        public int TotalSearchDBResults
        {
            get
            {
                return m_TotalSearchDBResults;
            }
        }

        public void AddResult(byte[] fileHash, long fileSize, byte[] id, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating)
        {
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
                throw new ArgumentOutOfRangeException("rating");

            try
            {
                m_Results.Lock();
                // 2007-05-27 T.Norad
                if (m_FileTypeFilter.Contains(fileName))
                {
                    string fileHashString = Core.ByteArrayToString(fileHash);

                    //2009-01-25 Nochbaer
                    if (!m_Results.ContainsKey(fileHashString))
                    {
                        m_Results.Add(fileHashString, new Result(m_Results, fileHash, fileSize, id, fileName, metaData, comment, rating));
                    }
                    else
                    {
                        if (m_Results[fileHashString].IsSearchDBResult)
                        {
                            m_Results.Remove(fileHashString);
                            m_Results.Add(fileHashString, new Result(m_Results, fileHash, fileSize, id, fileName, metaData, comment, rating));
                        }
                        else
                        {
                            m_Results[fileHashString].AddSource(id, fileName, metaData, comment, rating);
                        }
                    }
                }
            }
            finally
            {
                m_Results.Unlock();
            }
        }

        public void Process()
        {
            //2009-01-25 Nochbaer
            bool activateSearchDB = bool.Parse(m_Settings["ActivateSearchDB"]);
            if (!m_SearchedInDatabase && activateSearchDB && m_SearchType != SearchType.OnlyNetwork)
            {
                Core.AddSearchDBSearch(m_SearchIDString, m_SearchPattern);
                m_SearchedInDatabase = true;

                if (m_SearchType == SearchType.OnlyDatabase)
                {
                    m_SearchCommandsToSent = 0;
                }
            }
            else if (m_SearchedInDatabase && !m_GotSearchDBResults)
            {
                try
                {
                    m_Results.Lock();

                    RIndexedHashtable<string, SearchDBManager.OldSearchResult> searchdbResults = Core.GetSearchDBResults(m_SearchIDString);

                    if (searchdbResults != null)
                    {
                        int maxSearchDBResults = int.Parse(m_Settings["MaxSearchDBResults"]);
                        m_TotalSearchDBResults = searchdbResults.Count;

                        int resultCounter = 0;
                        foreach (SearchDBManager.OldSearchResult result in searchdbResults.Values)
                        {
                            if (m_FileTypeFilter.Contains(result.FileName))
                            {
                                if (!m_Results.ContainsKey(result.FileHashString))
                                {
                                    //2009-01-31 Nochbaer
                                    if (resultCounter >= maxSearchDBResults)
                                    {
                                        m_TooManySearchDBResults = true;
                                        break;
                                    }

                                    RIndexedHashtable<string, string> metaData = new RIndexedHashtable<string, string>();
                                    metaData.Add("Album", result.Album);
                                    metaData.Add("Artist", result.Artist);
                                    metaData.Add("Title", result.Title);
                                    m_Results.Add(result.FileHashString, new Result(m_Results, result.FileHash, result.FileSize, Core.GenerateIDOrHash(), result.FileName, metaData, string.Empty, result.Rating, true, result.Date));
                                    
                                    resultCounter++;
                                }
                            }
                        }

                        //Compare the results after filetypefilter
                        if (m_Results.Count >= 25)
                        {
                            m_SearchCommandsToSent = 0;
                        }

                        m_GotSearchDBResults = true;
                    }
                }
                finally
                {
                    m_Results.Unlock();
                }
            }
            else if (!activateSearchDB || m_SearchType == SearchType.OnlyNetwork)
            {
                m_SearchedInDatabase = true;
                m_GotSearchDBResults = true;
            }

            if (m_SearchedInDatabase && m_GotSearchDBResults && m_SearchCommandsToSent > 0 && DateTime.Now.Subtract(m_LastSent).TotalSeconds >= Constants.Command20Interval)
            {
                Core.SendCommand20(m_SearchFloodingHash, m_SearchPeerID, m_SearchID, m_SearchPattern);
                m_LastSent = DateTime.Now;
                m_SearchCommandsToSent--;
            }
        }

        public void Restart()
        {
            if (m_SearchCommandsToSent > 0)
                return;
            m_SearchCommandsToSent = Constants.Command20ToSend;
        }

        public void Stop()
        {
            if (m_SearchCommandsToSent == 0)
                return;
            m_SearchCommandsToSent = 0;
        }

        public Search(string searchPattern, FileType fileTypeFilter)
            : this(searchPattern, fileTypeFilter, SearchType.Auto)
        {
        }

        public Search(string searchPattern, FileType fileTypeFilter, SearchType searchType)
        {
            if (searchPattern == null)
                throw new ArgumentNullException("searchPattern");
            if (searchPattern.Length < 3)
                throw new ArgumentException();
            if (fileTypeFilter == null)
            {
                throw new ArgumentNullException("fileTypeFilter");
            }

            m_Results = new SearchResultCollection(Core.Searches);
            // 2007-05-27 T.Norad
            m_FileTypeFilter = fileTypeFilter;
            m_SearchPattern = searchPattern;
            m_SearchFloodingHash = Core.GenerateFloodingHash();
            m_SearchPeerID = Core.GenerateIDOrHash();
            m_SearchID = Core.GenerateIDOrHash();
            m_SearchIDString = Core.ByteArrayToString(m_SearchID);
            m_SearchType = searchType;
        }

        /* contains the file type object to filter results */
    }
}