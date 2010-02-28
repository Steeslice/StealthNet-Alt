//RShare
//Copyright (C) 2009 Lars Regensburger
//Copyright (C) 2009 T.Norad

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

using Regensburger.RAudioFileTags;
using Regensburger.RCollections.ArrayBased;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Regensburger.RShare
{
    public sealed class SharedFile
    {
        private string m_Album = string.Empty;

        private string m_Artist = string.Empty;

        private string m_Comment = string.Empty;

        private string m_DirectoryPath;

        private byte[] m_FileHash;

        private string m_FileHashString;

        private string m_FileName;

        private string m_FilePath;

        private long m_FileSize;

        private string m_FileSizeString;

        private DateTime? m_LastRequest;

        private DateTime m_LastWriteTime;

        private static Logger m_Logger = Logger.Instance;

        private RIndexedHashtable<string, string> m_MetaData = new RIndexedHashtable<string, string>();

        private byte[] m_OnceHashedFileHash;

        private string m_OnceHashedFileHashString;

        private byte m_Rating = 0;

        private long m_Sectors;

        private byte[] m_ThriceHashedFileHash;

        private string m_ThriceHashedFileHashString;

        private string m_Title = string.Empty;

        private byte[] m_TwiceHashedFileHash;

        private string m_TwiceHashedFileHashString;

        public string Album
        {
            get
            {
                return m_Album;
            }
        }

        public string Artist
        {
            get
            {
                return m_Artist;
            }
        }

        public string Comment
        {
            get
            {
                return m_Comment;
            }
            set
            {
                if (m_Comment == null)
                    throw new ArgumentNullException("value");

                m_Comment = value;
            }
        }

        public string DirectoryPath
        {
            get
            {
                return m_DirectoryPath;
            }
        }

        public byte[] FileHash
        {
            get
            {
                return m_FileHash;
            }
        }

        public string FileHashString
        {
            get
            {
                return m_FileHashString;
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
        }

        public string FilePath
        {
            get
            {
                return m_FilePath;
            }
        }

        public long FileSize
        {
            get
            {
                return m_FileSize;
            }
        }

        public string FileSizeString
        {
            get
            {
                return m_FileSizeString;
            }
        }

        public DateTime? LastRequest
        {
            get
            {
                return m_LastRequest;
            }
            set
            {
                m_LastRequest = value;
            }
        }

        public DateTime LastWriteTime
        {
            get
            {
                return m_LastWriteTime;
            }
        }

        public RIndexedHashtable<string, string> MetaData
        {
            get
            {
                return m_MetaData;
            }
        }

        public byte[] OnceHashedFileHash
        {
            get
            {
                return m_OnceHashedFileHash;
            }
        }

        public string OnceHashedFileHashString
        {
            get
            {
                return m_OnceHashedFileHashString;
            }
        }

        public byte Rating
        {
            get
            {
                return m_Rating;
            }
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException("value");

                m_Rating = value;
            }
        }

        public long Sectors
        {
            get
            {
                return m_Sectors;
            }
        }

        public byte[] ThriceHashedFileHash
        {
            get
            {
                return m_ThriceHashedFileHash;
            }
        }

        public string ThriceHashedFileHashString
        {
            get
            {
                return m_ThriceHashedFileHashString;
            }
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
        }

        public byte[] TwiceHashedFileHash
        {
            get
            {
                return m_TwiceHashedFileHash;
            }
        }

        public string TwiceHashedFileHashString
        {
            get
            {
                return m_TwiceHashedFileHashString;
            }
        }

        public int GetEntryLength()
        {
            UTF8Encoding encoding = new UTF8Encoding();
            int length = 64 + 4 + 2 + encoding.GetByteCount(m_FileName);
            foreach (KeyValuePair<string, string> metaData in m_MetaData)
            {
                length += 2;
                length += encoding.GetByteCount(metaData.Key);
                length += 2;
                length += encoding.GetByteCount(metaData.Value);
            }
            length += 2 + encoding.GetByteCount(m_Comment) + 1;
            return length;
        }

        public bool GetSectorData(long sector, out byte[] data, out byte[] hash, out byte[] hashCodeResult)
        {
            if (sector < 0)
                throw new ArgumentOutOfRangeException("sector");
            if (sector > m_Sectors)
                throw new ArgumentOutOfRangeException("sector");

            if (!File.Exists(m_FilePath) || File.GetLastWriteTime(m_FilePath) != m_LastWriteTime)
            {
                data = null;
                hash = null;
                hashCodeResult = null;
                return false;
            }
            try
            {
                byte[] readData = new byte[32768];
                FileStream fileStream = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                fileStream.Position = sector * 32768;
                int count;
                if (fileStream.Position + 32768 <= fileStream.Length)
                    count = 32768;
                else
                    count = (int)(fileStream.Length - fileStream.Position);
                fileStream.Read(readData, 0, count);
                fileStream.Close();
                data = readData;
                hash = ComputeHashes.SHA512Compute(data);
                // Sicherer Hash ANFANG
                hashCodeResult = new byte[64];
                for (int n = 0; n < 64; n++)
                    hashCodeResult[n] = (byte)(hash[n] ^ m_FileHash[n]);
                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                hashCodeResult = ComputeHashes.SHA512Compute(hashCodeResult);
                // Sicherer Hash ENDE
                return true;
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading from shared file '{0}'!", m_FileName);
                data = null;
                hash = null;
                hashCodeResult = null;
                return false;
            }
        }

        public SharedFile(string filePath, byte[] fileHash, RIndexedHashtable<string, string> metaData, string comment, byte rating, DateTime? lastRequest)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();
            if (rating > 3)
                throw new ArgumentOutOfRangeException("rating");
            if (comment == null)
                throw new ArgumentNullException("comment");

            m_FilePath = filePath;
            m_DirectoryPath = Path.GetDirectoryName(m_FilePath);
            m_FileName = Path.GetFileName(m_FilePath);
            m_FileHash = fileHash;
            m_FileHashString = Core.ByteArrayToString(m_FileHash);
            m_OnceHashedFileHash = ComputeHashes.SHA512Compute(m_FileHash);
            m_OnceHashedFileHashString = Core.ByteArrayToString(m_OnceHashedFileHash);
            m_TwiceHashedFileHash = ComputeHashes.SHA512Compute(m_OnceHashedFileHash);
            m_TwiceHashedFileHashString = Core.ByteArrayToString(m_TwiceHashedFileHash);
            m_ThriceHashedFileHash = ComputeHashes.SHA512Compute(m_TwiceHashedFileHash);
            m_ThriceHashedFileHashString = Core.ByteArrayToString(m_ThriceHashedFileHash);
            m_FileSize = new FileInfo(m_FilePath).Length;
            m_FileSizeString = Core.LengthToString(m_FileSize);
            m_Sectors = m_FileSize / 32768;
            if (metaData.IsEmpty)
                try
                {
                    switch (Path.GetExtension(m_FilePath))
                    {
                        case ".mp3":
                            FileStream fileStream = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                            ID3v1TagReader id3v1 = new ID3v1TagReader(fileStream);
                            if (id3v1.HasTag)
                            {
                                if (id3v1.HasAlbum && id3v1.Album.Trim() != string.Empty)
                                    m_MetaData.Add("Album", id3v1.Album.Trim());
                                if (id3v1.HasArtist && id3v1.Artist.Trim() != string.Empty)
                                    m_MetaData.Add("Artist", id3v1.Artist.Trim());
                                if (id3v1.HasTitle && id3v1.Title.Trim() != string.Empty)
                                    m_MetaData.Add("Title", id3v1.Title.Trim());
                            }
                            ID3v2TagTextFrameReader id3v2 = new ID3v2TagTextFrameReader(fileStream);
                            if (id3v2.HasTag)
                            {
                                if (id3v2.Frames.ContainsKey("TALB") && id3v2.Frames["TALB"].Trim() != string.Empty)
                                    m_MetaData.Add("TALB", id3v2.Frames["TALB"].Trim());
                                if (id3v2.Frames.ContainsKey("TPE1") && id3v2.Frames["TPE1"].Trim() != string.Empty)
                                    m_MetaData.Add("TPE1", id3v2.Frames["TPE1"].Trim());
                                if (id3v2.Frames.ContainsKey("TIT2") && id3v2.Frames["TIT2"].Trim() != string.Empty)
                                    m_MetaData.Add("TIT2", id3v2.Frames["TIT2"].Trim());
                            }
                            fileStream.Close();
                            break;
                        default:
                            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(m_FilePath);
                            if (fileVersionInfo.CompanyName != null && fileVersionInfo.CompanyName.Trim() != string.Empty)
                                m_MetaData.Add("CompanyName", fileVersionInfo.CompanyName.Trim());
                            if (fileVersionInfo.ProductName != null && fileVersionInfo.ProductName.Trim() != string.Empty)
                                m_MetaData.Add("ProductName", fileVersionInfo.ProductName.Trim());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An Exception was thrown while gathering meta data!");
                }
            else
                m_MetaData = metaData;
            Core.ParseMetaData(m_MetaData, out m_Album, out m_Artist, out m_Title);
            m_Rating = rating;
            m_Comment = comment;
            m_LastRequest = lastRequest;
            m_LastWriteTime = File.GetLastWriteTime(m_FilePath);
        }
    }
}
