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
    partial class DirectoriesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoriesControl));
            this.selectIncomingDirectoryButton = new System.Windows.Forms.Button();
            this.incomingDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.selectTemporaryDirectoryButton = new System.Windows.Forms.Button();
            this.temporaryDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.directoryFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.otherDirectoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.corruptDirectoryLabel = new System.Windows.Forms.Label();
            this.selectCorruptDirectoryButton = new System.Windows.Forms.Button();
            this.corruptDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.selectLogDirectoryButton = new System.Windows.Forms.Button();
            this.logDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.incomingDirectoryLabel = new System.Windows.Forms.Label();
            this.temporaryDirectoryLabel = new System.Windows.Forms.Label();
            this.logDirectoryLabel = new System.Windows.Forms.Label();
            this.preferencesDirectoryLabel = new System.Windows.Forms.Label();
            this.selectPreferencesDirectoryButton = new System.Windows.Forms.Button();
            this.preferencesDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.removeSharedDirectoryButton = new System.Windows.Forms.Button();
            this.addSharedDirectoryButton = new System.Windows.Forms.Button();
            this.sharedDirectoriesLabel = new System.Windows.Forms.Label();
            this.sharedDirectoriesDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sharedDirectoriesPictureBox = new System.Windows.Forms.PictureBox();
            this.otherDirectoriesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedDirectoriesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedDirectoriesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectIncomingDirectoryButton
            // 
            this.selectIncomingDirectoryButton.AccessibleDescription = null;
            this.selectIncomingDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.selectIncomingDirectoryButton, "selectIncomingDirectoryButton");
            this.selectIncomingDirectoryButton.BackgroundImage = null;
            this.selectIncomingDirectoryButton.Font = null;
            this.selectIncomingDirectoryButton.Name = "selectIncomingDirectoryButton";
            this.selectIncomingDirectoryButton.Click += new System.EventHandler(this.selectIncomingDirectoryButton_Click);
            // 
            // incomingDirectoryTextBox
            // 
            this.incomingDirectoryTextBox.AccessibleDescription = null;
            this.incomingDirectoryTextBox.AccessibleName = null;
            resources.ApplyResources(this.incomingDirectoryTextBox, "incomingDirectoryTextBox");
            this.incomingDirectoryTextBox.BackgroundImage = null;
            this.incomingDirectoryTextBox.Font = null;
            this.incomingDirectoryTextBox.Name = "incomingDirectoryTextBox";
            this.incomingDirectoryTextBox.ReadOnly = true;
            // 
            // selectTemporaryDirectoryButton
            // 
            this.selectTemporaryDirectoryButton.AccessibleDescription = null;
            this.selectTemporaryDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.selectTemporaryDirectoryButton, "selectTemporaryDirectoryButton");
            this.selectTemporaryDirectoryButton.BackgroundImage = null;
            this.selectTemporaryDirectoryButton.Font = null;
            this.selectTemporaryDirectoryButton.Name = "selectTemporaryDirectoryButton";
            this.selectTemporaryDirectoryButton.Click += new System.EventHandler(this.selectTemporaryDirectoryButton_Click);
            // 
            // temporaryDirectoryTextBox
            // 
            this.temporaryDirectoryTextBox.AccessibleDescription = null;
            this.temporaryDirectoryTextBox.AccessibleName = null;
            resources.ApplyResources(this.temporaryDirectoryTextBox, "temporaryDirectoryTextBox");
            this.temporaryDirectoryTextBox.BackgroundImage = null;
            this.temporaryDirectoryTextBox.Font = null;
            this.temporaryDirectoryTextBox.Name = "temporaryDirectoryTextBox";
            this.temporaryDirectoryTextBox.ReadOnly = true;
            // 
            // directoryFolderBrowserDialog
            // 
            resources.ApplyResources(this.directoryFolderBrowserDialog, "directoryFolderBrowserDialog");
            // 
            // otherDirectoriesGroupBox
            // 
            this.otherDirectoriesGroupBox.AccessibleDescription = null;
            this.otherDirectoriesGroupBox.AccessibleName = null;
            resources.ApplyResources(this.otherDirectoriesGroupBox, "otherDirectoriesGroupBox");
            this.otherDirectoriesGroupBox.BackgroundImage = null;
            this.otherDirectoriesGroupBox.Controls.Add(this.corruptDirectoryLabel);
            this.otherDirectoriesGroupBox.Controls.Add(this.selectCorruptDirectoryButton);
            this.otherDirectoriesGroupBox.Controls.Add(this.corruptDirectoryTextBox);
            this.otherDirectoriesGroupBox.Controls.Add(this.selectLogDirectoryButton);
            this.otherDirectoriesGroupBox.Controls.Add(this.logDirectoryTextBox);
            this.otherDirectoriesGroupBox.Controls.Add(this.incomingDirectoryLabel);
            this.otherDirectoriesGroupBox.Controls.Add(this.temporaryDirectoryLabel);
            this.otherDirectoriesGroupBox.Controls.Add(this.logDirectoryLabel);
            this.otherDirectoriesGroupBox.Controls.Add(this.preferencesDirectoryLabel);
            this.otherDirectoriesGroupBox.Controls.Add(this.selectIncomingDirectoryButton);
            this.otherDirectoriesGroupBox.Controls.Add(this.incomingDirectoryTextBox);
            this.otherDirectoriesGroupBox.Controls.Add(this.selectTemporaryDirectoryButton);
            this.otherDirectoriesGroupBox.Controls.Add(this.selectPreferencesDirectoryButton);
            this.otherDirectoriesGroupBox.Controls.Add(this.temporaryDirectoryTextBox);
            this.otherDirectoriesGroupBox.Controls.Add(this.preferencesDirectoryTextBox);
            this.otherDirectoriesGroupBox.Font = null;
            this.otherDirectoriesGroupBox.Name = "otherDirectoriesGroupBox";
            this.otherDirectoriesGroupBox.TabStop = false;
            // 
            // corruptDirectoryLabel
            // 
            this.corruptDirectoryLabel.AccessibleDescription = null;
            this.corruptDirectoryLabel.AccessibleName = null;
            resources.ApplyResources(this.corruptDirectoryLabel, "corruptDirectoryLabel");
            this.corruptDirectoryLabel.Font = null;
            this.corruptDirectoryLabel.Name = "corruptDirectoryLabel";
            // 
            // selectCorruptDirectoryButton
            // 
            this.selectCorruptDirectoryButton.AccessibleDescription = null;
            this.selectCorruptDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.selectCorruptDirectoryButton, "selectCorruptDirectoryButton");
            this.selectCorruptDirectoryButton.BackgroundImage = null;
            this.selectCorruptDirectoryButton.Font = null;
            this.selectCorruptDirectoryButton.Name = "selectCorruptDirectoryButton";
            this.selectCorruptDirectoryButton.Click += new System.EventHandler(this.selectCorruptDirectoryButton_Click);
            // 
            // corruptDirectoryTextBox
            // 
            this.corruptDirectoryTextBox.AccessibleDescription = null;
            this.corruptDirectoryTextBox.AccessibleName = null;
            resources.ApplyResources(this.corruptDirectoryTextBox, "corruptDirectoryTextBox");
            this.corruptDirectoryTextBox.BackgroundImage = null;
            this.corruptDirectoryTextBox.Font = null;
            this.corruptDirectoryTextBox.Name = "corruptDirectoryTextBox";
            this.corruptDirectoryTextBox.ReadOnly = true;
            // 
            // selectLogDirectoryButton
            // 
            this.selectLogDirectoryButton.AccessibleDescription = null;
            this.selectLogDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.selectLogDirectoryButton, "selectLogDirectoryButton");
            this.selectLogDirectoryButton.BackgroundImage = null;
            this.selectLogDirectoryButton.Font = null;
            this.selectLogDirectoryButton.Name = "selectLogDirectoryButton";
            this.selectLogDirectoryButton.Click += new System.EventHandler(this.selectLogDirectoryButton_Click);
            // 
            // logDirectoryTextBox
            // 
            this.logDirectoryTextBox.AccessibleDescription = null;
            this.logDirectoryTextBox.AccessibleName = null;
            resources.ApplyResources(this.logDirectoryTextBox, "logDirectoryTextBox");
            this.logDirectoryTextBox.BackgroundImage = null;
            this.logDirectoryTextBox.Font = null;
            this.logDirectoryTextBox.Name = "logDirectoryTextBox";
            this.logDirectoryTextBox.ReadOnly = true;
            // 
            // incomingDirectoryLabel
            // 
            this.incomingDirectoryLabel.AccessibleDescription = null;
            this.incomingDirectoryLabel.AccessibleName = null;
            resources.ApplyResources(this.incomingDirectoryLabel, "incomingDirectoryLabel");
            this.incomingDirectoryLabel.Font = null;
            this.incomingDirectoryLabel.Name = "incomingDirectoryLabel";
            // 
            // temporaryDirectoryLabel
            // 
            this.temporaryDirectoryLabel.AccessibleDescription = null;
            this.temporaryDirectoryLabel.AccessibleName = null;
            resources.ApplyResources(this.temporaryDirectoryLabel, "temporaryDirectoryLabel");
            this.temporaryDirectoryLabel.Font = null;
            this.temporaryDirectoryLabel.Name = "temporaryDirectoryLabel";
            // 
            // logDirectoryLabel
            // 
            this.logDirectoryLabel.AccessibleDescription = null;
            this.logDirectoryLabel.AccessibleName = null;
            resources.ApplyResources(this.logDirectoryLabel, "logDirectoryLabel");
            this.logDirectoryLabel.Font = null;
            this.logDirectoryLabel.Name = "logDirectoryLabel";
            // 
            // preferencesDirectoryLabel
            // 
            this.preferencesDirectoryLabel.AccessibleDescription = null;
            this.preferencesDirectoryLabel.AccessibleName = null;
            resources.ApplyResources(this.preferencesDirectoryLabel, "preferencesDirectoryLabel");
            this.preferencesDirectoryLabel.Font = null;
            this.preferencesDirectoryLabel.Name = "preferencesDirectoryLabel";
            // 
            // selectPreferencesDirectoryButton
            // 
            this.selectPreferencesDirectoryButton.AccessibleDescription = null;
            this.selectPreferencesDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.selectPreferencesDirectoryButton, "selectPreferencesDirectoryButton");
            this.selectPreferencesDirectoryButton.BackgroundImage = null;
            this.selectPreferencesDirectoryButton.Font = null;
            this.selectPreferencesDirectoryButton.Name = "selectPreferencesDirectoryButton";
            this.selectPreferencesDirectoryButton.Click += new System.EventHandler(this.selectPreferencesDirectoryButton_Click);
            // 
            // preferencesDirectoryTextBox
            // 
            this.preferencesDirectoryTextBox.AccessibleDescription = null;
            this.preferencesDirectoryTextBox.AccessibleName = null;
            resources.ApplyResources(this.preferencesDirectoryTextBox, "preferencesDirectoryTextBox");
            this.preferencesDirectoryTextBox.BackgroundImage = null;
            this.preferencesDirectoryTextBox.Font = null;
            this.preferencesDirectoryTextBox.Name = "preferencesDirectoryTextBox";
            this.preferencesDirectoryTextBox.ReadOnly = true;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // removeSharedDirectoryButton
            // 
            this.removeSharedDirectoryButton.AccessibleDescription = null;
            this.removeSharedDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.removeSharedDirectoryButton, "removeSharedDirectoryButton");
            this.removeSharedDirectoryButton.BackgroundImage = null;
            this.removeSharedDirectoryButton.Font = null;
            this.removeSharedDirectoryButton.Name = "removeSharedDirectoryButton";
            this.removeSharedDirectoryButton.Click += new System.EventHandler(this.removeSharedDirectoryButton_Click);
            // 
            // addSharedDirectoryButton
            // 
            this.addSharedDirectoryButton.AccessibleDescription = null;
            this.addSharedDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.addSharedDirectoryButton, "addSharedDirectoryButton");
            this.addSharedDirectoryButton.BackgroundImage = null;
            this.addSharedDirectoryButton.Font = null;
            this.addSharedDirectoryButton.Name = "addSharedDirectoryButton";
            this.addSharedDirectoryButton.Click += new System.EventHandler(this.addSharedDirectoryButton_Click);
            // 
            // sharedDirectoriesLabel
            // 
            this.sharedDirectoriesLabel.AccessibleDescription = null;
            this.sharedDirectoriesLabel.AccessibleName = null;
            resources.ApplyResources(this.sharedDirectoriesLabel, "sharedDirectoriesLabel");
            this.sharedDirectoriesLabel.Font = null;
            this.sharedDirectoriesLabel.Name = "sharedDirectoriesLabel";
            // 
            // sharedDirectoriesDataGridView
            // 
            this.sharedDirectoriesDataGridView.AccessibleDescription = null;
            this.sharedDirectoriesDataGridView.AccessibleName = null;
            this.sharedDirectoriesDataGridView.AllowUserToAddRows = false;
            this.sharedDirectoriesDataGridView.AllowUserToDeleteRows = false;
            this.sharedDirectoriesDataGridView.AllowUserToOrderColumns = true;
            this.sharedDirectoriesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.sharedDirectoriesDataGridView, "sharedDirectoriesDataGridView");
            this.sharedDirectoriesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sharedDirectoriesDataGridView.BackgroundImage = null;
            this.sharedDirectoriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sharedDirectoriesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sharedDirectoriesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sharedDirectoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sharedDirectoriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.Path});
            this.sharedDirectoriesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.sharedDirectoriesDataGridView.Font = null;
            this.sharedDirectoriesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.sharedDirectoriesDataGridView.Name = "sharedDirectoriesDataGridView";
            this.sharedDirectoriesDataGridView.ReadOnly = true;
            this.sharedDirectoriesDataGridView.RowHeadersVisible = false;
            this.sharedDirectoriesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sharedDirectoriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sharedDirectoriesDataGridView.ShowCellErrors = false;
            this.sharedDirectoriesDataGridView.ShowCellToolTips = false;
            this.sharedDirectoriesDataGridView.ShowEditingIcon = false;
            this.sharedDirectoriesDataGridView.ShowRowErrors = false;
            this.sharedDirectoriesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sharedDirectoriesDataGridView_DataError);
            this.sharedDirectoriesDataGridView.SelectionChanged += new System.EventHandler(this.sharedDirectoriesDataGridView_SelectionChanged);
            // 
            // Icon
            // 
            resources.ApplyResources(this.Icon, "Icon");
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Path, "Path");
            this.Path.MaxInputLength = 0;
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // sharedDirectoriesPictureBox
            // 
            this.sharedDirectoriesPictureBox.AccessibleDescription = null;
            this.sharedDirectoriesPictureBox.AccessibleName = null;
            resources.ApplyResources(this.sharedDirectoriesPictureBox, "sharedDirectoriesPictureBox");
            this.sharedDirectoriesPictureBox.BackgroundImage = null;
            this.sharedDirectoriesPictureBox.Font = null;
            this.sharedDirectoriesPictureBox.Image = global::Regensburger.RShare.Properties.Resources.directories_16x16;
            this.sharedDirectoriesPictureBox.ImageLocation = null;
            this.sharedDirectoriesPictureBox.Name = "sharedDirectoriesPictureBox";
            this.sharedDirectoriesPictureBox.TabStop = false;
            // 
            // DirectoriesControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.sharedDirectoriesPictureBox);
            this.Controls.Add(this.sharedDirectoriesLabel);
            this.Controls.Add(this.sharedDirectoriesDataGridView);
            this.Controls.Add(this.removeSharedDirectoryButton);
            this.Controls.Add(this.addSharedDirectoryButton);
            this.Controls.Add(this.otherDirectoriesGroupBox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "DirectoriesControl";
            this.otherDirectoriesGroupBox.ResumeLayout(false);
            this.otherDirectoriesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedDirectoriesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedDirectoriesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectIncomingDirectoryButton;
        private System.Windows.Forms.TextBox incomingDirectoryTextBox;
        private System.Windows.Forms.Button selectTemporaryDirectoryButton;
        private System.Windows.Forms.TextBox temporaryDirectoryTextBox;
        private System.Windows.Forms.FolderBrowserDialog directoryFolderBrowserDialog;
        private System.Windows.Forms.GroupBox otherDirectoriesGroupBox;
        private System.Windows.Forms.Button selectPreferencesDirectoryButton;
        private System.Windows.Forms.TextBox preferencesDirectoryTextBox;
        private System.Windows.Forms.Label temporaryDirectoryLabel;
        private System.Windows.Forms.Label logDirectoryLabel;
        private System.Windows.Forms.Label preferencesDirectoryLabel;
        private System.Windows.Forms.Label incomingDirectoryLabel;
        private System.Windows.Forms.Button selectLogDirectoryButton;
        private System.Windows.Forms.TextBox logDirectoryTextBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label corruptDirectoryLabel;
        private System.Windows.Forms.Button selectCorruptDirectoryButton;
        private System.Windows.Forms.TextBox corruptDirectoryTextBox;
        private DoubleBufferedDataGridView sharedDirectoriesDataGridView;
        private System.Windows.Forms.Button removeSharedDirectoryButton;
        private System.Windows.Forms.Button addSharedDirectoryButton;
        private System.Windows.Forms.PictureBox sharedDirectoriesPictureBox;
        private System.Windows.Forms.Label sharedDirectoriesLabel;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
    }
}
