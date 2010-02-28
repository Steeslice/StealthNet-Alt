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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class DirectoriesControl
        : UserControl
    {
        private ICoreSettings m_Settings = Settings.Instance;
        private Logger m_Logger = Logger.Instance; /// a logging object

        private void selectIncomingDirectoryButton_Click(object sender, EventArgs e)
        {
            directoryFolderBrowserDialog.SelectedPath = m_Settings["IncomingDirectory"];
            if (directoryFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && directoryFolderBrowserDialog.SelectedPath != m_Settings["IncomingDirectory"])
            {
                incomingDirectoryTextBox.Text = directoryFolderBrowserDialog.SelectedPath;
                m_Settings["IncomingDirectory"] = directoryFolderBrowserDialog.SelectedPath;
            }
        }

        private void selectLogDirectoryButton_Click(object sender, EventArgs e)
        {
            directoryFolderBrowserDialog.SelectedPath = m_Settings["LogDirectory"];
            if (directoryFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && directoryFolderBrowserDialog.SelectedPath != m_Settings["LogDirectory"])
            {
                logDirectoryTextBox.Text = directoryFolderBrowserDialog.SelectedPath;
                m_Settings["LogDirectory"] = directoryFolderBrowserDialog.SelectedPath;
            }
        }

        private void selectPreferencesDirectoryButton_Click(object sender, EventArgs e)
        {
            directoryFolderBrowserDialog.SelectedPath = m_Settings["PreferencesDirectory"];
            if (directoryFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && directoryFolderBrowserDialog.SelectedPath != m_Settings["PreferencesDirectory"])
            {
                preferencesDirectoryTextBox.Text = directoryFolderBrowserDialog.SelectedPath;
                m_Settings["PreferencesDirectory"] = directoryFolderBrowserDialog.SelectedPath;
            }
        }

        private void selectTemporaryDirectoryButton_Click(object sender, EventArgs e)
        {
            directoryFolderBrowserDialog.SelectedPath = m_Settings["TemporaryDirectory"];
            if (directoryFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && directoryFolderBrowserDialog.SelectedPath != m_Settings["TemporaryDirectory"])
            {
                temporaryDirectoryTextBox.Text = directoryFolderBrowserDialog.SelectedPath;
                m_Settings["TemporaryDirectory"] = directoryFolderBrowserDialog.SelectedPath;
            }
        }

        private void selectCorruptDirectoryButton_Click(object sender, EventArgs e)
        {
            directoryFolderBrowserDialog.SelectedPath = m_Settings["CorruptDirectory"];
            if (directoryFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && directoryFolderBrowserDialog.SelectedPath != m_Settings["CorruptDirectory"])
            {
                corruptDirectoryTextBox.Text = directoryFolderBrowserDialog.SelectedPath;
                m_Settings["CorruptDirectory"] = directoryFolderBrowserDialog.SelectedPath;
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Interval = Math.Max(1000, sharedDirectoriesDataGridView.Rows.Count * 10);
            try
            {
                //sharedDirectoriesLabel.Text = string.Format("Shared Directories ({0})", Core.SharedDirectories.Count);
                sharedDirectoriesLabel.Text = string.Format(Properties.Resources.SharedDirectories, Core.SharedDirectories.Count);
                
                int a = 0;
                {
                    DataGridViewRow row;
                    for (int n = sharedDirectoriesDataGridView.Rows.Count - 1; n >= 0; n--)
                    {
                        if (a % 50 == 0)
                            Application.DoEvents();
                        a++;
                        row = sharedDirectoriesDataGridView.Rows[n];
                        if (!Core.SharedDirectories.Contains((string)row.Tag))
                            try
                            {
                                sharedDirectoriesDataGridView.Rows.RemoveAt(n);
                            }
                            catch
                            {
                            }
                    }
                }
                DataGridViewRow sharedDirectoryRow;
                DataGridViewCell sharedDirectoryCell;
                foreach (string sharedDirectory in Core.SharedDirectories)
                {
                    if (a % 50 == 0)
                        Application.DoEvents();
                    a++;
                    sharedDirectoryRow = null;
                    foreach (DataGridViewRow row in sharedDirectoriesDataGridView.Rows)
                        if (row.Tag.Equals(sharedDirectory))
                        {
                            sharedDirectoryRow = row;
                            break;
                        }
                    if (sharedDirectoryRow == null)
                    {
                        sharedDirectoryRow = new DataGridViewRow();
                        sharedDirectoryRow.Height = 17;
                        sharedDirectoryCell = new DataGridViewImageCell();
                        sharedDirectoryRow.Cells.Add(sharedDirectoryCell);
                        sharedDirectoryCell.Value = Properties.Resources.directory_16x16;
                        sharedDirectoryCell = new DataGridViewTextBoxCell();
                        sharedDirectoryRow.Cells.Add(sharedDirectoryCell);
                        sharedDirectoryCell.Value = sharedDirectory;
                        sharedDirectoryRow.Tag = sharedDirectory;
                        sharedDirectoriesDataGridView.Rows.Add(sharedDirectoryRow);
                        continue;
                    }
                }
                sharedDirectoriesDataGridView.Sort(sharedDirectoriesDataGridView.SortedColumn, sharedDirectoriesDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            catch
            {
            }
        }

        private void sharedDirectoriesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // 2007-08-06 T.Norad Ticket #57
            // search for the incomming directory
            // if the incomming directory is selected: disable the remove button
            Boolean incommingDirectoryFound = false;
            foreach (DataGridViewRow row in sharedDirectoriesDataGridView.SelectedRows)
            {
                if (m_Settings["IncomingDirectory"].Equals(row.Tag))
                {
                    incommingDirectoryFound = true;
                    break;
                }   
            }

            // enable the remove button if the icomming directory is not selected and at least one
            // directory is selected
            if (!incommingDirectoryFound && (sharedDirectoriesDataGridView.SelectedRows.Count > 0))
            {
                removeSharedDirectoryButton.Enabled = true;
            }
            else
            {
                removeSharedDirectoryButton.Enabled = false;
            }
        }

        private void sharedDirectoriesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void addSharedDirectoryButton_Click(object sender, EventArgs e)
        {
            directoryFolderBrowserDialog.SelectedPath = string.Empty;
            if (directoryFolderBrowserDialog.ShowDialog(this) == DialogResult.OK && !Core.SharedDirectories.Contains(directoryFolderBrowserDialog.SelectedPath))
                Core.ShareManager.AddDirectory(directoryFolderBrowserDialog.SelectedPath);
        }

        private void removeSharedDirectoryButton_Click(object sender, EventArgs e)
        {
            for (int n = sharedDirectoriesDataGridView.SelectedRows.Count - 1; n >= 0; n--)
                Core.ShareManager.RemoveDirectory((string)sharedDirectoriesDataGridView.SelectedRows[n].Tag);
        }

        
        public DirectoriesControl()
        {
            InitializeComponent();
            sharedDirectoriesDataGridView.Sort(sharedDirectoriesDataGridView.Columns["Path"], ListSortDirection.Descending);
            preferencesDirectoryTextBox.Text = m_Settings["PreferencesDirectory"];
            logDirectoryTextBox.Text = m_Settings["LogDirectory"];
            temporaryDirectoryTextBox.Text = m_Settings["TemporaryDirectory"];
            incomingDirectoryTextBox.Text = m_Settings["IncomingDirectory"];
            corruptDirectoryTextBox.Text = m_Settings["CorruptDirectory"];
        }
    }
}