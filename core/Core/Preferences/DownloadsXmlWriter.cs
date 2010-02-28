//StealthNet
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

using Regensburger.RShare;
using System;
using System.IO;
using System.Xml;

namespace StealthNet.Core
{
    internal static class DownloadsXmlWriter
    {
        private static bool m_IsReady = false;

        private static Logger m_Logger = Logger.Instance;

        public static bool IsReady
        {
            get
            {
                return m_IsReady;
            }
        }

        public static void SetIsReady()
        {
            m_IsReady = true;
        }

        /// <summary>
        /// Neue Write()
        /// 03.07.2009 Lars
        /// 04.07.2009 Lars (!HasInformation und SectorsMap)
        /// 09.07.2009 Lars (Falls StealthNet abstürzt, wird die downloads.xml nicht mehr "gekillt")
        /// </summary>
        public static void Write(string downloadsFilePath, DownloadCollection downloads)
        {
            if (downloadsFilePath == null)
                throw new ArgumentNullException("downloadsFilePath");
            if (downloadsFilePath == string.Empty)
                throw new ArgumentException();
            if (downloads == null)
                throw new ArgumentNullException("downloads");

            if (!m_IsReady)
                return;
            try
            {
                try
                {
                    if (File.Exists(downloadsFilePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", downloadsFilePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(downloadsFilePath, backupFilePath);
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown while archiving the downloads.xml!");
                }
                XmlWriterSettings downloadsXmlWriterSettings = new XmlWriterSettings();
                downloadsXmlWriterSettings.CloseOutput = true;
                downloadsXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter downloadsXmlWriter = XmlWriter.Create(memoryStream, downloadsXmlWriterSettings);
                downloadsXmlWriter.WriteStartDocument();
                downloadsXmlWriter.WriteStartElement("downloads");
                foreach (Download download in downloads.Values)
                {
                    string fileHashString = download.FileHashString;
                    long fileSize = download.FileSize;
                    string fileName = download.FileName;
                    DateTime? lastSeen = download.LastSeen;
                    DateTime? lastReception = download.LastReception;
                    string subFolder = download.SubFolder;
                    byte[] sectorsMap = download.SectorsMap;
                    if (fileHashString == null || fileHashString.Length != 128 || fileSize < 0 ||
                        fileName == null || fileName == string.Empty || (download.HasInformation && sectorsMap == null))
                    {
                        m_Logger.Log("A download could not be saved because of invalid information about it!\n\nFile Hash: {0}\nFile Size: {1}\nFile Name: {2}\nSectors Map: {3}", fileHashString, fileSize, fileName, sectorsMap);
                        continue;
                    }
                    downloadsXmlWriter.WriteStartElement("download");
                    downloadsXmlWriter.WriteAttributeString("hash", fileHashString);
                    if (!download.HasInformation)
                        downloadsXmlWriter.WriteAttributeString("hasinformation", "none");
                    downloadsXmlWriter.WriteStartElement("filesize");
                    downloadsXmlWriter.WriteValue(fileSize);
                    downloadsXmlWriter.WriteEndElement();
                    if (download.HasInformation)
                    {
                        downloadsXmlWriter.WriteStartElement("sectorsmap");
                        downloadsXmlWriter.WriteValue(Convert.ToBase64String(sectorsMap));
                        downloadsXmlWriter.WriteEndElement();
                    }
                    downloadsXmlWriter.WriteStartElement("filename");
                    downloadsXmlWriter.WriteValue(fileName);
                    downloadsXmlWriter.WriteEndElement();
                    if (lastSeen != null && lastSeen.HasValue)
                    {
                        downloadsXmlWriter.WriteStartElement("lastseen");
                        downloadsXmlWriter.WriteValue(lastSeen.Value.ToString());
                        downloadsXmlWriter.WriteEndElement();
                    }
                    if (lastReception != null && lastReception.HasValue)
                    {
                        downloadsXmlWriter.WriteStartElement("lastreception");
                        downloadsXmlWriter.WriteValue(lastReception.Value.ToString());
                        downloadsXmlWriter.WriteEndElement();
                    }
                    if (subFolder != null && subFolder != string.Empty)
                    {
                        downloadsXmlWriter.WriteStartElement("subfolder");
                        downloadsXmlWriter.WriteValue(subFolder);
                        downloadsXmlWriter.WriteEndElement();
                    }
                    downloadsXmlWriter.WriteEndElement();
                }
                downloadsXmlWriter.WriteEndElement();
                downloadsXmlWriter.WriteEndDocument();
                downloadsXmlWriter.Flush();
                FileStream fileStream = new FileStream(downloadsFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                downloadsXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing the downloads.xml!");
            }
        }
    }
}
