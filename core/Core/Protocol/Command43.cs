//RShare
//Copyright (C) 2008 Lars Regensburger

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
    internal sealed class Command43
        : Command, IResponseCommand
    {
        private byte[] m_CommandID;

        private byte[] m_DownloadID;

        private byte[] m_ReceiverPeerID;

        private uint m_Sector;

        private byte[] m_SectorData;

        private byte[] m_SectorHash;

        private byte[] m_SenderPeerID;

        public byte[] CommandID
        {
            get
            {
                return m_CommandID;
            }
        }

        public byte[] DownloadID
        {
            get
            {
                return m_DownloadID;
            }
        }

        public byte[] ReceiverPeerID
        {
            get
            {
                return m_ReceiverPeerID;
            }
        }

        public uint Sector
        {
            get
            {
                return m_Sector;
            }
        }

        public byte[] SectorData
        {
            get
            {
                return m_SectorData;
            }
        }

        public byte[] SectorHash
        {
            get
            {
                return m_SectorHash;
            }
        }

        public byte[] SenderPeerID
        {
            get
            {
                return m_SenderPeerID;
            }
        }

        public Command43(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_CommandID = m_Command.ReadBytes(48);
            m_SenderPeerID = m_Command.ReadBytes(48);
            m_ReceiverPeerID = m_Command.ReadBytes(48);
            m_DownloadID = m_Command.ReadBytes(48);
            m_Sector = m_Command.ReadUInt32();
            m_SectorData = m_Command.ReadBytes(m_Command.ReadUInt16());
            m_SectorHash = m_Command.ReadBytes(64);
        }

        public Command43(byte[] commandID, byte[] senderPeerID, byte[] receiverPeerID, byte[] downloadID, uint sector, byte[] sectorData, byte[] sectorHash)
        {
            if (commandID == null)
                throw new ArgumentNullException("commandID");
            if (commandID.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (receiverPeerID == null)
                throw new ArgumentNullException("receiverPeerID");
            if (receiverPeerID.Length != 48)
                throw new ArgumentException();
            if (downloadID == null)
                throw new ArgumentNullException("downloadID");
            if (downloadID.Length != 48)
                throw new ArgumentException();
            if (sectorData == null)
                throw new ArgumentNullException("sectorData");
            if (sectorHash == null)
                throw new ArgumentNullException("sectorHash");
            if (sectorHash.Length != 64)
                throw new ArgumentException();

            m_CommandID = commandID;
            m_SenderPeerID = senderPeerID;
            m_ReceiverPeerID = receiverPeerID;
            m_DownloadID = downloadID;
            m_Sector = sector;
            m_SectorData = sectorData;
            m_SectorHash = sectorHash;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.Rijndael, 0x43);
            m_Command.Write((byte)0x43);
            m_Command.Write(m_CommandID);
            m_Command.Write(m_SenderPeerID);
            m_Command.Write(m_ReceiverPeerID);
            m_Command.Write(m_DownloadID);
            m_Command.Write(m_Sector);
            m_Command.Write((ushort)m_SectorData.Length);
            m_Command.Write(m_SectorData);
            m_Command.Write(m_SectorHash);
        }
    }
}