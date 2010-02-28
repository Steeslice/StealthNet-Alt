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

using Regensburger.RCollections.ArrayBased;
using System;
using System.Collections.Generic;

namespace Regensburger.RShare
{
    public sealed partial class Command23
        : Command, IResponseCommand
    {
        private byte[] m_CommandID;

        private byte[] m_ReceiverPeerID;

        private byte[] m_SearchID;

        private RList<SearchResult> m_SearchResults;

        private byte[] m_SenderPeerID;

        public byte[] CommandID
        {
            get
            {
                return m_CommandID;
            }
        }

        public byte[] ReceiverPeerID
        {
            get
            {
                return m_ReceiverPeerID;
            }
        }

        public byte[] SearchID
        {
            get
            {
                return m_SearchID;
            }
        }

        public RList<SearchResult> SearchResults
        {
            get
            {
                return m_SearchResults;
            }
        }

        public byte[] SenderPeerID
        {
            get
            {
                return m_SenderPeerID;
            }
        }

        public Command23(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_CommandID = m_Command.ReadBytes(48);
            m_SenderPeerID = m_Command.ReadBytes(48);
            m_ReceiverPeerID = m_Command.ReadBytes(48);
            m_SearchID = m_Command.ReadBytes(48);
            m_SearchResults = new RList<SearchResult>();
            ushort searchResultsCount = m_Command.ReadUInt16();
            for (int n = 0; n < searchResultsCount; n++)
            {
                byte[] fileHash = m_Command.ReadBytes(64);
                uint fileSize = m_Command.ReadUInt32();
                string fileName = m_Command.ReadString();
                RIndexedHashtable<string, string> metaData = new RIndexedHashtable<string, string>();
                ushort metaDataCount = m_Command.ReadUInt16();
                for (int m = 0; m < metaDataCount; m++)
                    metaData.Add(m_Command.ReadString(), m_Command.ReadString());
                m_SearchResults.Add(new SearchResult(fileHash, fileSize, fileName, metaData, m_Command.ReadString(), m_Command.ReadByte()));
            }
        }

        public Command23(byte[] commandID, byte[] senderPeerID, byte[] receiverPeerID, byte[] searchID, RList<SearchResult> searchResults)
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
            if (searchID == null)
                throw new ArgumentNullException("searchID");
            if (searchID.Length != 48)
                throw new ArgumentException();
            if (searchResults == null)
                throw new ArgumentNullException("searchResults");

            m_CommandID = commandID;
            m_SenderPeerID = senderPeerID;
            m_ReceiverPeerID = receiverPeerID;
            m_SearchID = searchID;
            m_SearchResults = searchResults;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.Rijndael, 0x23);
            m_Command.Write(0x23);
            m_Command.Write(m_CommandID);
            m_Command.Write(m_SenderPeerID);
            m_Command.Write(m_ReceiverPeerID);
            m_Command.Write(m_SearchID);
            m_Command.Write((ushort)m_SearchResults.Count);
            foreach (SearchResult searchResult in searchResults)
            {
                m_Command.Write(searchResult.FileHash);
                m_Command.Write(searchResult.FileSize);
                m_Command.Write(searchResult.FileName);
                m_Command.Write((ushort)searchResult.MetaData.Count);
                foreach (KeyValuePair<string, string> metaData in searchResult.MetaData)
                {
                    m_Command.Write(metaData.Key);
                    m_Command.Write(metaData.Value);
                }
                m_Command.Write(searchResult.Comment);
                m_Command.Write(searchResult.Rating);
            }
        }
    }
}