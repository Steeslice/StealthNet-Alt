//RShare
//Copyright (C) 2009 T.Norad

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
using System.Collections.Generic;
using System.Text;

namespace Regensburger.RShare
{
    public class FileType
    {
        /* contains the file extentions of all types for a category like audio or movie */
        private string[] m_FileExtentions;

        public string[] FileExtentions
        {
            get
            {
                return m_FileExtentions;
            }
            protected set
            {
                m_FileExtentions = value;
            }
        }

        /**
         * Returns true, if the passed filename extention contained in this file type.
         */
        public virtual bool Contains(string filename)
        {
            for (int i = 0; i < FileExtentions.Length; i++ )
            {
                if (filename.EndsWith(FileExtentions[i]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
