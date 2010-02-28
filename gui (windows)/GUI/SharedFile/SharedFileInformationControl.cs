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
    internal sealed partial class SharedFileInformationControl
        : UserControl
    {
        private SharedFile m_SharedFile;

        private void commentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (m_SharedFile.Comment != commentTextBox.Text)
                m_SharedFile.Comment = commentTextBox.Text;
        }

        private void ratingBadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_SharedFile.Rating != 3)
                m_SharedFile.Rating = 3;
        }

        private void ratingGoodRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_SharedFile.Rating != 1)
                m_SharedFile.Rating = 1;
        }

        private void ratingNeutralRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_SharedFile.Rating != 2)
                m_SharedFile.Rating = 2;
        }

        private void ratingUnknownRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_SharedFile.Rating != 0)
                m_SharedFile.Rating = 0;
        }

        public SharedFileInformationControl(SharedFile sharedFile)
        {
            InitializeComponent();
            m_SharedFile = sharedFile;
            try
            {
                // 2008-10-21 Eroli: Mono-Fix
                if (!UtilitiesForMono.IsRunningOnMono)
                    iconPictureBox.Image = ShellIcon.GetLargeSystemIcon(sharedFile.FileName);
            }
            catch
            {
            }
            fileNameTextBox.Text = m_SharedFile.FileName;
            fileSizeTextBox.Text = m_SharedFile.FileSizeString;
            fileHashTextBox.Text = m_SharedFile.FileHashString;
            commentTextBox.Text = sharedFile.Comment;
            switch (m_SharedFile.Rating)
            {
                case 1:
                    ratingGoodRadioButton.Checked = true;
                    break;
                case 2:
                    ratingNeutralRadioButton.Checked = true;
                    break;
                case 3:
                    ratingBadRadioButton.Checked = true;
                    break;
                default:
                    ratingUnknownRadioButton.Checked = true;
                    break;
            }
        }
    }
}