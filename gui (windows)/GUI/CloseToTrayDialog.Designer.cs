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
    partial class CloseToTrayDialog
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseToTrayDialog));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.cancelButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.AccessibleDescription = null;
            this.toolStripContainer.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainer, "toolStripContainer");
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.BottomToolStripPanel.AccessibleName = null;
            this.toolStripContainer.BottomToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.BottomToolStripPanel, "toolStripContainer.BottomToolStripPanel");
            this.toolStripContainer.BottomToolStripPanel.Font = null;
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.AccessibleDescription = null;
            this.toolStripContainer.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            this.toolStripContainer.ContentPanel.BackgroundImage = null;
            this.toolStripContainer.ContentPanel.Controls.Add(this.cancelButton);
            this.toolStripContainer.ContentPanel.Controls.Add(this.noButton);
            this.toolStripContainer.ContentPanel.Controls.Add(this.yesButton);
            this.toolStripContainer.ContentPanel.Controls.Add(this.checkBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.label);
            this.toolStripContainer.ContentPanel.Controls.Add(this.pictureBox);
            this.toolStripContainer.ContentPanel.Font = null;
            this.toolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.toolStripContainer.Font = null;
            // 
            // toolStripContainer.LeftToolStripPanel
            // 
            this.toolStripContainer.LeftToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.LeftToolStripPanel.AccessibleName = null;
            this.toolStripContainer.LeftToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.LeftToolStripPanel, "toolStripContainer.LeftToolStripPanel");
            this.toolStripContainer.LeftToolStripPanel.Font = null;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Name = "toolStripContainer";
            // 
            // toolStripContainer.RightToolStripPanel
            // 
            this.toolStripContainer.RightToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.RightToolStripPanel.AccessibleName = null;
            this.toolStripContainer.RightToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.RightToolStripPanel, "toolStripContainer.RightToolStripPanel");
            this.toolStripContainer.RightToolStripPanel.Font = null;
            this.toolStripContainer.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.TopToolStripPanel.AccessibleName = null;
            this.toolStripContainer.TopToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.TopToolStripPanel, "toolStripContainer.TopToolStripPanel");
            this.toolStripContainer.TopToolStripPanel.Font = null;
            this.toolStripContainer.TopToolStripPanelVisible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleDescription = null;
            this.cancelButton.AccessibleName = null;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.BackgroundImage = null;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = null;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // noButton
            // 
            this.noButton.AccessibleDescription = null;
            this.noButton.AccessibleName = null;
            resources.ApplyResources(this.noButton, "noButton");
            this.noButton.BackgroundImage = null;
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.noButton.Font = null;
            this.noButton.Name = "noButton";
            this.noButton.UseVisualStyleBackColor = true;
            // 
            // yesButton
            // 
            this.yesButton.AccessibleDescription = null;
            this.yesButton.AccessibleName = null;
            resources.ApplyResources(this.yesButton, "yesButton");
            this.yesButton.BackgroundImage = null;
            this.yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesButton.Font = null;
            this.yesButton.Name = "yesButton";
            this.yesButton.UseVisualStyleBackColor = true;
            // 
            // checkBox
            // 
            this.checkBox.AccessibleDescription = null;
            this.checkBox.AccessibleName = null;
            resources.ApplyResources(this.checkBox, "checkBox");
            this.checkBox.BackColor = System.Drawing.Color.Transparent;
            this.checkBox.BackgroundImage = null;
            this.checkBox.Font = null;
            this.checkBox.Name = "checkBox";
            this.checkBox.UseVisualStyleBackColor = false;
            // 
            // label
            // 
            this.label.AccessibleDescription = null;
            this.label.AccessibleName = null;
            resources.ApplyResources(this.label, "label");
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = null;
            this.label.Name = "label";
            // 
            // pictureBox
            // 
            this.pictureBox.AccessibleDescription = null;
            this.pictureBox.AccessibleName = null;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BackgroundImage = null;
            this.pictureBox.Font = null;
            this.pictureBox.Image = global::Regensburger.RShare.Properties.Resources.closetotray_48x48;
            this.pictureBox.ImageLocation = null;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // CloseToTrayDialog
            // 
            this.AcceptButton = this.yesButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.toolStripContainer);
            this.DoubleBuffered = true;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CloseToTrayDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.ContentPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button yesButton;
    }
}