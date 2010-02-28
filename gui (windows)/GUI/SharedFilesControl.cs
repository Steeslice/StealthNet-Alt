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
using System.Text;
using Regensburger.RCollections.ArrayBased;

namespace Regensburger.RShare
{
    internal sealed partial class SharedFilesControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_start = true;

        private Image GetRatingImage(SharedFile sharedFile)
        {
            if (sharedFile == null)
                throw new ArgumentNullException("sharedFile");

            switch (sharedFile.Rating)
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

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SharedFile sharedFile;
            for (int n = 0; n < sharedFilesDataGridView.SelectedRows.Count; n++)
            {
                if (Core.SharedFiles.TryGetValue(((RandomTag<string>)sharedFilesDataGridView.SelectedRows[n].Tag).Tag, out sharedFile))
                {
                    //2009-02-27 Nochbaer: Moved building of parameters to ProcessStarter.startExplorerProcess
                    // build the arguments for the process call
                    //String processArguments = string.Format("/e,{0}", sharedFile.DirectoryPath);
                    // call a new explorer process
                    // process call moved to new class ProcessStarter
                    // Added 2007-05-01 by T.Norad
                    ProcessStarter.startExplorerProcess(sharedFile.DirectoryPath, sharedFile.FileName);
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //2008-09-09 Nochbaer: catch error when file is not associated with a program
            try
            {
                SharedFile sharedFile;
                for (int n = 0; n < sharedFilesDataGridView.SelectedRows.Count; n++)
                {
                    if (Core.SharedFiles.TryGetValue(((RandomTag<string>)sharedFilesDataGridView.SelectedRows[n].Tag).Tag, out sharedFile))
                    {
                        // process call moved to new class ProcessStarter
                        // Added 2007-05-01 by T.Norad
                        ProcessStarter.startProcess(sharedFile.FilePath);
                    }
                }
            }
            catch
            {
            }
        }

        private void sharedFilesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void sharedFilesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (sharedFilesDataGridView.SelectedRows.Count > 0)
            {
                openFileToolStripMenuItem.Enabled = true;
                if (sharedFilesDataGridView.SelectedRows.Count == 1)
                {
                    openDirectoryToolStripMenuItem.Enabled = true;
                    showInformationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    openDirectoryToolStripMenuItem.Enabled = false;
                    showInformationToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                openFileToolStripMenuItem.Enabled = false;
                openDirectoryToolStripMenuItem.Enabled = false;
                showInformationToolStripMenuItem.Enabled = false;
            }
        }

        private void sharedFilesDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "RatingIcon":
                    e.SortResult = ((byte)sharedFilesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)sharedFilesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((byte)sharedFilesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)sharedFilesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "FileSize":
                    // 2007-05-17 T.Norad: fix for big files
                    e.SortResult = ((long)sharedFilesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)sharedFilesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((long)sharedFilesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)sharedFilesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "lastRequest":
                    // get the first value to compare from grid
                    object date1 = sharedFilesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag;
                    // second value from grid
                    object date2 = sharedFilesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag;

                    e.SortResult = SortHelper.compareDates(date1, date2);
                    // if the datetime equal we use the sort tag to prevent flickering sort results
                    if (e.SortResult == 0)
                    {
                        e.SortResult = ((RandomTag<string>)sharedFilesDataGridView.Rows[e.RowIndex1].Tag).SortTag.CompareTo(((RandomTag<string>)sharedFilesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SharedFileInformationDialog.ShowInformation(this);
        }

        public SharedFilesControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            m_MainForm = mainForm;
            InitializeComponent();
            sharedFilesDataGridView.Sort(sharedFilesDataGridView.Columns["FileName"], ListSortDirection.Ascending);
            SharedFileInformationDialog.Initialize(sharedFilesDataGridView);
            // select always the first entry for the search
            columnComboBox.SelectedIndex = 0;
            // display nummer of shared files
            sharedFilesLabel.Text = string.Format(Properties.Resources.SharedFiles, 0, Core.SharedFiles.Count);

            //2008-07-28 Nochbaer BZ 56 load order of columns
            try
            {
                sharedFilesDataGridView.Columns["Icon"].DisplayIndex = Int32.Parse(m_Settings["sharedIconIndex"]);
                sharedFilesDataGridView.Columns["Icon"].FillWeight = float.Parse(m_Settings["sharedIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["RatingIcon"].DisplayIndex = Int32.Parse(m_Settings["sharedRatingIconIndex"]);
                sharedFilesDataGridView.Columns["RatingIcon"].FillWeight = float.Parse(m_Settings["sharedRatingIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["FileName"].DisplayIndex = Int32.Parse(m_Settings["sharedFileNameIndex"]);
                sharedFilesDataGridView.Columns["FileName"].FillWeight = float.Parse(m_Settings["sharedFileNameWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["FileSize"].DisplayIndex = Int32.Parse(m_Settings["sharedFileSizeIndex"]);
                sharedFilesDataGridView.Columns["FileSize"].FillWeight = float.Parse(m_Settings["sharedFileSizeWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["Directory"].DisplayIndex = Int32.Parse(m_Settings["sharedDirectoryIndex"]);
                sharedFilesDataGridView.Columns["Directory"].FillWeight = float.Parse(m_Settings["sharedDirectoryWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["Album"].DisplayIndex = Int32.Parse(m_Settings["sharedAlbumIndex"]);
                sharedFilesDataGridView.Columns["Album"].FillWeight = float.Parse(m_Settings["sharedAlbumWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["Artist"].DisplayIndex = Int32.Parse(m_Settings["sharedArtistIndex"]);
                sharedFilesDataGridView.Columns["Artist"].FillWeight = float.Parse(m_Settings["sharedArtistWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["Title"].DisplayIndex = Int32.Parse(m_Settings["sharedTitleIndex"]);
                sharedFilesDataGridView.Columns["Title"].FillWeight = float.Parse(m_Settings["sharedTitleWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                sharedFilesDataGridView.Columns["lastRequest"].DisplayIndex = Int32.Parse(m_Settings["sharedlastRequestIndex"]);
                sharedFilesDataGridView.Columns["lastRequest"].FillWeight = float.Parse(m_Settings["sharedlastRequestWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading style of columns\n\n" + ex.Message, "SharedFilesControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            m_start = false;
        }

        private void copyLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyLinkToClipboard(false);
        }

        private void copyLinkHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyLinkToClipboard(true);
        }
        private void copyLinkToClipboard(bool htmlLink)
        {
            // 2007-11-15 T.Norad copy for all selected shared files the stealthnet-link to clipboard 
            SharedFile sharedFile;
            StringBuilder clipboardText = new StringBuilder();

            for (int n = 0; n < sharedFilesDataGridView.SelectedRows.Count; n++)
            {
                if (Core.SharedFiles.TryGetValue(((RandomTag<string>)sharedFilesDataGridView.SelectedRows[n].Tag).Tag, out sharedFile))
                {
                    // copy each link seperated by 2 newlines to clipboard
                    clipboardText.Append(new StealthNetLink(sharedFile, htmlLink).ToString());
                    clipboardText.Append(System.Environment.NewLine);
                }
            }
            // set only if the stringbuilder contains a value overwrite the clipboard text
            if (clipboardText.Length != 0)
            {
                Clipboard.SetText(clipboardText.ToString());
            }
        }

        //2008-03-20 Nochbaer
        private void createCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String FilePath;
            SharedFile sharedFile;
            StringBuilder collectionText = new StringBuilder();
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".sncollection";
            dialog.CheckPathExists = true;
            dialog.CheckFileExists = false;
            dialog.CreatePrompt  = false;
            dialog.Filter = "snCollection|*.sncollection";
            dialog.InitialDirectory = m_Settings["IncomingDirectory"];
            dialog.ValidateNames = true;
            DialogResult result = dialog.ShowDialog(this);

            if (result == DialogResult.Cancel || (dialog.FileName.Length > 0) == false)
            {
                return;
            }

            FilePath = dialog.FileName;

            for (int n = 0; n < sharedFilesDataGridView.SelectedRows.Count; n++)
            {
                if (Core.SharedFiles.TryGetValue(((RandomTag<string>)sharedFilesDataGridView.SelectedRows[n].Tag).Tag, out sharedFile))
                {
                    // copy each link seperated by 2 newlines to clipboard
                    collectionText.Append(new StealthNetLink(sharedFile, false).ToString());
                    collectionText.Append(System.Environment.NewLine);
                }
            }
            // set only if the stringbuilder contains a value overwrite the clipboard text
            if (collectionText.Length != 0)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(FilePath);
                sw.Write(collectionText);
                sw.Flush();
                sw.Close();
            }
        }

        private void sharedFilesDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["sharedIconIndex"]  = sharedFilesDataGridView.Columns["Icon"].DisplayIndex.ToString();
                m_Settings["sharedRatingIconIndex"] = sharedFilesDataGridView.Columns["RatingIcon"].DisplayIndex.ToString();
                m_Settings["sharedFileNameIndex"] = sharedFilesDataGridView.Columns["FileName"].DisplayIndex.ToString();
                m_Settings["sharedFileSizeIndex"] = sharedFilesDataGridView.Columns["FileSize"].DisplayIndex.ToString();
                m_Settings["sharedDirectoryIndex"] = sharedFilesDataGridView.Columns["Directory"].DisplayIndex.ToString();
                m_Settings["sharedAlbumIndex"] = sharedFilesDataGridView.Columns["Album"].DisplayIndex.ToString();
                m_Settings["sharedArtistIndex"] = sharedFilesDataGridView.Columns["Artist"].DisplayIndex.ToString();
                m_Settings["sharedTitleIndex"] = sharedFilesDataGridView.Columns["Title"].DisplayIndex.ToString();
                m_Settings["sharedlastRequestIndex"] = sharedFilesDataGridView.Columns["lastRequest"].DisplayIndex.ToString();
            }
        }

        private void sharedFilesDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["sharedIconWidth"] = sharedFilesDataGridView.Columns["Icon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedRatingIconWidth"] = sharedFilesDataGridView.Columns["RatingIcon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedFileNameWidth"] = sharedFilesDataGridView.Columns["FileName"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedFileSizeWidth"] = sharedFilesDataGridView.Columns["FileSize"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedDirectoryWidth"] = sharedFilesDataGridView.Columns["Directory"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedAlbumWidth"] = sharedFilesDataGridView.Columns["Album"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedArtistWidth"] = sharedFilesDataGridView.Columns["Artist"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedTitleWidth"] = sharedFilesDataGridView.Columns["Title"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["sharedlastRequestWidth"] = sharedFilesDataGridView.Columns["lastRequest"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
        }

        private void sharedFilesDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 2008-08-01 T.Norad BZ51: perform click only when a cell is clicked and not the header
            if (e.RowIndex != -1)
            {
                openFileToolStripMenuItem.PerformClick();
            }
        }

        private void columnComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchButton.PerformClick();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchButton.PerformClick();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // T.Norad BZ129
            SharedFileCollection searchResults = new SharedFileCollection();
            string searchpattern = searchTextBox.Text.Trim().ToLower();
            maxSearchCountLabel.Visible = false;

            // first search in the shared files collection in the core
            // then display this results in the grid. this reduces the lock-time of the core collection
            try
            {
                Core.SharedFiles.Lock();

                foreach (SharedFile sharedFile in Core.SharedFiles.Values)
                {
                    // if maximum search result reached: display the note and stop this search
                    if (searchResults.Count >= Constants.MaximumSharedFilesSearchesCount)
                    {
                        maxSearchCountLabel.Visible = true;
                        break;
                    }
                    switch (columnComboBox.SelectedIndex)
                    {
                        case 0:
                            if (sharedFile.FileName.ToLower().Contains(searchpattern) == true)
                            {
                                searchResults.Add(sharedFile);
                            }
                            break;
                        case 1:
                            if (sharedFile.DirectoryPath.ToLower().Contains(searchpattern) == true)
                            {
                                searchResults.Add(sharedFile);
                            }
                            break;
                        case 2:
                            if (sharedFile.Album.ToLower().Contains(searchpattern) == true)
                            {
                                searchResults.Add(sharedFile);
                            }
                            break;
                        case 3:
                            if (sharedFile.Artist.ToLower().Contains(searchpattern) == true)
                            {
                                searchResults.Add(sharedFile);
                            }
                            break;
                        case 4:
                            if (sharedFile.Title.ToLower().Contains(searchpattern) == true)
                            {
                                searchResults.Add(sharedFile);
                            }
                            break;
                    }
                }
            }
            finally
            {
                Core.SharedFiles.Unlock();
            }

            // now display the search results
            sharedFilesDataGridView.Rows.Clear();

            DataGridViewRow sharedFileRow;
            DataGridViewCell sharedFileCell;
            foreach (SharedFile sharedFile in searchResults.Values)
            {
                sharedFileRow = new DataGridViewRow();
                sharedFileRow.Height = 17;
                sharedFileCell = new DataGridViewImageCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                try
                {
                    // 2008-10-21 Eroli: Mono-Fix
                    if (!UtilitiesForMono.IsRunningOnMono)
                        sharedFileCell.Value = ShellIcon.GetSmallSystemIcon(sharedFile.FilePath);
                }
                catch
                {
                }
                sharedFileCell = new DataGridViewImageCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = GetRatingImage(sharedFile);
                sharedFileCell.Tag = sharedFile.Rating;
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = sharedFile.FileName;
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = sharedFile.FileSizeString;
                sharedFileCell.Tag = sharedFile.FileSize;
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = sharedFile.DirectoryPath;
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = sharedFile.Album;
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = sharedFile.Artist;
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                sharedFileCell.Value = sharedFile.Title;
                //2008-10-25 Eroli: Bugfix
                sharedFileCell = new DataGridViewTextBoxCell();
                sharedFileRow.Cells.Add(sharedFileCell);
                if (sharedFile.LastRequest != null)
                {
                    TimeSpan span = DateTime.Now.Subtract((DateTime)sharedFile.LastRequest);
                    sharedFileCell.Value = string.Format(Properties.Resources.Date_Diff, span.Days, span.Hours, span.Minutes, span.Seconds);
                }
                sharedFileCell.Tag = sharedFile.LastRequest;
                //2008-10-25 Eroli: Bugfix-End
                sharedFileRow.Tag = new RandomTag<string>(sharedFile.FileHashString);
                sharedFilesDataGridView.Rows.Add(sharedFileRow);
                continue;
            }

            sharedFilesLabel.Text = string.Format(Properties.Resources.SharedFiles, searchResults.Count, Core.SharedFiles.Count);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                if (m_MainForm.ActiveTab == this && !m_MainForm.IsInTray)
                {
                    sharedFilesLabel.Text = string.Format(Properties.Resources.SharedFiles, sharedFilesDataGridView.Rows.Count, Core.SharedFiles.Count);
                }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }
    }
}