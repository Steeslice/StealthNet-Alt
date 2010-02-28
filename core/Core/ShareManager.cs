//ShareManager class for RShare
//Copyright (C) 2009 Lars Regensburger, ariah, T.Norad

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
//Foundation, Inc., 51 Franklin Street, Fifth Floor,
//Boston, MA  02110-1301, USA.

using Regensburger.RCollections.ArrayBased;
using Regensburger.RCollections.LinkBased;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace Regensburger.RShare
{
    /* ShareManager will handle adding and removing shared directories, saving
     * and loading the configuration of shared directories, shared files, meta
     * data and comments. ShareManager supplies a list of shared files, and 
     * keeps it up to date. Runtime adding and removing shared files and
     * directories is supported. Use of ShareManager is threadsafe.
     */
    public partial class ShareManager
    {
        //2009-05-21 Eroli
        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_IsReady = false;

        /***** public members ************************************************/

        
        /**
         * Get the list of shared directories.
         */
        public Regensburger.RCollections.ArrayBased.RList<string> SharedDirectories
        {
            get
            {
                return m_SharedDirectories;
            }
        }


        /**
         * Get the list of shared files.
         */
        public SharedFileCollection SharedFiles
        {
            get
            {
                return m_SharedFiles;
            }
        }
        
        /**
         * Get the number of remaining files in the hashing queue.
         */
        public int HashingQueueCount
        {
            get
            {
                return m_HashingQueue.Count;
            }
        }

        public bool IsReady
        {
            get
            {
                return m_IsReady;
            }
        }



        /// <summary>
        /// Lädt alle Konfigurationsdateien, die die freigegebenenen Dateien betreffen.
        /// 07.07.2009 Lars
        /// </summary>
        public void LoadConfiguration(string sharedDirectoriesPath, string sharedFilesPath, string sharedFilesStatsPath, string metaDataPath, string commentsPath, string ratingsPath)
        {
            Thread loadConfigThread = new Thread(delegate()
            {
                // set ui language in this thread
                Core.SetUILanguage();
                try
                {
                    LoadSharedFileEntries(sharedFilesPath);
                    LoadMetaData(metaDataPath);
                    LoadComments(commentsPath);
                    LoadRatings(ratingsPath);
                    LoadSharedFilesStats(sharedFilesStatsPath);
                    LoadSharedDirectories(sharedDirectoriesPath);
                    m_IsReady = true;
                }
                catch (Exception ex)
                {
                    m_IsReady = false;
                    m_Logger.Log(ex, "An exception was thrown while reading shared files configuration!");
                    m_Logger.Log("All configuration files that belong to the shared files will not be overriden anymore!");
                }
            });
            loadConfigThread.IsBackground = true;
            loadConfigThread.Priority = ThreadPriority.Lowest;
            loadConfigThread.Start();
        }



        /// <summary>
        /// Speichert alle Konfigurationsdateien, die die freigegebenenen Dateien betreffen.
        /// 07.07.2009 Lars
        /// </summary>
        public void SaveConfiguration(string sharedDirectoriesPath, string sharedFilesPath, string sharedFilesStatsPath, string metaDataPath, string commentsPath, string ratingsPath)
        {
            if (!m_IsReady)
                return;
            try
            {
                SaveSharedFileEntries(sharedFilesPath);
                SaveSharedDirectories(sharedDirectoriesPath);
                SaveMetaData(metaDataPath);
                SaveComments(commentsPath);
                SaveRatings(ratingsPath);
                SaveSharedFilesStats(sharedFilesStatsPath);
            }
            catch (Exception ex)
            {
                m_IsReady = false;
                m_Logger.Log(ex, "An exception was thrown while saving shared files configuration!");
                m_Logger.Log("All configuration files that belong to the shared files will not be overriden anymore!");
            }
        }



        /// <summary>
        /// Fügt eine bereits heruntergeladene Datei zu den Entries hinzu,
        /// um ein erneutes Hashen zu verhindern.
        /// 08.07.2009 Lars
        /// </summary>
        public void AddDownloadedFile(string tempFilePath, string incomingFilePath, byte[] fileHash)
        {
            if (tempFilePath == null)
                throw new ArgumentNullException("tempFilePath");
            if (incomingFilePath == null)
                throw new ArgumentNullException("incomingFilePath");
            if (fileHash == null)
                throw new ArgumentNullException("fileHash");
            if (fileHash.Length != 64)
                throw new ArgumentException();

            try
            {
                m_SharedFileEntries.Lock();
                m_SharedFileEntries.Remove(incomingFilePath);
                m_SharedFileEntries.Add(incomingFilePath, new SharedFileEntry(incomingFilePath, fileHash, File.GetLastWriteTime(tempFilePath)));
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while adding a downloaded file!");
            }
            finally
            {
                m_SharedFileEntries.Unlock();
            }
        }



        /**
         * AddDirectory adds a directory path to the list of shared
         * directories. All files in the shared directory and its subdirectory
         * are hashed and added to the shred files list. The contents of the 
         * shared directory are atomatically tracked and updated via a
         * FileSystemWatcher object.
         */
        public bool AddDirectory(string sharedDirectory)
        {
            if (sharedDirectory == null)
                throw new ArgumentNullException("sharedDirectory");

            try
            {
                if (!Directory.Exists(sharedDirectory))
                {
                    m_Logger.Log("AddDirectory: Directory does not exist: \"{0}\"", sharedDirectory);
                    return false;
                }

                // check if parent or passed directory is already shared
                // 2007-08-06 fix for Ticket #71 T.Norad
                bool hasParent = false;
                bool isAlreadyShared = false;
                DirectoryInfo parentDirectory = Directory.GetParent(sharedDirectory);
                foreach (string sharedDir in m_SharedDirectories)
                {
                    // is the directory already shared?
                    if (sharedDirectory.Equals(sharedDir))
                    {
                        isAlreadyShared = true;
                        break;
                    }
                    // is the parent already shared?
                    if (parentDirectory != null && parentDirectory.FullName.Contains(sharedDir))
                    {
                        hasParent = true;
                        break;
                    }
                }

                if (!(hasParent || isAlreadyShared))
                {
                    // add directory
                    m_SharedDirectories.Add(sharedDirectory);

                    // add directory watcher
                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = sharedDirectory;
                    watcher.IncludeSubdirectories = true;
                    watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    watcher.Created += new FileSystemEventHandler(OnChanged);
                    watcher.Deleted += new FileSystemEventHandler(OnChanged);
                    watcher.Renamed += new RenamedEventHandler(OnRenamed);
                    watcher.EnableRaisingEvents = true;
                    m_DirectoryWatchers[sharedDirectory] = watcher;

                    m_Logger.Log(Properties.Resources_Core.AddedDirectory, sharedDirectory);
                }

                // index and hash contained files
                try
                {
                    FileInfo[] fileInfos = null;
                    while (fileInfos == null)
                    {
                        try
                        {
                            fileInfos = new DirectoryInfo(sharedDirectory).GetFiles("*", SearchOption.AllDirectories);
                        }
                        catch(Exception ex)
                        {
                            m_Logger.Log(ex, "An Exception was thrown while retrieving file information from directory \"{0}\"!", sharedDirectory);
                            // T.Norad BZ 134. break the loop if an exception is raised
                            return false;
                        }
                    }
                    SharedFileEntry sharedFileEntry;
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        if (m_SharedFileEntries.TryGetValue(fileInfo.FullName, out sharedFileEntry))
                        {
                            string fileHashString = Core.ByteArrayToString(sharedFileEntry.FileHash);

                            try
                            {
                                m_SharedFiles.Lock();
                                if (!m_SharedFiles.ContainsKey(fileHashString))
                                {
                                    MetaDataEntry metaDataEntry;
                                    if (!m_MetaDataEntries.TryGetValue(fileHashString, out metaDataEntry))
                                        metaDataEntry = new MetaDataEntry();
                                    m_SharedFiles.Add(new SharedFile(sharedFileEntry.FilePath, sharedFileEntry.FileHash, metaDataEntry.MetaData, metaDataEntry.Comment, metaDataEntry.Rating, metaDataEntry.LastRequest));
                                }
                            }
                            finally
                            {
                                m_SharedFiles.Unlock();
                            }
                        }
                        else
                        {
                            AddFile(fileInfo.FullName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown while indexing shared directory \"{0}\"!", sharedDirectory);
                    return false;
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while adding a shared directory!");
                return false;
            }
                        
            return true;
        }
        
        /**
         * RemoveDirectory removes a shared directory from the shared
         * directory list. All files contained in the directory or its sub
         * directories are removed from the shared files list. The
         * FileSystemWatcher for this directory is disabled and removed.
         */
        public bool RemoveDirectory(string sharedDirectory)
        {
            if (sharedDirectory == null)
                throw new ArgumentNullException("sharedDirectory");

            try
            {
                // remove shared directory and watcher
                try
                {
                    m_SharedDirectories.Lock();
                    if (m_DirectoryWatchers.ContainsKey(sharedDirectory)) 
                    {
                        m_DirectoryWatchers[sharedDirectory].EnableRaisingEvents = false;
                        m_DirectoryWatchers.Remove(sharedDirectory);
                    }
                    if (m_SharedDirectories.Contains(sharedDirectory))
                    {
                        m_SharedDirectories.Remove(sharedDirectory);
                    }
                }
                finally
                {
                    m_SharedDirectories.Unlock();
                }

                // remove all files in hash queue that contain the directory path
                try
                {
                    m_HashingQueue.Lock();
                    Regensburger.RCollections.LinkBased.RQueue<string> newHashingQueue = new Regensburger.RCollections.LinkBased.RQueue<string>();
                    while (!m_HashingQueue.IsEmpty)
                    {
                        string fileToHash = m_HashingQueue.Dequeue();
                        if (!fileToHash.Contains(sharedDirectory))
                        {
                            newHashingQueue.Enqueue(fileToHash);
                        }
                    }
                    while (!newHashingQueue.IsEmpty)
                    {
                        m_HashingQueue.Enqueue(newHashingQueue.Dequeue());
                    }
                }
                finally
                {
                    m_HashingQueue.Unlock();
                }

                // remove all shared files containing the directory path
                RHashtable<string, SharedFile> sharedFilesCopy = new RHashtable<string, SharedFile>(m_SharedFiles);
                foreach (SharedFile sharedFile in sharedFilesCopy.Values)
                {
                    if (sharedFile.FilePath.Contains(sharedDirectory))
                    {
                        RemoveFile(sharedFile.FilePath);
                    }
                }

                m_Logger.Log("Removed directory \"{0}\"", sharedDirectory);
                return true;
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while removing a shared directory!");
                return false;
            }
        }



        /***** private members ***********************************************/
   


        /**
         * AddFile adds a new entry (hash, path, lastwritetime, metadata)
         * to the list of shared files.
         */
        private void AddFile(string filePathQ)
        {
            try
            {
                // add file to hashing queue
                try
                {
                    m_HashingQueue.Lock();
                    if (!m_HashingQueue.Contains(filePathQ))
                    {
                        m_HashingQueue.Enqueue(filePathQ);
                    }
                }
                finally
                {
                    m_HashingQueue.Unlock();
                }

                // if no hashing thread is running, start a new hashing thread
                if (m_HashingThread == null || !m_HashingThread.IsAlive)
                {
                    m_HashingThread = new Thread(delegate()
                    {
                        while (!m_HashingQueue.IsEmpty)
                        {
                            try
                            {
                                string filePath = string.Empty;
                                try
                                {
                                    m_HashingQueue.Lock();
                                    filePath = m_HashingQueue.Dequeue();
                                }
                                finally
                                {
                                    m_HashingQueue.Unlock();
                                }
                                if (File.Exists(filePath))
                                {
                                    byte[] fileHash = null;
                                    string hashSource = "unknown";
                                    SharedFileEntry knownSharedFileEntry = null;

                                    // check to see if the file is already in the database
                                    try
                                    {
                                        m_SharedFileEntries.Lock();
                                        foreach (SharedFileEntry sharedFileEntry in m_SharedFileEntries.Values)
                                        {
                                            if (Path.GetFileName(sharedFileEntry.FilePath).Equals(Path.GetFileName(filePath)) &&
                                                new FileInfo(filePath).LastWriteTime.Equals(sharedFileEntry.LastWriteTime))
                                            {
                                                knownSharedFileEntry = sharedFileEntry;
                                                break;
                                            }
                                        }

                                        if (knownSharedFileEntry != null)
                                        {
                                            // file is already known, use the existing hash
                                            m_SharedFileEntries.Remove(knownSharedFileEntry.FilePath);
                                            fileHash = knownSharedFileEntry.FileHash;
                                            hashSource = "database";
                                        }
                                        else
                                        {
                                            // file is not known, so we have to calculate the hash
                                            FileStream fileStream = null;
                                            while (fileStream == null)
                                            {
                                                try
                                                {
                                                    fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                                                }
                                                catch (System.IO.IOException)
                                                {
                                                }
                                            }
                                            //FileStream fileStream = new FileStream(filePath, FileMode.Open);
                                            fileHash = ComputeHashes.SHA512Compute(fileStream);
                                            fileStream.Close();
                                            hashSource = "new file";
                                        }

                                        // check if hashed file is still valid (not removed during hashing)
                                        // and add to shared file entries
                                        foreach (string sharedDir in m_SharedDirectories)
                                        {
                                            if (filePath.Contains(sharedDir))
                                            {
                                                m_SharedFileEntries[filePath] = new SharedFileEntry(filePath, fileHash, new FileInfo(filePath).LastWriteTime);
                                                goto fileValid;
                                            }
                                        }
                                    }
                                    finally
                                    {
                                        m_SharedFileEntries.Unlock();
                                    }
                                    continue;
                                fileValid:

                                    // add to meta data entries and shared files
                                    try
                                    {
                                        m_SharedFiles.Lock();

                                        string fileHashString = Core.ByteArrayToString(fileHash);
                                        if (!m_SharedFiles.ContainsKey(fileHashString))
                                        {
                                            MetaDataEntry metaDataEntry;
                                            if (!m_MetaDataEntries.TryGetValue(fileHashString, out metaDataEntry))
                                                metaDataEntry = new MetaDataEntry();
                                            m_SharedFiles.Add(new SharedFile(filePath, fileHash, metaDataEntry.MetaData, metaDataEntry.Comment, metaDataEntry.Rating, metaDataEntry.LastRequest));
                                        }
                                    }
                                    finally
                                    {
                                        m_SharedFiles.Unlock();
                                    }

                                    m_Logger.Log("Added file from {0} \"{1}\"", hashSource, filePath);
                                }
                                else
                                {
                                    m_Logger.Log("AddFile: File does not exist: \"{0}\"", filePath);
                                }
                            }
                            catch (Exception ex)
                            {
                                m_Logger.Log("AddFile: An exception was thrown during hashing: {0}", ex);
                            }
                        }
                    });
                    m_HashingThread.IsBackground = true;
                    m_HashingThread.Priority = ThreadPriority.Lowest;
                    m_HashingThread.Start();
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while adding a shared file!");
            }
        }
        
        
        
        /**
         * RemoveFile removes a shared file from the list of shared
         * files. Metadata is kept for future use.
         */
        private bool RemoveFile(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");

            try
            {
                SharedFileEntry sharedFileEntry;
                m_SharedFiles.Lock();
                if (m_SharedFileEntries.TryGetValue(filePath, out sharedFileEntry))
                {
                    string fileHashString = Core.ByteArrayToString(sharedFileEntry.FileHash);
                    SharedFile sharedFile;
                    if (m_SharedFiles.TryGetValue(fileHashString, SharedFileCollection.KeyAccess.FileHash, out sharedFile))
                        m_SharedFiles.Remove(sharedFile);

                    m_Logger.Log("Removed file \"{0}\"", filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while removing a shared file!");
            }
            finally
            {
                m_SharedFiles.Unlock();
            }

            return false;
        }



        /**
         * RenameFile renames a file without starting a new hashing process.
         */
        private void RenameFile(string oldPath, string newPath)
        {
            try
            {
                if (!File.Exists(newPath))
                {
                    return;
                }

                try
                {
                    m_SharedFileEntries.Lock();
                    m_SharedFiles.Lock();
                    SharedFileEntry sharedFileEntry;
                    if (m_SharedFileEntries.TryGetValue(oldPath, out sharedFileEntry))
                    {
                        m_SharedFileEntries.Remove(oldPath);
                        sharedFileEntry.FilePath = newPath;
                        m_SharedFileEntries[newPath] = sharedFileEntry;
                        SharedFile sharedFile = m_SharedFiles[Core.ByteArrayToString(sharedFileEntry.FileHash)];
                        m_SharedFiles[sharedFile.FileHashString] = new SharedFile(newPath, sharedFile.FileHash, sharedFile.MetaData, sharedFile.Comment, sharedFile.Rating, sharedFile.LastRequest);
                        m_Logger.Log("Renamed file \"{0}\" to \"{1}\"", oldPath, newPath);
                    }
                }
                finally
                {
                    m_SharedFiles.Unlock();
                    m_SharedFileEntries.Unlock();
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while renaming a shared file!");
            }
        }



        /**
         * RenameDirectory renames a directory without starting a new hashing
         * process.
         */
        private void RenameDirectory(string oldPath, string newPath)
        {
            try
            {
                if (!Directory.Exists(newPath))
                {
                    return;
                }

                try
                {
                    m_SharedDirectories.Lock();
                    if (m_SharedDirectories.Contains(oldPath))
                        m_SharedDirectories.Remove(oldPath);
                    if (!m_SharedDirectories.Contains(newPath))
                        m_SharedDirectories.Add(newPath);
                }
                finally
                {
                    m_SharedDirectories.Unlock();
                }

                Regensburger.RCollections.ArrayBased.RList<string> temporaray = new Regensburger.RCollections.ArrayBased.RList<string>();
                foreach (SharedFileEntry sharedFileEntry in m_SharedFileEntries.Values)
                    if (sharedFileEntry.FilePath.Contains(oldPath))
                        temporaray.Add(sharedFileEntry.FilePath);
                foreach (string oldFilePath in temporaray)
                    RenameFile(oldFilePath, oldFilePath.Replace(oldPath, newPath));

                m_Logger.Log("Renamed directory \"{0}\" to \"{1}\"", oldPath, newPath);
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while renaming a shared directory!");
            }
        }



        /**
         * OnChanged implements an event handler that is called every time
         * when a shared file is changed on disc. The file is hashed /
         * removed appropriately.
         */
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                // set ui language in this thread
                Core.SetUILanguage();

                // check for deleted first, otherwise trying to get attribute
                // information will result in a file not found exception
                if (e.ChangeType.Equals(WatcherChangeTypes.Deleted))
                {
                    if (!RemoveFile(e.FullPath))
                    {
                        RemoveDirectory(e.FullPath);
                    }
                    return;
                }
                // 2007-08-06 T.Norad Reimplement fix for Ticket #51
                // check if the file exists before we get the attributs from file
                // in some cases this event is raised but the file doesn't really exist in filesystem
                // i. e. we download a file from the internet. the event is raised on start download
                // but the file exist in filesystem after finish download
                // T.Norad: Bugfix for BZ96. Moved directories not recognized
                if (e.FullPath != null && (File.Exists(e.FullPath) || Directory.Exists(e.FullPath)))
                {
                    if (File.GetAttributes(e.FullPath).Equals(FileAttributes.Directory))
                    {
                        // directory
                        switch (e.ChangeType)
                        {
                            case WatcherChangeTypes.Created:
                                AddDirectory(e.FullPath);
                                break;

                            case WatcherChangeTypes.Changed:
                                // do nothing for now
                                //RemoveDirectory(e.FullPath);
                                //AddDirectory(e.FullPath);
                                break;
                        }
                    }
                    else
                    {
                        // file
                        switch (e.ChangeType)
                        {
                            case WatcherChangeTypes.Created:
                                AddFile(e.FullPath);
                                break;

                            case WatcherChangeTypes.Changed:
                                RemoveFile(e.FullPath);
                                AddFile(e.FullPath);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown in \"OnChanged\"!");
            }
        }


        /**
         * OnRenamed implements an event handler that is called every time when
         * a shared file is renamed on disc. The file is rehashed
         * appropriately.
         */
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            try
            {
                if (e.ChangeType.Equals(WatcherChangeTypes.Renamed))
                {
                    if (Directory.Exists(e.FullPath))
                    {
                        RenameDirectory(e.OldFullPath, e.FullPath);
                    }
                    else
                    {
                        RenameFile(e.OldFullPath, e.FullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown in \"OnRenamed\"!");
            }
        }



        /**
         * SaveSharedDirectories writes information on shared directories to
         * a configuration file.
         */
        private void SaveSharedDirectories(string filePath)
        {
            try
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", filePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(filePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings sharedDirectoriesXmlWriterSettings = new XmlWriterSettings();
                sharedDirectoriesXmlWriterSettings.CloseOutput = true;
                sharedDirectoriesXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter sharedDirectoriesXmlWriter = XmlWriter.Create(memoryStream, sharedDirectoriesXmlWriterSettings);
                sharedDirectoriesXmlWriter.WriteStartDocument();
                sharedDirectoriesXmlWriter.WriteStartElement("shareddirectories");
                foreach (string sharedDirectory in m_SharedDirectories)
                {
                    sharedDirectoriesXmlWriter.WriteStartElement("shareddirectory");
                    sharedDirectoriesXmlWriter.WriteStartAttribute("path");
                    sharedDirectoriesXmlWriter.WriteValue(sharedDirectory);
                    sharedDirectoriesXmlWriter.WriteEndAttribute();
                    sharedDirectoriesXmlWriter.WriteEndElement();
                }
                sharedDirectoriesXmlWriter.WriteEndElement();
                sharedDirectoriesXmlWriter.WriteEndDocument();
                sharedDirectoriesXmlWriter.Flush();
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                sharedDirectoriesXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing shared directories file!");
            }
        }



        /**
         * SaveSharedFileEntries writes information on shared files to
         * a configuration file.
         */
        private void SaveSharedFileEntries(string filePath)
        {
            try
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", filePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(filePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings sharedFilesXmlWriterSettings = new XmlWriterSettings();
                sharedFilesXmlWriterSettings.CloseOutput = true;
                sharedFilesXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter sharedFilesXmlWriter = XmlWriter.Create(memoryStream, sharedFilesXmlWriterSettings);
                sharedFilesXmlWriter.WriteStartDocument();
                sharedFilesXmlWriter.WriteStartElement("sharedfiles");
                foreach (SharedFileEntry sharedFileEntry in m_SharedFileEntries.Values)
                {
                    sharedFilesXmlWriter.WriteStartElement("sharedfile");
                    sharedFilesXmlWriter.WriteStartAttribute("filepath");
                    sharedFilesXmlWriter.WriteValue(sharedFileEntry.FilePath);
                    sharedFilesXmlWriter.WriteEndAttribute();
                    sharedFilesXmlWriter.WriteStartElement("filehash");
                    sharedFilesXmlWriter.WriteValue(Core.ByteArrayToString(sharedFileEntry.FileHash));
                    sharedFilesXmlWriter.WriteEndElement();
                    sharedFilesXmlWriter.WriteStartElement("lastwritetime");
                    sharedFilesXmlWriter.WriteValue(sharedFileEntry.LastWriteTime);
                    sharedFilesXmlWriter.WriteEndElement();
                    sharedFilesXmlWriter.WriteEndElement();
                }
                sharedFilesXmlWriter.WriteEndElement();
                sharedFilesXmlWriter.WriteEndDocument();
                sharedFilesXmlWriter.Flush();
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                sharedFilesXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing shared files file!");
            }
        }



        /**
         * SaveComments writes the comments for shared files to a configuration
         * file.
         */
        private void SaveComments(string filePath)
        {
            try
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", filePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(filePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings commentsXmlWriterSettings = new XmlWriterSettings();
                commentsXmlWriterSettings.CloseOutput = true;
                commentsXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter commentsXmlWriter = XmlWriter.Create(memoryStream, commentsXmlWriterSettings);
                commentsXmlWriter.WriteStartDocument();
                commentsXmlWriter.WriteStartElement("sharedfiles");
                foreach (SharedFile sharedFile in m_SharedFiles.Values)
                {
                    if (sharedFile.Comment == string.Empty)
                        continue;
                    commentsXmlWriter.WriteStartElement("sharedfile");
                    commentsXmlWriter.WriteStartAttribute("filehash");
                    commentsXmlWriter.WriteValue(sharedFile.FileHashString);
                    commentsXmlWriter.WriteEndAttribute();
                    commentsXmlWriter.WriteStartElement("comment");
                    commentsXmlWriter.WriteValue(Convert.ToBase64String(Encoding.UTF8.GetBytes(sharedFile.Comment)));
                    commentsXmlWriter.WriteEndElement();
                    commentsXmlWriter.WriteEndElement();
                }
                commentsXmlWriter.WriteEndElement();
                commentsXmlWriter.WriteEndDocument();
                commentsXmlWriter.Flush();
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                commentsXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing comments file!");
            }
        }



        /**
         * SaveMetaData writes the meta data for shared files to a
         * configuration file.
         */
        private void SaveMetaData(string filePath)
        {
            try
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", filePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(filePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings metaDataXmlWriterSettings = new XmlWriterSettings();
                metaDataXmlWriterSettings.CloseOutput = true;
                metaDataXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter metaDataXmlWriter = XmlWriter.Create(memoryStream, metaDataXmlWriterSettings);
                metaDataXmlWriter.WriteStartDocument();
                metaDataXmlWriter.WriteStartElement("sharedfiles");
                foreach (SharedFile sharedFile in m_SharedFiles.Values)
                {
                    if (sharedFile.MetaData.IsEmpty)
                        continue;
                    metaDataXmlWriter.WriteStartElement("sharedfile");
                    metaDataXmlWriter.WriteStartAttribute("filehash");
                    metaDataXmlWriter.WriteValue(sharedFile.FileHashString);
                    metaDataXmlWriter.WriteEndAttribute();
                    foreach (KeyValuePair<string, string> metaData in sharedFile.MetaData)
                    {
                        metaDataXmlWriter.WriteStartElement("metadata");
                        metaDataXmlWriter.WriteStartAttribute("key");
                        metaDataXmlWriter.WriteValue(metaData.Key);
                        metaDataXmlWriter.WriteEndAttribute();
                        metaDataXmlWriter.WriteValue(Convert.ToBase64String(Encoding.UTF8.GetBytes(metaData.Value)));
                        metaDataXmlWriter.WriteEndElement();
                    }
                    metaDataXmlWriter.WriteEndElement();
                }
                metaDataXmlWriter.WriteEndElement();
                metaDataXmlWriter.WriteEndDocument();
                metaDataXmlWriter.Flush();
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                metaDataXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing meta data file!");
            }
        }



        /**
         * SaveRatings writes ratings for shared files to a configuration
         * file.
         */
        private void SaveRatings(string filePath)
        {
            try
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", filePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(filePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings ratingsXmlWriterSettings = new XmlWriterSettings();
                ratingsXmlWriterSettings.CloseOutput = true;
                ratingsXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter ratingsXmlWriter = XmlWriter.Create(memoryStream, ratingsXmlWriterSettings);
                ratingsXmlWriter.WriteStartDocument();
                ratingsXmlWriter.WriteStartElement("sharedfiles");
                foreach (SharedFile sharedFile in m_SharedFiles.Values)
                {
                    if (sharedFile.Rating == 0)
                        continue;
                    ratingsXmlWriter.WriteStartElement("sharedfile");
                    ratingsXmlWriter.WriteStartAttribute("filehash");
                    ratingsXmlWriter.WriteValue(sharedFile.FileHashString);
                    ratingsXmlWriter.WriteEndAttribute();
                    ratingsXmlWriter.WriteStartElement("rating");
                    ratingsXmlWriter.WriteValue(sharedFile.Rating);
                    ratingsXmlWriter.WriteEndElement();
                    ratingsXmlWriter.WriteEndElement();
                }
                ratingsXmlWriter.WriteEndElement();
                ratingsXmlWriter.WriteEndDocument();
                ratingsXmlWriter.Flush();
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                ratingsXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing ratings file!");
            }
        }


        /**
         * SaveSharedFilesStats writes stats for shared files to a configuration
         * file.
         */
        private void SaveSharedFilesStats(string filePath)
        {
            try
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string backupFilePath = string.Format("{0}.bak", filePath);
                        if (File.Exists(backupFilePath))
                        {
                            string backupBackupFilePath = string.Format("{0}.bak", backupFilePath);
                            if (File.Exists(backupBackupFilePath))
                                File.Delete(backupBackupFilePath);
                            File.Move(backupFilePath, backupBackupFilePath);
                        }
                        File.Move(filePath, backupFilePath);
                    }
                }
                catch
                {
                }
                XmlWriterSettings statsXmlWriterSettings = new XmlWriterSettings();
                statsXmlWriterSettings.CloseOutput = true;
                statsXmlWriterSettings.Indent = true;
                MemoryStream memoryStream = new MemoryStream();
                XmlWriter statsXmlWriter = XmlWriter.Create(memoryStream, statsXmlWriterSettings);
                statsXmlWriter.WriteStartDocument();
                statsXmlWriter.WriteStartElement("sharedfilesstats");
                foreach (SharedFile sharedFile in m_SharedFiles.Values)
                {
                    if (sharedFile.LastRequest != null)
                    {
                        statsXmlWriter.WriteStartElement("sharedfilestat");
                        statsXmlWriter.WriteStartAttribute("filehash");
                        statsXmlWriter.WriteValue(sharedFile.FileHashString);
                        statsXmlWriter.WriteEndAttribute();
                        statsXmlWriter.WriteStartElement("lastrequest");
                        statsXmlWriter.WriteValue(sharedFile.LastRequest.ToString());
                        statsXmlWriter.WriteEndElement();
                        statsXmlWriter.WriteEndElement();
                    }
                }
                statsXmlWriter.WriteEndElement();
                statsXmlWriter.WriteEndDocument();
                statsXmlWriter.Flush();
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
                byte[] buffer = memoryStream.ToArray();
                fileStream.Write(buffer, 0, buffer.Length);
                statsXmlWriter.Close();
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while writing shared files stats file!");
            }
        }


        /**
         * LoadSharedDirectories loads information on shared directories from
         * a configuration file.
         */
        private void LoadSharedDirectories(string filePath)
        {
            try
            {
                if (Directory.Exists(m_Settings["IncomingDirectory"]))
                {
                    AddDirectory(m_Settings["IncomingDirectory"]);
                }
                if (File.Exists(filePath))
                {
                    XmlDocument sharedDirectoriesXmlDocument = new XmlDocument();
                    sharedDirectoriesXmlDocument.Load(filePath);
                    foreach (XmlNode sharedDirectoriesNode in sharedDirectoriesXmlDocument.SelectSingleNode("shareddirectories").SelectNodes("shareddirectory"))
                        AddDirectory(sharedDirectoriesNode.Attributes["path"].Value);
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading shared directories file!");
            }
        }



        /// <summary>
        /// Lädt die sharedfiles.xml.
        /// 07.07.2009 Lars
        /// </summary>
        private void LoadSharedFileEntries(string filePath)
        {
            try
            {
                m_SharedFileEntries.Lock();
                if (File.Exists(filePath))
                {
                    XmlDocument sharedFilesXmlDocument = new XmlDocument();
                    sharedFilesXmlDocument.Load(filePath);
                    foreach (XmlNode sharedFileXmlNode in sharedFilesXmlDocument.SelectSingleNode("sharedfiles").SelectNodes("sharedfile"))
                    {
                        try
                        {
                            string sharedFilePath = sharedFileXmlNode.Attributes["filepath"].Value;
                            m_SharedFileEntries.Add(sharedFilePath, new SharedFileEntry(sharedFilePath, Core.FileHashStringToFileHash(sharedFileXmlNode.SelectSingleNode("filehash").InnerText), DateTime.Parse(sharedFileXmlNode.SelectSingleNode("lastwritetime").InnerText)));
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while reading a shared file entry from the shared files file!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading shared files file!");
            }
            finally
            {
                m_SharedFileEntries.Unlock();
            }
        }

        /// <summary>
        /// Liest die comments.xml.
        /// 07.07.2009 Lars
        /// </summary>
        private void LoadComments(string filePath)
        {
            try
            {
                m_MetaDataEntries.Lock();
                if (File.Exists(filePath))
                {
                    XmlDocument commentsXmlDocument = new XmlDocument();
                    commentsXmlDocument.Load(filePath);
                    foreach (XmlNode sharedFileXmlNode in commentsXmlDocument.SelectSingleNode("sharedfiles").SelectNodes("sharedfile"))
                    {
                        try
                        {
                            string fileHashString = sharedFileXmlNode.Attributes["filehash"].Value;
                            if (!m_MetaDataEntries.ContainsKey(fileHashString))
                                m_MetaDataEntries.Add(fileHashString, new MetaDataEntry());
                            m_MetaDataEntries[fileHashString].Comment = Encoding.UTF8.GetString(Convert.FromBase64String(sharedFileXmlNode.SelectSingleNode("comment").InnerText));
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while reading a comment entry from the comments file!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading comments file!");
            }
            finally
            {
                m_MetaDataEntries.Unlock();
            }
        }


        /// <summary>
        /// Liest die metadata.xml.
        /// 07.07.2009 Lars
        /// </summary>
        private void LoadMetaData(string filePath)
        {
            try
            {
                m_MetaDataEntries.Lock();
                if (File.Exists(filePath))
                {
                    XmlDocument metaDataXmlDocument = new XmlDocument();
                    metaDataXmlDocument.Load(filePath);
                    foreach (XmlNode sharedFileXmlNode in metaDataXmlDocument.SelectSingleNode("sharedfiles").SelectNodes("sharedfile"))
                    {
                        try
                        {
                            string fileHashString = sharedFileXmlNode.Attributes["filehash"].Value;
                            if (!m_MetaDataEntries.ContainsKey(fileHashString))
                                m_MetaDataEntries.Add(fileHashString, new MetaDataEntry());
                            RIndexedHashtable<string, string> metaData = m_MetaDataEntries[fileHashString].MetaData;
                            foreach (XmlNode metaDataXmlNode in sharedFileXmlNode.SelectNodes("metadata"))
                                metaData.Add(metaDataXmlNode.Attributes["key"].Value, Encoding.UTF8.GetString(Convert.FromBase64String(metaDataXmlNode.InnerText)));
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while reading a meta data entry from the meta data file!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading meta data file!");
            }
            finally
            {
                m_MetaDataEntries.Unlock();
            }
        }



        /// <summary>
        /// Lädt die ratings.xml.
        /// 07.07.2009 Lars
        /// </summary>
        private void LoadRatings(string filePath)
        {
            try
            {
                m_MetaDataEntries.Lock();
                if (File.Exists(filePath))
                {
                    XmlDocument ratingsXmlDocument = new XmlDocument();
                    ratingsXmlDocument.Load(filePath);
                    foreach (XmlNode sharedFileXmlNode in ratingsXmlDocument.SelectSingleNode("sharedfiles").SelectNodes("sharedfile"))
                    {
                        try
                        {
                            string fileHashString = sharedFileXmlNode.Attributes["filehash"].Value;
                            if (!m_MetaDataEntries.ContainsKey(fileHashString))
                                m_MetaDataEntries.Add(fileHashString, new MetaDataEntry());
                            m_MetaDataEntries[fileHashString].Rating = byte.Parse(sharedFileXmlNode.SelectSingleNode("rating").InnerText);
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while reading a rating entry from the ratings file!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading ratings file!");
            }
            finally
            {
                m_MetaDataEntries.Unlock();
            }
        }


        /// <summary>
        /// Lädt die sharedfilesstats.xml.
        /// 07.07.2009 Lars
        /// </summary>
        private void LoadSharedFilesStats(string filePath)
        {
            try
            {
                m_MetaDataEntries.Lock();
                if (File.Exists(filePath))
                {
                    XmlDocument statisticsXmlDocument = new XmlDocument();
                    statisticsXmlDocument.Load(filePath);
                    foreach (XmlNode sharedFileXmlNode in statisticsXmlDocument.SelectSingleNode("sharedfilesstats").SelectNodes("sharedfilestat"))
                    {
                        try
                        {
                            string fileHashString = sharedFileXmlNode.Attributes["filehash"].Value;
                            if (!m_MetaDataEntries.ContainsKey(fileHashString))
                                m_MetaDataEntries.Add(fileHashString, new MetaDataEntry());
                            m_MetaDataEntries[fileHashString].LastRequest = DateTime.Parse(sharedFileXmlNode.SelectSingleNode("lastrequest").InnerText);
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "An exception was thrown while reading a last request entry from the shared files statistics file!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while reading shared files statistics file!");
            }
            finally
            {
                m_MetaDataEntries.Unlock();
            }
        }
        

        
        private RHashtable<string, FileSystemWatcher> m_DirectoryWatchers = new RHashtable<string, FileSystemWatcher>(); /// contains the filesystem watchers 
        // [MONO] m_HashingList is assigned but its value is according to Mono never used
		// private Regensburger.RCollections.ArrayBased.RList<string> m_HashingList = new Regensburger.RCollections.ArrayBased.RList<string>(); /// contains all files that are to be hashed
        private Regensburger.RCollections.LinkBased.RQueue<string> m_HashingQueue = new Regensburger.RCollections.LinkBased.RQueue<string>(); /// contains all files that are to be hashed
        private Thread m_HashingThread = null; /// a thread that runs as long as m_HashingQueue is not empty and hashes all files in the queue
        private Logger m_Logger = Logger.Instance; /// a logging object
        private RHashtable<string, MetaDataEntry> m_MetaDataEntries = new RHashtable<string, MetaDataEntry>(); // contains metadata ( comments, ratings, ...)
        private Regensburger.RCollections.ArrayBased.RList<string> m_SharedDirectories = new Regensburger.RCollections.ArrayBased.RList<string>(); /// contains shared directories
        private RHashtable<string, SharedFileEntry> m_SharedFileEntries = new RHashtable<string, SharedFileEntry>(); /// contains a name to hash map of shared files
        private SharedFileCollection m_SharedFiles = new SharedFileCollection(); /// contains shared file information
    }
}
