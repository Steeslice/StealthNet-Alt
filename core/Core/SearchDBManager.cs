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
using System.IO;
using System.Text;
using System.Threading;

namespace Regensburger.RShare
{
    partial class SearchDBManager
    {
        private static int m_CleanUpDays = 7;

        private static bool m_IsClosing = false;

        private static string m_DateFormatString = "yyyy-MM-dd";

        private static int m_ErrorCounter = 0;

        private static DateTime m_LastCleanUp;

        private static long m_LastCleanUpCount = 0;

        private static Logger m_Logger = Logger.Instance;

        private static string m_FilePath;

        private static long m_FileSize = 0;

        private static ulong m_FileSizeOfEntries = 0;

        private static long m_ResultCount = 0;

        private static RList<Command23.SearchResult> m_ResultsToAdd = new RList<Command23.SearchResult>();

        private static RList<Command23.SearchResult> m_ResultsToAddBuffer = new RList<Command23.SearchResult>();

        private static Thread m_SearchDBThread;

        private static RIndexedHashtable<string, RIndexedHashtable<string, OldSearchResult>> m_SearchResults = new RIndexedHashtable<string, RIndexedHashtable<string, OldSearchResult>>();

        private static RIndexedHashtable<string, RIndexedHashtable<string, OldSearchResult>> m_SearchResultsBuffer = new RIndexedHashtable<string, RIndexedHashtable<string, OldSearchResult>>();

        private static RList<SearchToStart> m_SearchesToStart = new RList<SearchToStart>();

        private static RList<SearchToStart> m_SearchesToStartBuffer = new RList<SearchToStart>();

        //2009-05-21 Eroli
        private ICoreSettings m_Settings = Settings.Instance;

        public DateTime LastCleanUp
        {
            get
            {
                return m_LastCleanUp;
            }
        }

        public long LastCleanUpCount
        {
            get
            {
                return m_LastCleanUpCount;
            }
        }

        public long ResultCount
        {
            get
            {
                return m_ResultCount;
            }
        }

        public long FileSize
        {
            get
            {
                return m_FileSize;
            }
        }

        public ulong FileSizeOfEntries
        {
            get
            {
                return m_FileSizeOfEntries;
            }
        }

        public void AddResult(Command23.SearchResult result)
        {
            if (m_SearchDBThread.IsAlive)
            {
                try
                {
                    m_ResultsToAddBuffer.Lock();

                    if (!m_ResultsToAddBuffer.Contains(result))
                    {
                        m_ResultsToAddBuffer.Add(result);
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "SearchDBManager: An error was thrown while adding a result to the list.", new object[] { });
                }
                finally
                {
                    m_ResultsToAddBuffer.Unlock();
                }
            }
        }

