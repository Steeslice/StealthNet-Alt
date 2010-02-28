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

#pragma warning disable 0649

using System;
using System.Security.Cryptography;

namespace Regensburger.RShare
{
    public struct RijndaelParameters
    {
        public int BlockSize;

        public int FeedbackSize;

        public byte[] IV;

        public byte[] Key;

        public int KeySize;

        public CipherMode Mode;

        public PaddingMode Padding;

        public RijndaelManaged Export()
        {
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.BlockSize = BlockSize;
            rijndael.FeedbackSize = FeedbackSize;
            rijndael.KeySize = KeySize;
            rijndael.Mode = Mode;
            rijndael.Padding = Padding;
            rijndael.IV = IV;
            rijndael.Key = Key;
            return rijndael;
        }

        public RijndaelParameters(RijndaelManaged rijndael)
        {
            BlockSize = rijndael.BlockSize;
            FeedbackSize = rijndael.FeedbackSize;
            KeySize = rijndael.KeySize;
            Mode = rijndael.Mode;
            Padding = rijndael.Padding;
            IV = rijndael.IV;
            Key = rijndael.Key;
        }
    }
}

#pragma warning restore 0649