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
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Text;

namespace Regensburger.RShare
{
    internal sealed partial class SearchControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_start = true;

        private void addSearchButton_Click(object sender, EventArgs e)
        {
            //2009-02-25 Nochbaer
            string searchpattern = searchTextBox.Text.Trim().ToLower();
            foreach (Search s in Core.Searches.Values)
            {
                if (s.SearchPattern == searchpattern)
                {
                    DialogResult dr = MessageBox.Show(this, string.Format(Properties.Resources.AlreadySearchWithThisPattern.Replace(@"\n", "\n"), searchpattern), String.Format(Constants.Software, Core.Version), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        searchTextBox.Text = string.Empty;
                        s.Restart();
                    }
                    return;
                }
            }

            if (Core.Searches.Count < Constants.MaximumSearchesCount)
            {
                Search.SearchType searchType;
                switch (SearchTypeComboBox.SelectedIndex)
                {
                    case 0:
                        searchType = Search.SearchType.Auto;
                        break;
                    case 1:
                        searchType = Search.SearchType.OnlyNetwork;
                        break;
                    case 2:
                        searchType = Search.SearchType.OnlyDatabase;
                        break;
                    default:
                        searchType = Search.SearchType.Auto;
                        break;
                }

                Core.AddSearch(searchTextBox.Text.Trim(), (FileType)FileTypeFilterComboBox.Items[FileTypeFilterComboBox.SelectedIndex], searchType);
                searchTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(this, string.Format(Properties.Resources.AlreadyActiveSearches, Constants.MaximumSearchesCount), String.Format(Constants.Software, Core.Version), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search;
            Search.Result result;
            for (int n = 0; n < resultsDataGridView.SelectedRows.Count; n++)
                if (resultsDataGridView.Tag != null && Core.Searches.TryGetValue((string)resultsDataGridView.Tag, out search) && search.Results.TryGetValue(((RandomTag<string>)resultsDataGridView.SelectedRows[n].Tag).Tag, out result))
                    Core.AddDownload(result, "");
        }

        private void downloadToSubfolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFolderDialog dialog = new SubFolderDialog();
            DialogResult dr = dialog.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                Search search;
                Search.Result result;
                for (int n = 0; n < resultsDataGridView.SelectedRows.Count; n++)
                    if (resultsDataGridView.Tag != null && Core.Searches.TryGetValue((string)resultsDataGridView.Tag, out search) && search.Results.TryGetValue(((RandomTag<string>)resultsDataGridView.SelectedRows[n].Tag).Tag, out result))
                        Core.AddDownload(result, dialog.getName());
            }
            dialog.Dispose();
        }

