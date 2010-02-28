//StealthNet
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
using Regensburger.RShare;
using Microsoft.Win32;
using System.Web;
using System.Text.RegularExpressions;

namespace Regensburger.RShare
{
    public class StealthNetLink
    {
        // const for a parameter names
        private const string PARAM_NAME_HASH = "hash";
        private const string PARAM_NAME_NAME = "name";
        private const string PARAM_NAME_SIZE = "size";

        // The URL handler for this app
        private const string LINK_PREFIX = "stealthnet://";
        // split char of link parameters
        private const char PARAM_SPLIT_CHAR = '&';
        // split char of key and value
        private const char KEY_SPLIT_CHAR = '=';
        // parameter count of the link
        private const int PARAM_COUNT = 3;

        // [MONO] m_logger is assigned but its value is according to Mono never used
		// private static Logger m_Logger = Logger.Instance;
        private byte[] m_FileHash;
        private string m_FileName = string.Empty;
        private long m_FileSize = 0;

        // true, if the string representation of this link should contain a html link
        private bool m_htmlLink = false;

        public byte[] FileHash
        {
            get
            {
                return m_FileHash;
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
        }

        public long FileSize
        {
            get
            {
                return m_FileSize;
            }
        }

        /// <summary>
        /// Constructor
        /// 
        /// Create a StealthNetLink from a search result.
        /// Use this contructor to display this link with method 
        /// </summary>
        /// <param name="searchResult">searchResult object to construct the link from</param>
        /// <param name="htmlLink">true, if the string representation of this link should contain a html link</param>
        public StealthNetLink(Search.Result searchResult, bool htmlLink)
        {
            m_FileHash = searchResult.FileHash;
            m_FileName = searchResult.FileName;
            m_FileSize = searchResult.FileSize;
            m_htmlLink = htmlLink;
        }

        /// <summary>
        /// Constructor
        /// 
        /// Create a StealthNetLink from a shared file.
        /// Use this contructor to display this link with method 
        /// </summary>
        /// <param name="sharedFile">sharedFile object to construct the link from</param>
        /// <param name="htmlLink">true, if the string representation of this link should contain a html link</param>
        public StealthNetLink(SharedFile sharedFile, bool htmlLink)
        {
            m_FileHash = sharedFile.FileHash;
            m_FileName = sharedFile.FileName;
            m_FileSize = sharedFile.FileSize;
            m_htmlLink = htmlLink;
        }

        /// <summary>
        /// Constructor
        /// 
        /// Create a StealthNetLink from a download.
        /// Use this contructor to display this link with method 
        /// </summary>
        /// <param name="download">download object to construct the link from</param>
        /// <param name="htmlLink">true, if the string representation of this link should contain a html link</param>
        public StealthNetLink(Download download, bool htmlLink)
        {
            m_FileHash = download.FileHash;
            m_FileName = download.FileName;
            m_FileSize = download.FileSize;
            m_htmlLink = htmlLink;
        }

        /// <summary>
        /// Constructor
        /// 
        /// Trys to create a stealthnet link from the passed argument array.
        /// The link must be in the first index of the array
        /// 
        /// A StealthNet-link has the following format:
        /// stealthnet://?hash=<filehash>&name=<filename>&size=<filesize>
        /// </summary>
        /// <param name="arg">passed argument to parse for a stealthnet link</param>
        public StealthNetLink(string arg)
        {
            // check if the array is empty
            if (arg == null)
                throw new InvalidLinkException("arg == null");

            // begins the link with our prefix it may be a correct stealthnet link
            if (!arg.StartsWith(LINK_PREFIX))
                throw new InvalidLinkException("no stealthnet prefix");

            // cut the prefix from argument
            string possibleLink = arg.Substring(LINK_PREFIX.Length+2);

            // split link parameters and check
            string[] parameters = possibleLink.Split(PARAM_SPLIT_CHAR);
            if (parameters == null)
                throw new InvalidLinkException("parameters == null");

            // check count of parameters.
            if (parameters.Length < PARAM_COUNT)
                throw new InvalidLinkException("parameters.Length < ParameterCount. Lenght=" + parameters.Length);

            // extract file hash
            extractFileHash(parameters[0]);

            // extract filename
            extractFileName(parameters[1]);

            // extract filesize
            extractFileSize(parameters[2]);
        }

        /// <summary>
        /// extract the file name from the passed link parameter.
        /// the filename ist encoded with HttpUtility.UrlEncodeUnicode()
        /// </summary>
        /// <param name="fileName"></param>
        private void extractFileName(string fileName)
        {
            string[] keyValue = fileName.Split(KEY_SPLIT_CHAR);
            if (keyValue == null || keyValue.Length < 2)
            {
                throw new InvalidLinkException("extractFileName: keyValue == null || keyValue.Length < 2");
            }
            if (!keyValue[0].Equals(PARAM_NAME_NAME)) 
            {
                throw new InvalidLinkException("extractFileName: !keyValue.Equals(PARAM_NAME_NAME)");
            }
            m_FileName = HttpUtility.UrlDecode(keyValue[1]);
        }

        /// <summary>
        /// extract the filesize from the passed link parameter.
        /// the passed string is parsed with the .net method parse of long.
        /// </summary>
        /// <param name="fileSize"></param>
        private void extractFileSize(string fileSize)
        {
            string[] keyValue = fileSize.Split(KEY_SPLIT_CHAR);
            if (keyValue == null || keyValue.Length < 2)
            {
                throw new InvalidLinkException("extractFileSize: keyValue == null || keyValue.Length < 2");
            }
            if (!keyValue[0].Equals(PARAM_NAME_SIZE))
            {
                throw new InvalidLinkException("extractFileName: !keyValue.Equals(PARAM_NAME_SIZE)");
            }
            try
            {
                m_FileSize = long.Parse(keyValue[1]);
            } 
            catch (ArgumentException e1) 
            {
                throw new InvalidLinkException("extractFileSize", e1);
            }
            catch (OverflowException e2)
            {
                throw new InvalidLinkException("extractFileSize", e2);
            }
            catch (FormatException e3)
            {
                throw new InvalidLinkException("extractFileSize", e3);
            }
        }

        /// <summary>
        /// extract the file hash from the passed link parameter.
        /// if the link doesn't expect the format an exception is thrown 
        /// </summary>
        /// <param name="fileHash"></param>
        private void extractFileHash(string fileHash)
        {
            string[] keyValue = fileHash.Split(KEY_SPLIT_CHAR);
            if (keyValue == null || keyValue.Length < 2)
            {
                throw new InvalidLinkException("extractFileHash: keyValue == null || keyValue.Length < 2");
            }
            if (!keyValue[0].EndsWith(PARAM_NAME_HASH.Substring(1)))
            {
                throw new InvalidLinkException("extractFileName: !keyValue.Equals(PARAM_NAME_HASH)");
            }
            try
            {
                m_FileHash = Core.FileHashStringToFileHash(keyValue[1]);
            }
            catch (ArgumentNullException e1)
            {
                throw new InvalidLinkException("extractFileHash", e1);
            }
            catch (ArgumentException e2)
            {
                throw new InvalidLinkException("extractFileHash", e2);
            }
        }

        /// <summary>
        /// Return the correct stealthnet link to display in the gui or something
        /// like this.
        /// </summary>
        /// <returns>stealthnet link</returns>
        public override string ToString()
        {
            if (m_htmlLink)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<a href='");
                builder.Append(HttpUtility.HtmlEncode(buildLink()));
                builder.Append("'>");
                builder.Append(m_FileName);
                builder.Append("</a>");
                return builder.ToString();
            }
            else
            {
                return buildLink();
            }
        }

        /// <summary>
        /// Creates the link with a StringBuilder. The filename are url encoded.
        /// 
        /// </summary>
        /// <returns>created link as string</returns>
        private string buildLink()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(LINK_PREFIX);
            builder.Append("?");
            builder.Append(PARAM_NAME_HASH);
            builder.Append("=");
            builder.Append(Core.ByteArrayToString(m_FileHash));
            builder.Append("&");
            builder.Append(PARAM_NAME_NAME);
            builder.Append("=");
            builder.Append(HttpUtility.UrlEncodeUnicode(m_FileName));
            builder.Append("&");
            builder.Append(PARAM_NAME_SIZE);
            builder.Append("=");
            builder.Append(m_FileSize);
            return builder.ToString();
        }

        /// <summary>
        /// Exception class for invalid links
        /// </summary>
        class InvalidLinkException : ApplicationException 
        {
            public InvalidLinkException(string message)
                : base(message)
	    	{
		    }
            public InvalidLinkException(string message, Exception e)
                : base(message, e)
            {
            }
        }
    }
}