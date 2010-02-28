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
    internal sealed partial class SearchResultInformationControl
        : UserControl
    {
        private Search.Result m_Result;

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (!((string)iconPictureBox.Tag).Equals(m_Result.FileName))
            {
                iconPictureBox.Tag = m_Result.FileName;
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
            fileNameTextBox.Text = m_Result.FileName;
        }

        public SearchResultInformationControl(Search.Result result)
        {
            InitializeComponent();
            m_Result = result;
            iconPictureBox.Tag = m_Result.FileName;
            try
            {
                // 2008-10-21 Eroli: Mono-Fix
                if (!UtilitiesForMono.IsRunningOnMono)
                    iconPictureBox.Image = ShellIcon.GetLargeSystemIcon((string)iconPictureBox.Tag);
            }
            catch
            {
            }
            fileNameTextBox.Text = m_Result.FileName;
            fileSizeTextBox.Text = m_Result.FileSizeString;
            fileHashTextBox.Text = m_Result.FileHashString;
        }
    }
}