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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Regensburger.RShare
{
    internal static class ComputeHashes
    {
        public static byte[] SHA384Compute(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            SHA384Managed SHA384 = new SHA384Managed();
            byte[] hash = SHA384.ComputeHash(data);
            SHA384.Clear();
            return hash;
        }

        public static byte[] SHA512Compute(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            SHA512Managed SHA512 = new SHA512Managed();
            byte[] hash = SHA512.ComputeHash(data);
            SHA512.Clear();
            return hash;
        }

        public static byte[] SHA512Compute(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            SHA512Managed SHA512 = new SHA512Managed();
            byte[] hash = SHA512.ComputeHash(stream);
            SHA512.Clear();
            return hash;
        }
    }
}
