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
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Regensburger.RShare
{
    public sealed class Connection
    {
        private readonly DateTime m_ConnectedSince = DateTime.Now;

        // adjustment for dynamic bandwidth allocation
        private int m_DownloadAdjustment = 0;

        private int m_DownloadLimit = 0;
        
        private int m_DownloadLimitUsed = 0;

        private bool m_IsDisconnected = false;

        private bool m_IsEstablished = false;

        private long m_Received = 0;

        private long m_ReceivedCommands = 0;

        private string m_ReceivedString = Core.LengthToString(0);

        private ManualResetEvent m_ReceivingResetEvent = new ManualResetEvent(false);

        private IPEndPoint m_RemoteEndPoint;

        private RIndexedHashtable<byte[], DateTime> m_SendingQueue = new RIndexedHashtable<byte[], DateTime>();

        private ManualResetEvent m_SendingResetEvent = new ManualResetEvent(false);

        private long m_Sent = 0;

        private long m_SentCommands = 0;

        private string m_SentString = Core.LengthToString(0);

        //2009-05-21 Eroli
        private ICoreSettings m_Settings = Settings.Instance;

        private Socket m_Socket;

        // new variable used for dynamic bandwidth allocation
        private int m_UploadAdjustment = 0;

        private int m_UploadLimit = 0;

        private int m_UploadLimitUsed = 0;

        private static byte[] Protocol = Encoding.ASCII.GetBytes(Constants.Protocol);

        public RSAParameters PublicKey;

        public RijndaelParameters ReceivingKey;

        public RijndaelParameters SendingKey;

        public int DownloadAdjustment
        {
            set
            {
                m_DownloadAdjustment = value;
            }
        }

        public int DownloadLimitUsed
        {
            get
            {
                return m_DownloadLimitUsed;
            }
        }

        public int EnqueuedCommandsCount
        {
            get
            {
                return m_SendingQueue.Count;
            }
        }

        public bool IsDisconnected
        {
            get
            {
                return m_IsDisconnected;
            }
        }

        public bool IsEstablished
        {
            get
            {
                return m_IsEstablished;
            }
            set
            {
                m_IsEstablished = value;
            }
        }

        public long Received
        {
            get
            {
                return m_Received;
            }
        }

        public long ReceivedCommands
        {
            get
            {
                return m_ReceivedCommands;
            }
        }

        public string ReceivedString
        {
            get
            {
                return m_ReceivedString;
            }
        }

        public IPEndPoint RemoteEndPoint
        {
            get
            {
                return m_RemoteEndPoint;
            }
        }

        public long Sent
        {
            get
            {
                return m_Sent;
            }
        }

        public long SentCommands
        {
            get
            {
                return m_SentCommands;
            }
        }

        public string SentString
        {
            get
            {
                return m_SentString;
            }
        }

        public int UploadAdjustment
        {
            set
            {
                m_UploadAdjustment = value;
            }
        }

        public int UploadLimitUsed
        {
            get
            {
                return m_UploadLimitUsed;
            }
        }

        public void Disconnect()
        {
            if (m_IsDisconnected)
                return;
            m_IsDisconnected = true;
            m_ReceivingResetEvent.Set();
            m_SendingResetEvent.Set();
            try
            {
                if (m_Socket != null)
                {
                    m_Socket.Shutdown(SocketShutdown.Both);
                }
            }
            catch
            {
            }
            try
            {
                if (m_Socket != null)
                {
                    m_Socket.Close();
                }
            }
            catch
            {
            }
        }

        public void Process()
        {
            if (!m_IsEstablished && DateTime.Now.Subtract(m_ConnectedSince).TotalSeconds >= Constants.ConnectTimeout)
            {
                Disconnect();
                return;
            }
            try
            {
                m_SendingQueue.Lock();
                for (int n = m_SendingQueue.Count - 1; n >= 0; n--)
                    if (DateTime.Now.Subtract(m_SendingQueue[n].Value).TotalSeconds >= Constants.CommandTimeout)
                        m_SendingQueue.RemoveAt(n);
            }
            finally
            {
                m_SendingQueue.Unlock();
            }
            try
            {
                Core.Connections.Lock();
                if (bool.Parse(m_Settings["HasDownloadLimit"]) && int.Parse(m_Settings["DownloadLimit"]) > 0 && Core.Connections.Count != 0)
                    m_DownloadLimit = Math.Max(m_DownloadLimitUsed + m_DownloadAdjustment, (int)((float)int.Parse(m_Settings["DownloadLimit"]) / Core.Connections.Count));
                else
                    m_DownloadLimit = 0;
                m_DownloadLimitUsed = 0;
                m_ReceivingResetEvent.Set();
                if (bool.Parse(m_Settings["HasUploadLimit"]) && int.Parse(m_Settings["UploadLimit"]) > 0 && Core.Connections.Count != 0)
                    m_UploadLimit = Math.Max(m_UploadLimitUsed + m_UploadAdjustment, (int)((float)int.Parse(m_Settings["UploadLimit"]) / Core.Connections.Count));
                else
                    m_UploadLimit = 0;
                m_UploadLimitUsed = 0;
                m_SendingResetEvent.Set();
            }
            finally
            {
                Core.Connections.Unlock();
            }
        }

        public void Send(byte[] buffer, byte commandCode)
        {
            if (buffer == null)
                throw new ArgumentNullException("command");

            if (m_IsDisconnected)
                return;
            try
            {
                m_SendingQueue.Lock();
                if ((commandCode < 0x50 && commandCode > 0x6F) || m_SendingQueue.Count < 25)
                    m_SendingQueue.Add(buffer, DateTime.Now);
            }
            finally
            {
                m_SendingQueue.Unlock();
            }
            m_SendingResetEvent.Set();
        }

        public Connection(Socket socket)
        {
            if (socket == null)
                throw new ArgumentNullException("socket");

            try
            {
                m_Socket = socket;
                m_RemoteEndPoint = (IPEndPoint)m_Socket.RemoteEndPoint;
                Thread receivingThread = new Thread(delegate()
                {
                    try
                    {
                        byte[] receivingStream = new byte[Constants.MaximumCommandLength];
                        int receivingStreamOffset = 0;
                        while (!m_IsDisconnected)
                        {
                            m_ReceivingResetEvent.WaitOne();
                            if (m_IsDisconnected)
                                break;
                            int receivingStreamRest = receivingStream.Length - receivingStreamOffset;
                            int received;
                            if (m_DownloadLimit > 0)
                            {
                                int downloadLimitRest = m_DownloadLimit - m_DownloadLimitUsed;
                                received = 0;
                                if (downloadLimitRest > 0)
                                    received = m_Socket.Receive(receivingStream, receivingStreamOffset, downloadLimitRest < receivingStreamRest ? downloadLimitRest : receivingStreamRest, SocketFlags.None);
                                m_DownloadLimitUsed += received;
                                downloadLimitRest = m_DownloadLimit - m_DownloadLimitUsed;
                                if (downloadLimitRest <= 0)
                                    m_ReceivingResetEvent.Reset();
                            }
                            else
                                received = m_Socket.Receive(receivingStream, receivingStreamOffset, receivingStreamRest, SocketFlags.None);
                            if (received == 0)
                            {
                                Disconnect();
                                break;
                            }
                            receivingStreamOffset += received;
                            m_Received += received;
                            m_ReceivedString = Core.LengthToString(m_Received);
                            Core.ReportDownstream(received);
                            while (receivingStreamOffset >= Protocol.Length + 3)
                                if (Core.CompareByteArray(receivingStream, Protocol, Protocol.Length))
                                {
                                    int commandLength = Protocol.Length + 3 + BitConverter.ToUInt16(receivingStream, Protocol.Length + 1);
                                    if (receivingStreamOffset >= commandLength)
                                    {
                                        byte[] buffer = new byte[commandLength];
                                        Array.Copy(receivingStream, buffer, commandLength);
                                        try
                                        {
                                            Core.ProcessCommand(this, buffer);
                                        }
                                        catch
                                        {
                                        }
                                        Array.Copy(receivingStream, commandLength, receivingStream, 0, receivingStreamOffset - commandLength);
                                        receivingStreamOffset -= commandLength;
                                        m_ReceivedCommands++;
                                    }
                                    else
                                        break;
                                }
                                else
                                    receivingStreamOffset = 0;
                        }
                    }
                    catch
                    {
                        Disconnect();
                    }
                });
                receivingThread.Name = "receivingThread";
                receivingThread.IsBackground = true;
                receivingThread.Start();
                Thread sendingThread = new Thread(delegate()
                {
                    try
                    {
                        byte[] sendingStream = null;
                        int sendingStreamOffset = 0;
                        while (!m_IsDisconnected)
                        {
                            m_SendingResetEvent.WaitOne();
                            if (m_IsDisconnected)
                                break;
                            if (sendingStream == null || sendingStreamOffset == sendingStream.Length)
                                try
                                {
                                    m_SendingQueue.Lock();
                                    if (!m_SendingQueue.IsEmpty)
                                    {
                                        sendingStream = m_SendingQueue[0].Key;
                                        m_SendingQueue.RemoveAt(0);
                                        sendingStreamOffset = 0;
                                        m_SentCommands++;
                                    }
                                    else
                                    {
                                        m_SendingResetEvent.Reset();
                                        continue;
                                    }
                                }
                                finally
                                {
                                    m_SendingQueue.Unlock();
                                }
                            int sendingStreamRest = sendingStream.Length - sendingStreamOffset;
                            int sent;
                            if (m_UploadLimit > 0)
                            {
                                int uploadLimitRest = m_UploadLimit - m_UploadLimitUsed;
                                sent = 0;
                                if (uploadLimitRest > 0)
                                    sent = m_Socket.Send(sendingStream, sendingStreamOffset, uploadLimitRest < sendingStreamRest ? uploadLimitRest : sendingStreamRest, SocketFlags.None);
                                m_UploadLimitUsed += sent;
                                uploadLimitRest = m_UploadLimit - m_UploadLimitUsed;
                                if (uploadLimitRest <= 0)
                                    m_SendingResetEvent.Reset();
                            }
                            else
                                sent = m_Socket.Send(sendingStream, sendingStreamOffset, sendingStreamRest, SocketFlags.None);
                            sendingStreamOffset += sent;
                            m_Sent += sent;
                            m_SentString = Core.LengthToString(m_Sent);
                            Core.ReportUpstream(sent);
                        }
                    }
                    catch
                    {
                        Disconnect();
                    }
                });
                sendingThread.Name = "sendingThread";
                sendingThread.IsBackground = true;
                sendingThread.Start();
            }
            catch
            {
                Disconnect();
            }
        }
    }
}