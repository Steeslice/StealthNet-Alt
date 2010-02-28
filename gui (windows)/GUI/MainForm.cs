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
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class MainForm
        : Form
    {
        private static Logger m_Logger = Logger.Instance;

        private ConnectionsControl m_ConnectionsControl;

        private DownloadsControl m_DownloadsControl;

        private bool m_IsInTray = false;

        private bool m_IsStarting = false;

        private QuickInformationDialog m_QuickInformationDialog = null;

        private SearchControl m_SearchControl;

        private SharedFilesControl m_SharedFilesControl;

        private ICoreSettings m_Settings = Settings.Instance;

        private StatisticsControl m_StatisticsControl;

        private UploadsControl m_UploadsControl;

        public Image UpstreamImage
        {
            set
            {
                if (value != null)
                    upstreamToolStripStatusLabel.Image = value;
            }
            get
            {
                return upstreamToolStripStatusLabel.Image;
            }
        }

        public Image DownstreamImage
        {
            set
            {
                if (value != null)
                    downstreamToolStripStatusLabel.Image = value;
            }
            get
            {
                return downstreamToolStripStatusLabel.Image;
            }
        }

        public Control ActiveTab
        {
            get
            {
                return toolStripContainer.ContentPanel.Controls.Count > 0 ? toolStripContainer.ContentPanel.Controls[0] : null;
            }
        }

        public bool IsInTray
        {
            get
            {
                return m_IsInTray;
            }
        }

        private void closeRShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void connectionsToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["MainFormLastTab"] = "0";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is ConnectionsControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_ConnectionsControl);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
                m_ConnectionsControl.Focus();
            }
        }

        private void downloadsToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["MainFormLastTab"] = "2";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is DownloadsControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_DownloadsControl);
                m_DownloadsControl.Focus();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Settings["FirstStart"] = "False";
            m_Settings["MainFormLocationX"] = Location.X.ToString();
            m_Settings["MainFormLocationY"] = Location.Y.ToString();
            m_Settings["MainFormSizeWidth"] = Size.Width.ToString();
            m_Settings["MainFormSizeHeight"] = Size.Height.ToString();
            m_Settings["MainFormWindowState"] = WindowState.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !m_IsInTray)
            {
                bool closeToTray = false;
                if (bool.Parse(m_Settings["UserWasAsked"]))
                    closeToTray = bool.Parse(m_Settings["AlwaysCloseToTray"]);
                else
                {
                    CloseToTrayDialog closeToTrayDialog = new CloseToTrayDialog();
                    switch (closeToTrayDialog.ShowDialog(this))
                    {
                        case DialogResult.Yes:
                            closeToTray = true;
                            if (closeToTrayDialog.SaveTheAnswer)
                            {
                                m_Settings["UserWasAsked"] = "True";
                                m_Settings["AlwaysCloseToTray"] = "True";
                            }
                            break;
                        case DialogResult.No:
                            closeToTray = false;
                            if (closeToTrayDialog.SaveTheAnswer)
                            {
                                m_Settings["UserWasAsked"] = "True";
                                m_Settings["AlwaysCloseToTray"] = "False";
                            }
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                    closeToTrayDialog.Dispose();
                }
                if (closeToTray)
                {
                    e.Cancel = true;
                    ShowInTray();
                }
                else if (e.Cancel == true || bool.Parse(m_Settings["ShowMessageBoxes"]) && MessageBox.Show(this, Properties.Resources.GoingToClose, String.Format(Constants.Software, Core.Version), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    e.Cancel = true;
            }
            else if (e.CloseReason == CloseReason.UserClosing && bool.Parse(m_Settings["ShowMessageBoxes"]) && MessageBox.Show(this, Properties.Resources.GoingToClose, String.Format(Constants.Software, Core.Version), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!bool.Parse(m_Settings["FirstStart"]))
            {
                switch (m_Settings["MainFormWindowState"])
                {
                    case "Normal":
                        Location = new Point(int.Parse(m_Settings["MainFormLocationX"]), int.Parse(m_Settings["MainFormLocationY"]));
                        Size = new Size(int.Parse(m_Settings["MainFormSizeWidth"]), int.Parse(m_Settings["MainFormSizeHeight"]));
                        break;
                    case "Maximized":
                        WindowState = FormWindowState.Maximized;
                        break;
                    case "Minimized":
                        WindowState = FormWindowState.Minimized;
                        break;
                }
            }
            if (bool.Parse(m_Settings["ShowMessageBoxes"]) && Core.IsUpdateAvailable)
            {
                if (MessageBox.Show(this, Properties.Resources.NewVersionMessage.Replace(@"\n", "\n"), String.Format(Constants.Software, Core.Version), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    ProcessStarter.startProcess(Properties.Resources.NewVersionDownloadLink);
            }
            if (bool.Parse(m_Settings["HasDownloadLimit"]))
                DownstreamImage = Properties.Resources.downstream_limited_16x16;
            else
                DownstreamImage = Properties.Resources.downstream_16x16;

            if (bool.Parse(m_Settings["HasUploadLimit"]))
                UpstreamImage = Properties.Resources.upstream_limited_16x16;
            else
                UpstreamImage = Properties.Resources.upstream_16x16;
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            //2008-07-22 Nochbaer: BZ53
            if (m_IsStarting)
            {
                if (bool.Parse(m_Settings["StartInTray"]))
                {
                    ShowInTray();
                }
            }
        }

        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (m_QuickInformationDialog == null || m_QuickInformationDialog.IsDisposed)
                {
                    m_QuickInformationDialog = new QuickInformationDialog(this);
                    m_QuickInformationDialog.Show();
                }
                else
                    m_QuickInformationDialog.Activate();
            }
            else if (e.Clicks == 2)
            {
                if (m_QuickInformationDialog != null)
                    m_QuickInformationDialog.Close();
                showRShareToolStripMenuItem.PerformClick();
            }
        }

        private void preferencesToolStripButton_Click(object sender, EventArgs e)
        {
            PreferencesDialog preferencesDialog = new PreferencesDialog(this);
            preferencesDialog.ShowDialog(this);
            preferencesDialog.Dispose();
            try
            {
                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                m_Logger.Log(ex, "An exception was thrown while saving changed settings!");
            }
        }

        public void Restore()
        {
            showRShareToolStripMenuItem.PerformClick();
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["MainFormLastTab"] = "1";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is SearchControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_SearchControl);
                m_SearchControl.Focus();
            }
        }

        //2008-07-22 Nochbaer: BZ53
        public void SetStart()
        {
            m_IsStarting = true;
        }

        private void sharedFilesToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["MainFormLastTab"] = "4";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is SharedFilesControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_SharedFilesControl);
                m_SharedFilesControl.Focus();
            }
        }

        //2008-07-22 Nochbaer
        public void ShowInTray()
        {
            Hide();
            notifyIcon.Visible = true;
            m_IsInTray = true;
        }

        public void ShowPreferencesDialog()
        {
            preferencesToolStripButton.PerformClick();
        }

        private void showRShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //2008-07-22 Nochbaer: BZ 53
            m_IsStarting = false;
            notifyIcon.Visible = false;
            Show();
            Activate();
            m_IsInTray = false;
        }

        private void statisticsToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["MainFormLastTab"] = "5";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is StatisticsControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_StatisticsControl);
                m_StatisticsControl.Focus();
            }
        }

        public string TransferVolumeToString(int minuteAverage, int average)
        {
            if (minuteAverage < 0)
                throw new ArgumentOutOfRangeException("minuteAverage");
            if (average < 0)
                throw new ArgumentOutOfRangeException("average");

            float minuteAverageSingle = (float)minuteAverage;
            string minuteAverageString;
            if (bool.Parse(m_Settings["UseBytesInsteadOfBits"]))
                if (minuteAverageSingle <= 1024)
                    minuteAverageString = string.Format("{0:F0} B", minuteAverageSingle);
                else if (minuteAverageSingle <= 1048576)
                    minuteAverageString = string.Format("{0:F1} KiB", minuteAverageSingle / 1024);
                else if (minuteAverageSingle <= 1073741824)
                    minuteAverageString = string.Format("{0:F1} MiB", minuteAverageSingle / 1048576);
                else
                    minuteAverageString = string.Format("{0:F1} GiB", minuteAverageSingle / 1073741824);
            else
            {
                minuteAverageSingle *= 8;
                if (minuteAverageSingle <= 1024)
                    minuteAverageString = string.Format("{0:F0} b", minuteAverageSingle);
                else if (minuteAverageSingle <= 1048576)
                    minuteAverageString = string.Format("{0:F1} Kib", minuteAverageSingle / 1024);
                else if (minuteAverageSingle <= 1073741824)
                    minuteAverageString = string.Format("{0:F1} Mib", minuteAverageSingle / 1048576);
                else
                    minuteAverageString = string.Format("{0:F1} Gib", minuteAverageSingle / 1073741824);
            }
            float averageSingle = (float)average;
            string averageString;
            if (bool.Parse(m_Settings["UseBytesInsteadOfBits"]))
                if (averageSingle <= 1024)
                    averageString = string.Format("{0:F0} B", averageSingle);
                else if (averageSingle <= 1048576)
                    averageString = string.Format("{0:F1} KiB", averageSingle / 1024);
                else if (averageSingle <= 1073741824)
                    averageString = string.Format("{0:F1} MiB", averageSingle / 1048576);
                else
                    averageString = string.Format("{0:F1} GiB", averageSingle / 1073741824);
            else
            {
                averageSingle *= 8;
                if (averageSingle <= 1024)
                    averageString = string.Format("{0:F0} b", averageSingle);
                else if (averageSingle <= 1048576)
                    averageString = string.Format("{0:F1} Kib", averageSingle / 1024);
                else if (averageSingle <= 1073741824)
                    averageString = string.Format("{0:F1} Mib", averageSingle / 1048576);
                else
                    averageString = string.Format("{0:F1} Gib", averageSingle / 1073741824);
            }
            return string.Format("{0} ({1})", minuteAverageString, averageString);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 2008-06-29 T.Norad BZ42 Stop the timer if it is currently running to
                // prevent double run. This can happend when the interval has a great value
                // the timer run this method and set the value to a small interval
                ((System.Windows.Forms.Timer)sender).Stop();

                if (m_Logger.LastLogEntry != null)
                    logToolStripStatusLabel.Text = string.Format("{0:t} {1}", m_Logger.LastLogEntry.TimeStamp, m_Logger.LastLogEntry.Text);
                if (!Core.MinuteAverageDownloadStatistics.IsEmpty && !Core.AverageDownloadStatistics.IsEmpty)
                    downstreamToolStripStatusLabel.Text = TransferVolumeToString(Core.MinuteAverageDownloadStatistics[0], Core.AverageDownloadStatistics[0]);
                if (!Core.MinuteAverageUploadStatistics.IsEmpty && !Core.AverageUploadStatistics.IsEmpty)
                    upstreamToolStripStatusLabel.Text = TransferVolumeToString(Core.MinuteAverageUploadStatistics[0], Core.AverageUploadStatistics[0]);
                connectionsCountToolStripStatusLabel.Text = Core.Connections.Count.ToString();

                //2008-03-09 T.Norad: translation added
                if (Core.IsAccessible)
                {
                    accessibilityToolStripStatusLabel.Image = Properties.Resources.accessible_16x16;
                    accessibilityToolStripStatusLabel.ToolTipText = Properties.Resources.InOutConnectionEstablished;
                }
                else if (Core.IsWorldReachable)
                {
                    accessibilityToolStripStatusLabel.Image = Properties.Resources.worldaccessible_16x16;
                    accessibilityToolStripStatusLabel.ToolTipText = Properties.Resources.OutConnectionEstablished;
                }
                else
                {
                    accessibilityToolStripStatusLabel.Image = Properties.Resources.notaccessible_16x16;
                    accessibilityToolStripStatusLabel.ToolTipText = Properties.Resources.NoConnectionEstablished;
                }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }

        private void uploadsToolStripButton_Click(object sender, EventArgs e)
        {
            m_Settings["MainFormLastTab"] = "3";
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is UploadsControl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_UploadsControl);
                m_UploadsControl.Focus();
            }
        }

        public MainForm()
        {
            SetUILanguage();
            InitializeComponent();

            Text = string.Format(Text, String.Format(Constants.Software, Core.Version));
            notifyIcon.Icon = Icon;
            notifyIcon.Text = Text;

            m_ConnectionsControl = new ConnectionsControl(this);
            m_ConnectionsControl.Dock = DockStyle.Fill;
            m_SearchControl = new SearchControl(this);
            m_SearchControl.Dock = DockStyle.Fill;
            m_DownloadsControl = new DownloadsControl(this);
            m_DownloadsControl.Dock = DockStyle.Fill;
            m_UploadsControl = new UploadsControl(this);
            m_UploadsControl.Dock = DockStyle.Fill;
            m_SharedFilesControl = new SharedFilesControl(this);
            m_SharedFilesControl.Dock = DockStyle.Fill;
            m_StatisticsControl = new StatisticsControl(this);
            m_StatisticsControl.Dock = DockStyle.Fill;
            switch (m_Settings["MainFormLastTab"])
            {
                case "1":
                    searchToolStripButton.PerformClick();
                    break;
                case "2":
                    downloadsToolStripButton.PerformClick();
                    break;
                case "3":
                    uploadsToolStripButton.PerformClick();
                    break;
                case "4":
                    sharedFilesToolStripButton.PerformClick();
                    break;
                case "5":
                    statisticsToolStripButton.PerformClick();
                    break;
                default:
                    connectionsToolStripButton.PerformClick();
                    break;
            }
        }

        public static string GetUILanguage()
        {
            string UILanguage = Settings.Instance["UICulture"];
            return (UILanguage);
        }

        public static void SetUILanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Instance["UICulture"]);
        }

        /// <summary>
        /// override the method to handle adding stealthnet links to downloads. 
        /// the message is send by the class program.cs 
        /// </summary>
        /// <param name="m">recieved message</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // respond only to the copydata message
                case Win32APIWrapper.WM_COPYDATA:
                    Win32APIWrapper.CopyDataStruct st = (Win32APIWrapper.CopyDataStruct)Marshal.PtrToStructure(m.LParam, typeof(Win32APIWrapper.CopyDataStruct));
                    string strData = Marshal.PtrToStringUni(st.lpData);
                    try
                    {
                        if (strData.EndsWith(".sncollection"))
                        {
                            Core.ParseStealthNetCollection(strData);
                        }
                        else
                        {
                            StealthNetLink stealthNetLink = new StealthNetLink(strData);
                            Core.AddDownload(stealthNetLink.FileHash, stealthNetLink.FileName, stealthNetLink.FileSize, null);
                        }
                    }
                    catch
                    {
                        // ignore invalid links
                    }
                    break;
                default:
                    // let the base class deal with it
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}