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

using Regensburger.RCollections.ArrayBased;
using System;

namespace Regensburger.RShare
{
    partial class ShareManager
    {
        private class MetaDataEntry
        {
            private string m_Comment = string.Empty;

            private RIndexedHashtable<string, string> m_MetaData = new RIndexedHashtable<string, string>();

            private DateTime? m_LastRequest;

            private byte m_Rating = 0;

            public string Comment
            {
                get
                {
                    return m_Comment;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");

                    m_Comment = value;
                }
            }

            public RIndexedHashtable<string, string> MetaData
            {
                get
                {
                    return m_MetaData;
                }
            }

            public DateTime? LastRequest
            {
                get
                {
                    return m_LastRequest;
                }
                set
                {
                    m_LastRequest = value;
                }
            }

            public byte Rating
            {
                get
                {
                    return m_Rating;
                }
                set
                {
                    if (value > 3)
                        throw new ArgumentOutOfRangeException("value");

                    m_Rating = value;
                }
            }

            public MetaDataEntry()
            {
            }
        }
    }
}
