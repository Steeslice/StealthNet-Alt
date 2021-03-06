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
        private class SearchToStart
        {
            private string m_SearchID;
            private string m_Pattern;

            public SearchToStart(string searchID, string pattern)
            {
                m_SearchID = searchID;
                m_Pattern = pattern;
            }

            public string SearchID
            {
                get
                {
                    return m_SearchID;
                }
            }

            public string Pattern
            {
                get
                {
                    return m_Pattern;
                }
            }
        }
    }
}
