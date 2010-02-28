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
using System.Security.Cryptography;

namespace Regensburger.RShare
{
    internal sealed class Command12
        : Command
    {
        private RijndaelParameters m_Keys;

        public RijndaelParameters Keys
        {
            get
            {
                return m_Keys;
            }
        }

        public Command12(RijndaelParameters keys)
        {
            m_Keys = keys;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.RSA, 0x12);
            m_Command.Write((byte)0x12);
            m_Command.Write((ushort)m_Keys.BlockSize);
            m_Command.Write((ushort)m_Keys.FeedbackSize);
            m_Command.Write((ushort)m_Keys.KeySize);
            m_Command.Write((byte)m_Keys.Mode);
            m_Command.Write((byte)m_Keys.Padding);
            m_Command.Write((byte)m_Keys.IV.Length);
            m_Command.Write(m_Keys.IV);
            m_Command.Write((byte)m_Keys.Key.Length);
            m_Command.Write(m_Keys.Key);
        }

        public Command12(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_Keys.BlockSize = m_Command.ReadUInt16();
            m_Keys.FeedbackSize = m_Command.ReadUInt16();
            m_Keys.KeySize = m_Command.ReadUInt16();
            m_Keys.Mode = (CipherMode)m_Command.ReadByte();
            m_Keys.Padding = (PaddingMode)m_Command.ReadByte();
            m_Keys.IV = m_Command.ReadBytes(m_Command.ReadByte());
            m_Keys.Key = m_Command.ReadBytes(m_Command.ReadByte());
        }
    }
}