//StealthNet
//Copyright (C) 2009 Lars Regensburger, Roland Moch, T.Norad

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
    public static class Settings
    {
        private static ICoreSettings m_Instance = null;

        public static ICoreSettings Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    throw new Exception("You must first set an instance of class settings.");
                }

                return m_Instance;
            }
            set
            {
                if (m_Instance != null)
                {
                    throw new Exception("Class Settings already be created.");
                }

                m_Instance = value;
            }
        }
    }
}