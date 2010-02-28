//StealthNet
//Copyright (C) 2009 Lars Regensburger, Roland Moch, T.Norad

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
using System.Configuration;
using System.IO;

namespace Regensburger.RShare
{
    public sealed class CoreSettings
        : ICoreSettings
    {
        private Configuration m_Configuration;

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == null)
                    throw new ArgumentNullException("propertyName");

                return m_Configuration.AppSettings.Settings[propertyName].Value;

            }
            set
            {
                if (propertyName == null)
                    throw new ArgumentNullException("propertyName");
                if (value == null)
                    throw new ArgumentNullException("value");

                m_Configuration.AppSettings.Settings[propertyName].Value = value;
            }
        }

        public CoreSettings()
        {
            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
            exeConfigurationFileMap.ExeConfigFilename = new FileInfo("Config.xml").FullName;
            if (File.Exists(exeConfigurationFileMap.ExeConfigFilename))
            {
                m_Configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
                //2008-04-07 Nochbaer: Check Settings
                bool needtowrite = false;
                String[] keys = m_Configuration.AppSettings.Settings.AllKeys;
                Predicate<String> key;
                key = delegate(String StringToMatch) { return StringToMatch == "ActivateOnlineSignature"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("ActivateOnlineSignature", "False");
                    needtowrite = true;
                }
                //2009-01-25 Nochbaer
                key = delegate(String StringToMatch) { return StringToMatch == "ActivateSearchDB"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("ActivateSearchDB", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "AutoMoveDownloads"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("AutoMoveDownloads", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "AutoMoveDownloadsIntervall"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("AutoMoveDownloadsIntervall", "60");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "AverageConnectionsCount"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("AverageConnectionsCount", "5");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "ConfigurationFile"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("ConfigurationFile", "Config.xml");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "CorruptDirectory"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("CorruptDirectory", "corrupt");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "DownloadCapacity"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("DownloadCapacity", "131072");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "DownloadLimit"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("DownloadLimit", "65536");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "FirstStart"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("FirstStart", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "HasDownloadLimit"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("HasDownloadLimit", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "HasUploadLimit"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("HasUploadLimit", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "IncomingDirectory"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("IncomingDirectory", "incoming");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "LogDirectory"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("LogDirectory", "log");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "MaximumDownloadsCount"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("MaximumDownloadsCount", "6");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "MaxSearchDBResults"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("MaxSearchDBResults", "1000");
                    needtowrite = true;
                }
                //2008-07-24 Nochbaer: BZ 45
                key = delegate(String StringToMatch) { return StringToMatch == "NewDownloadsToBeginngingOfQueue"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("NewDownloadsToBeginngingOfQueue", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "OnlineSignatureUpdateIntervall"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("OnlineSignatureUpdateIntervall", "5");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "ParseCollections"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("ParseCollections", "True");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "Port"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("Port", "6097");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "PreferencesDirectory"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("PreferencesDirectory", "preferences");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "PreviewFiletypes"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("PreviewFiletypes", "wmv|mov|asf|avi|mpeg|mpg|mp3|flac|ogg|wav|wma");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "PreviewPlayer"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("PreviewPlayer", "");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "PreviewParams"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("PreviewParams", "");
                    needtowrite = true;
                }
                //2009-01-25 Nochbaer
                key = delegate(String StringToMatch) { return StringToMatch == "SearchDBCleanUpDays"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("SearchDBCleanUpDays", "7");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "SubFoldersForCollections"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("SubFoldersForCollections", "True");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "SynchronizeWebCaches"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("SynchronizeWebCaches", "True");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "TemporaryDirectory"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("TemporaryDirectory", "temp");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "UICulture"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("UICulture", "en");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "UploadCapacity"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("UploadCapacity", "16384");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "UploadLimit"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("UploadLimit", "8192");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "UseBytesInsteadOfBits"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("UseBytesInsteadOfBits", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "UserWasAsked"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("UserWasAsked", "False");
                    needtowrite = true;
                }
                key = delegate(String StringToMatch) { return StringToMatch == "WriteLogfile"; };
                if (!Array.Exists<String>(keys, key))
                {
                    m_Configuration.AppSettings.Settings.Add("WriteLogfile", "True");
                    needtowrite = true;
                }

                if (needtowrite)
                    m_Configuration.Save();
            }
            else
            {
                m_Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                m_Configuration.AppSettings.Settings.Add("ActivateOnlineSignature", "False");
                m_Configuration.AppSettings.Settings.Add("ActivateSearchDB", "False");
                m_Configuration.AppSettings.Settings.Add("AutoMoveDownloads", "False");
                m_Configuration.AppSettings.Settings.Add("AutoMoveDownloadsIntervall", "60");
                m_Configuration.AppSettings.Settings.Add("AverageConnectionsCount", "5");
                m_Configuration.AppSettings.Settings.Add("ConfigurationFile", "Config.xml");
                m_Configuration.AppSettings.Settings.Add("CorruptDirectory", "corrupt");
                m_Configuration.AppSettings.Settings.Add("DownloadCapacity", "131072");
                m_Configuration.AppSettings.Settings.Add("DownloadLimit", "65536");
                m_Configuration.AppSettings.Settings.Add("FirstStart", "False");
                m_Configuration.AppSettings.Settings.Add("HasDownloadLimit", "False");
                m_Configuration.AppSettings.Settings.Add("HasUploadLimit", "False");
                m_Configuration.AppSettings.Settings.Add("IncomingDirectory", "incoming");
                m_Configuration.AppSettings.Settings.Add("LogDirectory", "log");
                m_Configuration.AppSettings.Settings.Add("MaximumDownloadsCount", "5");
                m_Configuration.AppSettings.Settings.Add("MaxSearchDBResults", "1000");
                m_Configuration.AppSettings.Settings.Add("NewDownloadsToBeginngingOfQueue", "False");
                m_Configuration.AppSettings.Settings.Add("OnlineSignatureUpdateIntervall", "5");
                m_Configuration.AppSettings.Settings.Add("ParseCollections", "True");
                m_Configuration.AppSettings.Settings.Add("Port", "6097");
                m_Configuration.AppSettings.Settings.Add("PreferencesDirectory", "preferences");
                m_Configuration.AppSettings.Settings.Add("PreviewFiletypes", "wmv|mov|asf|avi|mpeg|mpg|mp3|flac|ogg|wav|wma");
                m_Configuration.AppSettings.Settings.Add("PreviewPlayer", "");
                m_Configuration.AppSettings.Settings.Add("PreviewParams", "");
                m_Configuration.AppSettings.Settings.Add("SearchDBCleanUpDays", "7");
                m_Configuration.AppSettings.Settings.Add("SubFoldersForCollections", "True");
                m_Configuration.AppSettings.Settings.Add("SynchronizeWebCaches", "True");
                m_Configuration.AppSettings.Settings.Add("TemporaryDirectory", "temp");
                m_Configuration.AppSettings.Settings.Add("UICulture", "en");
                m_Configuration.AppSettings.Settings.Add("UploadCapacity", "16384");
                m_Configuration.AppSettings.Settings.Add("UploadLimit", "8192");
                m_Configuration.AppSettings.Settings.Add("UseBytesInsteadOfBits", "False");
                m_Configuration.AppSettings.Settings.Add("UserWasAsked", "False");
                m_Configuration.AppSettings.Settings.Add("WriteLogfile", "True");
                m_Configuration.SaveAs(exeConfigurationFileMap.ExeConfigFilename);
            }
        }

        public void Save()
        {
            m_Configuration.Save();
        }

        public void Upgrade()
        {
            // no implmenetation for ui
        }
    }
}