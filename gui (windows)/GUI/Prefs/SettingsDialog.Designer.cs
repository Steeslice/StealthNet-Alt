namespace Regensburger.RShare
{
    partial class SettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.SettingToolStrip = new System.Windows.Forms.ToolStrip();
            this.SettingstoolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.SettingsNavPanel = new System.Windows.Forms.Panel();
            this.NavigationDataGridview = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.SettingstoolStripContainer.ContentPanel.SuspendLayout();
            this.SettingstoolStripContainer.SuspendLayout();
            this.SettingsNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavigationDataGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            resources.ApplyResources(this.toolStripContainer, "toolStripContainer");
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.SettingToolStrip);
            resources.ApplyResources(this.toolStripContainer.TopToolStripPanel, "toolStripContainer.TopToolStripPanel");
            // 
            // SettingToolStrip
            // 
            resources.ApplyResources(this.SettingToolStrip, "SettingToolStrip");
            this.SettingToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.SettingToolStrip.Name = "SettingToolStrip";
            // 
            // SettingstoolStripContainer
            // 
            this.SettingstoolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // SettingstoolStripContainer.ContentPanel
            // 
            this.SettingstoolStripContainer.ContentPanel.Controls.Add(this.toolStripContainer);
            this.SettingstoolStripContainer.ContentPanel.Controls.Add(this.SettingsNavPanel);
            this.SettingstoolStripContainer.ContentPanel.Controls.Add(this.btnCancel);
            this.SettingstoolStripContainer.ContentPanel.Controls.Add(this.btnApply);
            this.SettingstoolStripContainer.ContentPanel.Controls.Add(this.btnOK);
            this.SettingstoolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            resources.ApplyResources(this.SettingstoolStripContainer.ContentPanel, "SettingstoolStripContainer.ContentPanel");
            resources.ApplyResources(this.SettingstoolStripContainer, "SettingstoolStripContainer");
            this.SettingstoolStripContainer.LeftToolStripPanelVisible = false;
            this.SettingstoolStripContainer.Name = "SettingstoolStripContainer";
            this.SettingstoolStripContainer.RightToolStripPanelVisible = false;
            this.SettingstoolStripContainer.TopToolStripPanelVisible = false;
            // 
            // SettingsNavPanel
            // 
            this.SettingsNavPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SettingsNavPanel.Controls.Add(this.NavigationDataGridview);
            resources.ApplyResources(this.SettingsNavPanel, "SettingsNavPanel");
            this.SettingsNavPanel.Name = "SettingsNavPanel";
            // 
            // NavigationDataGridview
            // 
            this.NavigationDataGridview.AllowUserToAddRows = false;
            this.NavigationDataGridview.AllowUserToDeleteRows = false;
            this.NavigationDataGridview.AllowUserToOrderColumns = true;
            this.NavigationDataGridview.AllowUserToResizeColumns = false;
            this.NavigationDataGridview.AllowUserToResizeRows = false;
            this.NavigationDataGridview.BackgroundColor = System.Drawing.Color.White;
            this.NavigationDataGridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NavigationDataGridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.NavigationDataGridview.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.NavigationDataGridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NavigationDataGridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.NavigationDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NavigationDataGridview.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NavigationDataGridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.NavigationDataGridview.GridColor = System.Drawing.Color.White;
            resources.ApplyResources(this.NavigationDataGridview, "NavigationDataGridview");
            this.NavigationDataGridview.MultiSelect = false;
            this.NavigationDataGridview.Name = "NavigationDataGridview";
            this.NavigationDataGridview.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NavigationDataGridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.NavigationDataGridview.RowHeadersVisible = false;
            this.NavigationDataGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.NavigationDataGridview.RowTemplate.ReadOnly = true;
            this.NavigationDataGridview.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NavigationDataGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NavigationDataGridview.SelectionChanged += new System.EventHandler(this.NavigationDataGridview_SelectionChanged);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SettingstoolStripContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsDialog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsDialog_FormClosed);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.SettingstoolStripContainer.ContentPanel.ResumeLayout(false);
            this.SettingstoolStripContainer.ResumeLayout(false);
            this.SettingstoolStripContainer.PerformLayout();
            this.SettingsNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavigationDataGridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStripContainer SettingstoolStripContainer;
        private System.Windows.Forms.DataGridView NavigationDataGridview;
        private System.Windows.Forms.Panel SettingsNavPanel;
        private System.Windows.Forms.ToolStrip SettingToolStrip;
    }
}