        private Image GetRatingImage(Search.Result result)
        {
            if (result == null)
                throw new ArgumentNullException("result");

            switch (result.Rating)
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

        private static void GetRowColor(Search.Result result, DataGridViewRow resultRow)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            if (resultRow == null)
                throw new ArgumentNullException("resultRow");

            bool known = Core.SharedFiles.ContainsKey(result.FileHashString);
            if (!known && Core.DownloadsAndQueue.ContainsKey(result.FileHashString, DownloadCollection.KeyAccess.FileHash))
                known = true;
            if (known)
            {
                resultRow.Cells["FileName"].Style.ForeColor = Color.Red;
                resultRow.Cells["FileName"].Style.SelectionForeColor = Color.Red;
                resultRow.Cells["FileSize"].Style.ForeColor = Color.Red;
                resultRow.Cells["FileSize"].Style.SelectionForeColor = Color.Red;
                resultRow.Cells["Sources"].Style.ForeColor = Color.Red;
                resultRow.Cells["Sources"].Style.SelectionForeColor = Color.Red;
                resultRow.Cells["Album"].Style.ForeColor = Color.Red;
                resultRow.Cells["Album"].Style.SelectionForeColor = Color.Red;
                resultRow.Cells["Artist"].Style.ForeColor = Color.Red;
                resultRow.Cells["Artist"].Style.SelectionForeColor = Color.Red;
                resultRow.Cells["Title"].Style.ForeColor = Color.Red;
                resultRow.Cells["Title"].Style.SelectionForeColor = Color.Red;
                resultRow.Cells["Age"].Style.ForeColor = Color.Red;
                resultRow.Cells["Age"].Style.SelectionForeColor = Color.Red;
            }
            else
            {
                Color color = Color.FromArgb(0, 0, (int)(((float)Color.Blue.B / 13) * Math.Max(result.Sources.Count * 2 - 1 > 13 ? 13 : result.Sources.Count * 2 - 1, 0)));
                resultRow.Cells["FileName"].Style.ForeColor = color;
                resultRow.Cells["FileName"].Style.SelectionForeColor = Color.White;
                resultRow.Cells["FileSize"].Style.ForeColor = color;
                resultRow.Cells["FileSize"].Style.SelectionForeColor = Color.White;
                resultRow.Cells["Sources"].Style.ForeColor = color;
                resultRow.Cells["Sources"].Style.SelectionForeColor = Color.White;
                resultRow.Cells["Album"].Style.ForeColor = color;
                resultRow.Cells["Album"].Style.SelectionForeColor = Color.White;
                resultRow.Cells["Artist"].Style.ForeColor = color;
                resultRow.Cells["Artist"].Style.SelectionForeColor = Color.White;
                resultRow.Cells["Title"].Style.ForeColor = color;
                resultRow.Cells["Title"].Style.SelectionForeColor = Color.White;
                resultRow.Cells["Age"].Style.ForeColor = color;
                resultRow.Cells["Age"].Style.SelectionForeColor = Color.White;
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int n = Core.Searches.Count - 1; n >= 0; n--)
                Core.RemoveSearch(Core.Searches[n].Value.SearchID);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search;
            for (int n = searchesDataGridView.SelectedRows.Count - 1; n >= 0; n--)
                if (Core.Searches.TryGetValue(((RandomTag<string>)searchesDataGridView.SelectedRows[n].Tag).Tag, out search))
                    Core.RemoveSearch(search.SearchID);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search;
            for (int n = searchesDataGridView.SelectedRows.Count - 1; n >= 0; n--)
                if (Core.Searches.TryGetValue(((RandomTag<string>)searchesDataGridView.SelectedRows[n].Tag).Tag, out search))
                    search.Restart();
        }

