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
    public sealed class SearchResultSourceCollection
        : RIndexedHashtable<string, Search.Result.Source>
    {
        private bool m_IsReady = false;

        private SearchResultCollection m_Parent;

        public bool IsReady
        {
            get
            {
                return m_IsReady;
            }
        }

        public SearchResultCollection Parent
        {
            get
            {
                return m_Parent;
            }
        }

        public SearchResultSourceCollection(SearchResultCollection parent)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");

            m_Parent = parent;
            m_IsReady = true;
        }

        public override void Lock()
        {
            if (m_IsReady)
                m_Parent.Lock();
            base.Lock();
        }

        public override void Unlock()
        {
            base.Unlock();
            if (m_IsReady)
                m_Parent.Unlock();
        }
    }
}