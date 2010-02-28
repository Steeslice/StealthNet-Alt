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
    internal sealed class Command22
        : Command, IRequestCommand
    {
        private byte[] m_CommandID;

        private byte[] m_SearchID;

        private string m_SearchPattern;

        private byte[] m_SenderPeerID;

        public byte[] CommandID
        {
            get
            {
                return m_CommandID;
            }
        }

        public byte[] SearchID
        {
            get
            {
                return m_SearchID;
            }
        }

        public string SearchPattern
        {
            get
            {
                return m_SearchPattern;
            }
        }

        public byte[] SenderPeerID
        {
            get
            {
                return m_SenderPeerID;
            }
        }

        public Command22(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_CommandID = m_Command.ReadBytes(48);
            m_SenderPeerID = m_Command.ReadBytes(48);
            m_SearchID = m_Command.ReadBytes(48);
            m_SearchPattern = m_Command.ReadString();
        }

        public Command22(byte[] commandID, byte[] senderPeerID, byte[] searchID, string searchPattern)
        {
            if (commandID == null)
                throw new ArgumentNullException("commandID");
            if (commandID.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (searchID == null)
                throw new ArgumentNullException("searchID");
            if (searchID.Length != 48)
                throw new ArgumentException();
            if (searchPattern == null)
                throw new ArgumentNullException("searchPattern");

            m_CommandID = commandID;
            m_SenderPeerID = senderPeerID;
            m_SearchID = searchID;
            m_SearchPattern = searchPattern;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.Rijndael, 0x22);
            m_Command.Write(0x22);
            m_Command.Write(m_CommandID);
            m_Command.Write(m_SenderPeerID);
            m_Command.Write(m_SearchID);
            m_Command.Write(m_SearchPattern);
        }
    }
}