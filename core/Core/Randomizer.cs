//RShare
//Copyright (C) 2009 Lars Torsten Regensburger, T.Norad

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
    public static class Randomizer
    {
        private static RNGCryptoServiceProvider m_RNG = new RNGCryptoServiceProvider();

        public static int GenerateNumber(int minimum, int maximum)
        {
            if (minimum < 0)
                throw new ArgumentOutOfRangeException("minimum");
            if (maximum < 0)
                throw new ArgumentOutOfRangeException("maximum");
            if (minimum > maximum)
                throw new ArgumentException();

            return GenerateRandom().Next(minimum, maximum);
        }

        public static double GenerateNumber()
        {
            return GenerateRandom().NextDouble();
        }

        private static Random GenerateRandom()
        {
            byte[] buffer = new byte[4];
            m_RNG.GetBytes(buffer);
            int seed = (buffer[0] & 0x7F << 24) | (buffer[1] << 16) | (buffer[2] << 16) | buffer[3];
            m_RNG.GetBytes(buffer);
            seed ^= (buffer[3] & 0x7F << 24) | (buffer[2] << 16) | (buffer[1] << 16) | buffer[0];
            return new Random(seed);
        }
    }
}