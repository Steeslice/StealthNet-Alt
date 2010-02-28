//RShare
//Copyright (C) 2009 Lars Regensburger

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

namespace Regensburger.RShare
{
    partial class PreferencesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesControl));
            this.portGroupBox = new System.Windows.Forms.GroupBox();
            this.portTestButton = new System.Windows.Forms.Button();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.miscOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ResetTrayBehaviorButton = new System.Windows.Forms.Button();
            this.NewDownloadsToBeginngingOfQueueCheckBox = new System.Windows.Forms.CheckBox();
            this.startInTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.autoMoveLabel = new System.Windows.Forms.Label();
            this.autoMoveNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.autoMoveCheckBox = new System.Windows.Forms.CheckBox();
            this.SubFolderForCollectionsCheckBox = new System.Windows.Forms.CheckBox();
            this.ParseCollectionsCheckBox = new System.Windows.Forms.CheckBox();
            this.synchronizeWebCachesCheckBox = new System.Windows.Forms.CheckBox();
            this.useBytesInsteadOfBitsCheckBox = new System.Windows.Forms.CheckBox();
            this.showMessageBoxesCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBarsShowPercentCheckBox = new System.Windows.Forms.CheckBox();
            this.averageConnectionsCountGroupBox = new System.Windows.Forms.GroupBox();
            this.oneRadioButton = new System.Windows.Forms.RadioButton();
            this.tenRadioButton = new System.Windows.Forms.RadioButton();
            this.nineRadioButton = new System.Windows.Forms.RadioButton();
            this.eigthRadioButton = new System.Windows.Forms.RadioButton();
            this.sevenRadioButton = new System.Windows.Forms.RadioButton();
            this.sixRadioButton = new System.Windows.Forms.RadioButton();
            this.fiveRadioButton = new System.Windows.Forms.RadioButton();
            this.fourRadioButton = new System.Windows.Forms.RadioButton();
            this.threeRadioButton = new System.Windows.Forms.RadioButton();
            this.twoRadioButton = new System.Windows.Forms.RadioButton();
            this.uploadCapacityGroupBox = new System.Windows.Forms.GroupBox();
            this.uploadCapacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.downloadCapacityGroupBox = new System.Windows.Forms.GroupBox();
            this.downloadCapacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressBarsGroupBox = new System.Windows.Forms.GroupBox();
            this.progressBarsHaveShadowCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBarsShadowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uploadLimitGroupBox = new System.Windows.Forms.GroupBox();
            this.enableUploadLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.uploadLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.downloadLimitGroupBox = new System.Windows.Forms.GroupBox();
            this.enableDownloadLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.portGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.miscOptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoMoveNumericUpDown)).BeginInit();
            this.averageConnectionsCountGroupBox.SuspendLayout();
            this.uploadCapacityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadCapacityNumericUpDown)).BeginInit();
            this.downloadCapacityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadCapacityNumericUpDown)).BeginInit();
            this.progressBarsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarsShadowNumericUpDown)).BeginInit();
            this.uploadLimitGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadLimitNumericUpDown)).BeginInit();
            this.downloadLimitGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // portGroupBox
            // 
            this.portGroupBox.AccessibleDescription = null;
            this.portGroupBox.AccessibleName = null;
            resources.ApplyResources(this.portGroupBox, "portGroupBox");
            this.portGroupBox.BackgroundImage = null;
            this.portGroupBox.Controls.Add(this.portTestButton);
            this.portGroupBox.Controls.Add(this.portNumericUpDown);
            this.portGroupBox.Font = null;
            this.portGroupBox.Name = "portGroupBox";
            this.portGroupBox.TabStop = false;
            // 
            // portTestButton
            // 
            this.portTestButton.AccessibleDescription = null;
            this.portTestButton.AccessibleName = null;
            resources.ApplyResources(this.portTestButton, "portTestButton");
            this.portTestButton.BackgroundImage = null;
            this.portTestButton.Font = null;
            this.portTestButton.Name = "portTestButton";
            this.portTestButton.UseVisualStyleBackColor = true;
            this.portTestButton.Click += new System.EventHandler(this.portTestButton_Click);
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.AccessibleDescription = null;
            this.portNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.portNumericUpDown, "portNumericUpDown");
            this.portNumericUpDown.Font = null;
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDown.ValueChanged += new System.EventHandler(this.portNumericUpDown_ValueChanged);
            // 
            // miscOptionsGroupBox
            // 
            this.miscOptionsGroupBox.AccessibleDescription = null;
            this.miscOptionsGroupBox.AccessibleName = null;
            resources.ApplyResources(this.miscOptionsGroupBox, "miscOptionsGroupBox");
            this.miscOptionsGroupBox.BackgroundImage = null;
            this.miscOptionsGroupBox.Controls.Add(this.ResetTrayBehaviorButton);
            this.miscOptionsGroupBox.Controls.Add(this.NewDownloadsToBeginngingOfQueueCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.startInTrayCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.autoMoveLabel);
            this.miscOptionsGroupBox.Controls.Add(this.autoMoveNumericUpDown);
            this.miscOptionsGroupBox.Controls.Add(this.autoMoveCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.SubFolderForCollectionsCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.ParseCollectionsCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.synchronizeWebCachesCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.useBytesInsteadOfBitsCheckBox);
            this.miscOptionsGroupBox.Controls.Add(this.showMessageBoxesCheckBox);
            this.miscOptionsGroupBox.Font = null;
            this.miscOptionsGroupBox.Name = "miscOptionsGroupBox";
            this.miscOptionsGroupBox.TabStop = false;
            // 
            // ResetTrayBehaviorButton
            // 
            this.ResetTrayBehaviorButton.AccessibleDescription = null;
            this.ResetTrayBehaviorButton.AccessibleName = null;
            resources.ApplyResources(this.ResetTrayBehaviorButton, "ResetTrayBehaviorButton");
            this.ResetTrayBehaviorButton.BackgroundImage = null;
            this.ResetTrayBehaviorButton.Font = null;
            this.ResetTrayBehaviorButton.Name = "ResetTrayBehaviorButton";
            this.ResetTrayBehaviorButton.UseVisualStyleBackColor = true;
            this.ResetTrayBehaviorButton.Click += new System.EventHandler(this.ResetTrayBehaviorButton_Click);
            // 
            // NewDownloadsToBeginngingOfQueueCheckBox
            // 
            this.NewDownloadsToBeginngingOfQueueCheckBox.AccessibleDescription = null;
            this.NewDownloadsToBeginngingOfQueueCheckBox.AccessibleName = null;
            resources.ApplyResources(this.NewDownloadsToBeginngingOfQueueCheckBox, "NewDownloadsToBeginngingOfQueueCheckBox");
            this.NewDownloadsToBeginngingOfQueueCheckBox.BackgroundImage = null;
            this.NewDownloadsToBeginngingOfQueueCheckBox.Font = null;
            this.NewDownloadsToBeginngingOfQueueCheckBox.Name = "NewDownloadsToBeginngingOfQueueCheckBox";
            this.NewDownloadsToBeginngingOfQueueCheckBox.UseVisualStyleBackColor = true;
            this.NewDownloadsToBeginngingOfQueueCheckBox.CheckedChanged += new System.EventHandler(this.NewDownloadsToBeginngingOfQueueCheckBox_CheckedChanged);
            // 
            // startInTrayCheckBox
            // 
            this.startInTrayCheckBox.AccessibleDescription = null;
            this.startInTrayCheckBox.AccessibleName = null;
            resources.ApplyResources(this.startInTrayCheckBox, "startInTrayCheckBox");
            this.startInTrayCheckBox.BackgroundImage = null;
            this.startInTrayCheckBox.Font = null;
            this.startInTrayCheckBox.Name = "startInTrayCheckBox";
            this.startInTrayCheckBox.UseVisualStyleBackColor = true;
            this.startInTrayCheckBox.CheckedChanged += new System.EventHandler(this.startInTrayCheckBox_CheckedChanged);
            // 
            // autoMoveLabel
            // 
            this.autoMoveLabel.AccessibleDescription = null;
            this.autoMoveLabel.AccessibleName = null;
            resources.ApplyResources(this.autoMoveLabel, "autoMoveLabel");
            this.autoMoveLabel.Font = null;
            this.autoMoveLabel.Name = "autoMoveLabel";
            // 
            // autoMoveNumericUpDown
            // 
            this.autoMoveNumericUpDown.AccessibleDescription = null;
            this.autoMoveNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.autoMoveNumericUpDown, "autoMoveNumericUpDown");
            this.autoMoveNumericUpDown.Font = null;
            this.autoMoveNumericUpDown.Maximum = new decimal(new int[] {
            960,
            0,
            0,
            0});
            this.autoMoveNumericUpDown.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.autoMoveNumericUpDown.Name = "autoMoveNumericUpDown";
            this.autoMoveNumericUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.autoMoveNumericUpDown.ValueChanged += new System.EventHandler(this.autoMoveNumericUpDown_ValueChanged);
            // 
            // autoMoveCheckBox
            // 
            this.autoMoveCheckBox.AccessibleDescription = null;
            this.autoMoveCheckBox.AccessibleName = null;
            resources.ApplyResources(this.autoMoveCheckBox, "autoMoveCheckBox");
            this.autoMoveCheckBox.BackgroundImage = null;
            this.autoMoveCheckBox.Font = null;
            this.autoMoveCheckBox.Name = "autoMoveCheckBox";
            this.autoMoveCheckBox.UseVisualStyleBackColor = true;
            this.autoMoveCheckBox.CheckedChanged += new System.EventHandler(this.autoMoveCheckBox_CheckedChanged);
            // 
            // SubFolderForCollectionsCheckBox
            // 
            this.SubFolderForCollectionsCheckBox.AccessibleDescription = null;
            this.SubFolderForCollectionsCheckBox.AccessibleName = null;
            resources.ApplyResources(this.SubFolderForCollectionsCheckBox, "SubFolderForCollectionsCheckBox");
            this.SubFolderForCollectionsCheckBox.BackgroundImage = null;
            this.SubFolderForCollectionsCheckBox.Font = null;
            this.SubFolderForCollectionsCheckBox.Name = "SubFolderForCollectionsCheckBox";
            this.SubFolderForCollectionsCheckBox.UseVisualStyleBackColor = true;
            this.SubFolderForCollectionsCheckBox.CheckedChanged += new System.EventHandler(this.SubFolderForCollectionsCheckBox_CheckedChanged);
            // 
            // ParseCollectionsCheckBox
            // 
            this.ParseCollectionsCheckBox.AccessibleDescription = null;
            this.ParseCollectionsCheckBox.AccessibleName = null;
            resources.ApplyResources(this.ParseCollectionsCheckBox, "ParseCollectionsCheckBox");
            this.ParseCollectionsCheckBox.BackgroundImage = null;
            this.ParseCollectionsCheckBox.Font = null;
            this.ParseCollectionsCheckBox.Name = "ParseCollectionsCheckBox";
            this.ParseCollectionsCheckBox.UseVisualStyleBackColor = true;
            this.ParseCollectionsCheckBox.CheckedChanged += new System.EventHandler(this.ParseCollectionsCheckBox_CheckedChanged);
            // 
            // synchronizeWebCachesCheckBox
            // 
            this.synchronizeWebCachesCheckBox.AccessibleDescription = null;
            this.synchronizeWebCachesCheckBox.AccessibleName = null;
            resources.ApplyResources(this.synchronizeWebCachesCheckBox, "synchronizeWebCachesCheckBox");
            this.synchronizeWebCachesCheckBox.BackgroundImage = null;
            this.synchronizeWebCachesCheckBox.Font = null;
            this.synchronizeWebCachesCheckBox.Name = "synchronizeWebCachesCheckBox";
            this.synchronizeWebCachesCheckBox.UseVisualStyleBackColor = true;
            this.synchronizeWebCachesCheckBox.CheckedChanged += new System.EventHandler(this.synchronizeWebCachesCheckBox_CheckedChanged);
            // 
            // useBytesInsteadOfBitsCheckBox
            // 
            this.useBytesInsteadOfBitsCheckBox.AccessibleDescription = null;
            this.useBytesInsteadOfBitsCheckBox.AccessibleName = null;
            resources.ApplyResources(this.useBytesInsteadOfBitsCheckBox, "useBytesInsteadOfBitsCheckBox");
            this.useBytesInsteadOfBitsCheckBox.BackgroundImage = null;
            this.useBytesInsteadOfBitsCheckBox.Font = null;
            this.useBytesInsteadOfBitsCheckBox.Name = "useBytesInsteadOfBitsCheckBox";
            this.useBytesInsteadOfBitsCheckBox.UseVisualStyleBackColor = true;
            this.useBytesInsteadOfBitsCheckBox.CheckedChanged += new System.EventHandler(this.useBytesInsteadOfBitsCheckBox_CheckedChanged);
            // 
            // showMessageBoxesCheckBox
            // 
            this.showMessageBoxesCheckBox.AccessibleDescription = null;
            this.showMessageBoxesCheckBox.AccessibleName = null;
            resources.ApplyResources(this.showMessageBoxesCheckBox, "showMessageBoxesCheckBox");
            this.showMessageBoxesCheckBox.BackgroundImage = null;
            this.showMessageBoxesCheckBox.Font = null;
            this.showMessageBoxesCheckBox.Name = "showMessageBoxesCheckBox";
            this.showMessageBoxesCheckBox.UseVisualStyleBackColor = true;
            this.showMessageBoxesCheckBox.CheckedChanged += new System.EventHandler(this.showMessageBoxesCheckBox_CheckedChanged);
            // 
            // progressBarsShowPercentCheckBox
            // 
            this.progressBarsShowPercentCheckBox.AccessibleDescription = null;
            this.progressBarsShowPercentCheckBox.AccessibleName = null;
            resources.ApplyResources(this.progressBarsShowPercentCheckBox, "progressBarsShowPercentCheckBox");
            this.progressBarsShowPercentCheckBox.BackgroundImage = null;
            this.progressBarsShowPercentCheckBox.Font = null;
            this.progressBarsShowPercentCheckBox.Name = "progressBarsShowPercentCheckBox";
            this.progressBarsShowPercentCheckBox.UseVisualStyleBackColor = true;
            this.progressBarsShowPercentCheckBox.CheckedChanged += new System.EventHandler(this.progressBarsShowPercentCheckBox_CheckedChanged);
            // 
            // averageConnectionsCountGroupBox
            // 
            this.averageConnectionsCountGroupBox.AccessibleDescription = null;
            this.averageConnectionsCountGroupBox.AccessibleName = null;
            resources.ApplyResources(this.averageConnectionsCountGroupBox, "averageConnectionsCountGroupBox");
            this.averageConnectionsCountGroupBox.BackgroundImage = null;
            this.averageConnectionsCountGroupBox.Controls.Add(this.oneRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.tenRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.nineRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.eigthRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.sevenRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.sixRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.fiveRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.fourRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.threeRadioButton);
            this.averageConnectionsCountGroupBox.Controls.Add(this.twoRadioButton);
            this.averageConnectionsCountGroupBox.Font = null;
            this.averageConnectionsCountGroupBox.Name = "averageConnectionsCountGroupBox";
            this.averageConnectionsCountGroupBox.TabStop = false;
            // 
            // oneRadioButton
            // 
            this.oneRadioButton.AccessibleDescription = null;
            this.oneRadioButton.AccessibleName = null;
            resources.ApplyResources(this.oneRadioButton, "oneRadioButton");
            this.oneRadioButton.BackgroundImage = null;
            this.oneRadioButton.Font = null;
            this.oneRadioButton.Name = "oneRadioButton";
            this.oneRadioButton.TabStop = true;
            this.oneRadioButton.UseVisualStyleBackColor = true;
            this.oneRadioButton.CheckedChanged += new System.EventHandler(this.oneRadioButton_CheckedChanged);
            // 
            // tenRadioButton
            // 
            this.tenRadioButton.AccessibleDescription = null;
            this.tenRadioButton.AccessibleName = null;
            resources.ApplyResources(this.tenRadioButton, "tenRadioButton");
            this.tenRadioButton.BackgroundImage = null;
            this.tenRadioButton.Font = null;
            this.tenRadioButton.Name = "tenRadioButton";
            this.tenRadioButton.TabStop = true;
            this.tenRadioButton.UseVisualStyleBackColor = true;
            this.tenRadioButton.CheckedChanged += new System.EventHandler(this.tenRadioButton_CheckedChanged);
            // 
            // nineRadioButton
            // 
            this.nineRadioButton.AccessibleDescription = null;
            this.nineRadioButton.AccessibleName = null;
            resources.ApplyResources(this.nineRadioButton, "nineRadioButton");
            this.nineRadioButton.BackgroundImage = null;
            this.nineRadioButton.Font = null;
            this.nineRadioButton.Name = "nineRadioButton";
            this.nineRadioButton.TabStop = true;
            this.nineRadioButton.UseVisualStyleBackColor = true;
            this.nineRadioButton.CheckedChanged += new System.EventHandler(this.nineRadioButton_CheckedChanged);
            // 
            // eigthRadioButton
            // 
            this.eigthRadioButton.AccessibleDescription = null;
            this.eigthRadioButton.AccessibleName = null;
            resources.ApplyResources(this.eigthRadioButton, "eigthRadioButton");
            this.eigthRadioButton.BackgroundImage = null;
            this.eigthRadioButton.Font = null;
            this.eigthRadioButton.Name = "eigthRadioButton";
            this.eigthRadioButton.TabStop = true;
            this.eigthRadioButton.UseVisualStyleBackColor = true;
            this.eigthRadioButton.CheckedChanged += new System.EventHandler(this.eigthRadioButton_CheckedChanged);
            // 
            // sevenRadioButton
            // 
            this.sevenRadioButton.AccessibleDescription = null;
            this.sevenRadioButton.AccessibleName = null;
            resources.ApplyResources(this.sevenRadioButton, "sevenRadioButton");
            this.sevenRadioButton.BackgroundImage = null;
            this.sevenRadioButton.Font = null;
            this.sevenRadioButton.Name = "sevenRadioButton";
            this.sevenRadioButton.TabStop = true;
            this.sevenRadioButton.UseVisualStyleBackColor = true;
            this.sevenRadioButton.CheckedChanged += new System.EventHandler(this.sevenRadioButton_CheckedChanged);
            // 
            // sixRadioButton
            // 
            this.sixRadioButton.AccessibleDescription = null;
            this.sixRadioButton.AccessibleName = null;
            resources.ApplyResources(this.sixRadioButton, "sixRadioButton");
            this.sixRadioButton.BackgroundImage = null;
            this.sixRadioButton.Font = null;
            this.sixRadioButton.Name = "sixRadioButton";
            this.sixRadioButton.TabStop = true;
            this.sixRadioButton.UseVisualStyleBackColor = true;
            this.sixRadioButton.CheckedChanged += new System.EventHandler(this.sixRadioButton_CheckedChanged);
            // 
            // fiveRadioButton
            // 
            this.fiveRadioButton.AccessibleDescription = null;
            this.fiveRadioButton.AccessibleName = null;
            resources.ApplyResources(this.fiveRadioButton, "fiveRadioButton");
            this.fiveRadioButton.BackgroundImage = null;
            this.fiveRadioButton.Font = null;
            this.fiveRadioButton.Name = "fiveRadioButton";
            this.fiveRadioButton.TabStop = true;
            this.fiveRadioButton.UseVisualStyleBackColor = true;
            this.fiveRadioButton.CheckedChanged += new System.EventHandler(this.fiveRadioButton_CheckedChanged);
            // 
            // fourRadioButton
            // 
            this.fourRadioButton.AccessibleDescription = null;
            this.fourRadioButton.AccessibleName = null;
            resources.ApplyResources(this.fourRadioButton, "fourRadioButton");
            this.fourRadioButton.BackgroundImage = null;
            this.fourRadioButton.Font = null;
            this.fourRadioButton.Name = "fourRadioButton";
            this.fourRadioButton.TabStop = true;
            this.fourRadioButton.UseVisualStyleBackColor = true;
            this.fourRadioButton.CheckedChanged += new System.EventHandler(this.fourRadioButton_CheckedChanged);
            // 
            // threeRadioButton
            // 
            this.threeRadioButton.AccessibleDescription = null;
            this.threeRadioButton.AccessibleName = null;
            resources.ApplyResources(this.threeRadioButton, "threeRadioButton");
            this.threeRadioButton.BackgroundImage = null;
            this.threeRadioButton.Font = null;
            this.threeRadioButton.Name = "threeRadioButton";
            this.threeRadioButton.TabStop = true;
            this.threeRadioButton.UseVisualStyleBackColor = true;
            this.threeRadioButton.CheckedChanged += new System.EventHandler(this.threeRadioButton_CheckedChanged);
            // 
            // twoRadioButton
            // 
            this.twoRadioButton.AccessibleDescription = null;
            this.twoRadioButton.AccessibleName = null;
            resources.ApplyResources(this.twoRadioButton, "twoRadioButton");
            this.twoRadioButton.BackgroundImage = null;
            this.twoRadioButton.Font = null;
            this.twoRadioButton.Name = "twoRadioButton";
            this.twoRadioButton.TabStop = true;
            this.twoRadioButton.UseVisualStyleBackColor = true;
            this.twoRadioButton.CheckedChanged += new System.EventHandler(this.twoRadioButton_CheckedChanged);
            // 
            // uploadCapacityGroupBox
            // 
            this.uploadCapacityGroupBox.AccessibleDescription = null;
            this.uploadCapacityGroupBox.AccessibleName = null;
            resources.ApplyResources(this.uploadCapacityGroupBox, "uploadCapacityGroupBox");
            this.uploadCapacityGroupBox.BackgroundImage = null;
            this.uploadCapacityGroupBox.Controls.Add(this.uploadCapacityNumericUpDown);
            this.uploadCapacityGroupBox.Font = null;
            this.uploadCapacityGroupBox.Name = "uploadCapacityGroupBox";
            this.uploadCapacityGroupBox.TabStop = false;
            // 
            // uploadCapacityNumericUpDown
            // 
            this.uploadCapacityNumericUpDown.AccessibleDescription = null;
            this.uploadCapacityNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.uploadCapacityNumericUpDown, "uploadCapacityNumericUpDown");
            this.uploadCapacityNumericUpDown.Font = null;
            this.uploadCapacityNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.uploadCapacityNumericUpDown.Name = "uploadCapacityNumericUpDown";
            this.uploadCapacityNumericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.uploadCapacityNumericUpDown.ValueChanged += new System.EventHandler(this.uploadCapacityNumericUpDown_ValueChanged);
            // 
            // downloadCapacityGroupBox
            // 
            this.downloadCapacityGroupBox.AccessibleDescription = null;
            this.downloadCapacityGroupBox.AccessibleName = null;
            resources.ApplyResources(this.downloadCapacityGroupBox, "downloadCapacityGroupBox");
            this.downloadCapacityGroupBox.BackgroundImage = null;
            this.downloadCapacityGroupBox.Controls.Add(this.downloadCapacityNumericUpDown);
            this.downloadCapacityGroupBox.Font = null;
            this.downloadCapacityGroupBox.Name = "downloadCapacityGroupBox";
            this.downloadCapacityGroupBox.TabStop = false;
            // 
            // downloadCapacityNumericUpDown
            // 
            this.downloadCapacityNumericUpDown.AccessibleDescription = null;
            this.downloadCapacityNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.downloadCapacityNumericUpDown, "downloadCapacityNumericUpDown");
            this.downloadCapacityNumericUpDown.Font = null;
            this.downloadCapacityNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downloadCapacityNumericUpDown.Name = "downloadCapacityNumericUpDown";
            this.downloadCapacityNumericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downloadCapacityNumericUpDown.ValueChanged += new System.EventHandler(this.downloadCapacityNumericUpDown_ValueChanged);
            // 
            // progressBarsGroupBox
            // 
            this.progressBarsGroupBox.AccessibleDescription = null;
            this.progressBarsGroupBox.AccessibleName = null;
            resources.ApplyResources(this.progressBarsGroupBox, "progressBarsGroupBox");
            this.progressBarsGroupBox.BackgroundImage = null;
            this.progressBarsGroupBox.Controls.Add(this.progressBarsHaveShadowCheckBox);
            this.progressBarsGroupBox.Controls.Add(this.progressBarsShowPercentCheckBox);
            this.progressBarsGroupBox.Controls.Add(this.progressBarsShadowNumericUpDown);
            this.progressBarsGroupBox.Font = null;
            this.progressBarsGroupBox.Name = "progressBarsGroupBox";
            this.progressBarsGroupBox.TabStop = false;
            // 
            // progressBarsHaveShadowCheckBox
            // 
            this.progressBarsHaveShadowCheckBox.AccessibleDescription = null;
            this.progressBarsHaveShadowCheckBox.AccessibleName = null;
            resources.ApplyResources(this.progressBarsHaveShadowCheckBox, "progressBarsHaveShadowCheckBox");
            this.progressBarsHaveShadowCheckBox.BackgroundImage = null;
            this.progressBarsHaveShadowCheckBox.Font = null;
            this.progressBarsHaveShadowCheckBox.Name = "progressBarsHaveShadowCheckBox";
            this.progressBarsHaveShadowCheckBox.UseVisualStyleBackColor = true;
            this.progressBarsHaveShadowCheckBox.CheckedChanged += new System.EventHandler(this.progressBarsHaveShadowCheckBox_CheckedChanged);
            // 
            // progressBarsShadowNumericUpDown
            // 
            this.progressBarsShadowNumericUpDown.AccessibleDescription = null;
            this.progressBarsShadowNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.progressBarsShadowNumericUpDown, "progressBarsShadowNumericUpDown");
            this.progressBarsShadowNumericUpDown.Font = null;
            this.progressBarsShadowNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.progressBarsShadowNumericUpDown.Name = "progressBarsShadowNumericUpDown";
            this.progressBarsShadowNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.progressBarsShadowNumericUpDown.ValueChanged += new System.EventHandler(this.progressBarsShadowNumericUpDown_ValueChanged);
            // 
            // uploadLimitGroupBox
            // 
            this.uploadLimitGroupBox.AccessibleDescription = null;
            this.uploadLimitGroupBox.AccessibleName = null;
            resources.ApplyResources(this.uploadLimitGroupBox, "uploadLimitGroupBox");
            this.uploadLimitGroupBox.BackgroundImage = null;
            this.uploadLimitGroupBox.Controls.Add(this.enableUploadLimitCheckBox);
            this.uploadLimitGroupBox.Controls.Add(this.uploadLimitNumericUpDown);
            this.uploadLimitGroupBox.Font = null;
            this.uploadLimitGroupBox.Name = "uploadLimitGroupBox";
            this.uploadLimitGroupBox.TabStop = false;
            // 
            // enableUploadLimitCheckBox
            // 
            this.enableUploadLimitCheckBox.AccessibleDescription = null;
            this.enableUploadLimitCheckBox.AccessibleName = null;
            resources.ApplyResources(this.enableUploadLimitCheckBox, "enableUploadLimitCheckBox");
            this.enableUploadLimitCheckBox.BackgroundImage = null;
            this.enableUploadLimitCheckBox.Font = null;
            this.enableUploadLimitCheckBox.Name = "enableUploadLimitCheckBox";
            this.enableUploadLimitCheckBox.UseVisualStyleBackColor = true;
            this.enableUploadLimitCheckBox.CheckedChanged += new System.EventHandler(this.enableUploadLimitCheckBox_CheckedChanged);
            // 
            // uploadLimitNumericUpDown
            // 
            this.uploadLimitNumericUpDown.AccessibleDescription = null;
            this.uploadLimitNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.uploadLimitNumericUpDown, "uploadLimitNumericUpDown");
            this.uploadLimitNumericUpDown.Font = null;
            this.uploadLimitNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.uploadLimitNumericUpDown.Name = "uploadLimitNumericUpDown";
            this.uploadLimitNumericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.uploadLimitNumericUpDown.ValueChanged += new System.EventHandler(this.uploadLimitNumericUpDown_ValueChanged);
            // 
            // downloadLimitGroupBox
            // 
            this.downloadLimitGroupBox.AccessibleDescription = null;
            this.downloadLimitGroupBox.AccessibleName = null;
            resources.ApplyResources(this.downloadLimitGroupBox, "downloadLimitGroupBox");
            this.downloadLimitGroupBox.BackgroundImage = null;
            this.downloadLimitGroupBox.Controls.Add(this.enableDownloadLimitCheckBox);
            this.downloadLimitGroupBox.Controls.Add(this.downloadLimitNumericUpDown);
            this.downloadLimitGroupBox.Font = null;
            this.downloadLimitGroupBox.Name = "downloadLimitGroupBox";
            this.downloadLimitGroupBox.TabStop = false;
            // 
            // enableDownloadLimitCheckBox
            // 
            this.enableDownloadLimitCheckBox.AccessibleDescription = null;
            this.enableDownloadLimitCheckBox.AccessibleName = null;
            resources.ApplyResources(this.enableDownloadLimitCheckBox, "enableDownloadLimitCheckBox");
            this.enableDownloadLimitCheckBox.BackgroundImage = null;
            this.enableDownloadLimitCheckBox.Font = null;
            this.enableDownloadLimitCheckBox.Name = "enableDownloadLimitCheckBox";
            this.enableDownloadLimitCheckBox.UseVisualStyleBackColor = true;
            this.enableDownloadLimitCheckBox.CheckedChanged += new System.EventHandler(this.enableDownloadLimitCheckBox_CheckedChanged);
            // 
            // downloadLimitNumericUpDown
            // 
            this.downloadLimitNumericUpDown.AccessibleDescription = null;
            this.downloadLimitNumericUpDown.AccessibleName = null;
            resources.ApplyResources(this.downloadLimitNumericUpDown, "downloadLimitNumericUpDown");
            this.downloadLimitNumericUpDown.Font = null;
            this.downloadLimitNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downloadLimitNumericUpDown.Name = "downloadLimitNumericUpDown";
            this.downloadLimitNumericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downloadLimitNumericUpDown.ValueChanged += new System.EventHandler(this.downloadLimitNumericUpDown_ValueChanged);
            // 
            // PreferencesControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.uploadLimitGroupBox);
            this.Controls.Add(this.downloadLimitGroupBox);
            this.Controls.Add(this.progressBarsGroupBox);
            this.Controls.Add(this.uploadCapacityGroupBox);
            this.Controls.Add(this.downloadCapacityGroupBox);
            this.Controls.Add(this.averageConnectionsCountGroupBox);
            this.Controls.Add(this.portGroupBox);
            this.Controls.Add(this.miscOptionsGroupBox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "PreferencesControl";
            this.portGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.miscOptionsGroupBox.ResumeLayout(false);
            this.miscOptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoMoveNumericUpDown)).EndInit();
            this.averageConnectionsCountGroupBox.ResumeLayout(false);
            this.averageConnectionsCountGroupBox.PerformLayout();
            this.uploadCapacityGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uploadCapacityNumericUpDown)).EndInit();
            this.downloadCapacityGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.downloadCapacityNumericUpDown)).EndInit();
            this.progressBarsGroupBox.ResumeLayout(false);
            this.progressBarsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarsShadowNumericUpDown)).EndInit();
            this.uploadLimitGroupBox.ResumeLayout(false);
            this.uploadLimitGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadLimitNumericUpDown)).EndInit();
            this.downloadLimitGroupBox.ResumeLayout(false);
            this.downloadLimitGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox portGroupBox;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.GroupBox miscOptionsGroupBox;
        private System.Windows.Forms.GroupBox averageConnectionsCountGroupBox;
        private System.Windows.Forms.CheckBox showMessageBoxesCheckBox;
        private System.Windows.Forms.CheckBox useBytesInsteadOfBitsCheckBox;
        private System.Windows.Forms.CheckBox progressBarsShowPercentCheckBox;
        private System.Windows.Forms.GroupBox uploadCapacityGroupBox;
        private System.Windows.Forms.NumericUpDown uploadCapacityNumericUpDown;
        private System.Windows.Forms.GroupBox downloadCapacityGroupBox;
        private System.Windows.Forms.NumericUpDown downloadCapacityNumericUpDown;
        private System.Windows.Forms.CheckBox synchronizeWebCachesCheckBox;
        private System.Windows.Forms.GroupBox progressBarsGroupBox;
        private System.Windows.Forms.NumericUpDown progressBarsShadowNumericUpDown;
        private System.Windows.Forms.CheckBox progressBarsHaveShadowCheckBox;
        private System.Windows.Forms.RadioButton tenRadioButton;
        private System.Windows.Forms.RadioButton nineRadioButton;
        private System.Windows.Forms.RadioButton eigthRadioButton;
        private System.Windows.Forms.RadioButton sevenRadioButton;
        private System.Windows.Forms.RadioButton sixRadioButton;
        private System.Windows.Forms.RadioButton fiveRadioButton;
        private System.Windows.Forms.RadioButton fourRadioButton;
        private System.Windows.Forms.RadioButton threeRadioButton;
        private System.Windows.Forms.RadioButton twoRadioButton;
        private System.Windows.Forms.RadioButton oneRadioButton;
        private System.Windows.Forms.GroupBox uploadLimitGroupBox;
        private System.Windows.Forms.NumericUpDown uploadLimitNumericUpDown;
        private System.Windows.Forms.GroupBox downloadLimitGroupBox;
        private System.Windows.Forms.NumericUpDown downloadLimitNumericUpDown;
        private System.Windows.Forms.CheckBox enableUploadLimitCheckBox;
        private System.Windows.Forms.CheckBox enableDownloadLimitCheckBox;
        private System.Windows.Forms.CheckBox SubFolderForCollectionsCheckBox;
        private System.Windows.Forms.CheckBox ParseCollectionsCheckBox;
        private System.Windows.Forms.CheckBox autoMoveCheckBox;
        private System.Windows.Forms.Label autoMoveLabel;
        private System.Windows.Forms.NumericUpDown autoMoveNumericUpDown;
        private System.Windows.Forms.CheckBox startInTrayCheckBox;
        private System.Windows.Forms.CheckBox NewDownloadsToBeginngingOfQueueCheckBox;
        private System.Windows.Forms.Button portTestButton;
        private System.Windows.Forms.Button ResetTrayBehaviorButton;
    }
}
