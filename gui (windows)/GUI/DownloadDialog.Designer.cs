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
    partial class DownloadDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadDialog));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.subFolderTextBox = new System.Windows.Forms.TextBox();
            this.subFolderLabel = new System.Windows.Forms.Label();
            this.downloadButton = new System.Windows.Forms.Button();
            this.pasteFromClipboardLinkLabel = new System.Windows.Forms.LinkLabel();
            this.stealthnetLinkTextBox = new System.Windows.Forms.TextBox();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            this.toolStripContainer.BottomToolStripPanel.Font = null;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.AccessibleDescription = null;
            this.toolStripContainer.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            this.toolStripContainer.ContentPanel.BackgroundImage = null;
            this.toolStripContainer.ContentPanel.Controls.Add(this.subFolderTextBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.subFolderLabel);
            this.toolStripContainer.ContentPanel.Controls.Add(this.downloadButton);
            this.toolStripContainer.ContentPanel.Controls.Add(this.pasteFromClipboardLinkLabel);
            this.toolStripContainer.ContentPanel.Controls.Add(this.stealthnetLinkTextBox);
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
            // statusStrip
            // 
            this.statusStrip.AccessibleDescription = null;
            this.statusStrip.AccessibleName = null;
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.BackgroundImage = null;
            this.statusStrip.Font = null;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.SizingGrip = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AccessibleDescription = null;
            this.toolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            this.toolStripStatusLabel.BackgroundImage = null;
            this.toolStripStatusLabel.Image = global::Regensburger.RShare.Properties.Resources.information_16x16;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            // 
            // subFolderTextBox
            // 
            this.subFolderTextBox.AccessibleDescription = null;
            this.subFolderTextBox.AccessibleName = null;
            resources.ApplyResources(this.subFolderTextBox, "subFolderTextBox");
            this.subFolderTextBox.BackgroundImage = null;
            this.subFolderTextBox.Font = null;
            this.subFolderTextBox.Name = "subFolderTextBox";
            this.subFolderTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.subFolderTextBox_KeyPress);
            // 
            // subFolderLabel
            // 
            this.subFolderLabel.AccessibleDescription = null;
            this.subFolderLabel.AccessibleName = null;
            resources.ApplyResources(this.subFolderLabel, "subFolderLabel");
            this.subFolderLabel.BackColor = System.Drawing.Color.Transparent;
            this.subFolderLabel.Font = null;
            this.subFolderLabel.Name = "subFolderLabel";
            // 
            // downloadButton
            // 
            this.downloadButton.AccessibleDescription = null;
            this.downloadButton.AccessibleName = null;
            resources.ApplyResources(this.downloadButton, "downloadButton");
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.BackgroundImage = null;
            this.downloadButton.Font = null;
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // pasteFromClipboardLinkLabel
            // 
            this.pasteFromClipboardLinkLabel.AccessibleDescription = null;
            this.pasteFromClipboardLinkLabel.AccessibleName = null;
            resources.ApplyResources(this.pasteFromClipboardLinkLabel, "pasteFromClipboardLinkLabel");
            this.pasteFromClipboardLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.pasteFromClipboardLinkLabel.Font = null;
            this.pasteFromClipboardLinkLabel.Name = "pasteFromClipboardLinkLabel";
            this.pasteFromClipboardLinkLabel.TabStop = true;
            this.pasteFromClipboardLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pasteFromClipboardLinkLabel_LinkClicked);
            // 
            // stealthnetLinkTextBox
            // 
            this.stealthnetLinkTextBox.AccessibleDescription = null;
            this.stealthnetLinkTextBox.AccessibleName = null;
            resources.ApplyResources(this.stealthnetLinkTextBox, "stealthnetLinkTextBox");
            this.stealthnetLinkTextBox.BackgroundImage = null;
            this.stealthnetLinkTextBox.Font = null;
            this.stealthnetLinkTextBox.HideSelection = false;
            this.stealthnetLinkTextBox.Name = "stealthnetLinkTextBox";
            this.stealthnetLinkTextBox.TextChanged += new System.EventHandler(this.fileHashTextBox_TextChanged);
            this.stealthnetLinkTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fileHashTextBox_KeyDown);
            // 
            // DownloadDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.toolStripContainer);
            this.DoubleBuffered = true;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.DownloadDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DownloadDialog_KeyDown);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.ContentPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox stealthnetLinkTextBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.LinkLabel pasteFromClipboardLinkLabel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label subFolderLabel;
        private System.Windows.Forms.TextBox subFolderTextBox;

    }
}