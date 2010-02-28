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
    partial class SearchResultInformationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResultInformationControl));
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.fileHashTextBox = new System.Windows.Forms.TextBox();
            this.fileHashLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.fileSizeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.AccessibleDescription = null;
            this.iconPictureBox.AccessibleName = null;
            resources.ApplyResources(this.iconPictureBox, "iconPictureBox");
            this.iconPictureBox.BackgroundImage = null;
            this.iconPictureBox.Font = null;
            this.iconPictureBox.ImageLocation = null;
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.TabStop = false;
            // 
            // fileHashTextBox
            // 
            this.fileHashTextBox.AccessibleDescription = null;
            this.fileHashTextBox.AccessibleName = null;
            resources.ApplyResources(this.fileHashTextBox, "fileHashTextBox");
            this.fileHashTextBox.BackgroundImage = null;
            this.fileHashTextBox.Font = null;
            this.fileHashTextBox.Name = "fileHashTextBox";
            this.fileHashTextBox.ReadOnly = true;
            // 
            // fileHashLabel
            // 
            this.fileHashLabel.AccessibleDescription = null;
            this.fileHashLabel.AccessibleName = null;
            resources.ApplyResources(this.fileHashLabel, "fileHashLabel");
            this.fileHashLabel.Font = null;
            this.fileHashLabel.Name = "fileHashLabel";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AccessibleDescription = null;
            this.fileNameLabel.AccessibleName = null;
            resources.ApplyResources(this.fileNameLabel, "fileNameLabel");
            this.fileNameLabel.Font = null;
            this.fileNameLabel.Name = "fileNameLabel";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.AccessibleDescription = null;
            this.fileNameTextBox.AccessibleName = null;
            resources.ApplyResources(this.fileNameTextBox, "fileNameTextBox");
            this.fileNameTextBox.BackgroundImage = null;
            this.fileNameTextBox.Font = null;
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AccessibleDescription = null;
            this.fileSizeLabel.AccessibleName = null;
            resources.ApplyResources(this.fileSizeLabel, "fileSizeLabel");
            this.fileSizeLabel.Font = null;
            this.fileSizeLabel.Name = "fileSizeLabel";
            // 
            // fileSizeTextBox
            // 
            this.fileSizeTextBox.AccessibleDescription = null;
            this.fileSizeTextBox.AccessibleName = null;
            resources.ApplyResources(this.fileSizeTextBox, "fileSizeTextBox");
            this.fileSizeTextBox.BackgroundImage = null;
            this.fileSizeTextBox.Font = null;
            this.fileSizeTextBox.Name = "fileSizeTextBox";
            this.fileSizeTextBox.ReadOnly = true;
            // 
            // SearchResultInformationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.fileHashTextBox);
            this.Controls.Add(this.fileHashLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.fileSizeLabel);
            this.Controls.Add(this.fileSizeTextBox);
            this.Controls.Add(this.iconPictureBox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "SearchResultInformationControl";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.TextBox fileHashTextBox;
        private System.Windows.Forms.Label fileHashLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.TextBox fileSizeTextBox;

    }
}
