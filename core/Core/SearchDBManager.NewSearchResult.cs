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
    partial class SearchDBManager
    {
        private class NewSearchResult
        {
            byte[] m_FileHash;
            long m_FileSize;
            string[] m_FileNames;
            string m_Album = "";
            string m_Artist = "";
            string m_Title = "";
            byte m_Rating;

            public byte[] FileHash
            {
                get { return m_FileHash; }
            }

            public long FileSize
            {
                get { return m_FileSize; }
            }

            public string[] FileNames
            {
                get { return m_FileNames; }
            }

            public string Album
            {
                get { return m_Album; }
            }

            public string Artist
            {
                get { return m_Artist; }
            }

            public string Title
            {
                get { return m_Title; }
            }

            public byte Rating
            {
                get { return m_Rating; }
            }

            public void AddFileName(string filename)
            {
                bool existsAlready = false;

                for (int i = 0; i < m_FileNames.Length; i++)
                {
                    if (m_FileNames[i] == filename)
                    {
                        existsAlready = true;
                        break;
                    }
                }

                if (!existsAlready)
                {
                    string[] tempArray = new string[m_FileNames.Length + 1];
                    for (int i = 0; i < m_FileNames.Length; i++)
                    {
                        tempArray[i] = m_FileNames[i];
                    }
                    tempArray[m_FileNames.Length] = filename;
                    m_FileNames = tempArray;
                }
            }

            public NewSearchResult(Command23.SearchResult result)
            {
                m_FileHash = result.FileHash;
                m_FileSize = result.FileSize;
                m_FileNames = new string[1];
                m_FileNames[0] = result.FileName;
                Core.ParseMetaData(result.MetaData, out m_Album, out m_Artist, out m_Title);
                m_Rating = result.Rating;
            }
        }
    }
}