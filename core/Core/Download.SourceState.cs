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

namespace Regensburger.RShare
{
    partial class Download
    {
        /// <summary>
        /// Enthält die verschiedenen Zustände, die eine Downloadquelle während ihres Verlaufes annehmen kann.
        /// </summary>
        public enum SourceState
        {
            /// <summary>
            /// Die Downloadquelle ist aktiv und liefert die Sektoren des Downloads.
            /// </summary>
            Active = 0,
            /// <summary>
            /// Die Downloadquelle hat mit dem Kommando 0x75 geantwortet.
            /// Es werden im Intervall Anfragen gestellt, im Timeout-Fall wird sie gelöscht.
            /// </summary>
            Requested = 1,
            /// <summary>
            /// Die Downloadquelle hat noch nicht mit dem Kommando 0x75 geantwortet.
            /// Es werden im Intervall Anfragen gestellt, im Timeout-Fall wird sie gelöscht.
            /// </summary>
            Requesting = 2,
            /// <summary>
            /// Die Downloadquelle hat mit dem Kommando 0x71 geantwortet.
            /// Es werden im Intervall Anfragen gestellt, im Timeout-Fall wird sie gelöscht.
            /// </summary>
            Verified = 3,
            /// <summary>
            /// Die Downloadquelle hat noch nicht mit dem Kommando 0x71 geantwortet.
            /// Es werden im Intervall Anfragen gestellt, im Timeout-Fall wird sie gelöscht.
            /// </summary>
            Verifying = 4,
            /// <summary>
            /// Die Downloadquelle besitzt keine benötigten Sektoren.
            /// Es werden keinerlei Anfragen mehr an sie gestellt.
            /// </summary>
            NotNeeded = 5,
        }
    }
}