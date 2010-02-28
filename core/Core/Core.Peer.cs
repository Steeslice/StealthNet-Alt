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
using System.Net;

namespace Regensburger.RShare
{
    partial class Core
    {
        private sealed class Peer
        {
            private DateTime m_LastReceived = DateTime.Now;

            private IPAddress m_Route = IPAddress.None;

            public DateTime LastReceived
            {
                get
                {
                    return m_LastReceived;
                }
            }

            public IPAddress Route
            {
                get
                {
                    return m_Route;
                }
            }

            public void Process()
            {
                if (!Core.Connections.ContainsKey(m_Route))
                    m_Route = IPAddress.None;
            }

            public void ReportReceived()
            {
                m_LastReceived = DateTime.Now;
            }

            public void ReportReceived(IPAddress route)
            {
                if (route == null)
                    throw new ArgumentNullException("route");

                m_Route = route;
            }

            public Peer()
            {
            }
        }
    }
}