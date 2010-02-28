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

namespace Regensburger.RShare
{
    internal sealed class Command61
        : Command, IRequestCommand
    {
        private byte[] m_CommandID;

        private byte[] m_HashedFileHash;

        private ushort m_HopCount;

        private ushort m_Reserved;

        private byte[] m_SenderPeerID;

        private byte[] m_SourceSearchID;

        public byte[] CommandID
        {
            get
            {
                return m_CommandID;
            }
        }

        public byte[] HashedFileHash
        {
            get
            {
                return m_HashedFileHash;
            }
        }

        public ushort HopCount
        {
            get
            {
                return m_HopCount;
            }
        }

        public ushort Reserved
        {
            get
            {
                return m_Reserved;
            }
        }

        public byte[] SenderPeerID
        {
            get
            {
                return m_SenderPeerID;
            }
        }

        public byte[] SourceSearchID
        {
            get
            {
                return m_SourceSearchID;
            }
        }

        public Command61(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_CommandID = m_Command.ReadBytes(48);
            m_Reserved = m_Command.ReadUInt16();
            m_HopCount = m_Command.ReadUInt16();
            m_SenderPeerID = m_Command.ReadBytes(48);
            m_SourceSearchID = m_Command.ReadBytes(48);
            m_HashedFileHash = m_Command.ReadBytes(64);
        }

        public Command61(byte[] commandID, ushort reserved, ushort hopCount, byte[] senderPeerID, byte[] sourceSearchID, byte[] hashedFileHash)
        {
            if (commandID == null)
                throw new ArgumentNullException("commandID");
            if (commandID.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (sourceSearchID == null)
                throw new ArgumentNullException("sourceSearchID");
            if (sourceSearchID.Length != 48)
                throw new ArgumentException();
            if (hashedFileHash == null)
                throw new ArgumentNullException("hashedFileHash");
            if (hashedFileHash.Length != 64)
                throw new ArgumentException();

            m_CommandID = commandID;
            m_Reserved = reserved;
            m_HopCount = hopCount;
            m_SenderPeerID = senderPeerID;
            m_SourceSearchID = sourceSearchID;
            m_HashedFileHash = hashedFileHash;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.Rijndael, 0x61);
            m_Command.Write(0x61);
            m_Command.Write(m_CommandID);
            m_Command.Write(m_Reserved);
            m_Command.Write(m_HopCount);
            m_Command.Write(m_SenderPeerID);
            m_Command.Write(m_SourceSearchID);
            m_Command.Write(m_HashedFileHash);
        }
    }
}