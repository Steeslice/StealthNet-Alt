//RShare
//Copyright (C) 2009 Lars Regensburger, T.Norad

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

using System.Resources;
using System.Threading;
using System.Globalization;

namespace Regensburger.RShare
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.logIconToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.downstreamToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.upstreamToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.connectionsCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.accessibilityToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.downloadsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uploadsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sharedFilesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statisticsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showRShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeRShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.notifyIconContextMenuStrip.SuspendLayout();
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
            this.toolStripContainer.Name = "toolStripContainer";
            // 
            // toolStripContainer.RightToolStripPanel
            // 
            this.toolStripContainer.RightToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.RightToolStripPanel.AccessibleName = null;
            this.toolStripContainer.RightToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.RightToolStripPanel, "toolStripContainer.RightToolStripPanel");
            this.toolStripContainer.RightToolStripPanel.Font = null;
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.AccessibleDescription = null;
            this.toolStripContainer.TopToolStripPanel.AccessibleName = null;
            this.toolStripContainer.TopToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainer.TopToolStripPanel, "toolStripContainer.TopToolStripPanel");
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.TopToolStripPanel.Font = null;
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.BackgroundImage = null;
            this.statusStrip.Font = null;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logIconToolStripStatusLabel,
            this.logToolStripStatusLabel,
            this.toolStripSeparator6,
            this.downstreamToolStripStatusLabel,
            this.upstreamToolStripStatusLabel,
            this.toolStripSeparator7,
            this.connectionsCountToolStripStatusLabel,
            this.toolStripSeparator8,
            this.accessibilityToolStripStatusLabel});
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.ShowItemToolTips = true;
            // 
            // logIconToolStripStatusLabel
            // 
            this.logIconToolStripStatusLabel.AccessibleDescription = null;
            this.logIconToolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.logIconToolStripStatusLabel, "logIconToolStripStatusLabel");
            this.logIconToolStripStatusLabel.BackgroundImage = null;
            this.logIconToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logIconToolStripStatusLabel.Name = "logIconToolStripStatusLabel";
            // 
            // logToolStripStatusLabel
            // 
            this.logToolStripStatusLabel.AccessibleDescription = null;
            this.logToolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.logToolStripStatusLabel, "logToolStripStatusLabel");
            this.logToolStripStatusLabel.AutoToolTip = true;
            this.logToolStripStatusLabel.BackgroundImage = null;
            this.logToolStripStatusLabel.Name = "logToolStripStatusLabel";
            this.logToolStripStatusLabel.Spring = true;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AccessibleDescription = null;
            this.toolStripSeparator6.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // downstreamToolStripStatusLabel
            // 
            this.downstreamToolStripStatusLabel.AccessibleDescription = null;
            this.downstreamToolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.downstreamToolStripStatusLabel, "downstreamToolStripStatusLabel");
            this.downstreamToolStripStatusLabel.BackgroundImage = null;
            this.downstreamToolStripStatusLabel.Image = global::Regensburger.RShare.Properties.Resources.downstream_16x16;
            this.downstreamToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            this.downstreamToolStripStatusLabel.Name = "downstreamToolStripStatusLabel";
            // 
            // upstreamToolStripStatusLabel
            // 
            this.upstreamToolStripStatusLabel.AccessibleDescription = null;
            this.upstreamToolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.upstreamToolStripStatusLabel, "upstreamToolStripStatusLabel");
            this.upstreamToolStripStatusLabel.BackgroundImage = null;
            this.upstreamToolStripStatusLabel.Image = global::Regensburger.RShare.Properties.Resources.upstream_16x16;
            this.upstreamToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            this.upstreamToolStripStatusLabel.Name = "upstreamToolStripStatusLabel";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.AccessibleDescription = null;
            this.toolStripSeparator7.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // connectionsCountToolStripStatusLabel
            // 
            this.connectionsCountToolStripStatusLabel.AccessibleDescription = null;
            this.connectionsCountToolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.connectionsCountToolStripStatusLabel, "connectionsCountToolStripStatusLabel");
            this.connectionsCountToolStripStatusLabel.BackgroundImage = null;
            this.connectionsCountToolStripStatusLabel.Image = global::Regensburger.RShare.Properties.Resources.connections_16x16;
            this.connectionsCountToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            this.connectionsCountToolStripStatusLabel.Name = "connectionsCountToolStripStatusLabel";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.AccessibleDescription = null;
            this.toolStripSeparator8.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            // 
            // accessibilityToolStripStatusLabel
            // 
            this.accessibilityToolStripStatusLabel.AccessibleDescription = null;
            this.accessibilityToolStripStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.accessibilityToolStripStatusLabel, "accessibilityToolStripStatusLabel");
            this.accessibilityToolStripStatusLabel.BackgroundImage = null;
            this.accessibilityToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            this.accessibilityToolStripStatusLabel.Name = "accessibilityToolStripStatusLabel";
            // 
            // toolStrip
            // 
            this.toolStrip.AccessibleDescription = null;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.BackgroundImage = null;
            this.toolStrip.Font = null;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionsToolStripButton,
            this.toolStripSeparator1,
            this.searchToolStripButton,
            this.downloadsToolStripButton,
            this.uploadsToolStripButton,
            this.toolStripSeparator3,
            this.sharedFilesToolStripButton,
            this.toolStripSeparator4,
            this.statisticsToolStripButton,
            this.toolStripSeparator5,
            this.preferencesToolStripButton});
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.TabStop = true;
            // 
            // connectionsToolStripButton
            // 
            this.connectionsToolStripButton.AccessibleDescription = null;
            this.connectionsToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.connectionsToolStripButton, "connectionsToolStripButton");
            this.connectionsToolStripButton.BackgroundImage = null;
            this.connectionsToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.connections_24x24;
            this.connectionsToolStripButton.Name = "connectionsToolStripButton";
            this.connectionsToolStripButton.Click += new System.EventHandler(this.connectionsToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // searchToolStripButton
            // 
            this.searchToolStripButton.AccessibleDescription = null;
            this.searchToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.searchToolStripButton, "searchToolStripButton");
            this.searchToolStripButton.BackgroundImage = null;
            this.searchToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.search_24x24;
            this.searchToolStripButton.Name = "searchToolStripButton";
            this.searchToolStripButton.Click += new System.EventHandler(this.searchToolStripButton_Click);
            // 
            // downloadsToolStripButton
            // 
            this.downloadsToolStripButton.AccessibleDescription = null;
            this.downloadsToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.downloadsToolStripButton, "downloadsToolStripButton");
            this.downloadsToolStripButton.BackgroundImage = null;
            this.downloadsToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.download_24x24;
            this.downloadsToolStripButton.Name = "downloadsToolStripButton";
            this.downloadsToolStripButton.Click += new System.EventHandler(this.downloadsToolStripButton_Click);
            // 
            // uploadsToolStripButton
            // 
            this.uploadsToolStripButton.AccessibleDescription = null;
            this.uploadsToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.uploadsToolStripButton, "uploadsToolStripButton");
            this.uploadsToolStripButton.BackgroundImage = null;
            this.uploadsToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.upload_24x24;
            this.uploadsToolStripButton.Name = "uploadsToolStripButton";
            this.uploadsToolStripButton.Click += new System.EventHandler(this.uploadsToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AccessibleDescription = null;
            this.toolStripSeparator3.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // sharedFilesToolStripButton
            // 
            this.sharedFilesToolStripButton.AccessibleDescription = null;
            this.sharedFilesToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.sharedFilesToolStripButton, "sharedFilesToolStripButton");
            this.sharedFilesToolStripButton.BackgroundImage = null;
            this.sharedFilesToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.directory_24x24;
            this.sharedFilesToolStripButton.Name = "sharedFilesToolStripButton";
            this.sharedFilesToolStripButton.Click += new System.EventHandler(this.sharedFilesToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AccessibleDescription = null;
            this.toolStripSeparator4.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // statisticsToolStripButton
            // 
            this.statisticsToolStripButton.AccessibleDescription = null;
            this.statisticsToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.statisticsToolStripButton, "statisticsToolStripButton");
            this.statisticsToolStripButton.BackgroundImage = null;
            this.statisticsToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.statistics_24x24;
            this.statisticsToolStripButton.Name = "statisticsToolStripButton";
            this.statisticsToolStripButton.Click += new System.EventHandler(this.statisticsToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AccessibleDescription = null;
            this.toolStripSeparator5.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // preferencesToolStripButton
            // 
            this.preferencesToolStripButton.AccessibleDescription = null;
            this.preferencesToolStripButton.AccessibleName = null;
            resources.ApplyResources(this.preferencesToolStripButton, "preferencesToolStripButton");
            this.preferencesToolStripButton.BackgroundImage = null;
            this.preferencesToolStripButton.Image = global::Regensburger.RShare.Properties.Resources.preferences_24x24;
            this.preferencesToolStripButton.Name = "preferencesToolStripButton";
            this.preferencesToolStripButton.Click += new System.EventHandler(this.preferencesToolStripButton_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = null;
            this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.AccessibleDescription = null;
            this.notifyIconContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.notifyIconContextMenuStrip, "notifyIconContextMenuStrip");
            this.notifyIconContextMenuStrip.BackgroundImage = null;
            this.notifyIconContextMenuStrip.Font = null;
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRShareToolStripMenuItem,
            this.closeRShareToolStripMenuItem});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            // 
            // showRShareToolStripMenuItem
            // 
            this.showRShareToolStripMenuItem.AccessibleDescription = null;
            this.showRShareToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.showRShareToolStripMenuItem, "showRShareToolStripMenuItem");
            this.showRShareToolStripMenuItem.BackgroundImage = null;
            this.showRShareToolStripMenuItem.Name = "showRShareToolStripMenuItem";
            this.showRShareToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.showRShareToolStripMenuItem.Click += new System.EventHandler(this.showRShareToolStripMenuItem_Click);
            // 
            // closeRShareToolStripMenuItem
            // 
            this.closeRShareToolStripMenuItem.AccessibleDescription = null;
            this.closeRShareToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.closeRShareToolStripMenuItem, "closeRShareToolStripMenuItem");
            this.closeRShareToolStripMenuItem.BackgroundImage = null;
            this.closeRShareToolStripMenuItem.Name = "closeRShareToolStripMenuItem";
            this.closeRShareToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.closeRShareToolStripMenuItem.Click += new System.EventHandler(this.closeRShareToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.toolStripContainer);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton searchToolStripButton;
        private System.Windows.Forms.ToolStripButton downloadsToolStripButton;
        private System.Windows.Forms.ToolStripButton uploadsToolStripButton;
        private System.Windows.Forms.ToolStripButton sharedFilesToolStripButton;
        private System.Windows.Forms.ToolStripButton preferencesToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel logToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel connectionsCountToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel accessibilityToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel downstreamToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel upstreamToolStripStatusLabel;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showRShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeRShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton statisticsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel logIconToolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton connectionsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}