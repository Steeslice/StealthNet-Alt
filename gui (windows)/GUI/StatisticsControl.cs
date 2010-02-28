//RShare
//Copyright (C) 2006-2008 Roland Moch, Lars Regensburger, T.Norad

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
using System.Windows.Forms;
using System.Drawing;

namespace Regensburger.RShare
{
    internal sealed partial class StatisticsControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        public StatisticsControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            m_MainForm = mainForm;
            InitializeComponent();
            downloadGraphsControl.BorderPen.Color = downloadGraphsControl.XGridLinesPen.Color = downloadGraphsControl.YGridLinesPen.Color = downloadGraphsControl.ForeColor = Color.FromArgb(192, 192, 255);
            downloadGraphsControl.BackColor = Color.FromArgb(0, 0, 64);
            downloadGraphsControl.Graphs.Add(new Regensburger.RShare.GraphsControl.Graph());
            downloadGraphsControl.Graphs[0].Pen.Color = Color.FromArgb(0, 192, 64);
            downloadGraphsControl.Graphs[0].Description = Properties.Resources.Statistics_Average1Minute;
            downloadGraphsControl.Graphs[0].ValuesToShow = 300;
            downloadGraphsControl.Graphs[0].DrawFromRightToLeft = true;
            downloadGraphsControl.Graphs.Add(new GraphsControl.Graph());
            downloadGraphsControl.Graphs[1].Pen.Color = Color.FromArgb(0, 128, 64);
            downloadGraphsControl.Graphs[1].Description = Properties.Resources.Statistics_Average;
            downloadGraphsControl.Graphs[1].ValuesToShow = 300;
            downloadGraphsControl.Graphs[1].DrawFromRightToLeft = true;
            uploadGraphsControl.BorderPen.Color = uploadGraphsControl.XGridLinesPen.Color = uploadGraphsControl.YGridLinesPen.Color = uploadGraphsControl.ForeColor = Color.FromArgb(192, 192, 255);
            uploadGraphsControl.BackColor = Color.FromArgb(0, 0, 64);
            uploadGraphsControl.Graphs.Add(new GraphsControl.Graph());
            uploadGraphsControl.Graphs[0].Pen.Color = Color.FromArgb(192, 0, 64);
            uploadGraphsControl.Graphs[0].Description = Properties.Resources.Statistics_Average1Minute;
            uploadGraphsControl.Graphs[0].ValuesToShow = 300;
            uploadGraphsControl.Graphs[0].DrawFromRightToLeft = true;
            uploadGraphsControl.Graphs.Add(new GraphsControl.Graph());
            uploadGraphsControl.Graphs[1].Pen.Color = Color.FromArgb(128, 0, 64);
            uploadGraphsControl.Graphs[1].Description = Properties.Resources.Statistics_Average;
            uploadGraphsControl.Graphs[1].ValuesToShow = 300;
            uploadGraphsControl.Graphs[1].DrawFromRightToLeft = true;
            connectionsGraphsControl.BorderPen.Color = connectionsGraphsControl.XGridLinesPen.Color = connectionsGraphsControl.YGridLinesPen.Color = connectionsGraphsControl.ForeColor = Color.FromArgb(192, 192, 255);
            connectionsGraphsControl.BackColor = Color.FromArgb(0, 0, 64);
            connectionsGraphsControl.Graphs.Add(new GraphsControl.Graph());
            connectionsGraphsControl.Graphs[0].Pen.Color = Color.FromArgb(128, 192, 255);
            connectionsGraphsControl.Graphs[0].Description = Properties.Resources.Statistics_Current;
            connectionsGraphsControl.Graphs[0].ValuesToShow = 300;
            connectionsGraphsControl.Graphs[0].DrawFromRightToLeft = true;
            connectionsGraphsControl.DrawOnlyIntegers = true;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 2008-06-29 T.Norad BZ42 Stop the timer if it is currently running to
                // prevent double run. This can happend when the interval has a great value
                // the timer run this method and set the value to a small interval
                ((System.Windows.Forms.Timer)sender).Stop();
                updateTimer.Interval = 1000;
                if (m_MainForm.ActiveTab == this && !m_MainForm.IsInTray)
                {
                    // 2008-03-10 T.Norad: Translations added
                    treeView.Nodes[0].Nodes[0].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Downloaded, Core.LengthToString(Core.Downloaded));
                    treeView.Nodes[0].Nodes[0].Nodes[1].Text = string.Format(Properties.Resources.Statistics_CountDownloads, Core.DownloadsAndQueue.Count);
                    treeView.Nodes[0].Nodes[1].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Downloaded, Core.LengthToString(Core.CumulativeDownloaded));
                    treeView.Nodes[1].Nodes[0].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Uploaded, Core.LengthToString(Core.Uploaded));
                    treeView.Nodes[1].Nodes[0].Nodes[1].Text = string.Format(Properties.Resources.Statistics_CountUploads, Core.Uploads.Count);
                    treeView.Nodes[1].Nodes[1].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Uploaded, Core.LengthToString(Core.CumulativeUploaded));
                    treeView.Nodes[2].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Connections, Core.Connections.Count);
                    treeView.Nodes[3].Nodes[0].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Uptime, Core.Uptime.Days, Core.Uptime.Hours, Core.Uptime.Minutes, Core.Uptime.Seconds);
                    treeView.Nodes[3].Nodes[1].Nodes[0].Text = string.Format(Properties.Resources.Statistics_Uptime, Core.CumulativeUptime.Days, Core.CumulativeUptime.Hours, Core.CumulativeUptime.Minutes, Core.CumulativeUptime.Seconds);
                    //2009-01-29 Nochbaer
                    treeView.Nodes[4].Nodes[0].Text = string.Format(Properties.Resources.Statistics_SearchDBEntries, Core.GetSearchDBResultCount());
                    ulong size = Core.GetSearchDBFileSizeOfEntries();
                    string sizeString;
                    if (size < long.MaxValue)
                    {
                        sizeString = Core.LengthToString((long)size);
                    }
                    else
                    {
                        sizeString = Core.LengthToString(long.MaxValue);
                    }
                    treeView.Nodes[4].Nodes[1].Text = string.Format(Properties.Resources.Statistics_SearchDBFileSizeOfEntries, sizeString);
                    treeView.Nodes[4].Nodes[2].Text = string.Format(Properties.Resources.Statistics_SearchDBLastCleanUp, Core.GetSearchDBLastCleanUp());
                    treeView.Nodes[4].Nodes[3].Text = string.Format(Properties.Resources.Statistics_SearchDBLastCleanUpCount, Core.GetSearchDBLastCleanUpCount());
                    treeView.Nodes[4].Nodes[4].Text = String.Format(Properties.Resources.Statistics_SearchDBFileSize, Core.LengthToString(Core.GetSearchDBFileSize()));

                    downloadGraphsControl.YMaximum = downloadGraphsControl.Graphs[0].Maximum = downloadGraphsControl.Graphs[1].Maximum = bool.Parse(m_Settings["UseBytesInsteadOfBits"]) ? (int.Parse(m_Settings["DownloadCapacity"]) / 1024) : (int.Parse(m_Settings["DownloadCapacity"]) * 8 / 1024);
                    uploadGraphsControl.YMaximum = uploadGraphsControl.Graphs[0].Maximum = uploadGraphsControl.Graphs[1].Maximum = bool.Parse(m_Settings["UseBytesInsteadOfBits"]) ? (int.Parse(m_Settings["UploadCapacity"]) / 1024) : (int.Parse(m_Settings["UploadCapacity"]) * 8 / 1024);
                    connectionsGraphsControl.YMaximum = connectionsGraphsControl.Graphs[0].Maximum = float.Parse(m_Settings["AverageConnectionsCount"]) * 1.50F;
                    downloadGraphsControl.Graphs[0].Values.Clear();
                    for (int n = 0; n < Core.MinuteAverageDownloadStatistics.Count; n++)
                        downloadGraphsControl.Graphs[0].Values.Insert(n, bool.Parse(m_Settings["UseBytesInsteadOfBits"]) ? Core.MinuteAverageDownloadStatistics[n] / 1024 : Core.MinuteAverageDownloadStatistics[n] * 8 / 1024);
                    downloadGraphsControl.Graphs[1].Values.Clear();
                    for (int n = 0; n < Math.Min(600, Core.AverageDownloadStatistics.Count); n++)
                        downloadGraphsControl.Graphs[1].Values.Insert(n, bool.Parse(m_Settings["UseBytesInsteadOfBits"]) ? Core.AverageDownloadStatistics[n] / 1024 : Core.AverageDownloadStatistics[n] * 8 / 1024);
                    downloadGraphsControl.Refresh();
                    uploadGraphsControl.Graphs[0].Values.Clear();
                    for (int n = 0; n < Core.MinuteAverageUploadStatistics.Count; n++)
                        uploadGraphsControl.Graphs[0].Values.Insert(n, bool.Parse(m_Settings["UseBytesInsteadOfBits"]) ? Core.MinuteAverageUploadStatistics[n] / 1024 : Core.MinuteAverageUploadStatistics[n] * 8 / 1024);
                    uploadGraphsControl.Graphs[1].Values.Clear();
                    for (int n = 0; n < Math.Min(600, Core.AverageUploadStatistics.Count); n++)
                        uploadGraphsControl.Graphs[1].Values.Insert(n, bool.Parse(m_Settings["UseBytesInsteadOfBits"]) ? Core.AverageUploadStatistics[n] / 1024 : Core.AverageUploadStatistics[n] * 8 / 1024);
                    uploadGraphsControl.Refresh();
                    connectionsGraphsControl.Graphs[0].Values.Clear();
                    for (int n = 0; n < Core.ConnectionsStatistics.Count; n++)
                        connectionsGraphsControl.Graphs[0].Values.Insert(n, Core.ConnectionsStatistics[n]);
                    connectionsGraphsControl.Refresh();
                }
            }
            catch
            {
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }
    }
}