        public void AddResult(RList<Command23.SearchResult> results)
        {
            if (m_SearchDBThread.IsAlive)
            {
                try
                {
                    m_ResultsToAddBuffer.Lock();

                    foreach (Command23.SearchResult result in results)
                    {
                        if (!m_ResultsToAddBuffer.Contains(result))
                        {
                            m_ResultsToAddBuffer.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "SearchDBManager: An error was thrown while adding a result to the list.", new object[] { });
                }
                finally
                {
                    m_ResultsToAddBuffer.Unlock();
                }
            }
        }

        public void AddSearch(string searchID, string searchPattern)
        {
            if (m_SearchDBThread.IsAlive)
            {
                try
                {
                    m_SearchesToStartBuffer.Lock();

                    SearchToStart newSearch = new SearchToStart(searchID, searchPattern);

                    if (!m_SearchesToStartBuffer.Contains(newSearch))
                    {
                        m_SearchesToStartBuffer.Add(newSearch);
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "SearchDBManager: An error was thrown while adding a search to the list.", new object[] { });
                }
                finally
                {
                    m_SearchesToStartBuffer.Unlock();
                }
            }
        }

        public void Close()
        {
            m_IsClosing = true;
        }

        public RIndexedHashtable<string, OldSearchResult> GetResults(string searchID)
        {
            RIndexedHashtable<string, OldSearchResult> results = null;

            if (m_SearchDBThread.IsAlive)
            {
                try
                {
                    m_SearchResults.Lock();

                    if (m_SearchResults.ContainsKey(searchID))
                    {
                        results = m_SearchResults[searchID];
                        m_SearchResults.Remove(searchID);
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "SearchDBManager: An error was thrown while returning the results of a search.", new object[] { });
                }
                finally
                {
                    m_SearchResults.Unlock();
                }
            }
            else
            {
                results = new RIndexedHashtable<string, OldSearchResult>();
            }

            return results;
        }
        
        public SearchDBManager(string fileName )
        {
            m_FilePath = fileName;

            m_CleanUpDays = int.Parse(m_Settings["SearchDBCleanUpDays"]);

            m_SearchDBThread = new Thread(delegate()
            {
                try
                {
                    Core.SetUILanguage();

                    while (!m_IsClosing && m_ErrorCounter < 10)
                    {
                        //Move buffers to normal list
                        try
                        {
                            m_SearchesToStartBuffer.Lock();
                            m_SearchesToStart.Lock();

                            foreach (SearchDBManager.SearchToStart newSearch in m_SearchesToStartBuffer)
                            {
                                if (!m_SearchesToStart.Contains(newSearch))
                                {
                                    m_SearchesToStart.Add(newSearch);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "SearchDBManager: An error was thrown while reading the SearchesToStartBuffer.", new object[] { });
                        }
                        finally
                        {
                            m_SearchesToStartBuffer.Clear();

                            m_SearchesToStart.Unlock();
                            m_SearchesToStartBuffer.Unlock();
                        }

                        try
                        {
                            m_ResultsToAddBuffer.Lock();
                            m_ResultsToAdd.Lock();

                            foreach (Command23.SearchResult result in m_ResultsToAddBuffer)
                            {
                                if (!m_ResultsToAdd.Contains(result))
                                {
                                    m_ResultsToAdd.Add(result);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "SearchDBManager: An error was thrown while reading the ResultsToAddBuffer.", new object[] { });
                        }
                        finally
                        {
                            m_ResultsToAddBuffer.Clear();

                            m_ResultsToAdd.Unlock();
                            m_ResultsToAddBuffer.Unlock();
                        }



                        //Because we are only comparing dates, it is only necessary to compare them once a day
                        bool cleanUp = false;
                        if (((TimeSpan)DateTime.Now.Subtract(m_LastCleanUp)).Days >= 1)
                        {
                            //CleanUp();
                            cleanUp = true;
                        }

                        //The current entry
                        long lastKnownValidFilePosition = 0;
                        //The entry before
                        long lastKnownValidFilePosition2 = 0;

                        ulong fileSizeOfEntries = 0;
                        long cleanedUpCounter = 0;
                        long resultCounter = 0;

                        FileStream fileStream = null;
                        BinaryReader fileReader = null;
                        BinaryWriter fileWriter = null;

                        MemoryStream memoryStream = null;
                        BinaryReader memoryReader = null;
                        BinaryWriter memoryWriter = null;

                        try
                        {
                            m_ResultsToAdd.Lock();
                            m_SearchesToStart.Lock();
                            m_SearchResultsBuffer.Lock();

                            //Check if there is something to do
                            if (m_ResultsToAdd.Count > 0 || m_SearchesToStart.Count > 0 || cleanUp)
                            {
                                fileStream = new FileStream(m_FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                fileReader = new BinaryReader(fileStream, Encoding.Unicode);
                                fileWriter = new BinaryWriter(fileStream, Encoding.Unicode);

                                memoryStream = new MemoryStream();
                                memoryReader = new BinaryReader(memoryStream, Encoding.Unicode);
                                memoryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);

                                long fileLength = fileReader.BaseStream.Length;
                                int fileFlushCounter = 0;
                                long fileReadPosition = 0;
                                long fileWritePosition = 0;
                                bool insertingData = false;
                                bool isFirstChangedEntry = true;


                                //Add a array for the results of each search
                                foreach (SearchToStart searchToStart in m_SearchesToStart)
                                {
                                    m_SearchResultsBuffer.Add(searchToStart.SearchID, new RIndexedHashtable<string, OldSearchResult>());
                                }


                                //Go through the file
                                while (fileReadPosition < fileLength)
                                {
                                    bool isOld = false;
                                    
                                    long firstPositionOfThisEntry = fileReadPosition;

                                    lastKnownValidFilePosition2 = lastKnownValidFilePosition;
                                    lastKnownValidFilePosition = fileReadPosition;
                                    
                                    //Read the next entry
                                    byte[] rFileHash = fileReader.ReadBytes(64);
                                    long rFileSize = fileReader.ReadInt64();
                                    int rFileNameCount = fileReader.ReadInt32();
                                    string[] rFileNames = new string[rFileNameCount];
                                    for (int i = 0; i < rFileNameCount; i++)
                                    {
                                        rFileNames[i] = fileReader.ReadString();
                                    }
                                    string rAlbum = fileReader.ReadString();
                                    string rArtist = fileReader.ReadString();
                                    string rTitle = fileReader.ReadString();
                                    byte rRating = fileReader.ReadByte();
                                    //Save the position of the date
                                    long datePosition = fileReader.BaseStream.Position;
                                    string rDate = fileReader.ReadString();

                                    //Save the beginning of the next entry
                                    fileReadPosition = fileReader.BaseStream.Position;

                                    resultCounter++;

                                    //Check if this entry is a result to a search
                                    for (int i = 0; i < m_SearchesToStart.Count; i++)
                                    {

                                        string[] searchPattern = m_SearchesToStart[i].Pattern.ToLower().Split(new char[] { ' ' }); ;

                                        //Remove all small patterns
                                        RList<string> patterns = new RList<string>();
                                        for (int k = 0; k < searchPattern.Length; k++)
                                        {
                                            if (searchPattern[k].Length >= 3)
                                            {
                                                patterns.Add(searchPattern[k]);
                                            }
                                        }

                                        bool isResult = false;
                                        int fileNameNumber = 0;

                                        for (int j = 0; j < patterns.Count; j++)
                                        {
                                            //Check all filenames of this entry
                                            for (int k = 0; k < rFileNames.Length; k++)
                                            {

                                                if (rFileNames[k].ToLower().Contains(patterns[j]))
                                                {
                                                    fileNameNumber = k;
                                                    isResult = true;
                                                }
                                            }

                                            //Check the metadata of this entry
                                            if (!isResult)
                                            {
                                                if (rAlbum.ToLower().Contains(patterns[j]))
                                                {
                                                    isResult = true;
                                                }
                                                else if (rArtist.ToLower().Contains(patterns[j]))
                                                {
                                                    isResult = true;
                                                }
                                                else if (rTitle.ToLower().Contains(patterns[j]))
                                                {
                                                    isResult = true;
                                                }
                                            }

                                            //if this is no result for this part of the searchpattern,
                                            //we can stop, because there shall be only results with all
                                            //parts of the searchpattern.
                                            if (isResult == false)
                                            {
                                                break;
                                            }

                                            //Reset isResult for the next part of the searchpattern
                                            if (j != patterns.Count - 1)
                                            {
                                                isResult = false;
                                            }
                                        }

                                        if (isResult)
                                        {
                                            //Add this entry to the results of this search
                                            m_SearchResultsBuffer[m_SearchesToStart[i].SearchID].Add(Core.ByteArrayToString(rFileHash), new OldSearchResult(rFileHash, rFileSize, rFileNames[fileNameNumber], rAlbum, rArtist, rTitle, rRating, DateTime.Parse(rDate)));
                                        }
                                    }



                                    bool updateDate = false;
                                    int[] indexOfResultsToRemove = new int[0];

                                    //Check if a new result is equal to this entry
                                    for (int i = 0; i < m_ResultsToAdd.Count; i++)
                                    {
                                        //Compare the hashes
                                        if (Core.CompareByteArray(rFileHash, m_ResultsToAdd[i].FileHash))
                                        {
                                            //It exists already
                                            updateDate = true;

                                            int[] tempArray1 = new int[indexOfResultsToRemove.Length + 1];
                                            for (int j = 0; j < indexOfResultsToRemove.Length; j++)
                                            {
                                                tempArray1[j] = indexOfResultsToRemove[j];
                                            }
                                            tempArray1[indexOfResultsToRemove.Length] = i;
                                            indexOfResultsToRemove = tempArray1;

                                            //Check the filenames
                                            bool fileNameExists = false;
                                            for (int k = 0; k < rFileNames.Length; k++)
                                            {
                                                if (rFileNames[k] == m_ResultsToAdd[i].FileName)
                                                {
                                                    fileNameExists = true;
                                                    break;
                                                }
                                            }

                                            if (!fileNameExists)
                                            {
                                                //The filename is new -> add it
                                                insertingData = true;

                                                string[] tempArray = new string[rFileNameCount + 1];
                                                for (int k = 0; k < rFileNameCount; k++)
                                                {
                                                    tempArray[k] = rFileNames[k];
                                                }
                                                tempArray[rFileNameCount] = m_ResultsToAdd[i].FileName;
                                                rFileNames = tempArray;
                                                rFileNameCount++;
                                            }
                                        }
                                    }


                                    if (updateDate)
                                    {
                                        //Update the date
                                        rDate = DateTime.Now.ToString(m_DateFormatString);

                                        //Remove the new result from the list, because it exists
                                        RList<Command23.SearchResult> tempRemoveList = new RList<Command23.SearchResult>();
                                        for (int i = 0; i < m_ResultsToAdd.Count; i++)
                                        {
                                            bool addIt = false;
                                            for (int k = 0; k < indexOfResultsToRemove.Length; k++)
                                            {
                                                if (i == indexOfResultsToRemove[k])
                                                {
                                                    addIt = true;
                                                }
                                            }

                                            if (addIt)
                                            {
                                                tempRemoveList.Add(m_ResultsToAdd[i]);
                                            }
                                        }
                                        foreach (Command23.SearchResult r in tempRemoveList)
                                        {
                                            m_ResultsToAdd.Remove(r);
                                        }

                                        //Check if we can update the date directly in the file
                                        if (!insertingData)
                                        {
                                            //Write the new date to the file
                                            fileWriter.BaseStream.Position = datePosition;
                                            fileWriter.Write(rDate);
                                            fileWriter.Flush();
                                            fileReader.BaseStream.Position = fileReadPosition;
                                        }
                                    }

                                    //Check the date if we are cleaning up
                                    if (cleanUp)
                                    {
                                        if (((TimeSpan)DateTime.Now.Subtract(DateTime.Parse(rDate))).Days > m_CleanUpDays)
                                        {
                                            isOld = true;
                                            insertingData = true;
                                            cleanedUpCounter++;
                                        }
                                        else
                                        {
                                            fileSizeOfEntries += (ulong)rFileSize;
                                        }
                                    }
                                    else
                                    {
                                        fileSizeOfEntries += (ulong)rFileSize;
                                    }

                                    //Check if we have to insert data to the file
                                    if (insertingData)
                                    {
                                        if (isFirstChangedEntry)
                                        {
                                            //Here we have to beginn writing
                                            fileWritePosition = firstPositionOfThisEntry;
                                            isFirstChangedEntry = false;
                                        }

                                        if (!isOld)
                                        {
                                            fileFlushCounter++;

                                            //Write the entry to the buffer
                                            memoryWriter.Write(rFileHash);
                                            memoryWriter.Write(rFileSize);
                                            memoryWriter.Write(rFileNameCount);
                                            for (int i = 0; i < rFileNameCount; i++)
                                            {
                                                memoryWriter.Write(rFileNames[i]);
                                            }
                                            memoryWriter.Write(rAlbum);
                                            memoryWriter.Write(rArtist);
                                            memoryWriter.Write(rTitle);
                                            memoryWriter.Write(rRating);
                                            memoryWriter.Write(rDate);

                                            //if the buffer is big enough or we reached the end of the file, write the buffe to the file
                                            if (fileFlushCounter == 10000 || fileReadPosition >= fileLength)
                                            {
                                                fileFlushCounter = 0;

                                                memoryWriter.Flush();

                                                memoryReader.BaseStream.Position = 0;
                                                fileWriter.BaseStream.Position = fileWritePosition;

                                                long memoryLength = memoryReader.BaseStream.Length;
                                                long spaceInFile = fileReadPosition - fileWritePosition;

                                                //write only as much as space and data we have
                                                while (memoryReader.BaseStream.Position < spaceInFile && memoryReader.BaseStream.Position < memoryLength)
                                                {
                                                    fileWriter.Write(memoryReader.ReadByte());
                                                }
                                                fileWriter.Flush();

                                                //Reconfigure the filewriter/reader
                                                fileWritePosition = fileWriter.BaseStream.Position;
                                                fileReader.BaseStream.Position = fileReadPosition;

                                                //Write the rest of the data in the buffer to the beginning of the buffer
                                                long memoryReaderPosition = memoryReader.BaseStream.Position;
                                                long memoryWriterPosition = 0;

                                                while (memoryReaderPosition < memoryLength)
                                                {
                                                    memoryReader.BaseStream.Position = memoryReaderPosition;

                                                    byte b = memoryReader.ReadByte();

                                                    memoryReaderPosition = memoryReader.BaseStream.Position;
                                                    memoryWriter.BaseStream.Position = memoryWriterPosition;

                                                    memoryWriter.Write(b);

                                                    memoryWriterPosition = memoryWriter.BaseStream.Position;
                                                }
                                                memoryWriter.Flush();

                                                memoryWriter.BaseStream.SetLength(memoryWriterPosition);
                                            }
                                        }
                                    }
                                }

                                if (insertingData)
                                {
                                    //write the rest of the memorystream to the file.
                                    fileWriter.BaseStream.Position = fileWritePosition;
                                    
                                    long mlength = memoryReader.BaseStream.Length;
                                    memoryReader.BaseStream.Position = 0;
                                    while (memoryReader.BaseStream.Position < mlength)
                                    {
                                        fileWriter.Write(memoryReader.ReadByte());
                                    }
                                    fileWriter.Flush();
                                }

                                if (cleanUp)
                                {
                                    m_Logger.Log(Properties.Resources_Core.CleanSearchDatabase, new object[] { cleanedUpCounter, resultCounter });
                                    resultCounter -= cleanedUpCounter;
                                    m_LastCleanUpCount = cleanedUpCounter;
                                }

                                //Add the new results to the file
                                //The position of the filestream points already to the end
                                RIndexedHashtable<string, NewSearchResult> resultsToAdd = new RIndexedHashtable<string, NewSearchResult>();
                                foreach (Command23.SearchResult result in m_ResultsToAdd)
                                {
                                    string fileHashString = Core.ByteArrayToString(result.FileHash);

                                    if (resultsToAdd.ContainsKey(fileHashString))
                                    {
                                        resultsToAdd[fileHashString].AddFileName(result.FileName);
                                    }
                                    else
                                    {
                                        resultsToAdd.Add(fileHashString, new NewSearchResult(result));
                                    }
                                }


                                foreach (NewSearchResult newResult in resultsToAdd.Values)
                                {
                                    fileWriter.Write(newResult.FileHash);
                                    fileWriter.Write(newResult.FileSize);
                                    int fileNameCount = newResult.FileNames.Length;
                                    fileWriter.Write(fileNameCount);
                                    for (int i = 0; i < fileNameCount; i++)
                                    {
                                        fileWriter.Write(newResult.FileNames[i]);
                                    }
                                    fileWriter.Write(newResult.Album);
                                    fileWriter.Write(newResult.Artist);
                                    fileWriter.Write(newResult.Title);
                                    fileWriter.Write(newResult.Rating);
                                    fileWriter.Write(DateTime.Now.ToString(m_DateFormatString));
                                    resultCounter++;
                                    fileSizeOfEntries += (ulong)newResult.FileSize;
                                }
                                fileWriter.Flush();

                                //Clear the lists
                                m_ResultsToAdd.Clear();
                                m_SearchesToStart.Clear();

                                //Set the correct end of the file
                                if (insertingData)
                                {
                                    fileWriter.BaseStream.SetLength(fileWriter.BaseStream.Position);
                                }

                                if (cleanUp)
                                {
                                    m_LastCleanUp = DateTime.Now;
                                }

                                //Update information                        
                                m_ResultCount = resultCounter;
                                m_FileSize = fileStream.Length;
                                m_FileSizeOfEntries = fileSizeOfEntries;

                                fileReader.Close();
                                fileWriter.Close();
                                fileStream.Close();

                                memoryReader.Close();
                                memoryWriter.Close();
                                memoryStream.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            //Update information                        
                            m_ResultCount = resultCounter;
                            m_FileSize = fileStream.Length;
                            m_FileSizeOfEntries = fileSizeOfEntries;

                            m_ErrorCounter++;
                            m_Logger.Log(ex, "An exception was thrown in searchDBThread! (#{0})", new object[] { m_ErrorCounter });
                            try
                            {
                                fileStream.SetLength(lastKnownValidFilePosition2);
                                m_Logger.Log("Searchdatabase cutted to the entry bofore the last known valid entry. ({0} Bytes remaining)", new object[] { lastKnownValidFilePosition});
                                m_FileSize = lastKnownValidFilePosition2;
                                m_ResultCount = resultCounter - cleanedUpCounter;
                                m_FileSizeOfEntries = fileSizeOfEntries;
                            }
                            catch
                            {
                                try
                                {
                                    if (File.Exists(m_FilePath))
                                    {
                                        File.Delete(m_FilePath);
                                        m_Logger.Log("Searchdatabase deleted, because it was probably corrupt.", new object[] { });
                                        m_FileSize = 0;
                                        m_ResultCount = 0;
                                        m_FileSizeOfEntries = 0;
                                    }
                                }
                                catch { }
                            }
                        }
                        finally
                        {
                            m_ResultsToAdd.Unlock();
                            m_SearchesToStart.Unlock();
                            m_SearchResultsBuffer.Unlock();

                            if (fileReader != null)
                            {
                                fileReader.Close();
                            }
                            if (fileWriter != null)
                            {
                                fileWriter.Close();
                            }
                            if (fileStream != null)
                            {
                                fileStream.Close();
                            }

                            if (memoryReader != null)
                            {
                                memoryReader.Close();
                            }
                            if (memoryWriter != null)
                            {
                                memoryWriter.Close();
                            }
                            if (memoryStream != null)
                            {
                                memoryStream.Close();
                            }
                        }


                        //Move buffer to normal list
                        try
                        {
                            m_SearchResultsBuffer.Lock();
                            m_SearchResults.Lock();

                            for (int i = 0; i < m_SearchResultsBuffer.Count; i++)
                            {
                                if (!m_SearchResults.ContainsKey(((System.Collections.Generic.KeyValuePair<string, RIndexedHashtable<string, OldSearchResult>>)m_SearchResultsBuffer[i]).Key))
                                {
                                    m_SearchResults.Add(((System.Collections.Generic.KeyValuePair<string, RIndexedHashtable<string, OldSearchResult>>)m_SearchResultsBuffer[i]).Key, ((System.Collections.Generic.KeyValuePair<string, RIndexedHashtable<string, OldSearchResult>>)m_SearchResultsBuffer[i]).Value);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            m_Logger.Log(ex, "SearchDBManager: An error was thrown while reading the SearchResultsBuffer.", new object[] { });
                        }
                        finally
                        {
                            m_SearchResultsBuffer.Clear();

                            m_SearchResults.Unlock();
                            m_SearchResultsBuffer.Unlock();
                        }


                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    m_Logger.Log(ex, "An exception was thrown in searchDBThread!", new object[] { });
                }

                m_Logger.Log("SearchDBManager closed.", new object[] {  });
            });
            m_SearchDBThread.Name = "searchDBThread";
            m_SearchDBThread.IsBackground = true;
            m_SearchDBThread.Priority = ThreadPriority.Lowest;
            m_SearchDBThread.Start();
        }
    }
}
