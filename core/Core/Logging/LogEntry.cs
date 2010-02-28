//RShare
//Copyright (C) 2009 Lars Regensburger
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

namespace Regensburger.RShare
{
    public sealed class LogEntry
    {
        private string m_Text;

        private Exception m_ThrownException;

        private DateTime m_TimeStamp = DateTime.Now;

        public string Text
        {
            get
            {
                return m_Text;
            }
        }

        public Exception ThrownException
        {
            get
            {
                return m_ThrownException;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return m_TimeStamp;
            }
        }

        public LogEntry(string text, Exception thrownException)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            m_Text = text;
            m_ThrownException = thrownException;
        }
    }
}