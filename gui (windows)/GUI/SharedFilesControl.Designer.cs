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

namespace Regensburger.RShare
{
    partial class SharedFilesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharedFilesControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sharedFilesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharedFilesLabel = new System.Windows.Forms.Label();
            this.sharedFilesPictureBox = new System.Windows.Forms.PictureBox();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.maxSearchCountLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.columnComboBox = new System.Windows.Forms.ComboBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.sharedFilesDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.RatingIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Album = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sharedFilesContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedFilesPictureBox)).BeginInit();
            this.searchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedFilesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sharedFilesContextMenuStrip
            // 
            this.sharedFilesContextMenuStrip.AccessibleDescription = null;
            this.sharedFilesContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.sharedFilesContextMenuStrip, "sharedFilesContextMenuStrip");
            this.sharedFilesContextMenuStrip.BackgroundImage = null;
            this.sharedFilesContextMenuStrip.Font = null;
            this.sharedFilesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openDirectoryToolStripMenuItem,
            this.showInformationToolStripMenuItem,
            this.copyLinkToClipboardMenuItem,
            this.createCollectionToolStripMenuItem});
            this.sharedFilesContextMenuStrip.Name = "sharedFilesContextMenuStrip";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.AccessibleDescription = null;
            this.openFileToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.openFileToolStripMenuItem, "openFileToolStripMenuItem");
            this.openFileToolStripMenuItem.BackgroundImage = null;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.AccessibleDescription = null;
            this.openDirectoryToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.openDirectoryToolStripMenuItem, "openDirectoryToolStripMenuItem");
            this.openDirectoryToolStripMenuItem.BackgroundImage = null;
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
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
            // createCollectionToolStripMenuItem
            // 
            this.createCollectionToolStripMenuItem.AccessibleDescription = null;
            this.createCollectionToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.createCollectionToolStripMenuItem, "createCollectionToolStripMenuItem");
            this.createCollectionToolStripMenuItem.BackgroundImage = null;
            this.createCollectionToolStripMenuItem.Name = "createCollectionToolStripMenuItem";
            this.createCollectionToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.createCollectionToolStripMenuItem.Click += new System.EventHandler(this.createCollectionToolStripMenuItem_Click);
            // 
            // sharedFilesLabel
            // 
            this.sharedFilesLabel.AccessibleDescription = null;
            this.sharedFilesLabel.AccessibleName = null;
            resources.ApplyResources(this.sharedFilesLabel, "sharedFilesLabel");
            this.sharedFilesLabel.Font = null;
            this.sharedFilesLabel.Name = "sharedFilesLabel";
            // 
            // sharedFilesPictureBox
            // 
            this.sharedFilesPictureBox.AccessibleDescription = null;
            this.sharedFilesPictureBox.AccessibleName = null;
            resources.ApplyResources(this.sharedFilesPictureBox, "sharedFilesPictureBox");
            this.sharedFilesPictureBox.BackgroundImage = null;
            this.sharedFilesPictureBox.Font = null;
            this.sharedFilesPictureBox.ImageLocation = null;
            this.sharedFilesPictureBox.Name = "sharedFilesPictureBox";
            this.sharedFilesPictureBox.TabStop = false;
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.AccessibleDescription = null;
            this.searchGroupBox.AccessibleName = null;
            resources.ApplyResources(this.searchGroupBox, "searchGroupBox");
            this.searchGroupBox.BackgroundImage = null;
            this.searchGroupBox.Controls.Add(this.maxSearchCountLabel);
            this.searchGroupBox.Controls.Add(this.searchButton);
            this.searchGroupBox.Controls.Add(this.searchTextBox);
            this.searchGroupBox.Controls.Add(this.columnComboBox);
            this.searchGroupBox.Font = null;
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.TabStop = false;
            // 
            // maxSearchCountLabel
            // 
            this.maxSearchCountLabel.AccessibleDescription = null;
            this.maxSearchCountLabel.AccessibleName = null;
            resources.ApplyResources(this.maxSearchCountLabel, "maxSearchCountLabel");
            this.maxSearchCountLabel.Font = null;
            this.maxSearchCountLabel.Name = "maxSearchCountLabel";
            // 
            // searchButton
            // 
            this.searchButton.AccessibleDescription = null;
            this.searchButton.AccessibleName = null;
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.BackgroundImage = null;
            this.searchButton.Font = null;
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AccessibleDescription = null;
            this.searchTextBox.AccessibleName = null;
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.BackgroundImage = null;
            this.searchTextBox.Font = null;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // columnComboBox
            // 
            this.columnComboBox.AccessibleDescription = null;
            this.columnComboBox.AccessibleName = null;
            resources.ApplyResources(this.columnComboBox, "columnComboBox");
            this.columnComboBox.BackgroundImage = null;
            this.columnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox.Font = null;
            this.columnComboBox.FormattingEnabled = true;
            this.columnComboBox.Items.AddRange(new object[] {
            resources.GetString("columnComboBox.Items"),
            resources.GetString("columnComboBox.Items1"),
            resources.GetString("columnComboBox.Items2"),
            resources.GetString("columnComboBox.Items3"),
            resources.GetString("columnComboBox.Items4")});
            this.columnComboBox.Name = "columnComboBox";
            this.columnComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.columnComboBox_KeyDown);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 30000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // sharedFilesDataGridView
            // 
            this.sharedFilesDataGridView.AccessibleDescription = null;
            this.sharedFilesDataGridView.AccessibleName = null;
            this.sharedFilesDataGridView.AllowUserToAddRows = false;
            this.sharedFilesDataGridView.AllowUserToDeleteRows = false;
            this.sharedFilesDataGridView.AllowUserToOrderColumns = true;
            this.sharedFilesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.sharedFilesDataGridView, "sharedFilesDataGridView");
            this.sharedFilesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sharedFilesDataGridView.BackgroundImage = null;
            this.sharedFilesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sharedFilesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sharedFilesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sharedFilesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sharedFilesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.RatingIcon,
            this.FileName,
            this.FileSize,
            this.Directory,
            this.Album,
            this.Artist,
            this.Title,
            this.lastRequest});
            this.sharedFilesDataGridView.ContextMenuStrip = this.sharedFilesContextMenuStrip;
            this.sharedFilesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.sharedFilesDataGridView.Font = null;
            this.sharedFilesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.sharedFilesDataGridView.Name = "sharedFilesDataGridView";
            this.sharedFilesDataGridView.ReadOnly = true;
            this.sharedFilesDataGridView.RowHeadersVisible = false;
            this.sharedFilesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sharedFilesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sharedFilesDataGridView.ShowCellErrors = false;
            this.sharedFilesDataGridView.ShowCellToolTips = false;
            this.sharedFilesDataGridView.ShowEditingIcon = false;
            this.sharedFilesDataGridView.ShowRowErrors = false;
            this.sharedFilesDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.sharedFilesDataGridView_SortCompare);
            this.sharedFilesDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sharedFilesDataGridView_CellContentDoubleClick);
            this.sharedFilesDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.sharedFilesDataGridView_ColumnDisplayIndexChanged);
            this.sharedFilesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sharedFilesDataGridView_DataError);
            this.sharedFilesDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.sharedFilesDataGridView_ColumnWidthChanged);
            this.sharedFilesDataGridView.SelectionChanged += new System.EventHandler(this.sharedFilesDataGridView_SelectionChanged);
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
            this.FileName.FillWeight = 200F;
            resources.ApplyResources(this.FileName, "FileName");
            this.FileName.MaxInputLength = 0;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FileSize.DefaultCellStyle = dataGridViewCellStyle2;
            this.FileSize.FillWeight = 50F;
            resources.ApplyResources(this.FileSize, "FileSize");
            this.FileSize.MaxInputLength = 0;
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // Directory
            // 
            this.Directory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Directory, "Directory");
            this.Directory.MaxInputLength = 0;
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            // 
            // Album
            // 
            this.Album.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Album, "Album");
            this.Album.MaxInputLength = 0;
            this.Album.Name = "Album";
            this.Album.ReadOnly = true;
            // 
            // Artist
            // 
            this.Artist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Artist, "Artist");
            this.Artist.MaxInputLength = 0;
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Title, "Title");
            this.Title.MaxInputLength = 0;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // lastRequest
            // 
            this.lastRequest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastRequest.FillWeight = 50F;
            resources.ApplyResources(this.lastRequest, "lastRequest");
            this.lastRequest.MaxInputLength = 0;
            this.lastRequest.Name = "lastRequest";
            this.lastRequest.ReadOnly = true;
            // 
            // SharedFilesControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.searchGroupBox);
            this.Controls.Add(this.sharedFilesDataGridView);
            this.Controls.Add(this.sharedFilesPictureBox);
            this.Controls.Add(this.sharedFilesLabel);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "SharedFilesControl";
            this.sharedFilesContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sharedFilesPictureBox)).EndInit();
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedFilesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip sharedFilesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox sharedFilesPictureBox;
        private System.Windows.Forms.Label sharedFilesLabel;
        private Regensburger.RShare.DoubleBufferedDataGridView sharedFilesDataGridView;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToClipboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCollectionToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewImageColumn RatingIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Album;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRequest;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox columnComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label maxSearchCountLabel;
        private System.Windows.Forms.Timer updateTimer;
    }
}
