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

using Regensburger.RCollections.ArrayBased;
using System;
using System.Collections.Generic;

namespace Regensburger.RShare
{
    internal sealed class Command53
        : Command, IResponseCommand
    {
        private byte[] m_CommandID;

        private string m_Comment;

        private string m_FileName;

        private uint m_FileSize;

        private RIndexedHashtable<string, string> m_MetaData;

        private byte m_Rating;

        private byte[] m_ReceiverPeerID;

        private byte[] m_SenderPeerID;

        private byte[] m_SourceSearchID;

        public byte[] CommandID
        {
            get
            {
                return m_CommandID;
            }
        }

        public string Comment
        {
            get
            {
                return m_Comment;
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
        }

        public uint FileSize
        {
            get
            {
                return m_FileSize;
            }
        }

        public RIndexedHashtable<string, string> MetaData
        {
            get
            {
                return m_MetaData;
            }
        }

        public byte Rating
        {
            get
            {
                return m_Rating;
            }
        }

        public byte[] ReceiverPeerID
        {
            get
            {
                return m_ReceiverPeerID;
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

        public Command53(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_CommandID = m_Command.ReadBytes(48);
            m_SenderPeerID = m_Command.ReadBytes(48);
            m_ReceiverPeerID = m_Command.ReadBytes(48);
            m_SourceSearchID = m_Command.ReadBytes(48);
            m_FileSize = m_Command.ReadUInt32();
            m_FileName = m_Command.ReadString();
            m_MetaData = new RIndexedHashtable<string, string>();
            ushort metaDataCount = m_Command.ReadUInt16();
            for (int n = 0; n < metaDataCount; n++)
                m_MetaData.Add(m_Command.ReadString(), m_Command.ReadString());
            m_Comment = m_Command.ReadString();
            m_Rating = m_Command.ReadByte();
        }

        public Command53(byte[] commandID, byte[] senderPeerID, byte[] receiverPeerID, byte[] sourceSearchID, uint fileSize, string fileName, RIndexedHashtable<string, string> metaData, string comment, byte rating)
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
            if (sourceSearchID == null)
                throw new ArgumentNullException("sourceSearchID");
            if (sourceSearchID.Length != 48)
                throw new ArgumentException();
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (metaData == null)
                throw new ArgumentNullException("metaData");
            if (comment == null)
                throw new ArgumentNullException("comment");

            m_CommandID = commandID;
            m_SenderPeerID = senderPeerID;
            m_ReceiverPeerID = receiverPeerID;
            m_SourceSearchID = sourceSearchID;
            m_FileSize = fileSize;
            m_FileName = fileName;
            m_MetaData = metaData;
            m_Rating = rating;
            m_Comment = comment;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.Rijndael, 0x53);
            m_Command.Write(0x53);
            m_Command.Write(m_CommandID);
            m_Command.Write(m_SenderPeerID);
            m_Command.Write(m_ReceiverPeerID);
            m_Command.Write(m_SourceSearchID);
            m_Command.Write(m_FileSize);
            m_Command.Write(m_FileName);
            m_Command.Write((ushort)m_MetaData.Count);
            foreach (KeyValuePair<string, string> metaDataItem in metaData)
            {
                m_Command.Write(metaDataItem.Key);
                m_Command.Write(metaDataItem.Value);
            }
            m_Command.Write(m_Comment);
            m_Command.Write(m_Rating);
        }
    }
}