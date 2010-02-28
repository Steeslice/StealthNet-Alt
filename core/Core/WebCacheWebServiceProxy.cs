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
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace Regensburger.RShare
{
    [WebServiceBindingAttribute(Namespace = "http://rshare.de/rshare.asmx")]
    internal sealed class WebCacheWebServiceProxy
        : SoapHttpClientProtocol
    {
        [SoapDocumentMethodAttribute()]
        public void AddPeer(int port)
        {
            Invoke("AddPeer", new object[] { port });
        }

        [SoapDocumentMethodAttribute()]
        public string GetPeer()
        {
            return (string)Invoke("GetPeer", new object[0])[0];
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)base.GetWebRequest(uri);
            httpWebRequest.KeepAlive = false;
            if (!UtilitiesForMono.IsRunningOnMono)
                httpWebRequest.ServicePoint.Expect100Continue = false;
            return httpWebRequest;
        }

        [SoapDocumentMethodAttribute()]
        public void RemovePeer()
        {
            Invoke("RemovePeer", new object[0]);
        }

        public WebCacheWebServiceProxy(string url)
        {
            Url = url;
            if (!UtilitiesForMono.IsRunningOnMono)
                EnableDecompression = true;
        }
    }
}