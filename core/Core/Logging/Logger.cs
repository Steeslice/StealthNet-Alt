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

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Regensburger.RCollections.ArrayBased;

namespace Regensburger.RShare
{
    public sealed class Logger
    {
        // singelton instance and lock object
        // Added on 2007-05-05 by T.Norad
        private static Logger instance = null;
        private static readonly object padlock = new object();

        // indicates if this class is initialized and ready to log into a file
        // Added on 2007-05-05 by T.Norad
        private bool m_isInitialized = false;

        // references to the last log entry. Can be used to display upcomming log entries in a status bar.
        // Added on 2007-05-05 by T.Norad
        private LogEntry m_lastLogEntry = null;

        // contains the logfile directory.
        // Added on 2007-05-05 by T.Norad
        private String m_logFileDir = null;

        private RList<LogEntry> m_LogEntries = null;

        /*
         * private constructor to prevent creating manually an instance of this class.
         * 
         * Added on 2007-05-05 by T.Norad
         */
        private Logger()
        {
            m_LogEntries = new RList<LogEntry>();
        }

        /*
         * singelton implementation
         * 
         * Added on 2007-05-05 by T.Norad
         */
        public static Logger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        /*
         * Gets or sets the last log entry
         * 
         * Added on 2007-05-05 by T.Norad
         */
        public LogEntry LastLogEntry
        {
            get { return this.m_lastLogEntry; }
            private set { this.m_lastLogEntry = value; }
        }

        public RList<LogEntry> LogEntries
        {
            get
            {
                return m_LogEntries;
            }
        }

        /*
         * Gets or sets the logfile directory
         * 
         * Added on 2007-05-05 by T.Norad
         */
        private String LogFileDir
        {
            get { return this.m_logFileDir; }
            set { this.m_logFileDir = value; }
        }

        /// <summary>
        /// Method to initialize this logger class. 
        /// 
        /// Added on 2007-05-05 by T.Norad
        /// </summary>
        /// <param name="logDirectory">path of the directory to store the logfiles</param>
        public void initialize(String logDirectory)
        {
            // initialize logger only 1 times
            if (this.m_isInitialized)
            {
                throw new NotSupportedException("Logger-Class already initialized.");
            }

            // set the logfile directory
            this.LogFileDir = logDirectory;

            this.m_isInitialized = true;
        }

        /// <summary>
        /// Logs the passed message. The message can contain composite format strings like {0}.
        /// 
        /// Added on 2007-05-05 by T.Norad
        /// </summary>
        /// <param name="format">logmessage</param>
        /// <param name="args">array ob arguments replaced in the logmessage</param>
        public void Log(string format, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");
            if (args == null)
                throw new ArgumentNullException("args");

            this.Log(null, format, args);
        }

        /// <summary>
        /// Logs the passed message. The message can contain composite format strings like {0}.
        /// The passed exception is used to extend the log entry with the exception message.
        /// 
        /// Added on 2007-05-05 by T.Norad
        /// </summary>
        /// <param name="thrownException">exception to extend the log entry with the exception message</param>
        /// <param name="format">logmessage</param>
        /// <param name="args">array ob arguments replaced in the logmessage</param>
        public void Log(Exception thrownException, string format, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");
            if (args == null)
                throw new ArgumentNullException("args");

            this.Log(new LogEntry(string.Format(format, args), thrownException));
        }

        /// <summary>
        /// private method to write the log entry to a logfile. The LogEntry is only write to file if this class is initialized.
        /// 
        /// Added on 2007-05-05 by T.Norad
        /// </summary>
        /// <param name="logEntry">LogEntry contains all necessary informations to log</param>
        private void Log(LogEntry logEntry)
        {
            if (logEntry == null)
            {
                throw new ArgumentNullException("logEntry");
            }

            m_LogEntries.Add(logEntry);

            // remember the last log entry
            m_lastLogEntry = logEntry;
            // write to logfile only if this class is initialized.
            if (this.m_isInitialized)
            {
                // create logfile name
                String filename = string.Format("{0:yyyy}-{0:MM}-{0:dd}.log", DateTime.Now);
                // compine path and name and set it as member value
                String logPath = Path.Combine(this.LogFileDir, filename);

                try
                {
                    StreamWriter logFileStreamWriter = new StreamWriter(new FileStream(logPath, FileMode.Append, FileAccess.Write, FileShare.Read), Encoding.UTF8);
                    logFileStreamWriter.WriteLine("{0:T}: {1}", m_lastLogEntry.TimeStamp, m_lastLogEntry.Text);
                    if (m_lastLogEntry.ThrownException != null)
                        logFileStreamWriter.WriteLine(m_lastLogEntry.ThrownException.ToString());
                    logFileStreamWriter.Flush();
                    logFileStreamWriter.Close();
                }
                catch
                {
                }
            }
        }
    }
}
