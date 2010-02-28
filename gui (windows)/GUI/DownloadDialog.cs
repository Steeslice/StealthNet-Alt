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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class DownloadDialog
        : Form
    {
        //2008-03-20 Nochbaer Limit removed
        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 2008-01-20 T.Norad hack for old hashes. could removed in further version
                if (Regex.IsMatch(stealthnetLinkTextBox.Text, "^[0-9A-F]{128,128}$", RegexOptions.IgnoreCase))
                {
                    Core.AddDownload(Core.FileHashStringToFileHash(stealthnetLinkTextBox.Text), stealthnetLinkTextBox.Text, 0, subFolderTextBox.Text);
                    Close();
                }
                else
                {
                    // 2007-11-10 T.Norad create a stealthnet link and add download
                    StealthNetLink stealthNetLink = new StealthNetLink(stealthnetLinkTextBox.Text);
                    Core.AddDownload(stealthNetLink.FileHash, stealthNetLink.FileName, stealthNetLink.FileSize, subFolderTextBox.Text);
                    Close();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Image = Properties.Resources.error_16x16;
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        private void DownloadDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void fileHashTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                downloadButton.PerformClick();
        }

        private void fileHashTextBox_TextChanged(object sender, EventArgs e)
        {
            // 2007-11-10 T.Norad check if the text is a valid stealthnet link
            // 2008-01-20 T.Norad hack for old hashes. could removed in further version
            if (Regex.IsMatch(stealthnetLinkTextBox.Text, "^[0-9A-F]{128,128}$", RegexOptions.IgnoreCase))
            {
                downloadButton.Enabled = true;
            }
            else
            {
                try
                {
                    StealthNetLink stealthNetLink = new StealthNetLink(stealthnetLinkTextBox.Text);
                    downloadButton.Enabled = true;
                }
                catch
                {
                    downloadButton.Enabled = false;
                }
            }
        }

        private void pasteFromClipboardLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            stealthnetLinkTextBox.Text = Clipboard.GetText();
        }

        private void subFolderTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string notallowed = "<>|\"/\\?:*";
            if (notallowed.Contains(e.KeyChar.ToString()))
                e.Handled = true;
        }

        public DownloadDialog()
        {
            InitializeComponent();
        }

        private void DownloadDialog_Load(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            if (Regex.IsMatch(clipboardText, "^[0-9A-F]{128,128}$", RegexOptions.IgnoreCase))
            {
                stealthnetLinkTextBox.Text = clipboardText;
            }
            else
            {
                try
                {
                    StealthNetLink stealthNetLink = new StealthNetLink(clipboardText);
                    stealthnetLinkTextBox.Text = clipboardText;
                }
                catch
                {
                }
            }
        }
    }
}