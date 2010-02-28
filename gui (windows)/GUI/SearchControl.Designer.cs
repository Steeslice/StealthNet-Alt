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
    partial class SearchControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.searchesDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.Pattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.RatingIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Album = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToSubfolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSearchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchesLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.searchesPictureBox = new System.Windows.Forms.PictureBox();
            this.FileTypeFilterComboBox = new System.Windows.Forms.ComboBox();
            this.SearchTypeComboBox = new System.Windows.Forms.ComboBox();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchesDataGridView)).BeginInit();
            this.searchesContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.resultsContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchesPictureBox)).BeginInit();
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
            this.splitContainer.Panel1.BackgroundImage = null;
            this.splitContainer.Panel1.Controls.Add(this.searchesDataGridView);
            this.splitContainer.Panel1.Font = null;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleDescription = null;
            this.splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.BackgroundImage = null;
            this.splitContainer.Panel2.Controls.Add(this.resultsDataGridView);
            this.splitContainer.Panel2.Font = null;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // searchesDataGridView
            // 
            this.searchesDataGridView.AccessibleDescription = null;
            this.searchesDataGridView.AccessibleName = null;
            this.searchesDataGridView.AllowUserToAddRows = false;
            this.searchesDataGridView.AllowUserToDeleteRows = false;
            this.searchesDataGridView.AllowUserToOrderColumns = true;
            this.searchesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.searchesDataGridView, "searchesDataGridView");
            this.searchesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.searchesDataGridView.BackgroundImage = null;
            this.searchesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.searchesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.searchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.searchesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pattern,
            this.IsActive,
            this.Results});
            this.searchesDataGridView.ContextMenuStrip = this.searchesContextMenuStrip;
            this.searchesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.searchesDataGridView.Font = null;
            this.searchesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.searchesDataGridView.Name = "searchesDataGridView";
            this.searchesDataGridView.ReadOnly = true;
            this.searchesDataGridView.RowHeadersVisible = false;
            this.searchesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.searchesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchesDataGridView.ShowCellErrors = false;
            this.searchesDataGridView.ShowCellToolTips = false;
            this.searchesDataGridView.ShowEditingIcon = false;
            this.searchesDataGridView.ShowRowErrors = false;
            this.searchesDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.searchesDataGridView_SortCompare);
            this.searchesDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.searchesDataGridView_ColumnDisplayIndexChanged);
            this.searchesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.searchesDataGridView_DataError);
            this.searchesDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.searchesDataGridView_ColumnWidthChanged);
            this.searchesDataGridView.SelectionChanged += new System.EventHandler(this.searchesDataGridView_SelectionChanged);
            // 
            // Pattern
            // 
            this.Pattern.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Pattern, "Pattern");
            this.Pattern.MaxInputLength = 0;
            this.Pattern.Name = "Pattern";
            this.Pattern.ReadOnly = true;
            // 
            // IsActive
            // 
            this.IsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsActive.FillWeight = 50F;
            resources.ApplyResources(this.IsActive, "IsActive");
            this.IsActive.MaxInputLength = 0;
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // Results
            // 
            this.Results.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Results.DefaultCellStyle = dataGridViewCellStyle1;
            this.Results.FillWeight = 50F;
            resources.ApplyResources(this.Results, "Results");
            this.Results.MaxInputLength = 0;
            this.Results.Name = "Results";
            this.Results.ReadOnly = true;
            // 
            // searchesContextMenuStrip
            // 
            this.searchesContextMenuStrip.AccessibleDescription = null;
            this.searchesContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.searchesContextMenuStrip, "searchesContextMenuStrip");
            this.searchesContextMenuStrip.BackgroundImage = null;
            this.searchesContextMenuStrip.Font = null;
            this.searchesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.restartAllToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeAllToolStripMenuItem});
            this.searchesContextMenuStrip.Name = "searchesContextMenuStrip";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.AccessibleDescription = null;
            this.restartToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.restartToolStripMenuItem, "restartToolStripMenuItem");
            this.restartToolStripMenuItem.BackgroundImage = null;
            this.restartToolStripMenuItem.Image = global::Regensburger.RShare.Properties.Resources.refresh_16x16;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // restartAllToolStripMenuItem
            // 
            this.restartAllToolStripMenuItem.AccessibleDescription = null;
            this.restartAllToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.restartAllToolStripMenuItem, "restartAllToolStripMenuItem");
            this.restartAllToolStripMenuItem.BackgroundImage = null;
            this.restartAllToolStripMenuItem.Image = global::Regensburger.RShare.Properties.Resources.refresh_16x16;
            this.restartAllToolStripMenuItem.Name = "restartAllToolStripMenuItem";
            this.restartAllToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.restartAllToolStripMenuItem.Click += new System.EventHandler(this.restartAllToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.AccessibleDescription = null;
            this.stopToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.stopToolStripMenuItem, "stopToolStripMenuItem");
            this.stopToolStripMenuItem.BackgroundImage = null;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.AccessibleDescription = null;
            this.removeToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.BackgroundImage = null;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.AccessibleDescription = null;
            this.removeAllToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.removeAllToolStripMenuItem, "removeAllToolStripMenuItem");
            this.removeAllToolStripMenuItem.BackgroundImage = null;
            this.removeAllToolStripMenuItem.Image = global::Regensburger.RShare.Properties.Resources.remove_16x16;
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AccessibleDescription = null;
            this.resultsDataGridView.AccessibleName = null;
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.AllowUserToOrderColumns = true;
            this.resultsDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.resultsDataGridView, "resultsDataGridView");
            this.resultsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.resultsDataGridView.BackgroundImage = null;
            this.resultsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.resultsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.RatingIcon,
            this.FileName,
            this.FileSize,
            this.Sources,
            this.Album,
            this.Artist,
            this.Title,
            this.Age});
            this.resultsDataGridView.ContextMenuStrip = this.resultsContextMenuStrip;
            this.resultsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.resultsDataGridView.Font = null;
            this.resultsDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.RowHeadersVisible = false;
            this.resultsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.resultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsDataGridView.ShowCellErrors = false;
            this.resultsDataGridView.ShowCellToolTips = false;
            this.resultsDataGridView.ShowEditingIcon = false;
            this.resultsDataGridView.ShowRowErrors = false;
            this.resultsDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.resultsDataGridView_SortCompare);
            this.resultsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultsDataGridView_CellContentDoubleClick);
            this.resultsDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.resultsDataGridView_ColumnDisplayIndexChanged);
            this.resultsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.resultsDataGridView_DataError);
            this.resultsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.resultsDataGridView_ColumnWidthChanged);
            this.resultsDataGridView.SelectionChanged += new System.EventHandler(this.resultsDataGridView_SelectionChanged);
            // 
            // Icon
            // 
            resources.ApplyResources(this.Icon, "Icon");
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.FileName.FillWeight = 165.5039F;
            resources.ApplyResources(this.FileName, "FileName");
            this.FileName.MaxInputLength = 0;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileSize.FillWeight = 41.37597F;
            resources.ApplyResources(this.FileSize, "FileSize");
            this.FileSize.MaxInputLength = 0;
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // Sources
            // 
            this.Sources.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sources.FillWeight = 41.37597F;
            resources.ApplyResources(this.Sources, "Sources");
            this.Sources.MaxInputLength = 0;
            this.Sources.Name = "Sources";
            this.Sources.ReadOnly = true;
            // 
            // Album
            // 
            this.Album.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Album.FillWeight = 82.75194F;
            resources.ApplyResources(this.Album, "Album");
            this.Album.MaxInputLength = 0;
            this.Album.Name = "Album";
            this.Album.ReadOnly = true;
            // 
            // Artist
            // 
            this.Artist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Artist.FillWeight = 82.75194F;
            resources.ApplyResources(this.Artist, "Artist");
            this.Artist.MaxInputLength = 0;
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.FillWeight = 82.75194F;
            resources.ApplyResources(this.Title, "Title");
            this.Title.MaxInputLength = 0;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Age.FillWeight = 41.37597F;
            resources.ApplyResources(this.Age, "Age");
            this.Age.MaxInputLength = 0;
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // resultsContextMenuStrip
            // 
            this.resultsContextMenuStrip.AccessibleDescription = null;
            this.resultsContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.resultsContextMenuStrip, "resultsContextMenuStrip");
            this.resultsContextMenuStrip.BackgroundImage = null;
            this.resultsContextMenuStrip.Font = null;
            this.resultsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.downloadToSubfolderToolStripMenuItem,
            this.showInformationToolStripMenuItem,
            this.copyLinkToClipboardToolStripMenuItem});
            this.resultsContextMenuStrip.Name = "contextMenuStrip";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.AccessibleDescription = null;
            this.downloadToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.downloadToolStripMenuItem, "downloadToolStripMenuItem");
            this.downloadToolStripMenuItem.BackgroundImage = null;
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // downloadToSubfolderToolStripMenuItem
            // 
            this.downloadToSubfolderToolStripMenuItem.AccessibleDescription = null;
            this.downloadToSubfolderToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.downloadToSubfolderToolStripMenuItem, "downloadToSubfolderToolStripMenuItem");
            this.downloadToSubfolderToolStripMenuItem.BackgroundImage = null;
            this.downloadToSubfolderToolStripMenuItem.Image = global::Regensburger.RShare.Properties.Resources.download_16x16;
            this.downloadToSubfolderToolStripMenuItem.Name = "downloadToSubfolderToolStripMenuItem";
            this.downloadToSubfolderToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.downloadToSubfolderToolStripMenuItem.Click += new System.EventHandler(this.downloadToSubfolderToolStripMenuItem_Click);
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
            // copyLinkToClipboardToolStripMenuItem
            // 
            this.copyLinkToClipboardToolStripMenuItem.AccessibleDescription = null;
            this.copyLinkToClipboardToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyLinkToClipboardToolStripMenuItem, "copyLinkToClipboardToolStripMenuItem");
            this.copyLinkToClipboardToolStripMenuItem.BackgroundImage = null;
            this.copyLinkToClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLinkToolStripMenuItem,
            this.copyLinkHTMLToolStripMenuItem});
            this.copyLinkToClipboardToolStripMenuItem.Name = "copyLinkToClipboardToolStripMenuItem";
            this.copyLinkToClipboardToolStripMenuItem.ShortcutKeyDisplayString = null;
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
            // addSearchButton
            // 
            this.addSearchButton.AccessibleDescription = null;
            this.addSearchButton.AccessibleName = null;
            resources.ApplyResources(this.addSearchButton, "addSearchButton");
            this.addSearchButton.BackgroundImage = null;
            this.addSearchButton.Font = null;
            this.addSearchButton.Name = "addSearchButton";
            this.addSearchButton.Click += new System.EventHandler(this.addSearchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AccessibleDescription = null;
            this.searchTextBox.AccessibleName = null;
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.BackgroundImage = null;
            this.searchTextBox.Font = null;
            this.searchTextBox.HideSelection = false;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // searchesLabel
            // 
            this.searchesLabel.AccessibleDescription = null;
            this.searchesLabel.AccessibleName = null;
            resources.ApplyResources(this.searchesLabel, "searchesLabel");
            this.searchesLabel.Font = null;
            this.searchesLabel.Name = "searchesLabel";
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // searchesPictureBox
            // 
            this.searchesPictureBox.AccessibleDescription = null;
            this.searchesPictureBox.AccessibleName = null;
            resources.ApplyResources(this.searchesPictureBox, "searchesPictureBox");
            this.searchesPictureBox.BackgroundImage = null;
            this.searchesPictureBox.Font = null;
            this.searchesPictureBox.Image = global::Regensburger.RShare.Properties.Resources.search_16x16;
            this.searchesPictureBox.ImageLocation = null;
            this.searchesPictureBox.Name = "searchesPictureBox";
            this.searchesPictureBox.TabStop = false;
            // 
            // FileTypeFilterComboBox
            // 
            this.FileTypeFilterComboBox.AccessibleDescription = null;
            this.FileTypeFilterComboBox.AccessibleName = null;
            resources.ApplyResources(this.FileTypeFilterComboBox, "FileTypeFilterComboBox");
            this.FileTypeFilterComboBox.BackgroundImage = null;
            this.FileTypeFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileTypeFilterComboBox.Font = null;
            this.FileTypeFilterComboBox.FormattingEnabled = true;
            this.FileTypeFilterComboBox.Name = "FileTypeFilterComboBox";
            this.FileTypeFilterComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTypeFilterComboBox_KeyDown);
            // 
            // SearchTypeComboBox
            // 
            this.SearchTypeComboBox.AccessibleDescription = null;
            this.SearchTypeComboBox.AccessibleName = null;
            resources.ApplyResources(this.SearchTypeComboBox, "SearchTypeComboBox");
            this.SearchTypeComboBox.BackgroundImage = null;
            this.SearchTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchTypeComboBox.Font = null;
            this.SearchTypeComboBox.FormattingEnabled = true;
            this.SearchTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("SearchTypeComboBox.Items"),
            resources.GetString("SearchTypeComboBox.Items1"),
            resources.GetString("SearchTypeComboBox.Items2")});
            this.SearchTypeComboBox.Name = "SearchTypeComboBox";
            this.SearchTypeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTypeComboBox_KeyDown);
            // 
            // SearchControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.SearchTypeComboBox);
            this.Controls.Add(this.FileTypeFilterComboBox);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.searchesPictureBox);
            this.Controls.Add(this.searchesLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.addSearchButton);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "SearchControl";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchesDataGridView)).EndInit();
            this.searchesContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.resultsContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip resultsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
        private System.Windows.Forms.Button addSearchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.PictureBox searchesPictureBox;
        private Regensburger.RShare.DoubleBufferedDataGridView resultsDataGridView;
        private System.Windows.Forms.Label searchesLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Regensburger.RShare.DoubleBufferedDataGridView searchesDataGridView;
        private System.Windows.Forms.ContextMenuStrip searchesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ComboBox FileTypeFilterComboBox;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToSubfolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartAllToolStripMenuItem;
        private System.Windows.Forms.ComboBox SearchTypeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Results;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewImageColumn RatingIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sources;
        private System.Windows.Forms.DataGridViewTextBoxColumn Album;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
    }
}
