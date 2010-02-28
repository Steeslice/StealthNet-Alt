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
    partial class ConnectionsControl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionsControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.connectionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsLabel = new System.Windows.Forms.Label();
            this.connectionsDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.connectionsPictureBox = new System.Windows.Forms.PictureBox();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnqueuedCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionsContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionsContextMenuStrip
            // 
            this.connectionsContextMenuStrip.AccessibleDescription = null;
            this.connectionsContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.connectionsContextMenuStrip, "connectionsContextMenuStrip");
            this.connectionsContextMenuStrip.BackgroundImage = null;
            this.connectionsContextMenuStrip.Font = null;
            this.connectionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.connectionsContextMenuStrip.Name = "connectionsContextMenuStrip";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.AccessibleDescription = null;
            this.connectToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.connectToolStripMenuItem, "connectToolStripMenuItem");
            this.connectToolStripMenuItem.BackgroundImage = null;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // connectionsLabel
            // 
            this.connectionsLabel.AccessibleDescription = null;
            this.connectionsLabel.AccessibleName = null;
            resources.ApplyResources(this.connectionsLabel, "connectionsLabel");
            this.connectionsLabel.Font = null;
            this.connectionsLabel.Name = "connectionsLabel";
            // 
            // connectionsDataGridView
            // 
            this.connectionsDataGridView.AccessibleDescription = null;
            this.connectionsDataGridView.AccessibleName = null;
            this.connectionsDataGridView.AllowUserToAddRows = false;
            this.connectionsDataGridView.AllowUserToDeleteRows = false;
            this.connectionsDataGridView.AllowUserToOrderColumns = true;
            this.connectionsDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.connectionsDataGridView, "connectionsDataGridView");
            this.connectionsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.connectionsDataGridView.BackgroundImage = null;
            this.connectionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.connectionsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.connectionsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.connectionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.connectionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.IPAddress,
            this.Port,
            this.Sent,
            this.Received,
            this.SentCommands,
            this.ReceivedCommands,
            this.EnqueuedCommands});
            this.connectionsDataGridView.ContextMenuStrip = this.connectionsContextMenuStrip;
            this.connectionsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.connectionsDataGridView.Font = null;
            this.connectionsDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.connectionsDataGridView.MultiSelect = false;
            this.connectionsDataGridView.Name = "connectionsDataGridView";
            this.connectionsDataGridView.ReadOnly = true;
            this.connectionsDataGridView.RowHeadersVisible = false;
            this.connectionsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.connectionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.connectionsDataGridView.ShowCellErrors = false;
            this.connectionsDataGridView.ShowCellToolTips = false;
            this.connectionsDataGridView.ShowEditingIcon = false;
            this.connectionsDataGridView.ShowRowErrors = false;
            this.connectionsDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.connectionsDataGridView_SortCompare);
            this.connectionsDataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.connectionsDataGridView_ColumnDisplayIndexChanged);
            this.connectionsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.connectionsDataGridView_DataError);
            this.connectionsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.connectionsDataGridView_ColumnWidthChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // connectionsPictureBox
            // 
            this.connectionsPictureBox.AccessibleDescription = null;
            this.connectionsPictureBox.AccessibleName = null;
            resources.ApplyResources(this.connectionsPictureBox, "connectionsPictureBox");
            this.connectionsPictureBox.BackgroundImage = null;
            this.connectionsPictureBox.Font = null;
            this.connectionsPictureBox.Image = global::Regensburger.RShare.Properties.Resources.connections_16x16;
            this.connectionsPictureBox.ImageLocation = null;
            this.connectionsPictureBox.Name = "connectionsPictureBox";
            this.connectionsPictureBox.TabStop = false;
            // 
            // Icon
            // 
            resources.ApplyResources(this.Icon, "Icon");
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IPAddress
            // 
            this.IPAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IPAddress.FillWeight = 84.07821F;
            resources.ApplyResources(this.IPAddress, "IPAddress");
            this.IPAddress.MaxInputLength = 0;
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Port.FillWeight = 84.07821F;
            resources.ApplyResources(this.Port, "Port");
            this.Port.MaxInputLength = 0;
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            // 
            // Sent
            // 
            this.Sent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Sent.DefaultCellStyle = dataGridViewCellStyle1;
            this.Sent.FillWeight = 84.07821F;
            resources.ApplyResources(this.Sent, "Sent");
            this.Sent.MaxInputLength = 0;
            this.Sent.Name = "Sent";
            this.Sent.ReadOnly = true;
            // 
            // Received
            // 
            this.Received.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Received.DefaultCellStyle = dataGridViewCellStyle2;
            this.Received.FillWeight = 84.07821F;
            resources.ApplyResources(this.Received, "Received");
            this.Received.MaxInputLength = 0;
            this.Received.Name = "Received";
            this.Received.ReadOnly = true;
            // 
            // SentCommands
            // 
            this.SentCommands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SentCommands.DefaultCellStyle = dataGridViewCellStyle3;
            this.SentCommands.FillWeight = 84.07821F;
            resources.ApplyResources(this.SentCommands, "SentCommands");
            this.SentCommands.MaxInputLength = 0;
            this.SentCommands.Name = "SentCommands";
            this.SentCommands.ReadOnly = true;
            // 
            // ReceivedCommands
            // 
            this.ReceivedCommands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReceivedCommands.DefaultCellStyle = dataGridViewCellStyle4;
            this.ReceivedCommands.FillWeight = 84.07821F;
            resources.ApplyResources(this.ReceivedCommands, "ReceivedCommands");
            this.ReceivedCommands.MaxInputLength = 0;
            this.ReceivedCommands.Name = "ReceivedCommands";
            this.ReceivedCommands.ReadOnly = true;
            // 
            // EnqueuedCommands
            // 
            this.EnqueuedCommands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EnqueuedCommands.DefaultCellStyle = dataGridViewCellStyle5;
            this.EnqueuedCommands.FillWeight = 84.07821F;
            resources.ApplyResources(this.EnqueuedCommands, "EnqueuedCommands");
            this.EnqueuedCommands.MaxInputLength = 0;
            this.EnqueuedCommands.Name = "EnqueuedCommands";
            this.EnqueuedCommands.ReadOnly = true;
            // 
            // ConnectionsControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.connectionsDataGridView);
            this.Controls.Add(this.connectionsLabel);
            this.Controls.Add(this.connectionsPictureBox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "ConnectionsControl";
            this.connectionsContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip connectionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.PictureBox connectionsPictureBox;
        private System.Windows.Forms.Label connectionsLabel;
        private Regensburger.RShare.DoubleBufferedDataGridView connectionsDataGridView;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnqueuedCommands;
    }
}