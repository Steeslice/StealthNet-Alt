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
    internal sealed class WebCacheProvider
    {
        private int m_LastGetPeerRequest = -1;

        private RList<WebCacheWebServiceProxy> m_WebCaches;

        ~WebCacheProvider()
        {
            for (int n = m_WebCaches.Count - 1; n >= 0; n--)
            {
                m_WebCaches[n].Dispose();
                m_WebCaches.RemoveAt(n);
            }
        }

        public void AddPeer(int port)
        {
            foreach (WebCacheWebServiceProxy webCacheServiceProxy in m_WebCaches)
                try
                {
                    webCacheServiceProxy.AddPeer(port);
                }
                catch
                {
                }
        }

        public string GetPeer()
        {
            for (int n = 0; n < m_WebCaches.Count; n++)
            {
                m_LastGetPeerRequest++;
                if (m_LastGetPeerRequest >= m_WebCaches.Count)
                    m_LastGetPeerRequest = 0;
                try
                {
                    string peer = m_WebCaches[m_LastGetPeerRequest].GetPeer();
                    if (peer != string.Empty)
                        return peer;
                }
                catch
                {
                }
            }
            return string.Empty;
        }

        public void RemovePeer()
        {
            foreach (WebCacheWebServiceProxy webCacheServiceProxy in m_WebCaches)
                try
                {
                    webCacheServiceProxy.RemovePeer();
                }
                catch
                {
                }
        }

        public WebCacheProvider(RList<string> webCaches)
        {
            if (webCaches == null)
                throw new ArgumentNullException("webCaches");

            m_WebCaches = new RList<WebCacheWebServiceProxy>();
            foreach (string webCache in webCaches)
                m_WebCaches.Add(new WebCacheWebServiceProxy(webCache));
        }
    }
}