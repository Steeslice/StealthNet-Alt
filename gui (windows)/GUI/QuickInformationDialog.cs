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
using System.Diagnostics;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class QuickInformationDialog : Form
    {
        private MainForm m_MainForm;

        private void openIncomingDirectoryPictureBox_Click(object sender, EventArgs e)
        {
            //2009-02-27: Nochbaer: Moved building of arguments to ProcessStarter.startExplorerProcess
            // build the arguments for the process call
            //String processArguments = string.Format("/e,{0}", Settings.Instance["IncomingDirectory"]);
            // call a new explorer process
            // process call moved to new class ProcessStarter
            // Added 2007-05-01 by T.Norad
            ProcessStarter.startExplorerProcess(Settings.Instance["IncomingDirectory"],"");
        }

        private void preferencesPictureBox_Click(object sender, EventArgs e)
        {
            Close();
            m_MainForm.ShowPreferencesDialog();
        }

        private void restorePictureBox_Click(object sender, EventArgs e)
        {
            Close();
            m_MainForm.Restore();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            accessibilityPictureBox.Image = Core.IsAccessible ? Properties.Resources.accessible_16x16 : Properties.Resources.notaccessible_16x16;
            accessibilityLabel.Text = Core.IsAccessible ? Properties.Resources.InOutConnectionEstablished : Properties.Resources.NoConnectionEstablished;
            connectionsLabel.Text = string.Format(Properties.Resources.Statistics_Connections, Core.Connections.Count);
            if (!Core.MinuteAverageDownloadStatistics.IsEmpty && !Core.AverageDownloadStatistics.IsEmpty)
                downstreamLabel.Text = m_MainForm.TransferVolumeToString(Core.MinuteAverageDownloadStatistics[0], Core.AverageDownloadStatistics[0]);
            if (!Core.MinuteAverageUploadStatistics.IsEmpty && !Core.AverageUploadStatistics.IsEmpty)
                upstreamLabel.Text = m_MainForm.TransferVolumeToString(Core.MinuteAverageUploadStatistics[0], Core.AverageUploadStatistics[0]);
            downstreamPictureBox.Image = m_MainForm.DownstreamImage;
            upstreamPictureBox.Image = m_MainForm.UpstreamImage;
            timer.Interval = 1000;
        }

        public QuickInformationDialog(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            InitializeComponent();
            m_MainForm = mainForm;
            Left = Screen.PrimaryScreen.Bounds.Width - (int)((float)Width * 1.25F);
            Top = Screen.PrimaryScreen.Bounds.Height - (int)((float)Height * 1.25F);
        }
    }
}