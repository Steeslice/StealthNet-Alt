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

using System;
using System.IO;
using System.Text;

namespace Regensburger.RShare
{
    public sealed partial class CommandBuilder
    {
        private byte m_CommandCode = 0x00;

        private MemoryStream m_CommandData;

        private EncryptionMethod m_EncryptionMethod;

        private byte[] m_ReceivedBuffer;

        private CommandBuilder(Connection connection, byte[] receivedBuffer)
        {
            m_ReceivedBuffer = receivedBuffer;
            MemoryStream command = new MemoryStream(m_ReceivedBuffer);
            byte[] header = new byte[Encoding.ASCII.GetByteCount(Constants.Protocol)];
            command.Read(header, 0, header.Length);
            if (!Encoding.ASCII.GetString(header).Equals(Constants.Protocol))
                throw new InvalidDataException();
            m_EncryptionMethod = (EncryptionMethod)command.ReadByte();
            byte[] encryptedDataLength = new byte[2];
            command.Read(encryptedDataLength, 0, encryptedDataLength.Length);
            byte[] encryptedData = new byte[BitConverter.ToUInt16(encryptedDataLength, 0)];
            if (encryptedData.Length > command.Position + encryptedData.Length)
                throw new InvalidDataException();
            command.Read(encryptedData, 0, encryptedData.Length);
            switch (m_EncryptionMethod)
            {
                case EncryptionMethod.None:
                    m_CommandData = new MemoryStream(encryptedData);
                    break;
                case EncryptionMethod.Rijndael:
                    m_CommandData = new MemoryStream(Core.RijndaelDecrypt(connection.ReceivingKey, encryptedData));
                    break;
                case EncryptionMethod.RSA:
                    m_CommandData = new MemoryStream(Core.RSADecrypt(encryptedData));
                    break;
                default:
                    throw new InvalidDataException();
            }
        }

        public CommandBuilder(EncryptionMethod encryptionMethod, byte commandCode)
        {
            m_EncryptionMethod = encryptionMethod;
            m_CommandData = new MemoryStream();
            m_CommandCode = commandCode;
        }

        public byte ReadByte()
        {
            byte value = (byte)m_CommandData.ReadByte();
            return value;
        }

        public byte[] ReadBytes(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");

            byte[] buffer = new byte[count];
            m_CommandData.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        public string ReadString()
        {
            byte[] data = new byte[ReadUInt16()];
            m_CommandData.Read(data, 0, data.Length);
            return Encoding.UTF8.GetString(data);
        }

        public ushort ReadUInt16()
        {
            byte[] data = new byte[2];
            m_CommandData.Read(data, 0, data.Length);
            return BitConverter.ToUInt16(data, 0);
        }

        public uint ReadUInt32()
        {
            byte[] data = new byte[4];
            m_CommandData.Read(data, 0, data.Length);
            return BitConverter.ToUInt32(data, 0);
        }

        public static Command Receive(Connection connection, byte[] receivedBuffer)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            if (receivedBuffer == null)
                throw new ArgumentNullException("buffer");
            if (receivedBuffer.Length < 10)
                throw new ArgumentException();

            CommandBuilder command = new CommandBuilder(connection, receivedBuffer);
            byte code = command.ReadByte();
            command.SetCommandCode(code);
            switch (code)
            {
                case 0x10:
                    return new Command10(command);
                case 0x11:
                    return new Command11(command);
                case 0x12:
                    return new Command12(command);
                case 0x13:
                    return new Command13(command);
                case 0x20:
                    return new Command20(command);
                case 0x21:
                    return new Command21(command);
                case 0x22:
                    return new Command22(command);
                case 0x23:
                    return new Command23(command);
                case 0x40:
                    return new Command40(command);
                case 0x41:
                    return new Command41(command);
                case 0x42:
                    return new Command42(command);
                case 0x43:
                    return new Command43(command);
                case 0x44:
                    return new Command44(command);
                case 0x45:
                    return new Command45(command);
                case 0x46:
                    return new Command46(command);
                case 0x50:
                    return new Command50(command);
                case 0x51:
                    return new Command51(command);
                case 0x52:
                    return new Command52(command);
                case 0x53:
                    return new Command53(command);
                case 0x54:
                    return new Command54(command);
                case 0x60:
                    return new Command60(command);
                case 0x61:
                    return new Command61(command);
                case 0x62:
                    return new Command62(command);
                case 0x63:
                    return new Command63(command);
                case 0x64:
                    return new Command64(command);
                case 0x70:
                    return new Command70(command);
                case 0x71:
                    return new Command71(command);
                case 0x72:
                    return new Command72(command);
                case 0x74:
                    return new Command74(command);
                case 0x75:
                    return new Command75(command);
                case 0x76:
                    return new Command76(command);
                case 0x78:
                    return new Command78(command);
                case 0x79:
                    return new Command79(command);
                case 0x7A:
                    return new Command7A(command);
                default:
                    throw new InvalidDataException();
            }
        }

        public void Send(Connection connection)
        {
            byte[] encryptedData = m_CommandData.ToArray();
            switch (m_EncryptionMethod)
            {
                case EncryptionMethod.Rijndael:
                    encryptedData = Core.RijndaelEncrypt(connection.SendingKey, m_CommandData.ToArray());
                    break;
                case EncryptionMethod.RSA:
                    encryptedData = Core.RSAEncrypt(connection.PublicKey, m_CommandData.ToArray());
                    break;
            }
            MemoryStream command = new MemoryStream();
            byte[] header = Encoding.ASCII.GetBytes(Constants.Protocol);
            command.Write(header, 0, header.Length);
            command.WriteByte((byte)m_EncryptionMethod);
            command.Write(BitConverter.GetBytes((ushort)encryptedData.Length), 0, 2);
            command.Write(encryptedData, 0, encryptedData.Length);
            connection.Send(command.ToArray(), m_CommandCode);
        }

        private void SetCommandCode(byte commandCode)
        {
            m_CommandCode = commandCode;
        }

        public void Write(ushort value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            m_CommandData.Write(buffer, 0, 2);
        }

        public void Write(uint value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            m_CommandData.Write(buffer, 0, 4);
        }

        public void Write(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            byte[] data = Encoding.UTF8.GetBytes(value);
            Write((ushort)data.Length);
            m_CommandData.Write(data, 0, data.Length);
        }

        public void Write(byte value)
        {
            m_CommandData.WriteByte(value);
        }

        public void Write(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            m_CommandData.Write(buffer, 0, buffer.Length);
        }
    }
}