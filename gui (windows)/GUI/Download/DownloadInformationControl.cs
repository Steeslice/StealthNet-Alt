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

using System;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class DownloadInformationControl
        : UserControl
    {
        private Download m_Download;


        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (!((string)iconPictureBox.Tag).Equals(m_Download.FileName))
            {
                iconPictureBox.Tag = m_Download.FileName;
                try
                {
                    // 2008-10-21 Eroli: Mono-Fix
                    if (!UtilitiesForMono.IsRunningOnMono)
                        iconPictureBox.Image = ShellIcon.GetLargeSystemIcon((string)iconPictureBox.Tag);
                }
                catch
                {
                }
            }
            fileNameTextBox.Text = m_Download.FileName;
            fileSizeTextBox.Text = m_Download.FileSizeString;
            fileHashTextBox.Text = m_Download.FileHashString;
            if (m_Download.LastReception != null)
            {
                TimeSpan span = DateTime.Now.Subtract((DateTime)m_Download.LastReception);
                lastReceptionTextBox.Text = string.Format(Properties.Resources.Date_Diff, span.Days, span.Hours, span.Minutes, span.Seconds);
            }
            try
            {
                progressPictureBox.Image.Dispose();
            }
            catch
            {
            }
            try
            {
                progressPictureBox.Image = ProgressBars.GetProgressBar(m_Download, progressPictureBox.Width, progressPictureBox.Height, Font);
            }
            catch
            {
            }
            subFolderTextBox.Text = m_Download.SubFolder;
        }

        public DownloadInformationControl(Download download)
        {
            InitializeComponent();
            m_Download = download;
            iconPictureBox.Tag = m_Download.FileName;
            try
            {
                // 2008-10-21 Eroli: Mono-Fix
                if (!UtilitiesForMono.IsRunningOnMono)
                    iconPictureBox.Image = ShellIcon.GetLargeSystemIcon((string)iconPictureBox.Tag);
            }
            catch
            {
            }
            fileSizeTextBox.Text = m_Download.FileSizeString;
            fileNameTextBox.Text = m_Download.FileName;
            subFolderTextBox.Text = m_Download.SubFolder;
            fileHashTextBox.Text = m_Download.FileHashString;
            if (m_Download.LastReception != null)
            {
                TimeSpan span = DateTime.Now.Subtract((DateTime)m_Download.LastReception);
                lastReceptionTextBox.Text = string.Format(Properties.Resources.Date_Diff, span.Days, span.Hours, span.Minutes, span.Seconds);
            }
            try
            {
                progressPictureBox.Image = ProgressBars.GetProgressBar(m_Download, progressPictureBox.Width, progressPictureBox.Height, Font);
            }
            catch
            {
            }
        }
    }
}