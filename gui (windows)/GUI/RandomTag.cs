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
    internal sealed class RandomTag<T>
    {
        private double m_SortTag = Randomizer.GenerateNumber() * (127.0 / 256.0);

        private T m_Tag;

        public double SortTag
        {
            get
            {
                return m_SortTag;
            }
        }

        public T Tag
        {
            get
            {
                return m_Tag;
            }
        }

        public RandomTag(T tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            m_Tag = tag;
        }
    }
}
