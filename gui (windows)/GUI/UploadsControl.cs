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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Regensburger.RCollections.ArrayBased;

namespace Regensburger.RShare
{
    internal sealed partial class UploadsControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_start = true;

        private void uploadsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void uploadsDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                switch (e.Column.Name)
                {
                    case "FileSize":
                    case "Completed":
                        e.SortResult = ((long)uploadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)uploadsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((long)uploadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)uploadsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                        e.Handled = true;
                        break;
                    case "lastRequest":
                        e.SortResult = ((int)uploadsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)uploadsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)uploadsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)uploadsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                        e.Handled = true;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                //BZ 122: ignore the exception. sometimes the lastRequest column is null. the reason for this is unknown
            }
        }

        public UploadsControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            m_MainForm = mainForm;
            InitializeComponent();
            uploadsDataGridView.Sort(uploadsDataGridView.Columns["Progress"], ListSortDirection.Descending);

            //2008-07-28 Nochbaer BZ 56 load order of columns
            try
            {
                uploadsDataGridView.Columns["FileName"].DisplayIndex = Int32.Parse(m_Settings["uploadsFileNameIndex"]);
                uploadsDataGridView.Columns["FileName"].FillWeight = float.Parse(m_Settings["uploadsFileNameWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                uploadsDataGridView.Columns["FileSize"].DisplayIndex = Int32.Parse(m_Settings["uploadsFileSizeIndex"]);
                uploadsDataGridView.Columns["FileSize"].FillWeight = float.Parse(m_Settings["uploadsFileSizeWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                uploadsDataGridView.Columns["Completed"].DisplayIndex = Int32.Parse(m_Settings["uploadsCompletedIndex"]);
                uploadsDataGridView.Columns["Completed"].FillWeight = float.Parse(m_Settings["uploadsCompletedWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                uploadsDataGridView.Columns["Progress"].DisplayIndex = Int32.Parse(m_Settings["uploadsProgressIndex"]);
                uploadsDataGridView.Columns["Progress"].FillWeight = float.Parse(m_Settings["uploadsProgressWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                uploadsDataGridView.Columns["Remaining"].DisplayIndex = Int32.Parse(m_Settings["uploadsRemainingIndex"]);
                uploadsDataGridView.Columns["Remaining"].FillWeight = float.Parse(m_Settings["uploadsRemainingWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                uploadsDataGridView.Columns["lastRequest"].DisplayIndex = Int32.Parse(m_Settings["uploadslastRequestIndex"]);
                uploadsDataGridView.Columns["lastRequest"].FillWeight = float.Parse(m_Settings["uploadslastRequestWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading style of columns\n\n" + ex.Message, "UploadsControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            m_start = false;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                updateTimer.Interval = Math.Max(1000, uploadsDataGridView.Rows.Count * 10);
                if (m_MainForm.ActiveTab == this && !m_MainForm.IsInTray)
                    try
                    {
                        // T.Norad: BZ 121. Copy uploads collection to prevent a lock on the uploads collection in core.
                        RIndexedHashtable<string, Upload> uploadsCopy = new RIndexedHashtable<string, Upload>(Core.Uploads);
                        uploadsLabel.Text = string.Format(Properties.Resources.Uploads, uploadsCopy.Count, Constants.MaximumUploadsCount, uploadsCopy.Count - Constants.MaximumUploadsCount < 0 ? 0 : uploadsCopy.Count - Constants.MaximumUploadsCount);
                        {
                            DataGridViewRow row;
                            for (int n = uploadsDataGridView.Rows.Count - 1; n >= 0; n--)
                            {
                                row = uploadsDataGridView.Rows[n];
                                if (!uploadsCopy.ContainsKey(((RandomTag<string>)row.Tag).Tag))
                                {
                                    try
                                    {
                                        ((Image)row.Cells["Progress"].Value).Dispose();
                                    }
                                    catch
                                    {
                                    }
                                    uploadsDataGridView.Rows.RemoveAt(n);
                                }
                            }
                        }
                        DataGridViewRow uploadRow;
                        DataGridViewCell uploadCell;
                        int a = 0;
                        foreach (Upload upload in uploadsCopy.Values)
                        {
                            if (a % 50 == 0)
                                Application.DoEvents();
                            a++;
                            uploadRow = null;
                            foreach (DataGridViewRow row in uploadsDataGridView.Rows)
                                if ((((RandomTag<string>)row.Tag).Tag).Equals(upload.UploadIDString))
                                {
                                    uploadRow = row;
                                    break;
                                }

                            // get display values from shared files or (swarming) download
                            String fileName;
                            String fileSizeString;
                            long fileSize;
                            try
                            {
                                SharedFile sharedFile;
                                if (Core.SharedFiles.TryGetValue(upload.FileHashString, out sharedFile))
                                {
                                    fileName = sharedFile.FileName;
                                    fileSizeString = sharedFile.FileSizeString;
                                    fileSize = sharedFile.FileSize;
                                }
                                else
                                {
                                    Download download;
                                    if (Core.DownloadsAndQueue.TryGetValue(upload.SourceDownloadIDString, out download))
                                    {
                                        fileName = download.FileName;
                                        fileSizeString = download.FileSizeString;
                                        fileSize = download.FileSize;
                                    }
                                    else
                                        continue;
                                }
                            }
                            catch
                            {
                                continue;
                            }
                            // create grid rows          
                            if (uploadRow == null)
                            {
                                uploadRow = new DataGridViewRow();
                                uploadRow.Height = 17;
                                uploadCell = new DataGridViewTextBoxCell();
                                uploadRow.Cells.Add(uploadCell);
                                uploadCell.Value = fileName;
                                uploadCell = new DataGridViewTextBoxCell();
                                uploadRow.Cells.Add(uploadCell);
                                uploadCell.Value = fileSizeString;
                                uploadCell.Tag = fileSize;
                                uploadCell = new DataGridViewTextBoxCell();
                                uploadRow.Cells.Add(uploadCell);
                                uploadCell.Value = upload.CompletedString;
                                uploadCell.Tag = upload.Completed;
                                uploadCell = new DataGridViewImageCell();
                                uploadRow.Cells.Add(uploadCell);
                                try
                                {
                                    uploadCell.Value = ProgressBars.GetProgressBar(upload, uploadsDataGridView.Columns["Progress"].Width, 16);
                                }
                                catch
                                {
                                }
                                uploadCell = new DataGridViewTextBoxCell();
                                uploadRow.Cells.Add(uploadCell);
                                if (uploadsCopy.IndexOfKey(upload.UploadIDString) < Constants.MaximumUploadsCount)
                                {
                                    uploadCell.Value = upload.UpstreamString;
                                    uploadCell.Tag = upload.Upstream;
                                }
                                else
                                {
                                    uploadCell.Value = string.Empty;
                                    uploadCell.Tag = -1;
                                }
                                uploadCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                uploadRow.Tag = new RandomTag<string>(upload.UploadIDString);
                                uploadsDataGridView.Rows.Add(uploadRow);
                                continue;
                            }
                            uploadCell = uploadRow.Cells["FileName"];
                            uploadCell.Value = fileName;
                            uploadCell = uploadRow.Cells["FileSize"];
                            uploadCell.Value = fileSizeString;
                            uploadCell.Tag = fileSize;
                            uploadCell = uploadRow.Cells["Completed"];
                            uploadCell.Value = upload.CompletedString;
                            uploadCell.Tag = upload.Completed;
                            uploadCell = uploadRow.Cells["Progress"];
                            try
                            {
                                ((Image)uploadCell.Value).Dispose();
                            }
                            catch
                            {
                            }
                            try
                            {
                                uploadCell.Value = ProgressBars.GetProgressBar(upload, (int)uploadsDataGridView.Columns["Progress"].Width, 16);
                            }
                            catch
                            {
                            }
                            uploadCell = uploadRow.Cells["lastRequest"];
                            if (uploadsCopy.IndexOfKey(upload.UploadIDString) < Constants.MaximumUploadsCount)
                            {
                                uploadCell.Value = upload.UpstreamString;
                                uploadCell.Tag = upload.Upstream;
                            }
                            else
                            {
                                uploadCell.Value = string.Empty;
                                uploadCell.Tag = -1;
                            }
                        }
                        uploadsDataGridView.Sort(uploadsDataGridView.SortedColumn, uploadsDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Log(ex, "An exception was thrown! (UploadsControl)");
                    }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }

        private void uploadsDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["uploadsFileNameIndex"] = uploadsDataGridView.Columns["FileName"].DisplayIndex.ToString();
                m_Settings["uploadsFileSizeIndex"] = uploadsDataGridView.Columns["FileSize"].DisplayIndex.ToString();
                m_Settings["uploadsCompletedIndex"] = uploadsDataGridView.Columns["Completed"].DisplayIndex.ToString();
                m_Settings["uploadsProgressIndex"] = uploadsDataGridView.Columns["Progress"].DisplayIndex.ToString();
                m_Settings["uploadsRemainingIndex"] = uploadsDataGridView.Columns["Remaining"].DisplayIndex.ToString();
                m_Settings["uploadslastRequestIndex"] = uploadsDataGridView.Columns["lastRequest"].DisplayIndex.ToString();
            }
        }

        private void uploadsDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["uploadsFileNameWidth"] = uploadsDataGridView.Columns["FileName"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["uploadsFileSizeWidth"] = uploadsDataGridView.Columns["FileSize"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["uploadsCompletedWidth"] = uploadsDataGridView.Columns["Completed"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["uploadsProgressWidth"] = uploadsDataGridView.Columns["Progress"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["uploadsRemainingWidth"] = uploadsDataGridView.Columns["Remaining"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["uploadslastRequestWidth"] = uploadsDataGridView.Columns["lastRequest"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
        }
    }
}