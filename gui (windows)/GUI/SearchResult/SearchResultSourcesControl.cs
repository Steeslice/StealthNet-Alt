//RShare
//Copyright (C) 2009 Lars Regensburger

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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class SearchResultSourcesControl
        : UserControl
    {
        private Search.Result m_Result;

        public SearchResultSourcesControl(Search.Result result)
        {
            InitializeComponent();
            sourcesDataGridView.Sort(sourcesDataGridView.Columns["FileName"], ListSortDirection.Ascending);
            m_Result = result;
        }

        private Image GetRatingImage(Search.Result.Source source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            switch (source.Rating)
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

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                updateTimer.Interval = Math.Max(1000, sourcesDataGridView.Rows.Count * 10);
                try
                {
                    m_Result.Sources.Lock();
                    {
                        DataGridViewRow row;
                        for (int n = sourcesDataGridView.Rows.Count - 1; n >= 0; n--)
                        {
                            row = sourcesDataGridView.Rows[n];
                            if (!m_Result.Sources.ContainsKey(((RandomTag<string>)row.Tag).Tag))
                                sourcesDataGridView.Rows.RemoveAt(n);
                        }
                    }
                    DataGridViewRow sourceRow;
                    DataGridViewCell sourceCell;
                    int a = 0;
                    foreach (Search.Result.Source source in m_Result.Sources.Values)
                    {
                        if (a % 50 == 0)
                            Application.DoEvents();
                        a++;
                        sourceRow = null;
                        foreach (DataGridViewRow row in sourcesDataGridView.Rows)
                            if ((((RandomTag<string>)row.Tag).Tag).Equals(source.IDString))
                            {
                                sourceRow = row;
                                break;
                            }
                        if (sourceRow == null)
                        {
                            sourceRow = new DataGridViewRow();
                            sourceRow.Height = 17;
                            sourceCell = new DataGridViewImageCell();
                            sourceRow.Cells.Add(sourceCell);
                            try
                            {
                                // 2008-10-21 Eroli: Mono-Fix
                                if (!UtilitiesForMono.IsRunningOnMono)
                                    sourceCell.Value = ShellIcon.GetSmallSystemIcon(source.FileName);
                            }
                            catch
                            {
                            }
                            sourceCell = new DataGridViewImageCell();
                            sourceRow.Cells.Add(sourceCell);
                            sourceCell.Value = GetRatingImage(source);
                            sourceCell = new DataGridViewTextBoxCell();
                            sourceRow.Cells.Add(sourceCell);
                            sourceCell.Value = source.FileName;
                            sourceCell = new DataGridViewTextBoxCell();
                            sourceRow.Cells.Add(sourceCell);
                            sourceCell.Value = source.Comment;
                            sourceRow.Tag = new RandomTag<string>(source.IDString);
                            sourcesDataGridView.Rows.Add(sourceRow);
                            continue;
                        }
                        if ((string)sourceRow.Cells["FileIcon"].Tag != source.FileName)
                        {
                            sourceRow.Cells["FileIcon"].Tag = source.FileName;
                            try
                            {
                                // 2008-10-21 Eroli: Mono-Fix
                                if (!UtilitiesForMono.IsRunningOnMono)
                                    sourceRow.Cells["FileIcon"].Value = ShellIcon.GetSmallSystemIcon((string)sourceRow.Cells["FileIcon"].Tag);
                            }
                            catch
                            {
                            }
                        }
                        sourceRow.Cells["Rating"].Value = GetRatingImage(source);
                        sourceRow.Cells["FileName"].Value = source.FileName;
                        sourceRow.Cells["Comment"].Value = source.Comment;
                    }
                    sourcesDataGridView.Sort(sourcesDataGridView.SortedColumn, sourcesDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                }
                catch (InvalidOperationException)
                {
                    // TODO
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log(ex, "An exception was thrown! (SearchResultSourcesControl)");
                }
                finally
                {
                    m_Result.Sources.Unlock();
                }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }

        private void sourcesDataDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}