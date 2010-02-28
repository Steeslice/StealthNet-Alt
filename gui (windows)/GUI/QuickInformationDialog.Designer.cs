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
    partial class QuickInformationDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickInformationDialog));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.openIncomingDirectoryPictureBox = new System.Windows.Forms.PictureBox();
            this.preferencesPictureBox = new System.Windows.Forms.PictureBox();
            this.restorePictureBox = new System.Windows.Forms.PictureBox();
            this.upstreamLabel = new System.Windows.Forms.Label();
            this.downstreamLabel = new System.Windows.Forms.Label();
            this.connectionsLabel = new System.Windows.Forms.Label();
            this.upstreamPictureBox = new System.Windows.Forms.PictureBox();
            this.downstreamPictureBox = new System.Windows.Forms.PictureBox();
            this.connectionsPictureBox = new System.Windows.Forms.PictureBox();
            this.accessibilityLabel = new System.Windows.Forms.Label();
            this.accessibilityPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openIncomingDirectoryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preferencesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restorePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upstreamPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downstreamPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessibilityPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.openIncomingDirectoryPictureBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.preferencesPictureBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.restorePictureBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.upstreamLabel);
            this.toolStripContainer.ContentPanel.Controls.Add(this.downstreamLabel);
            this.toolStripContainer.ContentPanel.Controls.Add(this.connectionsLabel);
            this.toolStripContainer.ContentPanel.Controls.Add(this.upstreamPictureBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.downstreamPictureBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.connectionsPictureBox);
            this.toolStripContainer.ContentPanel.Controls.Add(this.accessibilityLabel);
            this.toolStripContainer.ContentPanel.Controls.Add(this.accessibilityPictureBox);
            this.toolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            resources.ApplyResources(this.toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            resources.ApplyResources(this.toolStripContainer, "toolStripContainer");
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.TopToolStripPanelVisible = false;
            // 
            // openIncomingDirectoryPictureBox
            // 
            resources.ApplyResources(this.openIncomingDirectoryPictureBox, "openIncomingDirectoryPictureBox");
            this.openIncomingDirectoryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.openIncomingDirectoryPictureBox.Image = global::Regensburger.RShare.Properties.Resources.download_16x16;
            this.openIncomingDirectoryPictureBox.Name = "openIncomingDirectoryPictureBox";
            this.openIncomingDirectoryPictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.openIncomingDirectoryPictureBox, resources.GetString("openIncomingDirectoryPictureBox.ToolTip"));
            this.openIncomingDirectoryPictureBox.Click += new System.EventHandler(this.openIncomingDirectoryPictureBox_Click);
            // 
            // preferencesPictureBox
            // 
            resources.ApplyResources(this.preferencesPictureBox, "preferencesPictureBox");
            this.preferencesPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.preferencesPictureBox.Image = global::Regensburger.RShare.Properties.Resources.preferences_16x16;
            this.preferencesPictureBox.Name = "preferencesPictureBox";
            this.preferencesPictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.preferencesPictureBox, resources.GetString("preferencesPictureBox.ToolTip"));
            this.preferencesPictureBox.Click += new System.EventHandler(this.preferencesPictureBox_Click);
            // 
            // restorePictureBox
            // 
            resources.ApplyResources(this.restorePictureBox, "restorePictureBox");
            this.restorePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.restorePictureBox.Image = global::Regensburger.RShare.Properties.Resources.restore_16x16;
            this.restorePictureBox.Name = "restorePictureBox";
            this.restorePictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.restorePictureBox, resources.GetString("restorePictureBox.ToolTip"));
            this.restorePictureBox.Click += new System.EventHandler(this.restorePictureBox_Click);
            // 
            // upstreamLabel
            // 
            resources.ApplyResources(this.upstreamLabel, "upstreamLabel");
            this.upstreamLabel.BackColor = System.Drawing.Color.Transparent;
            this.upstreamLabel.Name = "upstreamLabel";
            // 
            // downstreamLabel
            // 
            resources.ApplyResources(this.downstreamLabel, "downstreamLabel");
            this.downstreamLabel.BackColor = System.Drawing.Color.Transparent;
            this.downstreamLabel.Name = "downstreamLabel";
            // 
            // connectionsLabel
            // 
            resources.ApplyResources(this.connectionsLabel, "connectionsLabel");
            this.connectionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectionsLabel.Name = "connectionsLabel";
            // 
            // upstreamPictureBox
            // 
            this.upstreamPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.upstreamPictureBox.Image = global::Regensburger.RShare.Properties.Resources.upstream_16x16;
            resources.ApplyResources(this.upstreamPictureBox, "upstreamPictureBox");
            this.upstreamPictureBox.Name = "upstreamPictureBox";
            this.upstreamPictureBox.TabStop = false;
            // 
            // downstreamPictureBox
            // 
            this.downstreamPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.downstreamPictureBox.Image = global::Regensburger.RShare.Properties.Resources.downstream_16x16;
            resources.ApplyResources(this.downstreamPictureBox, "downstreamPictureBox");
            this.downstreamPictureBox.Name = "downstreamPictureBox";
            this.downstreamPictureBox.TabStop = false;
            // 
            // connectionsPictureBox
            // 
            this.connectionsPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.connectionsPictureBox.Image = global::Regensburger.RShare.Properties.Resources.connections_16x16;
            resources.ApplyResources(this.connectionsPictureBox, "connectionsPictureBox");
            this.connectionsPictureBox.Name = "connectionsPictureBox";
            this.connectionsPictureBox.TabStop = false;
            // 
            // accessibilityLabel
            // 
            resources.ApplyResources(this.accessibilityLabel, "accessibilityLabel");
            this.accessibilityLabel.BackColor = System.Drawing.Color.Transparent;
            this.accessibilityLabel.Name = "accessibilityLabel";
            // 
            // accessibilityPictureBox
            // 
            this.accessibilityPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.accessibilityPictureBox, "accessibilityPictureBox");
            this.accessibilityPictureBox.Name = "accessibilityPictureBox";
            this.accessibilityPictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // QuickInformationDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickInformationDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.ContentPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openIncomingDirectoryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preferencesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restorePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upstreamPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downstreamPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessibilityPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.Label accessibilityLabel;
        private System.Windows.Forms.PictureBox accessibilityPictureBox;
        private System.Windows.Forms.PictureBox downstreamPictureBox;
        private System.Windows.Forms.PictureBox connectionsPictureBox;
        private System.Windows.Forms.PictureBox upstreamPictureBox;
        private System.Windows.Forms.Label upstreamLabel;
        private System.Windows.Forms.Label downstreamLabel;
        private System.Windows.Forms.Label connectionsLabel;
        private System.Windows.Forms.PictureBox openIncomingDirectoryPictureBox;
        private System.Windows.Forms.PictureBox preferencesPictureBox;
        private System.Windows.Forms.PictureBox restorePictureBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
    }
}