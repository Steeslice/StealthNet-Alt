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
using System.Net;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class ConnectDialog
        : Form
    {
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                Core.AddConnection(new IPEndPoint(Dns.GetHostEntry(textBox.Text).AddressList[0], (int)portNumericUpDown.Value));
                Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Image = Properties.Resources.error_16x16;
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        private void ConnectDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void portNumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connectButton.PerformClick();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connectButton.PerformClick();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text != string.Empty)
                connectButton.Enabled = true;
            else
                connectButton.Enabled = false;
        }

        public ConnectDialog()
        {
            InitializeComponent();
            portNumericUpDown.Value = decimal.Parse(Settings.Instance["Port"]);
        }
    }
}