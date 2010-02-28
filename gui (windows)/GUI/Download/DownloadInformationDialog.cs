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
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class DownloadInformationDialog
        : Form
    {
        private static DataGridView m_DataGridView;

        private DownloadInformationControl m_InformationControl;

        private static DownloadInformationDialog m_Instance;

        private bool m_IsChanging = false;

        private DownloadSourcesControl m_SourcesControl;

        public Control ActiveTab
        {
            get
            {
                return toolStripContainer.ContentPanel.Controls.Count > 0 ? toolStripContainer.ContentPanel.Controls[0] : null;
            }
        }

        private void DownloadInformationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_DataGridView.SelectionChanged -= new EventHandler(m_DataGridView_SelectionChanged);
            toolStripContainer.ContentPanel.Controls.Clear();
            if (m_InformationControl != null)
                m_InformationControl.Dispose();
            if (m_SourcesControl != null)
                m_SourcesControl.Dispose();
            m_Instance = null;
        }

        private void DownloadInformationDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void informationToolStripButton_Click(object sender, EventArgs e)
        {
            Settings.Instance["DownloadInformationDialogLastTab"] = "0";
            if (m_InformationControl != null)
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_InformationControl);
                m_InformationControl.Focus();
            }
        }

        public static void Initialize(DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException("dataGridView");

            m_DataGridView = dataGridView;
        }

        private void m_DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (m_DataGridView.SelectedRows.Count > 0)
            {
                Skip(m_DataGridView.SelectedRows[0].Index);
            }
            else if (!m_IsChanging)
                Close();
        }

        private void nextToolStripButton_Click(object sender, EventArgs e)
        {
            m_IsChanging = true;
            if (m_DataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = m_DataGridView.SelectedRows[0].Index;
                if (selectedIndex < m_DataGridView.Rows.Count - 1)
                {
                    m_DataGridView.ClearSelection();
                    m_DataGridView.Rows[selectedIndex + 1].Selected = true;
                    m_DataGridView.FirstDisplayedCell = m_DataGridView.Rows[selectedIndex + 1].Cells[0];
                }
            }
            m_IsChanging = false;
        }

        private void previousToolStripButton_Click(object sender, EventArgs e)
        {
            m_IsChanging = true;
            if (m_DataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = m_DataGridView.SelectedRows[0].Index;
                if (selectedIndex > 0)
                {
                    m_DataGridView.ClearSelection();
                    m_DataGridView.Rows[selectedIndex - 1].Selected = true;
                    m_DataGridView.FirstDisplayedCell = m_DataGridView.Rows[selectedIndex - 1].Cells[0];
                }
            }
            m_IsChanging = false;
        }

        public static void ShowInformation(IWin32Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");

            if (m_DataGridView == null)
                throw new ArgumentNullException("m_DataGridView");
            if (m_Instance == null)
            {
                new DownloadInformationDialog();
                m_Instance.Show(owner);
            }
            else
                m_Instance.BringToFront();
        }

        private void Skip(int selectedIndex)
        {
            toolStripContainer.ContentPanel.Controls.Clear();
            Download download;
            if (Core.DownloadsAndQueue.TryGetValue(((RandomTag<string>)m_DataGridView.Rows[selectedIndex].Tag).Tag, out download))
            {
                if (m_InformationControl != null)
                    m_InformationControl.Dispose();
                m_InformationControl = new DownloadInformationControl(download);
                m_InformationControl.Dock = DockStyle.Fill;
                if (m_SourcesControl != null)
                    m_SourcesControl.Dispose();
                m_SourcesControl = new DownloadSourcesControl(download);
                m_SourcesControl.Dock = DockStyle.Fill;
                switch (Settings.Instance["DownloadInformationDialogLastTab"])
                {
                    case "1":
                        sourcesToolStripButton.PerformClick();
                        break;
                    default:
                        informationToolStripButton.PerformClick();
                        break;
                }
            }
        }

        private void sourcesToolStripButton_Click(object sender, EventArgs e)
        {
            Settings.Instance["DownloadInformationDialogLastTab"] = "1";
            if (m_SourcesControl != null)
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_SourcesControl);
                m_SourcesControl.Focus();
            }
        }

        private DownloadInformationDialog()
        {
            m_Instance = this;
            InitializeComponent();
            m_DataGridView.SelectionChanged += new EventHandler(m_DataGridView_SelectionChanged);
            if (m_DataGridView.SelectedRows.Count > 0)
                Skip(m_DataGridView.SelectedRows[0].Index);
        }
    }
}