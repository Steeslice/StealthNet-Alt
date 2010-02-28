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
using System.Windows.Forms;
using Regensburger.RShare.GUI.Preferences;

namespace Regensburger.RShare
{
    internal sealed partial class PreferencesDialog
        : Form
    {
        private AboutControl m_AboutControl;

        private DirectoriesControl m_DirectoriesControl;

        private MiscControl m_MiscControl;

        private PreferencesControl m_PreferencesControl;

        private ICoreSettings m_Settings = Settings.Instance;

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["PreferencesDialogLastTab"] = "3";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is AboutControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_AboutControl);
                m_AboutControl.Focus();
            }
        }

        private void directoriesToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["PreferencesDialogLastTab"] = "1";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is DirectoriesControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_DirectoriesControl);
                m_DirectoriesControl.Focus();
            }
        }

        private void miscToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["PreferencesDialogLastTab"] = "2";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is MiscControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_MiscControl);
                m_MiscControl.Focus();
            }
        }

        private void PreferencesDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            toolStripContainer.ContentPanel.Controls.Clear();
            if (m_PreferencesControl != null)
                m_PreferencesControl.Dispose();
            if (m_DirectoriesControl != null)
                m_DirectoriesControl.Dispose();
            if (m_MiscControl != null)
                m_MiscControl.Dispose();
            if (m_AboutControl != null)
                m_AboutControl.Dispose();
        }

        private void PreferencesDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void preferencesToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["PreferencesDialogLastTab"] = "0";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is PreferencesControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_PreferencesControl);
                m_PreferencesControl.Focus();
            }
        }

        public PreferencesDialog(MainForm mainForm)
        {
            RShare.MainForm.SetUILanguage();
            InitializeComponent();
            m_PreferencesControl = new PreferencesControl(mainForm);
            m_PreferencesControl.Dock = DockStyle.Fill;
            m_DirectoriesControl = new DirectoriesControl();
            m_DirectoriesControl.Dock = DockStyle.Fill;
            m_MiscControl = new MiscControl();
            m_MiscControl.Dock = DockStyle.Fill;
            m_AboutControl = new AboutControl();
            m_AboutControl.Dock = DockStyle.Fill;
            toolStripStatusLabel.Text = Properties.Resources.RestartAfterChanges;
            switch (m_Settings["PreferencesDialogLastTab"])
            {
                case "1":
                    directoriesToolStripButton.PerformClick();
                    break;
                case "2":
                    miscToolStripButton.PerformClick();
                    break;
                case "3":
                    aboutToolStripButton.PerformClick();
                    break;
                default:
                    preferencesToolStripButton.PerformClick();
                    break;
            }
        }
    }
}