        private void resultsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void resultsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (resultsDataGridView.SelectedRows.Count > 0)
            {
                downloadToolStripMenuItem.Enabled = true;
                downloadToSubfolderToolStripMenuItem.Enabled = true;
                if (resultsDataGridView.SelectedRows.Count == 1)
                    showInformationToolStripMenuItem.Enabled = true;
                else
                    showInformationToolStripMenuItem.Enabled = false;
            }
            else
            {
                downloadToolStripMenuItem.Enabled = false;
                downloadToSubfolderToolStripMenuItem.Enabled = false;
                showInformationToolStripMenuItem.Enabled = false;
            }
        }

        private void resultsDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "RatingIcon":
                    e.SortResult = ((byte)resultsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((byte)resultsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "FileSize":
                    // 2007-09-30 T.Norad support for big files
                    e.SortResult = ((long)resultsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((long)resultsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "Sources":
                    e.SortResult = ((int)resultsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)resultsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "Age":
                    // get the first value to compare from grid
                    object date1 = resultsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag;
                    // second value from grid
                    object date2 = resultsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag;

                    e.SortResult = SortHelper.compareDates(date1, date2);
                    // if the datetime equal we use the sort tag to prevent flickering sort results
                    if (e.SortResult == 0)
                    {
                        e.SortResult = ((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex1].Tag).SortTag.CompareTo(((RandomTag<string>)resultsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void searchesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void searchesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (searchesDataGridView.SelectedRows.Count > 0)
            {
                restartToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                removeToolStripMenuItem.Enabled = true;
            }
            else
            {
                restartToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
            }
        }

        private void searchesDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "IsActive":
                    e.SortResult = (((bool)searchesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag ? 1 : 0) + ((RandomTag<string>)searchesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo(((bool)searchesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag ? 1 : 0) + ((RandomTag<string>)searchesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "Results":
                    e.SortResult = ((int)searchesDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<string>)searchesDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)searchesDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<string>)searchesDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
            }
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.D3:
                        searchTextBox.Text = ".mp3";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.D7:
                        searchTextBox.Text = ".7z";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.A:
                        searchTextBox.Text = ".avi";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.C:
                        searchTextBox.Text = ".sncollection";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.I:
                        searchTextBox.Text = ".iso";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.M:
                        searchTextBox.Text = ".mpg";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.N:
                        searchTextBox.Text = ".nrg";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.P:
                        searchTextBox.Text = ".pdf";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.R:
                        searchTextBox.Text = ".rar";
                        searchTextBox.SelectAll();
                        break;
                    case Keys.Z:
                        searchTextBox.Text = ".zip";
                        searchTextBox.SelectAll();
                        break;
                }
            }
            if (e.KeyCode == Keys.Enter)
                addSearchButton.PerformClick();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Trim().Length >= 3)
                addSearchButton.Enabled = true;
            else
                addSearchButton.Enabled = false;
        }

        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchResultInformationDialog.ShowInformation(this);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search;
            for (int n = searchesDataGridView.SelectedRows.Count - 1; n >= 0; n--)
                if (Core.Searches.TryGetValue(((RandomTag<string>)searchesDataGridView.SelectedRows[n].Tag).Tag, out search))
                    search.Stop();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                updateTimer.Interval = Math.Max(Math.Max(1000, searchesDataGridView.Rows.Count * 10), Math.Max(1000, resultsDataGridView.Rows.Count * 10));
                if (m_MainForm.ActiveTab == this && !m_MainForm.IsInTray)
                {
                    Search selectedSearch = null;
                    try
                    {
                        Core.Searches.Lock();
                        searchesLabel.Text = string.Format(Properties.Resources.Searches, Core.Searches.Count, Constants.MaximumSearchesCount);
                        {
                            DataGridViewRow row;
                            for (int n = searchesDataGridView.Rows.Count - 1; n >= 0; n--)
                            {
                                row = searchesDataGridView.Rows[n];
                                if (!Core.Searches.ContainsKey(((RandomTag<string>)row.Tag).Tag))
                                    searchesDataGridView.Rows.RemoveAt(n);
                            }
                        }
                        DataGridViewRow searchRow;
                        DataGridViewCell searchCell;
                        int a = 0;
                        foreach (Search search in Core.Searches.Values)
                        {
                            if (a % 50 == 0)
                                Application.DoEvents();
                            a++;
                            searchRow = null;
                            foreach (DataGridViewRow row in searchesDataGridView.Rows)
                                if (((RandomTag<string>)row.Tag).Tag.Equals(search.SearchIDString))
                                {
                                    searchRow = row;
                                    break;
                                }
                            if (searchRow == null)
                            {
                                searchRow = new DataGridViewRow();
                                searchRow.Height = 17;
                                searchCell = new DataGridViewTextBoxCell();
                                searchRow.Cells.Add(searchCell);
                                searchCell.Value = search.SearchPattern;
                                searchCell = new DataGridViewTextBoxCell();
                                searchRow.Cells.Add(searchCell);
                                searchCell.Value = search.IsActive ? Properties.Resources.SearchState_Active : Properties.Resources.SearchState_Passive;
                                searchCell.Tag = search.IsActive;
                                searchCell = new DataGridViewTextBoxCell();
                                searchRow.Cells.Add(searchCell);
                                searchCell.Value = search.Results.Count.ToString();
                                searchCell.Tag = search.Results.Count;
                                searchRow.Tag = new RandomTag<string>(search.SearchIDString);
                                searchesDataGridView.Rows.Add(searchRow);
                                continue;
                            }
                            searchCell = searchRow.Cells["IsActive"];
                            searchCell.Value = search.IsActive ? Properties.Resources.SearchState_Active : Properties.Resources.SearchState_Passive;
                            searchCell.Tag = search.IsActive;
                            searchCell = searchRow.Cells["Results"];
                            searchCell.Value = search.Results.Count.ToString();
                            searchCell.Tag = search.Results.Count;
                        }
                        searchesDataGridView.Sort(searchesDataGridView.SortedColumn, searchesDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                        if (searchesDataGridView.SelectedRows.Count == 1 && Core.Searches.ContainsKey(((RandomTag<string>)searchesDataGridView.SelectedRows[0].Tag).Tag))
                            selectedSearch = Core.Searches[((RandomTag<string>)searchesDataGridView.SelectedRows[0].Tag).Tag];
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Log(ex, "An exception was thrown! (SearchControl - Searches)");
                    }
                    finally
                    {
                        Core.Searches.Unlock();
                    }
                    if (selectedSearch != null)
                    {
                        try
                        {
                            selectedSearch.Results.Lock();
                            //2009-01-31 Nochbaer
                            if (selectedSearch.TooManySearchDBResults)
                            {
                                searchesLabel.Text += string.Format(Properties.Resources.TooManySearchDBResults, m_Settings["MaxSearchDBResults"], selectedSearch.TotalSearchDBResults);
                            }

                            resultsDataGridView.Tag = selectedSearch.SearchIDString;
                            resultsDataGridView.Enabled = true;
                            {
                                DataGridViewRow row;
                                for (int n = resultsDataGridView.Rows.Count - 1; n >= 0; n--)
                                {
                                    row = resultsDataGridView.Rows[n];
                                    if (!selectedSearch.Results.ContainsKey(((RandomTag<string>)row.Tag).Tag))
                                        resultsDataGridView.Rows.RemoveAt(n);
                                }
                            }
                            DataGridViewRow resultRow;
                            DataGridViewCell resultCell;
                            int a = 0;
                            foreach (Search.Result result in selectedSearch.Results.Values)
                            {
                                if (a % 50 == 0)
                                    Application.DoEvents();
                                a++;

                                resultRow = null;
                                foreach (DataGridViewRow row in resultsDataGridView.Rows)
                                    if (((RandomTag<string>)row.Tag).Tag.Equals(result.FileHashString))
                                    {
                                        resultRow = row;
                                        break;
                                    }
                                if (resultRow == null)
                                {
                                    resultRow = new DataGridViewRow();
                                    resultRow.Height = 17;
                                    resultCell = new DataGridViewImageCell();
                                    resultCell.Tag = result.FileName;
                                    resultRow.Cells.Add(resultCell);
                                    try
                                    {
                                        // 2008-10-21 Eroli: Mono-Fix
                                        if (!UtilitiesForMono.IsRunningOnMono)
                                            resultCell.Value = ShellIcon.GetSmallSystemIcon((string)resultCell.Tag);
                                    }
                                    catch
                                    {
                                    }
                                    resultCell = new DataGridViewImageCell();
                                    resultRow.Cells.Add(resultCell);
                                    resultCell.Value = GetRatingImage(result);
                                    resultCell.Tag = result.Rating;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    resultCell.Value = result.FileName;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    resultCell.Value = result.FileSizeString;
                                    resultCell.Tag = result.FileSize;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    string sourcesString;
                                    if (result.IsSearchDBResult)
                                    {
                                        sourcesString = "DB";
                                    }
                                    else
                                    {
                                        sourcesString = result.Sources.Count.ToString();
                                    }
                                    resultCell.Value = sourcesString;
                                    resultCell.Tag = result.Sources.Count;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    resultCell.Value = result.Album;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    resultCell.Value = result.Artist;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    resultCell.Value = result.Title;
                                    resultCell = new DataGridViewTextBoxCell();
                                    resultRow.Cells.Add(resultCell);
                                    if (result.IsSearchDBResult)
                                    {
                                        int days = ((TimeSpan)DateTime.Now.Subtract(result.Date)).Days;
                                        if (days == 0)
                                        {
                                            resultCell.Value = Properties.Resources.Today;
                                        }
                                        else
                                        {
                                            resultCell.Value = string.Format(Properties.Resources.Date_Diff_Only_Days, days);
                                        }
                                    }
                                    else
                                    {
                                        resultCell.Value = RShare.Properties.Resources.Today;
                                    }
                                    resultCell.Tag = result.Date;
                                    resultRow.Tag = new RandomTag<string>(result.FileHashString);
                                    resultsDataGridView.Rows.Add(resultRow);
                                    GetRowColor(result, resultRow);
                                    continue;
                                }
                                resultCell = resultRow.Cells["Icon"];
                                if ((string)resultCell.Tag != result.FileName)
                                {
                                    resultCell.Tag = result.FileName;
                                    try
                                    {
                                        // 2008-10-21 Eroli: Mono-Fix
                                        if (!UtilitiesForMono.IsRunningOnMono)
                                            resultCell.Value = ShellIcon.GetSmallSystemIcon((string)resultCell.Tag);
                                    }
                                    catch
                                    {
                                    }
                                }
                                resultCell = resultRow.Cells["RatingIcon"];
                                resultCell.Value = GetRatingImage(result);
                                resultCell.Tag = result.Rating;
                                resultCell = resultRow.Cells["FileName"];
                                resultCell.Value = result.FileName;
                                resultCell = resultRow.Cells["Sources"];
                                string sourcesString2;
                                if (result.IsSearchDBResult)
                                {
                                    sourcesString2 = "DB";
                                }
                                else
                                {
                                    sourcesString2 = result.Sources.Count.ToString();
                                }
                                resultCell.Value = sourcesString2;
                                resultCell.Tag = result.Sources.Count;
                                resultCell = resultRow.Cells["Album"];
                                resultCell.Value = result.Album;
                                resultCell = resultRow.Cells["Artist"];
                                resultCell.Value = result.Artist;
                                resultCell = resultRow.Cells["Title"];
                                resultCell.Value = result.Title;
                                resultCell = resultRow.Cells["Age"];
                                if (result.IsSearchDBResult)
                                {
                                    int days = ((TimeSpan)DateTime.Now.Subtract(result.Date)).Days;
                                    if (days == 0)
                                    {
                                        resultCell.Value = Properties.Resources.Today;
                                    }
                                    else
                                    {
                                        resultCell.Value = string.Format(Properties.Resources.Date_Diff_Only_Days, days);
                                    }
                                }
                                else
                                {
                                    resultCell.Value = RShare.Properties.Resources.Today;
                                }
                                resultCell.Tag = result.Date;

                                GetRowColor(result, resultRow);
                            }
                            resultsDataGridView.Sort(resultsDataGridView.SortedColumn, resultsDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.Log(ex, "An exception was thrown! (SearchControl - Results)");
                        }
                        finally
                        {
                            selectedSearch.Results.Unlock();
                        }
                    }
                    else
                    {
                        resultsDataGridView.Rows.Clear();
                        resultsDataGridView.Tag = null;
                        resultsDataGridView.Enabled = false;
                    }
                }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }

        public SearchControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            m_MainForm = mainForm;
            RShare.MainForm.SetUILanguage();
            InitializeComponent();
            searchesDataGridView.Sort(searchesDataGridView.Columns["Pattern"], ListSortDirection.Ascending);
            resultsDataGridView.Sort(resultsDataGridView.Columns["Sources"], ListSortDirection.Descending);
            // 2007-05-28 T.Norad
            FileTypeFilterComboBox.Items.Add(new AnyFileType());
            FileTypeFilterComboBox.Items.Add(new ArchiveFileType());
            FileTypeFilterComboBox.Items.Add(new AudioFileType());
            FileTypeFilterComboBox.Items.Add(new CDImageFileType());
            FileTypeFilterComboBox.Items.Add(new DocumentFileType());
            FileTypeFilterComboBox.Items.Add(new ImageFileType());
            FileTypeFilterComboBox.Items.Add(new ProgramFileType());
            FileTypeFilterComboBox.Items.Add(new SNCollectionFileType());
            FileTypeFilterComboBox.Items.Add(new VideoFileType());
            // preselect always the first entry. cause the default filter is AnyType
            FileTypeFilterComboBox.SelectedIndex = 0;
            // 2008-07-15 T.Norad: BZ58 fixed the drop down item count to display all contained items
            FileTypeFilterComboBox.MaxDropDownItems = FileTypeFilterComboBox.Items.Count;

            //2009-02-01 Nochbaer
            SearchTypeComboBox.SelectedIndex = 0;
            if (!bool.Parse(m_Settings["ActivateSearchDB"]))
            {
                SearchTypeComboBox.Enabled = false;
            }


            SearchResultInformationDialog.Initialize(resultsDataGridView);

            //2008-07-28 Nochbaer BZ 56 load order of columns
            try
            {
                splitContainer.SplitterDistance = (Int32.Parse(m_Settings["searchSplitterDistance"]) * this.Width) / 100;

                searchesDataGridView.Columns["Pattern"].DisplayIndex = Int32.Parse(m_Settings["searchesPatternIndex"]);
                searchesDataGridView.Columns["Pattern"].FillWeight = float.Parse(m_Settings["searchesPatternWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                searchesDataGridView.Columns["IsActive"].DisplayIndex = Int32.Parse(m_Settings["searchesIsActiveIndex"]);
                searchesDataGridView.Columns["IsActive"].FillWeight = float.Parse(m_Settings["searchesIsActiveWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                searchesDataGridView.Columns["Results"].DisplayIndex = Int32.Parse(m_Settings["searchesResultsIndex"]);
                searchesDataGridView.Columns["Results"].FillWeight = float.Parse(m_Settings["searchesResultsWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));

                resultsDataGridView.Columns["Icon"].DisplayIndex = Int32.Parse(m_Settings["resultsIconIndex"]);
                resultsDataGridView.Columns["Icon"].FillWeight = float.Parse(m_Settings["resultsIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["RatingIcon"].DisplayIndex = Int32.Parse(m_Settings["resultsRatingIconIndex"]);
                resultsDataGridView.Columns["RatingIcon"].FillWeight = float.Parse(m_Settings["resultsRatingIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["FileName"].DisplayIndex = Int32.Parse(m_Settings["resultsFileNameIndex"]);
                resultsDataGridView.Columns["FileName"].FillWeight = float.Parse(m_Settings["resultsFileNameWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["FileSize"].DisplayIndex = Int32.Parse(m_Settings["resultsFileSizeIndex"]);
                resultsDataGridView.Columns["FileSize"].FillWeight = float.Parse(m_Settings["resultsFileSizeWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["Sources"].DisplayIndex = Int32.Parse(m_Settings["resultsSourcesIndex"]);
                resultsDataGridView.Columns["Sources"].FillWeight = float.Parse(m_Settings["resultsSourcesWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["Album"].DisplayIndex = Int32.Parse(m_Settings["resultsAlbumIndex"]);
                resultsDataGridView.Columns["Album"].FillWeight = float.Parse(m_Settings["resultsAlbumWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["Artist"].DisplayIndex = Int32.Parse(m_Settings["resultsArtistIndex"]);
                resultsDataGridView.Columns["Artist"].FillWeight = float.Parse(m_Settings["resultsArtistWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["Title"].DisplayIndex = Int32.Parse(m_Settings["resultsTitleIndex"]);
                resultsDataGridView.Columns["Title"].FillWeight = float.Parse(m_Settings["resultsTitleWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                resultsDataGridView.Columns["Age"].DisplayIndex = Int32.Parse(m_Settings["resultsAgeIndex"]);
                resultsDataGridView.Columns["Age"].FillWeight = float.Parse(m_Settings["resultsAgeWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading style of columns\n\n" + ex.Message, "SearchControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // 2007-11-15 T.Norad copy for all selected downloads the stealthnet-link to clipboard 
            Search search;
            Search.Result result;
            StringBuilder clipboardText = new StringBuilder();

            for (int n = 0; n < resultsDataGridView.SelectedRows.Count; n++)
            {
                if (Core.Searches.TryGetValue((string)resultsDataGridView.Tag, out search) && search.Results.TryGetValue(((RandomTag<string>)resultsDataGridView.SelectedRows[n].Tag).Tag, out result))
                {
                    // copy each link seperated by 2 newlines to clipboard
                    clipboardText.Append(new StealthNetLink(result, htmlLink).ToString());
                    clipboardText.Append(System.Environment.NewLine);
                }
            }
            // set only if the stringbuilder contains a value overwrite the clipboard text
            if (clipboardText.Length != 0)
            {
                Clipboard.SetText(clipboardText.ToString());
            }
        }

        private void restartAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 2008-06-28 T.Norad: restart all searches BZ41
            for (int n = Core.Searches.Count - 1; n >= 0; n--)
            {
                Core.Searches[n].Value.Restart();
            }
        }

        private void resultsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 2008-07-05 T.Norad BZ51: perform click only when a cell is clicked and not the header
            if (e.RowIndex != -1)
            {
                downloadToolStripMenuItem.PerformClick();
            }
        }

        private void resultsDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["resultsIconIndex"] = resultsDataGridView.Columns["Icon"].DisplayIndex.ToString();
                m_Settings["resultsRatingIconIndex"] = resultsDataGridView.Columns["RatingIcon"].DisplayIndex.ToString();
                m_Settings["resultsFileNameIndex"] = resultsDataGridView.Columns["FileName"].DisplayIndex.ToString();
                m_Settings["resultsFileSizeIndex"] = resultsDataGridView.Columns["FileSize"].DisplayIndex.ToString();
                m_Settings["resultsSourcesIndex"] = resultsDataGridView.Columns["Sources"].DisplayIndex.ToString();
                m_Settings["resultsAlbumIndex"] = resultsDataGridView.Columns["Album"].DisplayIndex.ToString();
                m_Settings["resultsArtistIndex"] = resultsDataGridView.Columns["Artist"].DisplayIndex.ToString();
                m_Settings["resultsTitleIndex"] = resultsDataGridView.Columns["Title"].DisplayIndex.ToString();
                m_Settings["resultsAgeIndex"] = resultsDataGridView.Columns["Age"].DisplayIndex.ToString();
            }
        }

        private void resultsDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["resultsIconWidth"] = resultsDataGridView.Columns["Icon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsRatingIconWidth"] = resultsDataGridView.Columns["RatingIcon"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsFileNameWidth"] = resultsDataGridView.Columns["FileName"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsFileSizeWidth"] = resultsDataGridView.Columns["FileSize"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsSourcesWidth"] = resultsDataGridView.Columns["Sources"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsAlbumWidth"] = resultsDataGridView.Columns["Album"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsArtistWidth"] = resultsDataGridView.Columns["Artist"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsTitleWidth"] = resultsDataGridView.Columns["Title"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["resultsAgeWidth"] = resultsDataGridView.Columns["Age"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["searchSplitterDistance"] = ((Int32)((splitContainer.SplitterDistance * 100) / this.Width)).ToString();
            }
        }

        private void searchesDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["searchesPatternIndex"] = searchesDataGridView.Columns["Pattern"].DisplayIndex.ToString();
                m_Settings["searchesIsActiveIndex"] = searchesDataGridView.Columns["IsActive"].DisplayIndex.ToString();
                m_Settings["searchesResultsIndex"] = searchesDataGridView.Columns["Results"].DisplayIndex.ToString();
            }
        }

        private void searchesDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["searchesPatternWidth"] = searchesDataGridView.Columns["Pattern"].FillWeight.ToString();
                m_Settings["searchesIsActiveWidth"] = searchesDataGridView.Columns["IsActive"].FillWeight.ToString();
                m_Settings["searchesResultsWidth"] = searchesDataGridView.Columns["Results"].FillWeight.ToString();
            }
        }

        private void FileTypeFilterComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addSearchButton.PerformClick();
        }

        private void SearchTypeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addSearchButton.PerformClick();
        }
    }
}