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
    partial class UploadsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadsControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uploadsLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.uploadsPictureBox = new System.Windows.Forms.PictureBox();
            this.uploadsDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewImageColumn();
            this.Remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uploadsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadsLabel
            // 
            resources.ApplyResources(this.uploadsLabel, "uploadsLabel");
            this.uploadsLabel.Name = "uploadsLabel";
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // uploadsPictureBox
            // 
            this.uploadsPictureBox.Image = global::Regensburger.RShare.Properties.Resources.upload_16x16;
            resources.ApplyResources(this.uploadsPictureBox, "uploadsPictureBox");
            this.uploadsPictureBox.Name = "uploadsPictureBox";
            this.uploadsPictureBox.TabStop = false;
            // 
            // uploadsDataGridView
            // 
            this.uploadsDataGridView.AllowUserToAddRows = false;
            this.uploadsDataGridView.AllowUserToDeleteRows = false;
            this.uploadsDataGridView.AllowUserToOrderColumns = true;
            this.uploadsDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.uploadsDataGridView, "uploadsDataGridView");
            this.uploadsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.uploadsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uploadsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.uploadsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.uploadsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uploadsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileSize,
            this.Completed,
            this.Progress,
            this.Remaining,
            this.lastRequest});
            this.uploadsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uploadsDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.uploadsDataGridView.Name = "uploadsDataGridView";
            this.uploadsDataGridView.ReadOnly = true;
            this.uploadsDataGridView.RowHeadersVisible = false;
            this.uploadsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.uploadsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uploadsDataGridView.ShowCellErrors = false;
            this.uploadsDataGridView.ShowCellToolTips = false;
            this.uploadsDataGridView.ShowEditingIcon = false;
            this.uploadsDataGridView.ShowRowErrors = false;
            this.uploadsDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.uploadsDataGridView_SortCompare);
            this.uploadsDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.uploadsDataGridView_ColumnDisplayIndexChanged);
            this.uploadsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.uploadsDataGridView_DataError);
            this.uploadsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.uploadsDataGridView_ColumnWidthChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FileSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.FileSize.FillWeight = 50F;
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
            resources.ApplyResources(this.Completed, "Completed");
            this.Completed.MaxInputLength = 0;
            this.Completed.Name = "Completed";
            this.Completed.ReadOnly = true;
            // 
            // Progress
            // 
            this.Progress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Progress.FillWeight = 200F;
            resources.ApplyResources(this.Progress, "Progress");
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            this.Progress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Remaining
            // 
            this.Remaining.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Remaining.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Remaining, "Remaining");
            this.Remaining.MaxInputLength = 0;
            this.Remaining.Name = "Remaining";
            this.Remaining.ReadOnly = true;
            // 
            // lastRequest
            // 
            this.lastRequest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.lastRequest.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.lastRequest, "lastRequest");
            this.lastRequest.MaxInputLength = 0;
            this.lastRequest.Name = "lastRequest";
            this.lastRequest.ReadOnly = true;
            // 
            // UploadsControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uploadsDataGridView);
            this.Controls.Add(this.uploadsLabel);
            this.Controls.Add(this.uploadsPictureBox);
            this.DoubleBuffered = true;
            this.Name = "UploadsControl";
            ((System.ComponentModel.ISupportInitialize)(this.uploadsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox uploadsPictureBox;
        private System.Windows.Forms.Label uploadsLabel;
        private Regensburger.RShare.DoubleBufferedDataGridView uploadsDataGridView;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Completed;
        private System.Windows.Forms.DataGridViewImageColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRequest;
    }
}
