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
    partial class DownloadsControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadsControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.downloadsLabel = new System.Windows.Forms.Label();
            this.downloadsPictureBox = new System.Windows.Forms.PictureBox();
            this.downloadsDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.DownloadIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.RatingIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastReception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToTopOfQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToBottomOfQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadByFileHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadByCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourcesDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.SourceIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.TypeIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewImageColumn();
            this.Queue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadsDataGridView)).BeginInit();
            this.downloadsContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AccessibleDescription = null;
            this.splitContainer.AccessibleName = null;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.BackgroundImage = null;
            this.splitContainer.Font = null;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleDescription = null;
            this.splitContainer.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer.Panel1.BackgroundImage = null;
            this.splitContainer.Panel1.Controls.Add(this.downloadsLabel);
            this.splitContainer.Panel1.Controls.Add(this.downloadsPictureBox);
            this.splitContainer.Panel1.Controls.Add(this.downloadsDataGridView);
            this.splitContainer.Panel1.Font = null;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleDescription = null;
            this.splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.BackgroundImage = null;
            this.splitContainer.Panel2.Controls.Add(this.sourcesDataGridView);
            this.splitContainer.Panel2.Font = null;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // downloadsLabel
            // 
            this.downloadsLabel.AccessibleDescription = null;
            this.downloadsLabel.AccessibleName = null;
            resources.ApplyResources(this.downloadsLabel, "downloadsLabel");
            this.downloadsLabel.Font = null;
            this.downloadsLabel.Name = "downloadsLabel";
            // 
            // downloadsPictureBox
            // 
            this.downloadsPictureBox.AccessibleDescription = null;
            this.downloadsPictureBox.AccessibleName = null;
            resources.ApplyResources(this.downloadsPictureBox, "downloadsPictureBox");
            this.downloadsPictureBox.BackgroundImage = null;
            this.downloadsPictureBox.Font = null;
            this.downloadsPictureBox.ImageLocation = null;
            this.downloadsPictureBox.Name = "downloadsPictureBox";
            this.downloadsPictureBox.TabStop = false;
            // 
            // downloadsDataGridView
            // 
            this.downloadsDataGridView.AccessibleDescription = null;
            this.downloadsDataGridView.AccessibleName = null;
            this.downloadsDataGridView.AllowUserToAddRows = false;
            this.downloadsDataGridView.AllowUserToDeleteRows = false;
            this.downloadsDataGridView.AllowUserToOrderColumns = true;
            this.downloadsDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.downloadsDataGridView, "downloadsDataGridView");
            this.downloadsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.downloadsDataGridView.BackgroundImage = null;
            this.downloadsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.downloadsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.downloadsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.downloadsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.downloadsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DownloadIcon,
            this.RatingIcon,
            this.FileName,
            this.FileSize,
            this.Completed,
            this.ProgressImage,
            this.Status,
            this.Sources,
            this.Remaining,
            this.lastSeen,
            this.lastReception});
            this.downloadsDataGridView.ContextMenuStrip = this.downloadsContextMenuStrip;
            this.downloadsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.downloadsDataGridView.Font = null;
            this.downloadsDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.downloadsDataGridView.Name = "downloadsDataGridView";
            this.downloadsDataGridView.ReadOnly = true;
            this.downloadsDataGridView.RowHeadersVisible = false;
            this.downloadsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.downloadsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.downloadsDataGridView.ShowCellErrors = false;
            this.downloadsDataGridView.ShowCellToolTips = false;
            this.downloadsDataGridView.ShowEditingIcon = false;
            this.downloadsDataGridView.ShowRowErrors = false;
            this.downloadsDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.downloadsDataGridView_SortCompare);
            this.downloadsDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.downloadsDataGridView_ColumnDisplayIndexChanged);
            this.downloadsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.downloadsDataGridView_DataError);
            this.downloadsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.downloadsDataGridView_ColumnWidthChanged);
            this.downloadsDataGridView.SelectionChanged += new System.EventHandler(this.downloadsDataGridView_SelectionChanged);
            // 
            // DownloadIcon
            // 
            resources.ApplyResources(this.DownloadIcon, "DownloadIcon");
            this.DownloadIcon.Name = "DownloadIcon";
            this.DownloadIcon.ReadOnly = true;
            this.DownloadIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // RatingIcon
            // 
            resources.ApplyResources(this.RatingIcon, "RatingIcon");
            this.RatingIcon.Name = "RatingIcon";
            this.RatingIcon.ReadOnly = true;
            this.RatingIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RatingIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.FillWeight = 120F;
            resources.ApplyResources(this.FileName, "FileName");
            this.FileName.MaxInputLength = 0;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FileSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.FileSize.FillWeight = 30F;
            resources.ApplyResources(this.FileSize, "FileSize");
            this.FileSize.MaxInputLength = 0;
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // Completed
            // 
            this.Completed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Completed.DefaultCellStyle = dataGridViewCellStyle2;
            this.Completed.FillWeight = 30F;
            resources.ApplyResources(this.Completed, "Completed");
            this.Completed.MaxInputLength = 0;
            this.Completed.Name = "Completed";
            this.Completed.ReadOnly = true;
            // 
            // ProgressImage
            // 
            this.ProgressImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProgressImage.FillWeight = 110F;
            resources.ApplyResources(this.ProgressImage, "ProgressImage");
            this.ProgressImage.Name = "ProgressImage";
            this.ProgressImage.ReadOnly = true;
            this.ProgressImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Status.DefaultCellStyle = dataGridViewCellStyle3;
            this.Status.FillWeight = 30F;
            resources.ApplyResources(this.Status, "Status");
            this.Status.MaxInputLength = 0;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Sources
            // 
            this.Sources.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Sources.DefaultCellStyle = dataGridViewCellStyle4;
            this.Sources.FillWeight = 30F;
            resources.ApplyResources(this.Sources, "Sources");
            this.Sources.MaxInputLength = 0;
            this.Sources.Name = "Sources";
            this.Sources.ReadOnly = true;
            // 
            // Remaining
            // 
            this.Remaining.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Remaining.DefaultCellStyle = dataGridViewCellStyle5;
            this.Remaining.FillWeight = 30F;
            resources.ApplyResources(this.Remaining, "Remaining");
            this.Remaining.MaxInputLength = 0;
            this.Remaining.Name = "Remaining";
            this.Remaining.ReadOnly = true;
            // 
            // lastSeen
            // 
            this.lastSeen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastSeen.FillWeight = 40F;
            resources.ApplyResources(this.lastSeen, "lastSeen");
            this.lastSeen.MaxInputLength = 0;
            this.lastSeen.Name = "lastSeen";
            this.lastSeen.ReadOnly = true;
            // 
            // lastReception
            // 
            this.lastReception.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastReception.FillWeight = 40F;
            resources.ApplyResources(this.lastReception, "lastReception");
            this.lastReception.MaxInputLength = 0;
            this.lastReception.Name = "lastReception";
            this.lastReception.ReadOnly = true;
            // 
            // downloadsContextMenuStrip
            // 
            this.downloadsContextMenuStrip.AccessibleDescription = null;
            this.downloadsContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.downloadsContextMenuStrip, "downloadsContextMenuStrip");
            this.downloadsContextMenuStrip.BackgroundImage = null;
            this.downloadsContextMenuStrip.Font = null;
            this.downloadsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToQueueToolStripMenuItem,
            this.toolStripSeparator2,
            this.moveToTopOfQueueToolStripMenuItem,
            this.moveToBottomOfQueueToolStripMenuItem,
            this.toolStripSeparator3,
            this.showInformationToolStripMenuItem,
            this.previewToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.toolStripSeparator1,
            this.downloadByFileHashToolStripMenuItem,
            this.downloadByCollectionToolStripMenuItem,
            this.copyLinkToClipboardMenuItem});
            this.downloadsContextMenuStrip.Name = "downloadContextMenuStrip";
            // 
            // moveToQueueToolStripMenuItem
            // 
            this.moveToQueueToolStripMenuItem.AccessibleDescription = null;
            this.moveToQueueToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.moveToQueueToolStripMenuItem, "moveToQueueToolStripMenuItem");
            this.moveToQueueToolStripMenuItem.BackgroundImage = null;
            this.moveToQueueToolStripMenuItem.Name = "moveToQueueToolStripMenuItem";
            this.moveToQueueToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.moveToQueueToolStripMenuItem.Click += new System.EventHandler(this.moveToQueueToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // moveToTopOfQueueToolStripMenuItem
            // 
            this.moveToTopOfQueueToolStripMenuItem.AccessibleDescription = null;
            this.moveToTopOfQueueToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.moveToTopOfQueueToolStripMenuItem, "moveToTopOfQueueToolStripMenuItem");
            this.moveToTopOfQueueToolStripMenuItem.BackgroundImage = null;
            this.moveToTopOfQueueToolStripMenuItem.Name = "moveToTopOfQueueToolStripMenuItem";
            this.moveToTopOfQueueToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.moveToTopOfQueueToolStripMenuItem.Click += new System.EventHandler(this.moveToTopOfQueueToolStripMenuItem_Click);
            // 
            // moveToBottomOfQueueToolStripMenuItem
            // 
            this.moveToBottomOfQueueToolStripMenuItem.AccessibleDescription = null;
            this.moveToBottomOfQueueToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.moveToBottomOfQueueToolStripMenuItem, "moveToBottomOfQueueToolStripMenuItem");
            this.moveToBottomOfQueueToolStripMenuItem.BackgroundImage = null;
            this.moveToBottomOfQueueToolStripMenuItem.Name = "moveToBottomOfQueueToolStripMenuItem";
            this.moveToBottomOfQueueToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.moveToBottomOfQueueToolStripMenuItem.Click += new System.EventHandler(this.moveToBottomOfQueueToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AccessibleDescription = null;
            this.toolStripSeparator3.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // showInformationToolStripMenuItem
            // 
            this.showInformationToolStripMenuItem.AccessibleDescription = null;
            this.showInformationToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.showInformationToolStripMenuItem, "showInformationToolStripMenuItem");
            this.showInformationToolStripMenuItem.BackgroundImage = null;
            this.showInformationToolStripMenuItem.Name = "showInformationToolStripMenuItem";
            this.showInformationToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.showInformationToolStripMenuItem.Click += new System.EventHandler(this.showInformationToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.AccessibleDescription = null;
            this.previewToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.previewToolStripMenuItem, "previewToolStripMenuItem");
            this.previewToolStripMenuItem.BackgroundImage = null;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.AccessibleDescription = null;
            this.cancelToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.cancelToolStripMenuItem, "cancelToolStripMenuItem");
            this.cancelToolStripMenuItem.BackgroundImage = null;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // downloadByFileHashToolStripMenuItem
            // 
            this.downloadByFileHashToolStripMenuItem.AccessibleDescription = null;
            this.downloadByFileHashToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.downloadByFileHashToolStripMenuItem, "downloadByFileHashToolStripMenuItem");
            this.downloadByFileHashToolStripMenuItem.BackgroundImage = null;
            this.downloadByFileHashToolStripMenuItem.Name = "downloadByFileHashToolStripMenuItem";
            this.downloadByFileHashToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.downloadByFileHashToolStripMenuItem.Click += new System.EventHandler(this.downloadByFileHashToolStripMenuItem_Click);
            // 
            // downloadByCollectionToolStripMenuItem
            // 
            this.downloadByCollectionToolStripMenuItem.AccessibleDescription = null;
            this.downloadByCollectionToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.downloadByCollectionToolStripMenuItem, "downloadByCollectionToolStripMenuItem");
            this.downloadByCollectionToolStripMenuItem.BackgroundImage = null;
            this.downloadByCollectionToolStripMenuItem.Name = "downloadByCollectionToolStripMenuItem";
            this.downloadByCollectionToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.downloadByCollectionToolStripMenuItem.Click += new System.EventHandler(this.downloadByCollectionToolStripMenuItem_Click);
            // 
            // copyLinkToClipboardMenuItem
            // 
            this.copyLinkToClipboardMenuItem.AccessibleDescription = null;
            this.copyLinkToClipboardMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyLinkToClipboardMenuItem, "copyLinkToClipboardMenuItem");
            this.copyLinkToClipboardMenuItem.BackgroundImage = null;
            this.copyLinkToClipboardMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLinkToolStripMenuItem,
            this.copyLinkHTMLToolStripMenuItem});
            this.copyLinkToClipboardMenuItem.Name = "copyLinkToClipboardMenuItem";
            this.copyLinkToClipboardMenuItem.ShortcutKeyDisplayString = null;
            // 
            // copyLinkToolStripMenuItem
            // 
            this.copyLinkToolStripMenuItem.AccessibleDescription = null;
            this.copyLinkToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyLinkToolStripMenuItem, "copyLinkToolStripMenuItem");
            this.copyLinkToolStripMenuItem.BackgroundImage = null;
            this.copyLinkToolStripMenuItem.Name = "copyLinkToolStripMenuItem";
            this.copyLinkToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.copyLinkToolStripMenuItem.Click += new System.EventHandler(this.copyLinkToolStripMenuItem_Click);
            // 
            // copyLinkHTMLToolStripMenuItem
            // 
            this.copyLinkHTMLToolStripMenuItem.AccessibleDescription = null;
            this.copyLinkHTMLToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyLinkHTMLToolStripMenuItem, "copyLinkHTMLToolStripMenuItem");
            this.copyLinkHTMLToolStripMenuItem.BackgroundImage = null;
            this.copyLinkHTMLToolStripMenuItem.Name = "copyLinkHTMLToolStripMenuItem";
            this.copyLinkHTMLToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.copyLinkHTMLToolStripMenuItem.Click += new System.EventHandler(this.copyLinkHTMLToolStripMenuItem_Click);
            // 
            // sourcesDataGridView
            // 
            this.sourcesDataGridView.AccessibleDescription = null;
            this.sourcesDataGridView.AccessibleName = null;
            this.sourcesDataGridView.AllowUserToAddRows = false;
            this.sourcesDataGridView.AllowUserToDeleteRows = false;
            this.sourcesDataGridView.AllowUserToOrderColumns = true;
            this.sourcesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.sourcesDataGridView, "sourcesDataGridView");
            this.sourcesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sourcesDataGridView.BackgroundImage = null;
            this.sourcesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sourcesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sourcesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sourcesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sourcesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceIcon,
            this.TypeIcon,
            this.Type,
            this.Progress,
            this.Queue,
            this.SentCommands,
            this.ReceivedCommands});
            this.sourcesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.sourcesDataGridView.Font = null;
            this.sourcesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.sourcesDataGridView.MultiSelect = false;
            this.sourcesDataGridView.Name = "sourcesDataGridView";
            this.sourcesDataGridView.ReadOnly = true;
            this.sourcesDataGridView.RowHeadersVisible = false;
            this.sourcesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sourcesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sourcesDataGridView.ShowCellErrors = false;
            this.sourcesDataGridView.ShowCellToolTips = false;
            this.sourcesDataGridView.ShowEditingIcon = false;
            this.sourcesDataGridView.ShowRowErrors = false;
            this.sourcesDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.sourcesDataGridView_SortCompare);
            this.sourcesDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.sourcesDataGridView_ColumnDisplayIndexChanged);
            this.sourcesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sourcesDataGridView_DataError);
            this.sourcesDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.sourcesDataGridView_ColumnWidthChanged);
            // 
            // SourceIcon
            // 
            resources.ApplyResources(this.SourceIcon, "SourceIcon");
            this.SourceIcon.Name = "SourceIcon";
            this.SourceIcon.ReadOnly = true;
            this.SourceIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TypeIcon
            // 
            resources.ApplyResources(this.TypeIcon, "TypeIcon");
            this.TypeIcon.Name = "TypeIcon";
            this.TypeIcon.ReadOnly = true;
            this.TypeIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TypeIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.FillWeight = 40F;
            resources.ApplyResources(this.Type, "Type");
            this.Type.MaxInputLength = 0;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Progress
            // 
            this.Progress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Progress.FillWeight = 110F;
            resources.ApplyResources(this.Progress, "Progress");
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            this.Progress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Queue
            // 
            this.Queue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Queue.DefaultCellStyle = dataGridViewCellStyle6;
            this.Queue.FillWeight = 40F;
            resources.ApplyResources(this.Queue, "Queue");
            this.Queue.MaxInputLength = 0;
            this.Queue.Name = "Queue";
            this.Queue.ReadOnly = true;
            // 
            // SentCommands
            // 
            this.SentCommands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SentCommands.DefaultCellStyle = dataGridViewCellStyle7;
            this.SentCommands.FillWeight = 40F;
            resources.ApplyResources(this.SentCommands, "SentCommands");
            this.SentCommands.MaxInputLength = 0;
            this.SentCommands.Name = "SentCommands";
            this.SentCommands.ReadOnly = true;
            // 
            // ReceivedCommands
            // 
            this.ReceivedCommands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReceivedCommands.DefaultCellStyle = dataGridViewCellStyle8;
            this.ReceivedCommands.FillWeight = 40F;
            resources.ApplyResources(this.ReceivedCommands, "ReceivedCommands");
            this.ReceivedCommands.MaxInputLength = 0;
            this.ReceivedCommands.Name = "ReceivedCommands";
            this.ReceivedCommands.ReadOnly = true;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // DownloadsControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "DownloadsControl";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.downloadsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadsDataGridView)).EndInit();
            this.downloadsContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip downloadsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem downloadByFileHashToolStripMenuItem;
        private Regensburger.RShare.DoubleBufferedDataGridView downloadsDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DoubleBufferedDataGridView sourcesDataGridView;
        private System.Windows.Forms.Label downloadsLabel;
        private System.Windows.Forms.PictureBox downloadsPictureBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToClipboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToTopOfQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToBottomOfQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem downloadByCollectionToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn DownloadIcon;
        private System.Windows.Forms.DataGridViewImageColumn RatingIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Completed;
        private System.Windows.Forms.DataGridViewImageColumn ProgressImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sources;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastReception;
        private System.Windows.Forms.DataGridViewImageColumn SourceIcon;
        private System.Windows.Forms.DataGridViewImageColumn TypeIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewImageColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Queue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedCommands;
    }
}
