//RShare
//Copyright (C) 2009 Lars Regensburger, T.Norad

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
using System.Security.Cryptography;

namespace Regensburger.RShare
{
    public static class Constants
    {
        public const int Command20Interval = 120;

        public const int Command20ToSend = 6;

        public const int Command30Interval = 3600;

        public const int Command70Interval = 720;

        public const int Command70ToSend = 6;

        public const int Command71Timeout = 120;

        public const int Command74Interval = 120;

        public const int Command74ToSend = 3;

        public const int Command75Timeout = 120;

        public const int Command78Interval = 60;

        public const int Command78ToSend = 6;

        public const int Command79Timeout = 60;

        public const int CommandTimeout = 120;

        public const int ConnectTimeout = 30;

        public const int DownloadRequestingDelay = 90;

        public const int LastCommandIDTimeout = 240;

        public const int MaximumCommandLength = (64 * 1024) - 30;

        public const int MaximumDataLength = 32 * 1024;

        private static int? m_MaximumDownloadsCount = null;

        public static int MaximumDownloadsCount
        {
            get
            {
                if (!m_MaximumDownloadsCount.HasValue)
                    return 6;
                if (m_MaximumDownloadsCount < 1 || m_MaximumDownloadsCount > 12)
                    m_MaximumDownloadsCount = 6;
                return m_MaximumDownloadsCount.Value;
            }
        }

        public static void SetMaximumDownloadsCount(int maximumDownloadsCount)
        {
            if (m_MaximumDownloadsCount.HasValue)
                return;
            m_MaximumDownloadsCount = maximumDownloadsCount;
            if (m_MaximumDownloadsCount < 1 || m_MaximumDownloadsCount > 12)
                m_MaximumDownloadsCount = 6;
        }

        public const int MaximumHopCount = 31;

        public const int MaximumSearchesCount = 10;

        public const int MaximumSharedFilesSearchesCount = 2500;

        public static int MaximumSourcesCount
        {
            get
            {
                switch (MaximumDownloadsCount)
                {
                    case 1:
                        return 12;
                    case 2:
                        return 6;
                    case 3:
                        return 4;
                    case 4:
                        return 3;
                    case 5:
                    case 6:
                        return 2;
                    default:
                        return 1;
                }
            }
        }

        public const int MaximumUploadsCount = 10;

        public const int PeerTimeout = 5600;

        public const string Protocol = "LARS REGENSBURGER'S FILE SHARING PROTOCOL 0.2";

        public const UInt16 RijndaelBlockSize = 256;

        public const UInt16 RijndaelFeedbackSize = 256;

        public const UInt16 RijndaelKeySize = 256;

        public const CipherMode RijndaelMode = CipherMode.CBC;

        public const PaddingMode RijndaelPadding = PaddingMode.PKCS7;

        public const UInt16 RSAKeySize = 1024;

        public const string Software = "StealthNet {0} Anonymous File Sharing";

        public const int UploadTimeout = 480;
    }
}