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
    internal sealed partial class PreferencesControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        private void autoMoveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoMoveCheckBox.Checked != bool.Parse(m_Settings["AutoMoveDownloads"]))
                m_Settings["AutoMoveDownloads"] = autoMoveCheckBox.Checked.ToString();
        }

        private void autoMoveNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (autoMoveNumericUpDown.Value.ToString() != m_Settings["AutoMoveDownloadsIntervall"] && autoMoveNumericUpDown.Value >= 60)
                m_Settings["AutoMoveDownloadsIntervall"] = autoMoveNumericUpDown.Value.ToString();
        }

        private void downloadCapacityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((uint)downloadCapacityNumericUpDown.Value / 8 * 1024 != int.Parse(m_Settings["DownloadCapacity"]))
                m_Settings["DownloadCapacity"] = ((uint)downloadCapacityNumericUpDown.Value / 8 * 1024).ToString();
        }

        private void downloadLimitNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((uint)downloadLimitNumericUpDown.Value / 8 * 1024 != int.Parse(m_Settings["DownloadLimit"]))
                m_Settings["DownloadLimit"] = ((uint)downloadLimitNumericUpDown.Value / 8 * 1024).ToString();
        }

        private void eigthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "8")
                m_Settings["AverageConnectionsCount"] = "8";
        }

        private void enableDownloadLimitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            downloadLimitNumericUpDown.Enabled = enableDownloadLimitCheckBox.Checked;
            if (enableDownloadLimitCheckBox.Checked != bool.Parse(m_Settings["HasDownloadLimit"]))
                m_Settings["HasDownloadLimit"] = enableDownloadLimitCheckBox.Checked.ToString();

            if (bool.Parse(m_Settings["HasDownloadLimit"]))
                m_MainForm.DownstreamImage = Properties.Resources.downstream_limited_16x16;
            else
                m_MainForm.DownstreamImage = Properties.Resources.downstream_16x16;
        }

        private void enableUploadLimitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            uploadLimitNumericUpDown.Enabled = enableUploadLimitCheckBox.Checked;
            if (enableUploadLimitCheckBox.Checked != bool.Parse(m_Settings["HasUploadLimit"]))
                m_Settings["HasUploadLimit"] = enableUploadLimitCheckBox.Checked.ToString();

            if (bool.Parse(m_Settings["HasUploadLimit"]))
                m_MainForm.UpstreamImage = Properties.Resources.upstream_limited_16x16;
            else
                m_MainForm.UpstreamImage = Properties.Resources.upstream_16x16;
        }

        private void fiveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "5")
                m_Settings["AverageConnectionsCount"] = "5";
        }

        private void fourRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "4")
                m_Settings["AverageConnectionsCount"] = "4";
        }

        //2008-07-24 Nochbaer: BZ 45
        private void NewDownloadsToBeginngingOfQueueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NewDownloadsToBeginngingOfQueueCheckBox.Checked != bool.Parse(m_Settings["NewDownloadsToBeginngingOfQueue"]))
                m_Settings["NewDownloadsToBeginngingOfQueue"] = NewDownloadsToBeginngingOfQueueCheckBox.Checked.ToString();
        }

        private void nineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "9")
                m_Settings["AverageConnectionsCount"] = "9";
        }

        private void oneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "1")
                m_Settings["AverageConnectionsCount"] = "1";
        }

        private void portNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (portNumericUpDown.Value != int.Parse(m_Settings["Port"]))
                m_Settings["Port"] = portNumericUpDown.Value.ToString();
        }

        private void progressBarsHaveShadowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            progressBarsShadowNumericUpDown.Enabled = progressBarsHaveShadowCheckBox.Checked;
            if (progressBarsHaveShadowCheckBox.Checked != bool.Parse(m_Settings["ProgressBarsHaveShadow"]))
                m_Settings["ProgressBarsHaveShadow"] = progressBarsHaveShadowCheckBox.Checked.ToString();
        }

        private void progressBarsShadowNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (progressBarsShadowNumericUpDown.Value != decimal.Parse(m_Settings["ProgressBarsShadow"]))
                m_Settings["ProgressBarsShadow"] = progressBarsShadowNumericUpDown.Value.ToString();
        }

        private void progressBarsShowPercentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (progressBarsShowPercentCheckBox.Checked != bool.Parse(m_Settings["ProgressBarsShowPercent"]))
                m_Settings["ProgressBarsShowPercent"] = progressBarsShowPercentCheckBox.Checked.ToString();
        }

        private void sevenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "7")
                m_Settings["AverageConnectionsCount"] = "7";
        }

        private void showMessageBoxesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showMessageBoxesCheckBox.Checked != bool.Parse(m_Settings["ShowMessageBoxes"]))
                m_Settings["ShowMessageBoxes"] = showMessageBoxesCheckBox.Checked.ToString();
        }

        private void showPercentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (progressBarsShowPercentCheckBox.Checked != bool.Parse(m_Settings["ProgressBarsShowPercent"]))
                m_Settings["ProgressBarsShowPercent"] = progressBarsShowPercentCheckBox.Checked.ToString();
        }

        private void sixRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "6")
                m_Settings["AverageConnectionsCount"] = "6";
        }

        private void synchronizeWebCachesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (synchronizeWebCachesCheckBox.Checked != bool.Parse(m_Settings["SynchronizeWebCaches"]))
                m_Settings["SynchronizeWebCaches"] = synchronizeWebCachesCheckBox.Checked.ToString();
        }

        //2008-03-13 Nochbaer
        private void SubFolderForCollectionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SubFolderForCollectionsCheckBox.Checked != bool.Parse(m_Settings["SubFoldersForCollections"]))
                m_Settings["SubFoldersForCollections"] = SubFolderForCollectionsCheckBox.Checked.ToString();
        }

        //2008-07-22 Nochbaer
        private void startInTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startInTrayCheckBox.Checked != bool.Parse(m_Settings["StartInTray"]))
                m_Settings["StartInTray"] = startInTrayCheckBox.Checked.ToString();

        }

        private void tenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "10")
                m_Settings["AverageConnectionsCount"] = "10";
        }

        private void threeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "3")
                m_Settings["AverageConnectionsCount"] = "3";
        }

        private void twoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Settings["AverageConnectionsCount"] != "2")
                m_Settings["AverageConnectionsCount"] = "2";
        }

        private void uploadCapacityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((uint)uploadCapacityNumericUpDown.Value / 8 * 1024 != int.Parse(m_Settings["UploadCapacity"]))
                m_Settings["UploadCapacity"] = ((uint)uploadCapacityNumericUpDown.Value / 8 * 1024).ToString();
        }

        private void uploadLimitNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if ((uint)uploadLimitNumericUpDown.Value / 8 * 1024 != int.Parse(m_Settings["UploadLimit"]))
                m_Settings["UploadLimit"] = ((uint)uploadLimitNumericUpDown.Value / 8 * 1024).ToString();
        }

        private void useBytesInsteadOfBitsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useBytesInsteadOfBitsCheckBox.Checked != bool.Parse(m_Settings["UseBytesInsteadOfBits"]))
                m_Settings["UseBytesInsteadOfBits"] = useBytesInsteadOfBitsCheckBox.Checked.ToString();
        }

        //2008-03-13 Nochbaer
        private void ParseCollectionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ParseCollectionsCheckBox.Checked != bool.Parse(m_Settings["ParseCollections"]))
                m_Settings["ParseCollections"] = ParseCollectionsCheckBox.Checked.ToString();
        }

        public PreferencesControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            InitializeComponent();
            m_MainForm = mainForm;
            if (int.Parse(m_Settings["Port"]) < portNumericUpDown.Minimum)
                m_Settings["Port"] = portNumericUpDown.Minimum.ToString();
            if (int.Parse(m_Settings["Port"]) > portNumericUpDown.Maximum)
                m_Settings["Port"] = portNumericUpDown.Maximum.ToString();
            portNumericUpDown.Value = decimal.Parse(m_Settings["Port"]);
            if (int.Parse(m_Settings["AverageConnectionsCount"]) < 2)
                oneRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 3)
                twoRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 4)
                threeRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 5)
                fourRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 6)
                fiveRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 7)
                sixRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 8)
                sevenRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 9)
                eigthRadioButton.Checked = true;
            else if (int.Parse(m_Settings["AverageConnectionsCount"]) < 10)
                nineRadioButton.Checked = true;
            else
                tenRadioButton.Checked = true;
            int downloadCapacity = int.Parse(m_Settings["DownloadCapacity"]) * 8 / 1024;
            if (downloadCapacity < downloadCapacityNumericUpDown.Minimum)
                downloadCapacity = (int)downloadCapacityNumericUpDown.Minimum;
            if (downloadCapacity > downloadCapacityNumericUpDown.Maximum)
                downloadCapacity = (int)downloadCapacityNumericUpDown.Maximum;
            downloadCapacityNumericUpDown.Value = downloadCapacity;
            int uploadCapacity = int.Parse(m_Settings["UploadCapacity"]) * 8 / 1024;
            if (uploadCapacity < uploadCapacityNumericUpDown.Minimum)
                uploadCapacity = (int)uploadCapacityNumericUpDown.Minimum;
            if (uploadCapacity > uploadCapacityNumericUpDown.Maximum)
                uploadCapacity = (int)uploadCapacityNumericUpDown.Maximum;
            uploadCapacityNumericUpDown.Value = uploadCapacity;
            enableDownloadLimitCheckBox.Checked = bool.Parse(m_Settings["HasDownloadLimit"]);
            int downloadLimit = int.Parse(m_Settings["DownloadLimit"]) * 8 / 1024;
            if (downloadLimit < downloadLimitNumericUpDown.Minimum)
                downloadLimit = (int)downloadLimitNumericUpDown.Minimum;
            if (downloadLimit > downloadLimitNumericUpDown.Maximum)
                downloadLimit = (int)downloadLimitNumericUpDown.Maximum;
            downloadLimitNumericUpDown.Value = downloadLimit;
            enableUploadLimitCheckBox.Checked = bool.Parse(m_Settings["HasUploadLimit"]);
            int uploadLimit = int.Parse(m_Settings["UploadLimit"]) * 8 / 1024;
            if (uploadLimit < uploadLimitNumericUpDown.Minimum)
                uploadLimit = (int)uploadLimitNumericUpDown.Minimum;
            if (uploadLimit > uploadLimitNumericUpDown.Maximum)
                uploadLimit = (int)uploadLimitNumericUpDown.Maximum;
            uploadLimitNumericUpDown.Value = uploadLimit;
            //2008-07-24 Nochbaer: BZ 45
            NewDownloadsToBeginngingOfQueueCheckBox.Checked = bool.Parse(m_Settings["NewDownloadsToBeginngingOfQueue"]);
            progressBarsHaveShadowCheckBox.Checked = bool.Parse(m_Settings["ProgressBarsHaveShadow"]);
            if (int.Parse(m_Settings["ProgressBarsShadow"]) < progressBarsShadowNumericUpDown.Minimum)
                m_Settings["ProgressBarsShadow"] = progressBarsShadowNumericUpDown.Minimum.ToString();
            if (int.Parse(m_Settings["ProgressBarsShadow"]) > progressBarsShadowNumericUpDown.Maximum)
                m_Settings["ProgressBarsShadow"] = progressBarsShadowNumericUpDown.Maximum.ToString();
            progressBarsShadowNumericUpDown.Value = decimal.Parse(m_Settings["ProgressBarsShadow"]);
            progressBarsShowPercentCheckBox.Checked = bool.Parse(m_Settings["ProgressBarsShowPercent"]);
            synchronizeWebCachesCheckBox.Checked = bool.Parse(m_Settings["SynchronizeWebCaches"]);
            showMessageBoxesCheckBox.Checked = bool.Parse(m_Settings["ShowMessageBoxes"]);
            useBytesInsteadOfBitsCheckBox.Checked = bool.Parse(m_Settings["UseBytesInsteadOfBits"]);
            //2008-03-13 Nochbaer
            SubFolderForCollectionsCheckBox.Checked = bool.Parse(m_Settings["SubFoldersForCollections"]);
            //2008-07-22 Nochbaer
            startInTrayCheckBox.Checked = bool.Parse(m_Settings["StartInTray"]);
            ParseCollectionsCheckBox.Checked = bool.Parse(m_Settings["ParseCollections"]);
            autoMoveCheckBox.Checked = bool.Parse(m_Settings["AutoMoveDownloads"]);
            autoMoveNumericUpDown.Value = Int32.Parse(m_Settings["AutoMoveDownloadsIntervall"]);
        }

        //2008-08-14 Nochbaer BZ 46
        private void portTestButton_Click(object sender, EventArgs e)
        {
            ProcessStarter.startProcess(Properties.Resources.PortTestUrl + portNumericUpDown.Value.ToString());
        }

        private void ResetTrayBehaviorButton_Click(object sender, EventArgs e)
        {
            m_Settings["UserWasAsked"] = false.ToString();
        }
    }
}