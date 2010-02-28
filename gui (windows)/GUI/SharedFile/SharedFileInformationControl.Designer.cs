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
    partial class SharedFileInformationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharedFileInformationControl));
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.ratingBadRadioButton = new System.Windows.Forms.RadioButton();
            this.ratingNeutralRadioButton = new System.Windows.Forms.RadioButton();
            this.ratingGoodRadioButton = new System.Windows.Forms.RadioButton();
            this.ratingUnknownRadioButton = new System.Windows.Forms.RadioButton();
            this.fileHashTextBox = new System.Windows.Forms.TextBox();
            this.fileHashLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.fileSizeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // commentLabel
            // 
            this.commentLabel.AccessibleDescription = null;
            this.commentLabel.AccessibleName = null;
            resources.ApplyResources(this.commentLabel, "commentLabel");
            this.commentLabel.Font = null;
            this.commentLabel.Name = "commentLabel";
            // 
            // commentTextBox
            // 
            this.commentTextBox.AccessibleDescription = null;
            this.commentTextBox.AccessibleName = null;
            resources.ApplyResources(this.commentTextBox, "commentTextBox");
            this.commentTextBox.BackgroundImage = null;
            this.commentTextBox.Font = null;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.TextChanged += new System.EventHandler(this.commentTextBox_TextChanged);
            // 
            // ratingLabel
            // 
            this.ratingLabel.AccessibleDescription = null;
            this.ratingLabel.AccessibleName = null;
            resources.ApplyResources(this.ratingLabel, "ratingLabel");
            this.ratingLabel.Font = null;
            this.ratingLabel.Name = "ratingLabel";
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
            // ratingBadRadioButton
            // 
            this.ratingBadRadioButton.AccessibleDescription = null;
            this.ratingBadRadioButton.AccessibleName = null;
            resources.ApplyResources(this.ratingBadRadioButton, "ratingBadRadioButton");
            this.ratingBadRadioButton.BackgroundImage = null;
            this.ratingBadRadioButton.Font = null;
            this.ratingBadRadioButton.Image = global::Regensburger.RShare.Properties.Resources.rating3_16x16;
            this.ratingBadRadioButton.Name = "ratingBadRadioButton";
            this.ratingBadRadioButton.TabStop = true;
            this.ratingBadRadioButton.UseVisualStyleBackColor = true;
            this.ratingBadRadioButton.CheckedChanged += new System.EventHandler(this.ratingBadRadioButton_CheckedChanged);
            // 
            // ratingNeutralRadioButton
            // 
            this.ratingNeutralRadioButton.AccessibleDescription = null;
            this.ratingNeutralRadioButton.AccessibleName = null;
            resources.ApplyResources(this.ratingNeutralRadioButton, "ratingNeutralRadioButton");
            this.ratingNeutralRadioButton.BackgroundImage = null;
            this.ratingNeutralRadioButton.Font = null;
            this.ratingNeutralRadioButton.Image = global::Regensburger.RShare.Properties.Resources.rating2_16x16;
            this.ratingNeutralRadioButton.Name = "ratingNeutralRadioButton";
            this.ratingNeutralRadioButton.TabStop = true;
            this.ratingNeutralRadioButton.UseVisualStyleBackColor = true;
            this.ratingNeutralRadioButton.CheckedChanged += new System.EventHandler(this.ratingNeutralRadioButton_CheckedChanged);
            // 
            // ratingGoodRadioButton
            // 
            this.ratingGoodRadioButton.AccessibleDescription = null;
            this.ratingGoodRadioButton.AccessibleName = null;
            resources.ApplyResources(this.ratingGoodRadioButton, "ratingGoodRadioButton");
            this.ratingGoodRadioButton.BackgroundImage = null;
            this.ratingGoodRadioButton.Font = null;
            this.ratingGoodRadioButton.Image = global::Regensburger.RShare.Properties.Resources.rating1_16x16;
            this.ratingGoodRadioButton.Name = "ratingGoodRadioButton";
            this.ratingGoodRadioButton.TabStop = true;
            this.ratingGoodRadioButton.UseVisualStyleBackColor = true;
            this.ratingGoodRadioButton.CheckedChanged += new System.EventHandler(this.ratingGoodRadioButton_CheckedChanged);
            // 
            // ratingUnknownRadioButton
            // 
            this.ratingUnknownRadioButton.AccessibleDescription = null;
            this.ratingUnknownRadioButton.AccessibleName = null;
            resources.ApplyResources(this.ratingUnknownRadioButton, "ratingUnknownRadioButton");
            this.ratingUnknownRadioButton.BackgroundImage = null;
            this.ratingUnknownRadioButton.Font = null;
            this.ratingUnknownRadioButton.Image = global::Regensburger.RShare.Properties.Resources.rating0_16x16;
            this.ratingUnknownRadioButton.Name = "ratingUnknownRadioButton";
            this.ratingUnknownRadioButton.TabStop = true;
            this.ratingUnknownRadioButton.UseVisualStyleBackColor = true;
            this.ratingUnknownRadioButton.CheckedChanged += new System.EventHandler(this.ratingUnknownRadioButton_CheckedChanged);
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
            // SharedFileInformationControl
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
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.ratingBadRadioButton);
            this.Controls.Add(this.ratingNeutralRadioButton);
            this.Controls.Add(this.ratingGoodRadioButton);
            this.Controls.Add(this.ratingUnknownRadioButton);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.commentTextBox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "SharedFileInformationControl";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.RadioButton ratingUnknownRadioButton;
        private System.Windows.Forms.RadioButton ratingGoodRadioButton;
        private System.Windows.Forms.RadioButton ratingNeutralRadioButton;
        private System.Windows.Forms.RadioButton ratingBadRadioButton;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.TextBox fileHashTextBox;
        private System.Windows.Forms.Label fileHashLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.TextBox fileSizeTextBox;


    }
}
