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
    partial class DownloadSourcesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadSourcesControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.sourcesDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.FileIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rating = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sourcesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // sourcesDataGridView
            // 
            this.sourcesDataGridView.AccessibleDescription = null;
            this.sourcesDataGridView.AccessibleName = null;
            this.sourcesDataGridView.AllowUserToAddRows = false;
            this.sourcesDataGridView.AllowUserToDeleteRows = false;
            this.sourcesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.sourcesDataGridView, "sourcesDataGridView");
            this.sourcesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sourcesDataGridView.BackgroundImage = null;
            this.sourcesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sourcesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sourcesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sourcesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sourcesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sourcesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sourcesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileIcon,
            this.Rating,
            this.FileName,
            this.Comment});
            this.sourcesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.sourcesDataGridView.Font = null;
            this.sourcesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.sourcesDataGridView.Name = "sourcesDataGridView";
            this.sourcesDataGridView.ReadOnly = true;
            this.sourcesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sourcesDataGridView.RowHeadersVisible = false;
            this.sourcesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sourcesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sourcesDataGridView.ShowCellErrors = false;
            this.sourcesDataGridView.ShowCellToolTips = false;
            this.sourcesDataGridView.ShowEditingIcon = false;
            this.sourcesDataGridView.ShowRowErrors = false;
            this.sourcesDataGridView.StandardTab = true;
            this.sourcesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sourcesDataDataGridView_DataError);
            // 
            // FileIcon
            // 
            resources.ApplyResources(this.FileIcon, "FileIcon");
            this.FileIcon.Name = "FileIcon";
            this.FileIcon.ReadOnly = true;
            this.FileIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Rating
            // 
            resources.ApplyResources(this.Rating, "Rating");
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            this.Rating.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Comment, "Comment");
            this.Comment.MaxInputLength = 0;
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // DownloadSourcesControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.sourcesDataGridView);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "DownloadSourcesControl";
            ((System.ComponentModel.ISupportInitialize)(this.sourcesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private Regensburger.RShare.DoubleBufferedDataGridView sourcesDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn FileIcon;
        private System.Windows.Forms.DataGridViewImageColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}
