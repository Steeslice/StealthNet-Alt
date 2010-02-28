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
    internal sealed class Command10
        : Command
    {
        private RSAParameters m_Keys;

        public RSAParameters Keys
        {
            get
            {
                return m_Keys;
            }
        }

        public Command10(RSAParameters keys)
        {
            m_Keys = keys;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.None, 0x10);
            m_Command.Write((byte)0x10);
            m_Command.Write((ushort)keys.Modulus.Length);
            m_Command.Write(keys.Modulus);
            m_Command.Write((ushort)keys.Exponent.Length);
            m_Command.Write(keys.Exponent);
        }

        public Command10(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_Keys.Modulus = m_Command.ReadBytes(command.ReadUInt16());
            m_Keys.Exponent = m_Command.ReadBytes(command.ReadUInt16());
        }
    }
}