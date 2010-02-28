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

using Regensburger.RCollections;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Text;

namespace Regensburger.RShare
{
    internal sealed partial class DownloadsControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_start = true;

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bool.Parse(m_Settings["ShowMessageBoxes"]) || (bool.Parse(m_Settings["ShowMessageBoxes"]) && MessageBox.Show(this, Properties.Resources.CancelDownload, String.Format(Constants.Software, Core.Version), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                try
                {
                    Core.DownloadsAndQueue.Lock();
                    Download download;
                    for (int n = downloadsDataGridView.SelectedRows.Count - 1; n >= 0; n--)
                        if (Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[n].Tag).Tag, out download))
                            download.Cancel();
                }
                finally
                {
                    Core.DownloadsAndQueue.Unlock();
                }
            }
        }

        private void downloadByFileHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DownloadDialog downloadDialog = new DownloadDialog())
            {
                downloadDialog.ShowDialog(this);
            }
        }

        //2008-03-20 Nochbaer
        private void downloadByCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AddExtension = false;
            dialog.CheckPathExists = true;
            dialog.CheckFileExists = true;
            dialog.Filter = "snCollection|*.sncollection";
            dialog.InitialDirectory = m_Settings["IncomingDirectory"];
            dialog.Multiselect = false;
            dialog.ValidateNames = true;
            DialogResult result = dialog.ShowDialog(this);
            dialog.Dispose();

            if (result == DialogResult.Cancel || (dialog.FileName.Length > 0) == false || dialog.FileName.EndsWith(".sncollection") == false || System.IO.File.Exists(dialog.FileName) == false)
            {
                return;
            }

            Core.ParseStealthNetCollection(dialog.FileName);
        }

        private void downloadsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void downloadsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged();
        }

        private void downloadsDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "RatingIcon":
                    e.SortResult = ((byte)downloadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((byte)downloadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "FileSize":
                case "Completed":
                case "Remaining":
                    // 2007-05-20 T.Norad
                    // fix for big files
                    e.SortResult = ((long)downloadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((long)downloadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "Status": // 2008-03-20 Nochbaer
                case "Sources":
                case "lastReception":
                    // 2007-06-10 T.Norad
                    // fix: Sources are int-values
                    e.SortResult = ((int)downloadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)downloadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "ProgressImage":
                    e.SortResult = ((float)downloadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex1].Tag).SortTag / 100).CompareTo((float)downloadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex2].Tag).SortTag / 100);
                    e.Handled = true;
                    break;
                case "lastSeen":
                    // get the first value to compare from grid
                    object date1 = downloadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag;
                    // second value from grid
                    object date2 = downloadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag;

                    e.SortResult = SortHelper.compareDates(date1, date2);
                    // if the datetime equal we use the sort tag to prevent flickering sort results
                    if (e.SortResult == 0)
                    {
                        e.SortResult = ((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex1].Tag).SortTag.CompareTo(((RandomTag<string>)downloadsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    }
                    e.Handled = true;
                    break;
            }
        }

        private Image GetRatingImage(Download download)
        {
            if (download == null)
                throw new ArgumentNullException("result");

            switch (download.Rating)
            {
                case 1:
                    return Properties.Resources.rating1_16x16;
                case 2:
                    return Properties.Resources.rating2_16x16;
                case 3:
                    return Properties.Resources.rating3_16x16;
                default:
                    return Properties.Resources.rating0_16x16;
            }
        }

        //2008-07-29 Nochbaer BZ 52
        private string GetSourceString(Download download)
        {
            if (download == null)
                throw new ArgumentNullException("download");

            if (download.Sources.Values.Count == 0)
            {
                return "0";
            }
            else
            {
                int active = 0;
                int verified = 0;
                int total = download.Sources.Count;
                foreach (Download.Source source in download.Sources.Values)
                    if (source.State == Download.SourceState.Active)
                    {
                        active++;
                        verified++;
                    }
                    else if (source.State == Download.SourceState.Requested ||
                        source.State == Download.SourceState.Verified)
                        verified++;
                return string.Format("{0} ({1})/{2}", active, verified, total);
            }
        }

        private Image GetTypeImage(Download.Source source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int minutes = (int)DateTime.Now.Subtract(source.LastReceived).TotalMinutes;
            if (minutes < 12)
                return Properties.Resources.peer0_16x16;
            else if (minutes < 24)
                return Properties.Resources.peer1_16x16;
            else if (minutes < 36)
                return Properties.Resources.peer2_16x16;
            else if (minutes < 48)
                return Properties.Resources.peer3_16x16;
            else
                return Properties.Resources.peer4_16x16;
        }

        private string GetSourceStateString(Download.SourceState state)
        {
            switch (state)
            {
                case Download.SourceState.Active:
                    return RShare.Properties.Resources.SourceState_Active;
                case Download.SourceState.Requested:
                    return RShare.Properties.Resources.SourceState_Requested;
                case Download.SourceState.Requesting:
                    return RShare.Properties.Resources.SourceState_Requesting;
                case Download.SourceState.Verified:
                    return RShare.Properties.Resources.SourceState_Verified;
                case Download.SourceState.Verifying:
                    return RShare.Properties.Resources.SourceState_Verifying;
                case Download.SourceState.NotNeeded:
                    return RShare.Properties.Resources.SourceState_NotNeeded;
                default:
                    return "error getting localized string";
            }
        }

        private string GetTypeString(Download.Source source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            string type;
            int minutes = (int)DateTime.Now.Subtract(source.LastReceived).TotalMinutes;
            if (minutes < 12)
                type = string.Format("0 +{0}", minutes);
            else if (minutes < 24)
                type = string.Format("1 +{0}", minutes - 12);
            else if (minutes < 36)
                type = string.Format("2 +{0}", minutes - 24);
            else if (minutes < 48)
                type = string.Format("3 +{0}", minutes - 36);
            else
                type = string.Format("4 +{0}", minutes - 48);

            return string.Format("{0} ({1}{2})", GetSourceStateString(source.State), type, source.IsComplete ? string.Empty : "; " + RShare.Properties.Resources.Swarming);
        }

        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadInformationDialog.ShowInformation(this);
        }

        private void sourcesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void sourcesDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "TypeIcon":
                    e.SortResult = ((int)DateTime.Now.Subtract((DateTime)sourcesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag).TotalMinutes + ((RandomTag<string>)sourcesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)DateTime.Now.Subtract((DateTime)sourcesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag).TotalMinutes + ((RandomTag<string>)sourcesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "Queue":
                case "Type":
                    e.SortResult = ((int)sourcesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)sourcesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)sourcesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)sourcesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "SentCommands":
                case "ReceivedCommands":
                    e.SortResult = ((long)sourcesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)sourcesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((long)sourcesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)sourcesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                updateTimer.Interval = Math.Max(Math.Max(1000, downloadsDataGridView.Rows.Count * 10), Math.Max(1000, Math.Max(downloadsDataGridView.Rows.Count * 10, sourcesDataGridView.Rows.Count * 10)));
                if (m_MainForm.ActiveTab == this && !m_MainForm.IsInTray)
                {
                    Download selectedDownload = null;
                    try
                    {
                        Core.DownloadsAndQueue.Lock();
                        downloadsLabel.Text = string.Format(RShare.Properties.Resources.Downloads, Math.Min(Core.DownloadsAndQueue.Count, Constants.MaximumDownloadsCount), Core.DownloadsAndQueue.Count);
                        {
                            DataGridViewRow row;
                            for (int n = downloadsDataGridView.Rows.Count - 1; n >= 0; n--)
                            {
                                row = downloadsDataGridView.Rows[n];
                                if (!Core.DownloadsAndQueue.ContainsKey(((RandomTag<string>)row.Tag).Tag))
                                {
                                    try
                                    {
                                        ((Image)row.Cells["ProgressImage"].Value).Dispose();
                                    }
                                    catch
                                    {
                                    }
                                    downloadsDataGridView.Rows.RemoveAt(n);
                                }
                            }
                        }
                        DataGridViewRow downloadRow;
                        DataGridViewCell downloadCell;
                        int a = 0;
                        foreach (Download download in Core.DownloadsAndQueue.Values)
                        {
                            if (a % 50 == 0)
                                Application.DoEvents();
                            a++;
                            downloadRow = null;
                            foreach (DataGridViewRow row in downloadsDataGridView.Rows)
                                if ((((RandomTag<string>)row.Tag).Tag).Equals(download.DownloadIDString))
                                {
                                    downloadRow = row;
                                    break;
                                }
                            if (downloadRow == null)
                            {
                                downloadRow = new DataGridViewRow();
                                downloadRow.Height = 17;
                                downloadCell = new DataGridViewImageCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Tag = download.FileName;
                                try
                                {
                                    // 2008-10-21 Eroli: Mono-Fix
                                    if (!UtilitiesForMono.IsRunningOnMono)
                                        downloadCell.Value = ShellIcon.GetSmallSystemIcon((string)downloadCell.Tag);
                                }
                                catch
                                {
                                }
                                downloadCell = new DataGridViewImageCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Value = GetRatingImage(download);
                                downloadCell.Tag = download.Rating;
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Value = download.FileName;
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Value = download.FileSizeString;
                                downloadCell.Tag = download.FileSize;
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Value = download.CompletedString;
                                downloadCell.Tag = download.Completed;
                                downloadCell = new DataGridViewImageCell();
                                downloadRow.Cells.Add(downloadCell);
                                try
                                {
                                    downloadCell.Value = ProgressBars.GetProgressBar(download, downloadsDataGridView.Columns["ProgressImage"].Width, 16, Font);
                                }
                                catch
                                {
                                }
                                downloadCell.Tag = download.Progress;
                                //2008-10-21 Eroli: Bugfix
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Value = download.IsActive ? RShare.Properties.Resources.DownloadIsStarted : RShare.Properties.Resources.DownloadIsQueued;
                                downloadCell.Tag = download.QueuePostition;
                                //2008-10-21 Eroli: Bugfix-End
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                //2009-01-02 Eroli: Bugfix
                                downloadCell.Value = GetSourceString(download);
                                downloadCell.Tag = download.Sources.Count;
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                downloadCell.Value = download.RemainingString;
                                downloadCell.Tag = download.Remaining;
                                //2008-10-21 Eroli: Bugfix
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                if (download.LastSeen != null)
                                {
                                    TimeSpan span = DateTime.Now.Subtract((DateTime)download.LastSeen);
                                    downloadCell.Value = string.Format(Properties.Resources.Date_Diff, span.Days, span.Hours, span.Minutes, span.Seconds);
                                    downloadCell.Tag = download.LastSeen;
                                }
                                downloadCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                downloadCell = new DataGridViewTextBoxCell();
                                downloadRow.Cells.Add(downloadCell);
                                if (Core.DownloadsAndQueue.IndexOfKey(download.DownloadIDString) < Constants.MaximumDownloadsCount)
                                {
                                    downloadCell.Value = download.DownstreamString;
                                    downloadCell.Tag = download.Downstream;
                                }
                                else
                                {
                                    downloadCell.Value = string.Empty;
                                    downloadCell.Tag = -1;
                                }
                                downloadCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //2008-10-21 Eroli: Bugfix-End
                                downloadRow.Tag = new RandomTag<string>(download.DownloadIDString);
                                downloadsDataGridView.Rows.Add(downloadRow);
                                continue;
                            }
                            downloadCell = downloadRow.Cells["DownloadIcon"];
                            if ((string)downloadCell.Tag != download.FileName)
                            {
                                downloadCell.Tag = download.FileName;
                                try
                                {
                                    // 2008-10-21 Eroli: Mono-Fix
                                    if (!UtilitiesForMono.IsRunningOnMono)
                                        downloadCell.Value = ShellIcon.GetSmallSystemIcon((string)downloadCell.Tag);
                                }
                                catch
                                {
                                }
                            }
                            downloadCell = downloadRow.Cells["RatingIcon"];
                            downloadCell.Value = GetRatingImage(download);
                            downloadCell.Tag = download.Rating;
                            downloadCell = downloadRow.Cells["FileName"];
                            downloadCell.Value = download.FileName;
                            downloadCell = downloadRow.Cells["FileSize"];
                            downloadCell.Value = download.FileSizeString;
                            downloadCell.Tag = download.FileSize;
                            downloadCell = downloadRow.Cells["Completed"];
                            downloadCell.Value = download.CompletedString;
                            downloadCell.Tag = download.Completed;
                            downloadCell = downloadRow.Cells["ProgressImage"];

                            try
                            {
                                ((Image)downloadCell.Value).Dispose();
                            }
                            catch
                            {
                            }
                            try
                            {
                                downloadCell.Value = ProgressBars.GetProgressBar(download, downloadsDataGridView.Columns["ProgressImage"].Width, 16, Font);
                            }
                            catch
                            {
                            }
                            downloadCell.Tag = download.Progress;
                            //2008-03-20 Nochbaer
                            downloadCell = downloadRow.Cells["Status"];
                            downloadCell.Value = download.IsActive ? RShare.Properties.Resources.DownloadIsStarted : RShare.Properties.Resources.DownloadIsQueued;
                            downloadCell.Tag = download.QueuePostition;
                            downloadCell = downloadRow.Cells["Sources"];
                            downloadCell.Value = GetSourceString(download);
                            downloadCell.Tag = download.Sources.Count;
                            downloadCell = downloadRow.Cells["Remaining"];
                            downloadCell.Value = download.RemainingString;
                            downloadCell.Tag = download.Remaining;
                            downloadCell = downloadRow.Cells["lastSeen"];
                            // T.Norad: calculate the date diff for display
                            if (download.LastSeen != null)
                            {
                                TimeSpan span = DateTime.Now.Subtract((DateTime)download.LastSeen);
                                downloadCell.Value = string.Format(Properties.Resources.Date_Diff, span.Days, span.Hours, span.Minutes, span.Seconds);
                                downloadCell.Tag = download.LastSeen;
                            }
                            downloadCell = downloadRow.Cells["lastReception"];
                            if (Core.DownloadsAndQueue.IndexOfKey(download.DownloadIDString) < Constants.MaximumDownloadsCount)
                            {
                                downloadCell.Value = download.DownstreamString;
                                downloadCell.Tag = download.Downstream;
                            }
                            else
                            {
                                downloadCell.Value = string.Empty;
                                downloadCell.Tag = -1;
                            }
                            downloadCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        downloadsDataGridView.Sort(downloadsDataGridView.SortedColumn, downloadsDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                        if (downloadsDataGridView.SelectedRows.Count == 1)
                            Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[0].Tag).Tag, out selectedDownload);
                    }
                    catch (InvalidOperationException)
                    {
                        // T.Norad BZ138: Ignore this exception.
                        // cause of this exception is: the enumerator from "Core.DownloadsAndQueue.Values"
                        // comes invalid cause some other code change the collection if we use
                        // the enumerator. 
                        // catch this exception is only a workaround.
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Log(ex, "An exception was thrown! (DownloadsControl - Downloads)");
                    }
                    finally
                    {
                        Core.DownloadsAndQueue.Unlock();
                    }
                    if (selectedDownload != null)
                    {
                        try
                        {
                            selectedDownload.Sources.Lock();
                            sourcesDataGridView.Tag = selectedDownload.DownloadIDString;
                            sourcesDataGridView.Enabled = true;
                            {
                                DataGridViewRow row;
                                for (int n = sourcesDataGridView.Rows.Count - 1; n >= 0; n--)
                                {
                                    row = sourcesDataGridView.Rows[n];
                                    if (!selectedDownload.Sources.ContainsKey(((RandomTag<string>)row.Tag).Tag))
                                        sourcesDataGridView.Rows.RemoveAt(n);
                                }
                            }
                            DataGridViewRow sourceRow;
                            DataGridViewCell sourceCell;
                            int a = 0;
                            foreach (Download.Source source in selectedDownload.Sources.Values)
                            {
                                if (a % 50 == 0)
                                    Application.DoEvents();
                                a++;
                                sourceRow = null;
                                foreach (DataGridViewRow row in sourcesDataGridView.Rows)
                                    if ((((RandomTag<string>)row.Tag).Tag).Equals(source.PeerIDString))
                                    {
                                        sourceRow = row;
                                        break;
                                    }
                                if (sourceRow == null)
                                {
                                    sourceRow = new DataGridViewRow();
                                    sourceRow.Height = 17;
                                    // column: peer icon
                                    sourceCell = new DataGridViewImageCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    sourceCell.Value = Properties.Resources.peer_16x16;
                                    // column: star icon
                                    sourceCell = new DataGridViewImageCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    sourceCell.Value = GetTypeImage(source);
                                    sourceCell.Tag = source.LastReceived;
                                    sourceCell = new DataGridViewTextBoxCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    sourceCell.Value = GetTypeString(source);
                                    sourceCell.Tag = source.State;
                                    // column: progress bar
                                    sourceCell = new DataGridViewImageCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    try
                                    {
                                        sourceCell.Value = ProgressBars.GetProgressBar(selectedDownload, source, sourcesDataGridView.Columns["Progress"].Width, 16);
                                    }
                                    catch
                                    {
                                    }
                                    // column: queue position
                                    sourceCell = new DataGridViewTextBoxCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    if (source.State == Download.SourceState.NotNeeded)
                                    {
                                        sourceCell.Value = Properties.Resources.NoNeededSectors;
                                        sourceCell.Tag = int.MaxValue - 1;
                                    }
                                    else if (source.State == Download.SourceState.Verifying ||
                                        source.State == Download.SourceState.Requesting ||
                                        source.IsQueueFull)
                                    {
                                        sourceCell.Value = Properties.Resources.SourceQueuePositionUnknown;
                                        sourceCell.Tag = int.MaxValue;
                                    }
                                    else if (source.State == Download.SourceState.Verified)
                                    {
                                        sourceCell.Value = source.QueueLength.ToString();
                                        sourceCell.Tag = source.QueueLength + 1;
                                    }
                                    else if (source.State == Download.SourceState.Requested)
                                    {
                                        sourceCell.Value = source.QueuePosition.ToString();
                                        sourceCell.Tag = source.QueuePosition + 1;
                                    }
                                    else if (source.State == Download.SourceState.Active)
                                    {
                                        sourceCell.Value = Properties.Resources.SourceState_Active;
                                        sourceCell.Tag = 0;
                                    }
                                    //
                                    sourceCell = new DataGridViewTextBoxCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    sourceCell.Value = source.SentCommands.ToString();
                                    sourceCell.Tag = source.SentCommands;
                                    sourceCell = new DataGridViewTextBoxCell();
                                    sourceRow.Cells.Add(sourceCell);
                                    sourceCell.Value = source.ReceivedCommands.ToString();
                                    sourceCell.Tag = source.ReceivedCommands;
                                    sourceRow.Tag = new RandomTag<string>(source.PeerIDString);
                                    sourcesDataGridView.Rows.Add(sourceRow);
                                    continue;
                                }
                                sourceCell = sourceRow.Cells["TypeIcon"];
                                sourceCell.Value = GetTypeImage(source);
                                sourceCell.Tag = source.LastReceived;
                                sourceCell = sourceRow.Cells["Type"];
                                sourceCell.Value = GetTypeString(source);
                                sourceCell.Tag = source.State;
                                sourceCell = sourceRow.Cells["Progress"];
                                try
                                {
                                    ((Image)sourceCell.Value).Dispose();
                                }
                                catch
                                {
                                }
                                try
                                {
                                    sourceCell.Value = ProgressBars.GetProgressBar(selectedDownload, source, sourcesDataGridView.Columns["Progress"].Width, 16);
                                }
                                catch
                                {
                                }
                                sourceCell = sourceRow.Cells["Queue"];
                                if (source.State == Download.SourceState.NotNeeded)
                                {
                                    sourceCell.Value = Properties.Resources.NoNeededSectors;
                                    sourceCell.Tag = int.MaxValue - 1;
                                }
                                else if (source.State == Download.SourceState.Verifying ||
                                    source.State == Download.SourceState.Requesting ||
                                    source.IsQueueFull)
                                {
                                    sourceCell.Value = Properties.Resources.SourceQueuePositionUnknown;
                                    sourceCell.Tag = int.MaxValue;
                                }
                                else if (source.State == Download.SourceState.Verified)
                                {
                                    sourceCell.Value = source.QueueLength.ToString();
                                    sourceCell.Tag = source.QueueLength + 1;
                                }
                                else if (source.State == Download.SourceState.Requested)
                                {
                                    sourceCell.Value = source.QueuePosition.ToString();
                                    sourceCell.Tag = source.QueuePosition + 1;
                                }
                                else if (source.State == Download.SourceState.Active)
                                {
                                    sourceCell.Value = Properties.Resources.SourceState_Active;
                                    sourceCell.Tag = 0;
                                }
                                sourceCell = sourceRow.Cells["SentCommands"];
                                sourceCell.Value = source.SentCommands.ToString();
                                sourceCell.Tag = source.SentCommands;
                                sourceCell = sourceRow.Cells["ReceivedCommands"];
                                sourceCell.Value = source.ReceivedCommands.ToString();
                                sourceCell.Tag = source.ReceivedCommands;
                            }
                            sourcesDataGridView.Sort(sourcesDataGridView.SortedColumn, sourcesDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.Log(ex, "An exception was thrown! (DownloadsControl - Sources)");
                        }
                        finally
                        {
                            selectedDownload.Sources.Unlock();
                        }
                    }
                    else
                    {
                        sourcesDataGridView.Rows.Clear();
                        sourcesDataGridView.Tag = null;
                        sourcesDataGridView.Enabled = false;
                    }
                    SelectionChanged();
                }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }

        public DownloadsControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            m_MainForm = mainForm;

            // Added 2007-05-20 by markus for MUI support
            RShare.MainForm.SetUILanguage();
            InitializeComponent();
            downloadsDataGridView.Sort(downloadsDataGridView.Columns["ProgressImage"], ListSortDirection.Descending);
            sourcesDataGridView.Sort(sourcesDataGridView.Columns["Queue"], ListSortDirection.Ascending);
            DownloadInformationDialog.Initialize(downloadsDataGridView);

            //2008-07-28 Nochbaer BZ 56 load order of columns
            try
            {
                splitContainer.SplitterDistance = (Int32.Parse(m_Settings["downloadsSplitterDistance"]) * this.Height) / 100;

                downloadsDataGridView.Columns["DownloadIcon"].DisplayIndex = Int32.Parse(m_Settings["downloadsDownloadIconIndex"]);
                downloadsDataGridView.Columns["DownloadIcon"].FillWeight = float.Parse(m_Settings["downloadsDownloadIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["RatingIcon"].DisplayIndex = Int32.Parse(m_Settings["downloadsRatingIconIndex"]);
                downloadsDataGridView.Columns["RatingIcon"].FillWeight = float.Parse(m_Settings["downloadsRatingIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["FileName"].DisplayIndex = Int32.Parse(m_Settings["downloadsFileNameIndex"]);
                downloadsDataGridView.Columns["FileName"].FillWeight = float.Parse(m_Settings["downloadsFileNameWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["FileSize"].DisplayIndex = Int32.Parse(m_Settings["downloadsFileSizeIndex"]);
                downloadsDataGridView.Columns["FileSize"].FillWeight = float.Parse(m_Settings["downloadsFileSizeWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["Completed"].DisplayIndex = Int32.Parse(m_Settings["downloadsCompletedIndex"]);
                downloadsDataGridView.Columns["Completed"].FillWeight = float.Parse(m_Settings["downloadsCompletedWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["ProgressImage"].DisplayIndex = Int32.Parse(m_Settings["downloadsProgressImageIndex"]);
                downloadsDataGridView.Columns["ProgressImage"].FillWeight = float.Parse(m_Settings["downloadsProgressImageWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["Status"].DisplayIndex = Int32.Parse(m_Settings["downloadsStatusIndex"]);
                downloadsDataGridView.Columns["Status"].FillWeight = float.Parse(m_Settings["downloadsStatusWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["Sources"].DisplayIndex = Int32.Parse(m_Settings["downloadsSourcesIndex"]);
                downloadsDataGridView.Columns["Sources"].FillWeight = float.Parse(m_Settings["downloadsSourcesWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["Remaining"].DisplayIndex = Int32.Parse(m_Settings["downloadsRemainingIndex"]);
                downloadsDataGridView.Columns["Remaining"].FillWeight = float.Parse(m_Settings["downloadsRemainingWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["lastSeen"].DisplayIndex = Int32.Parse(m_Settings["downloadslastSeenIndex"]);
                downloadsDataGridView.Columns["lastSeen"].FillWeight = float.Parse(m_Settings["downloadslastSeenWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                downloadsDataGridView.Columns["lastReception"].DisplayIndex = Int32.Parse(m_Settings["downloadslastReceptionIndex"]);
                downloadsDataGridView.Columns["lastReception"].FillWeight = float.Parse(m_Settings["downloadslastReceptionWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));


                sourcesDataGridView.Columns["SourceIcon"].DisplayIndex = Int32.Parse(m_Settings["sourcesSourceIconIndex"]);
                sourcesDataGridView.Columns["SourceIcon"].FillWeight = float.Parse(m_Settings["sourcesSourceIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sourcesDataGridView.Columns["TypeIcon"].DisplayIndex = Int32.Parse(m_Settings["sourcesTypeIconIndex"]);
                sourcesDataGridView.Columns["TypeIcon"].FillWeight = float.Parse(m_Settings["sourcesTypeIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sourcesDataGridView.Columns["Type"].DisplayIndex = Int32.Parse(m_Settings["sourcesTypeIndex"]);
                sourcesDataGridView.Columns["Type"].FillWeight = float.Parse(m_Settings["sourcesTypeWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sourcesDataGridView.Columns["Queue"].DisplayIndex = Int32.Parse(m_Settings["sourcesQueueIndex"]);
                sourcesDataGridView.Columns["Queue"].FillWeight = float.Parse(m_Settings["sourcesQueueWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sourcesDataGridView.Columns["SentCommands"].DisplayIndex = Int32.Parse(m_Settings["sourcesSentCommandsIndex"]);
                sourcesDataGridView.Columns["SentCommands"].FillWeight = float.Parse(m_Settings["sourcesSentCommandsWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sourcesDataGridView.Columns["ReceivedCommands"].DisplayIndex = Int32.Parse(m_Settings["sourcesReceivedCommandsIndex"]);
                sourcesDataGridView.Columns["ReceivedCommands"].FillWeight = float.Parse(m_Settings["sourcesReceivedCommandsWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading style of columns\n\n" + ex.Message, "DownloadsControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            m_start = false;
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Added 2007-06-12 by Nightwalker_z Preview function for not finished media files
            // 2007-10-03 T.Norad: fix to ignore the case sensitive of extensions
            // get the selected Download to gain values like the filename, the hash and the size
            Download selectedDownload = null;
            if (downloadsDataGridView.SelectedRows.Count == 1 && Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[0].Tag).Tag, out selectedDownload))
            {
                string myFilename = selectedDownload.FileName; // the true filename of the partially downloaded file
                string myTempFile = selectedDownload.TempFilePath; // the temporary name (hash-value) of the partially downloaded file

                string PreviewPlayer = m_Settings["PreviewPlayer"]; //gets the default preview player (executable) out of the config 

                if (System.IO.File.Exists(PreviewPlayer))
                {
                    foreach (string ext in m_Settings["PreviewFiletypes"].Split('|')) // compares the file extensions in the config file with the current extension
                    {
                        if (myFilename.ToUpper().EndsWith("." + ext.ToUpper())) //if there is a match, start playing the file with the player
                            // 2008-03-04 T.Norad: Fixed preview player function with whitespaces in names
                            Process.Start(PreviewPlayer, "\"" + myTempFile + "\"");
                    } //foreach (string ext in m_Settings["PreviewFiletypes"].Split('|')) // compares the file extensions in the config file with the current extension


                } //if (System.IO.File.Exists(PreviewPlayer))
                else
                {
                    // Message that no player has been defined!
                    MessageBox.Show(Properties.Resources.noDefindedPreviewPlayer);

                } //else
            }
        }

        private void copyLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyLinkToClipboard(false);
        }

        private void copyLinkToClipboard(bool htmlLink)
        {
            StringBuilder clipboardText = new StringBuilder();
            try
            {
                Core.DownloadsAndQueue.Lock();
                for (int n = 0; n < downloadsDataGridView.SelectedRows.Count; n++)
                {
                    Download download;
                    if (Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[n].Tag).Tag, out download))
                    {
                        // copy each link seperated by 2 newlines to clipboard
                        clipboardText.Append(new StealthNetLink(download, htmlLink).ToString());
                        clipboardText.Append(System.Environment.NewLine);
                    }
                }
            }
            finally
            {
                Core.DownloadsAndQueue.Unlock();
            }
            // set only if the stringbuilder contains a value overwrite the clipboard text
            if (clipboardText.Length != 0)
            {
                Clipboard.SetText(clipboardText.ToString());
            }
        }

        private void copyLinkHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyLinkToClipboard(true);
        }

        private void moveToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download download;
            if (downloadsDataGridView.SelectedRows.Count == 1 && Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[0].Tag).Tag, out download))
                Core.MoveDownloadToQueue(download.DownloadIDString);
            else if (downloadsDataGridView.SelectedRows.Count > 1)
            {
                string[] temp = new string[downloadsDataGridView.SelectedRows.Count];
                int n = downloadsDataGridView.SelectedRows.Count - 1;
                for (int i = 0; i < downloadsDataGridView.SelectedRows.Count; i++)
                    if (Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[i].Tag).Tag, out download))
                        temp[n - i] = download.DownloadIDString;
                Core.MoveDownloadToQueue(temp);
            }
        }

        private void moveToTopOfQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download download;
            if (downloadsDataGridView.SelectedRows.Count == 1 && Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[0].Tag).Tag, out download))
                Core.MoveToTopOfQueue(download.DownloadIDString);
            else if (downloadsDataGridView.SelectedRows.Count > 1)
            {
                string[] temp = new string[downloadsDataGridView.SelectedRows.Count];
                int n = downloadsDataGridView.SelectedRows.Count - 1;
                for (int i = 0; i < downloadsDataGridView.SelectedRows.Count; i++)
                    if (Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[i].Tag).Tag, out download))
                        temp[n - i] = download.DownloadIDString;
                Core.MoveToTopOfQueue(temp);
            }
        }

        private void moveToBottomOfQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download download;
            if (downloadsDataGridView.SelectedRows.Count == 1 && Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[0].Tag).Tag, out download))
                Core.MoveToBottomOfQueue(download.DownloadIDString);
            else if (downloadsDataGridView.SelectedRows.Count > 1)
            {
                string[] temp = new string[downloadsDataGridView.SelectedRows.Count];
                int n = downloadsDataGridView.SelectedRows.Count - 1;
                for (int i = 0; i < downloadsDataGridView.SelectedRows.Count; i++)
                    if (Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)downloadsDataGridView.SelectedRows[i].Tag).Tag, out download))
                        temp[n - i] = download.DownloadIDString;
                Core.MoveToBottomOfQueue(temp);
            }
        }

        private void SelectionChanged()
        {
            if (downloadsDataGridView.SelectedRows.Count > 0)
            {
                if (downloadsDataGridView.SelectedRows.Count == 1)
                {
                    showInformationToolStripMenuItem.Enabled = true;
                    previewToolStripMenuItem.Enabled = true;
                    int index = int.Parse(downloadsDataGridView.SelectedRows[0].Cells["Status"].Tag.ToString());
                    if (index < Constants.MaximumDownloadsCount)
                    {
                        moveToQueueToolStripMenuItem.Enabled = true;
                        moveToBottomOfQueueToolStripMenuItem.Enabled = false;
                        moveToTopOfQueueToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        moveToQueueToolStripMenuItem.Enabled = false;
                        moveToTopOfQueueToolStripMenuItem.Enabled = index > Constants.MaximumDownloadsCount;
                        moveToBottomOfQueueToolStripMenuItem.Enabled = index < Core.DownloadsAndQueue.Count - 1;
                    }
                }
                else
                {
                    showInformationToolStripMenuItem.Enabled = false;
                    previewToolStripMenuItem.Enabled = false;
                    bool started = false;
                    bool queued = false;
                    foreach (DataGridViewRow row in downloadsDataGridView.SelectedRows)
                    {
                        if (int.Parse(row.Cells["Status"].Tag.ToString()) < Constants.MaximumDownloadsCount)
                            started = true;
                        else
                            queued = true;
                    }
                    if (started == true)
                        moveToQueueToolStripMenuItem.Enabled = true;
                    else
                        moveToQueueToolStripMenuItem.Enabled = false;
                    if (queued == true)
                    {
                        moveToBottomOfQueueToolStripMenuItem.Enabled = true;
                        moveToTopOfQueueToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        moveToBottomOfQueueToolStripMenuItem.Enabled = false;
                        moveToTopOfQueueToolStripMenuItem.Enabled = false;
                    }
                }
                cancelToolStripMenuItem.Enabled = true;
            }
            else
            {
                showInformationToolStripMenuItem.Enabled = false;
                previewToolStripMenuItem.Enabled = false;
                cancelToolStripMenuItem.Enabled = false;
                moveToQueueToolStripMenuItem.Enabled = false;
                moveToBottomOfQueueToolStripMenuItem.Enabled = false;
                moveToTopOfQueueToolStripMenuItem.Enabled = false;
            }
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["downloadsSplitterDistance"] = ((Int32)((splitContainer.SplitterDistance * 100) / this.Height)).ToString();
            }
        }

        private void downloadsDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["downloadsDownloadIconIndex"] = downloadsDataGridView.Columns["DownloadIcon"].DisplayIndex.ToString();
                m_Settings["downloadsRatingIconIndex"] = downloadsDataGridView.Columns["RatingIcon"].DisplayIndex.ToString();
                m_Settings["downloadsFileNameIndex"] = downloadsDataGridView.Columns["FileName"].DisplayIndex.ToString();
                m_Settings["downloadsFileSizeIndex"] = downloadsDataGridView.Columns["FileSize"].DisplayIndex.ToString();
                m_Settings["downloadsCompletedIndex"] = downloadsDataGridView.Columns["Completed"].DisplayIndex.ToString();
                m_Settings["downloadsProgressImageIndex"] = downloadsDataGridView.Columns["ProgressImage"].DisplayIndex.ToString();
                m_Settings["downloadsStatusIndex"] = downloadsDataGridView.Columns["Status"].DisplayIndex.ToString();
                m_Settings["downloadsSourcesIndex"] = downloadsDataGridView.Columns["Sources"].DisplayIndex.ToString();
                m_Settings["downloadsRemainingIndex"] = downloadsDataGridView.Columns["Remaining"].DisplayIndex.ToString();
                m_Settings["downloadslastSeenIndex"] = downloadsDataGridView.Columns["lastSeen"].DisplayIndex.ToString();
                m_Settings["downloadslastReceptionIndex"] = downloadsDataGridView.Columns["lastReception"].DisplayIndex.ToString();
            }
        }

        private void downloadsDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["downloadsDownloadIconWidth"] = downloadsDataGridView.Columns["DownloadIcon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsRatingIconWidth"] = downloadsDataGridView.Columns["RatingIcon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsFileNameWidth"] = downloadsDataGridView.Columns["FileName"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsFileSizeWidth"] = downloadsDataGridView.Columns["FileSize"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsCompletedWidth"] = downloadsDataGridView.Columns["Completed"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsProgressImageWidth"] = downloadsDataGridView.Columns["ProgressImage"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsStatusWidth"] = downloadsDataGridView.Columns["Status"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsSourcesWidth"] = downloadsDataGridView.Columns["Sources"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadsRemainingWidth"] = downloadsDataGridView.Columns["Remaining"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadslastSeenWidth"] = downloadsDataGridView.Columns["lastSeen"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["downloadslastReceptionWidth"] = downloadsDataGridView.Columns["lastReception"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
        }

        private void sourcesDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["sourcesSourceIconIndex"] = sourcesDataGridView.Columns["SourceIcon"].DisplayIndex.ToString();
                m_Settings["sourcesTypeIconIndex"] = sourcesDataGridView.Columns["TypeIcon"].DisplayIndex.ToString();
                m_Settings["sourcesTypeIndex"] = sourcesDataGridView.Columns["Type"].DisplayIndex.ToString();
                m_Settings["sourcesQueueIndex"] = sourcesDataGridView.Columns["Queue"].DisplayIndex.ToString();
                m_Settings["sourcesSentCommandsIndex"] = sourcesDataGridView.Columns["SentCommands"].DisplayIndex.ToString();
                m_Settings["sourcesReceivedCommandsIndex"] = sourcesDataGridView.Columns["ReceivedCommands"].DisplayIndex.ToString();
            }
        }

        private void sourcesDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["sourcesSourceIconWidth"] = sourcesDataGridView.Columns["SourceIcon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sourcesTypeIconWidth"] = sourcesDataGridView.Columns["TypeIcon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sourcesTypeWidth"] = sourcesDataGridView.Columns["Type"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sourcesQueueWidth"] = sourcesDataGridView.Columns["Queue"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sourcesSentCommandsWidth"] = sourcesDataGridView.Columns["SentCommands"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sourcesReceivedCommandsWidth"] = sourcesDataGridView.Columns["ReceivedCommands"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
        }
    }
}