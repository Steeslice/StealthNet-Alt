//StealthNet
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

using Regensburger.RShare;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace StealthNet.Core
{
    internal static class StatisticsXmlWriter
    {
        // instance of the logger
        private static Logger m_Logger = Logger.Instance;

        public static void write(string statisticsFilePath, string cumulativeDownloaded, string cumulativeUploaded, string uptime)
        {
            try
            {
                try
                {
                    if (File.Exists(statisticsFilePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", statisticsFilePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(statisticsFilePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings statisticsXmlWriterSettings = new XmlWriterSettings();
                statisticsXmlWriterSettings.CloseOutput = true;
                statisticsXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter statisticsXmlWriter = XmlWriter.Create(memoryStream, statisticsXmlWriterSettings);
                statisticsXmlWriter.WriteStartDocument();
                statisticsXmlWriter.WriteStartElement("statistics");
                statisticsXmlWriter.WriteStartElement("downloaded");
                statisticsXmlWriter.WriteValue(cumulativeDownloaded);
                statisticsXmlWriter.WriteEndElement();
                statisticsXmlWriter.WriteStartElement("uploaded");
                statisticsXmlWriter.WriteValue(cumulativeUploaded);
                statisticsXmlWriter.WriteEndElement();
                statisticsXmlWriter.WriteStartElement("uptime");
                statisticsXmlWriter.WriteValue(uptime);
                statisticsXmlWriter.WriteEndElement();
                statisticsXmlWriter.WriteEndElement();
                statisticsXmlWriter.WriteEndDocument();
                statisticsXmlWriter.Flush();
                FileStream fileStream = new FileStream(statisticsFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                statisticsXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing statistics file!");
            }
        }
    }
}
