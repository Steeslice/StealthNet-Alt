namespace Regensburger.RShare
{
    partial class Settings_DirectoryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_DirectoryControl));
            this.sharedDirs_groupbox = new System.Windows.Forms.GroupBox();
            this.sharedDirectoriesLabel = new System.Windows.Forms.Label();
            this.removeSharedDirectoryButton = new System.Windows.Forms.Button();
            this.addSharedDirectoryButton = new System.Windows.Forms.Button();
            this.sharedDirectoriesDataGridView = new Regensburger.RShare.DoubleBufferedDataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progDirs_groupbox = new System.Windows.Forms.GroupBox();
            this.browsePrefFiles_btn = new System.Windows.Forms.Button();
            this.SettingDirPrefFiles_label = new System.Windows.Forms.Label();
            this.SettingDirPrefFiles_textbox = new System.Windows.Forms.TextBox();
            this.browseTempFiles_btn = new System.Windows.Forms.Button();
            this.browseCorruptFiles_btn = new System.Windows.Forms.Button();
            this.browseIncomFiles_btn = new System.Windows.Forms.Button();
            this.browseLogFiles_btn = new System.Windows.Forms.Button();
            this.SettingDirTempFiles_textbox = new System.Windows.Forms.TextBox();
            this.SettingDirCoruptFiles_textbox = new System.Windows.Forms.TextBox();
            this.SettingDirIncomFiles_textbox = new System.Windows.Forms.TextBox();
            this.SettingDirCoruptFiles_label = new System.Windows.Forms.Label();
            this.SettingDirIncomFiles_label = new System.Windows.Forms.Label();
            this.SettingDirTempFiles_label = new System.Windows.Forms.Label();
            this.SettingDirLogFiles_label = new System.Windows.Forms.Label();
            this.SettingDirLogFiles_textbox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.sharedDirs_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedDirectoriesDataGridView)).BeginInit();
            this.progDirs_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sharedDirs_groupbox
            // 
            this.sharedDirs_groupbox.AccessibleDescription = null;
            this.sharedDirs_groupbox.AccessibleName = null;
            resources.ApplyResources(this.sharedDirs_groupbox, "sharedDirs_groupbox");
            this.sharedDirs_groupbox.BackgroundImage = null;
            this.sharedDirs_groupbox.Controls.Add(this.sharedDirectoriesLabel);
            this.sharedDirs_groupbox.Controls.Add(this.removeSharedDirectoryButton);
            this.sharedDirs_groupbox.Controls.Add(this.addSharedDirectoryButton);
            this.sharedDirs_groupbox.Controls.Add(this.sharedDirectoriesDataGridView);
            this.sharedDirs_groupbox.Font = null;
            this.sharedDirs_groupbox.Name = "sharedDirs_groupbox";
            this.sharedDirs_groupbox.TabStop = false;
            // 
            // sharedDirectoriesLabel
            // 
            this.sharedDirectoriesLabel.AccessibleDescription = null;
            this.sharedDirectoriesLabel.AccessibleName = null;
            resources.ApplyResources(this.sharedDirectoriesLabel, "sharedDirectoriesLabel");
            this.sharedDirectoriesLabel.Font = null;
            this.sharedDirectoriesLabel.Name = "sharedDirectoriesLabel";
            // 
            // removeSharedDirectoryButton
            // 
            this.removeSharedDirectoryButton.AccessibleDescription = null;
            this.removeSharedDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.removeSharedDirectoryButton, "removeSharedDirectoryButton");
            this.removeSharedDirectoryButton.BackgroundImage = null;
            this.removeSharedDirectoryButton.Font = null;
            this.removeSharedDirectoryButton.Image = global::Regensburger.RShare.Properties.Resources.directory_remove_16x16;
            this.removeSharedDirectoryButton.Name = "removeSharedDirectoryButton";
            this.removeSharedDirectoryButton.UseVisualStyleBackColor = true;
            this.removeSharedDirectoryButton.Click += new System.EventHandler(this.removeSharedDirectoryButton_Click);
            // 
            // addSharedDirectoryButton
            // 
            this.addSharedDirectoryButton.AccessibleDescription = null;
            this.addSharedDirectoryButton.AccessibleName = null;
            resources.ApplyResources(this.addSharedDirectoryButton, "addSharedDirectoryButton");
            this.addSharedDirectoryButton.BackgroundImage = null;
            this.addSharedDirectoryButton.Font = null;
            this.addSharedDirectoryButton.Image = global::Regensburger.RShare.Properties.Resources.directory_add_16x16;
            this.addSharedDirectoryButton.Name = "addSharedDirectoryButton";
            this.addSharedDirectoryButton.UseVisualStyleBackColor = true;
            this.addSharedDirectoryButton.Click += new System.EventHandler(this.addSharedDirectoryButton_Click);
            // 
            // sharedDirectoriesDataGridView
            // 
            this.sharedDirectoriesDataGridView.AccessibleDescription = null;
            this.sharedDirectoriesDataGridView.AccessibleName = null;
            this.sharedDirectoriesDataGridView.AllowUserToAddRows = false;
            this.sharedDirectoriesDataGridView.AllowUserToDeleteRows = false;
            this.sharedDirectoriesDataGridView.AllowUserToOrderColumns = true;
            this.sharedDirectoriesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.sharedDirectoriesDataGridView, "sharedDirectoriesDataGridView");
            this.sharedDirectoriesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sharedDirectoriesDataGridView.BackgroundImage = null;
            this.sharedDirectoriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sharedDirectoriesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sharedDirectoriesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sharedDirectoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sharedDirectoriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.Path});
            this.sharedDirectoriesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.sharedDirectoriesDataGridView.Font = null;
            this.sharedDirectoriesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.sharedDirectoriesDataGridView.Name = "sharedDirectoriesDataGridView";
            this.sharedDirectoriesDataGridView.ReadOnly = true;
            this.sharedDirectoriesDataGridView.RowHeadersVisible = false;
            this.sharedDirectoriesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sharedDirectoriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sharedDirectoriesDataGridView.ShowCellErrors = false;
            this.sharedDirectoriesDataGridView.ShowCellToolTips = false;
            this.sharedDirectoriesDataGridView.ShowEditingIcon = false;
            this.sharedDirectoriesDataGridView.ShowRowErrors = false;
            // 
            // Icon
            // 
            resources.ApplyResources(this.Icon, "Icon");
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Path, "Path");
            this.Path.MaxInputLength = 0;
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // progDirs_groupbox
            // 
            this.progDirs_groupbox.AccessibleDescription = null;
            this.progDirs_groupbox.AccessibleName = null;
            resources.ApplyResources(this.progDirs_groupbox, "progDirs_groupbox");
            this.progDirs_groupbox.BackgroundImage = null;
            this.progDirs_groupbox.Controls.Add(this.browsePrefFiles_btn);
            this.progDirs_groupbox.Controls.Add(this.SettingDirPrefFiles_label);
            this.progDirs_groupbox.Controls.Add(this.SettingDirPrefFiles_textbox);
            this.progDirs_groupbox.Controls.Add(this.browseTempFiles_btn);
            this.progDirs_groupbox.Controls.Add(this.browseCorruptFiles_btn);
            this.progDirs_groupbox.Controls.Add(this.browseIncomFiles_btn);
            this.progDirs_groupbox.Controls.Add(this.browseLogFiles_btn);
            this.progDirs_groupbox.Controls.Add(this.SettingDirTempFiles_textbox);
            this.progDirs_groupbox.Controls.Add(this.SettingDirCoruptFiles_textbox);
            this.progDirs_groupbox.Controls.Add(this.SettingDirIncomFiles_textbox);
            this.progDirs_groupbox.Controls.Add(this.SettingDirCoruptFiles_label);
            this.progDirs_groupbox.Controls.Add(this.SettingDirIncomFiles_label);
            this.progDirs_groupbox.Controls.Add(this.SettingDirTempFiles_label);
            this.progDirs_groupbox.Controls.Add(this.SettingDirLogFiles_label);
            this.progDirs_groupbox.Controls.Add(this.SettingDirLogFiles_textbox);
            this.progDirs_groupbox.Font = null;
            this.progDirs_groupbox.Name = "progDirs_groupbox";
            this.progDirs_groupbox.TabStop = false;
            // 
            // browsePrefFiles_btn
            // 
            this.browsePrefFiles_btn.AccessibleDescription = null;
            this.browsePrefFiles_btn.AccessibleName = null;
            resources.ApplyResources(this.browsePrefFiles_btn, "browsePrefFiles_btn");
            this.browsePrefFiles_btn.BackgroundImage = null;
            this.browsePrefFiles_btn.Font = null;
            this.browsePrefFiles_btn.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            this.browsePrefFiles_btn.Name = "browsePrefFiles_btn";
            this.browsePrefFiles_btn.UseVisualStyleBackColor = true;
            this.browsePrefFiles_btn.Click += new System.EventHandler(this.browsePrefFiles_btn_Click);
            // 
            // SettingDirPrefFiles_label
            // 
            this.SettingDirPrefFiles_label.AccessibleDescription = null;
            this.SettingDirPrefFiles_label.AccessibleName = null;
            resources.ApplyResources(this.SettingDirPrefFiles_label, "SettingDirPrefFiles_label");
            this.SettingDirPrefFiles_label.Font = null;
            this.SettingDirPrefFiles_label.Name = "SettingDirPrefFiles_label";
            // 
            // SettingDirPrefFiles_textbox
            // 
            this.SettingDirPrefFiles_textbox.AccessibleDescription = null;
            this.SettingDirPrefFiles_textbox.AccessibleName = null;
            resources.ApplyResources(this.SettingDirPrefFiles_textbox, "SettingDirPrefFiles_textbox");
            this.SettingDirPrefFiles_textbox.BackgroundImage = null;
            this.SettingDirPrefFiles_textbox.Font = null;
            this.SettingDirPrefFiles_textbox.Name = "SettingDirPrefFiles_textbox";
            // 
            // browseTempFiles_btn
            // 
            this.browseTempFiles_btn.AccessibleDescription = null;
            this.browseTempFiles_btn.AccessibleName = null;
            resources.ApplyResources(this.browseTempFiles_btn, "browseTempFiles_btn");
            this.browseTempFiles_btn.BackgroundImage = null;
            this.browseTempFiles_btn.Font = null;
            this.browseTempFiles_btn.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            this.browseTempFiles_btn.Name = "browseTempFiles_btn";
            this.browseTempFiles_btn.UseVisualStyleBackColor = true;
            this.browseTempFiles_btn.Click += new System.EventHandler(this.browseTempFiles_btn_Click);
            // 
            // browseCorruptFiles_btn
            // 
            this.browseCorruptFiles_btn.AccessibleDescription = null;
            this.browseCorruptFiles_btn.AccessibleName = null;
            resources.ApplyResources(this.browseCorruptFiles_btn, "browseCorruptFiles_btn");
            this.browseCorruptFiles_btn.BackgroundImage = null;
            this.browseCorruptFiles_btn.Font = null;
            this.browseCorruptFiles_btn.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            this.browseCorruptFiles_btn.Name = "browseCorruptFiles_btn";
            this.browseCorruptFiles_btn.UseVisualStyleBackColor = true;
            this.browseCorruptFiles_btn.Click += new System.EventHandler(this.browseCorruptFiles_btn_Click);
            // 
            // browseIncomFiles_btn
            // 
            this.browseIncomFiles_btn.AccessibleDescription = null;
            this.browseIncomFiles_btn.AccessibleName = null;
            resources.ApplyResources(this.browseIncomFiles_btn, "browseIncomFiles_btn");
            this.browseIncomFiles_btn.BackgroundImage = null;
            this.browseIncomFiles_btn.Font = null;
            this.browseIncomFiles_btn.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            this.browseIncomFiles_btn.Name = "browseIncomFiles_btn";
            this.browseIncomFiles_btn.UseVisualStyleBackColor = true;
            this.browseIncomFiles_btn.Click += new System.EventHandler(this.browseIncomFiles_btn_Click);
            // 
            // browseLogFiles_btn
            // 
            this.browseLogFiles_btn.AccessibleDescription = null;
            this.browseLogFiles_btn.AccessibleName = null;
            resources.ApplyResources(this.browseLogFiles_btn, "browseLogFiles_btn");
            this.browseLogFiles_btn.BackgroundImage = null;
            this.browseLogFiles_btn.Font = null;
            this.browseLogFiles_btn.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            this.browseLogFiles_btn.Name = "browseLogFiles_btn";
            this.browseLogFiles_btn.UseVisualStyleBackColor = true;
            this.browseLogFiles_btn.Click += new System.EventHandler(this.browseLogFiles_btn_Click);
            // 
            // SettingDirTempFiles_textbox
            // 
            this.SettingDirTempFiles_textbox.AccessibleDescription = null;
            this.SettingDirTempFiles_textbox.AccessibleName = null;
            resources.ApplyResources(this.SettingDirTempFiles_textbox, "SettingDirTempFiles_textbox");
            this.SettingDirTempFiles_textbox.BackgroundImage = null;
            this.SettingDirTempFiles_textbox.Font = null;
            this.SettingDirTempFiles_textbox.Name = "SettingDirTempFiles_textbox";
            // 
            // SettingDirCoruptFiles_textbox
            // 
            this.SettingDirCoruptFiles_textbox.AccessibleDescription = null;
            this.SettingDirCoruptFiles_textbox.AccessibleName = null;
            resources.ApplyResources(this.SettingDirCoruptFiles_textbox, "SettingDirCoruptFiles_textbox");
            this.SettingDirCoruptFiles_textbox.BackgroundImage = null;
            this.SettingDirCoruptFiles_textbox.Font = null;
            this.SettingDirCoruptFiles_textbox.Name = "SettingDirCoruptFiles_textbox";
            // 
            // SettingDirIncomFiles_textbox
            // 
            this.SettingDirIncomFiles_textbox.AccessibleDescription = null;
            this.SettingDirIncomFiles_textbox.AccessibleName = null;
            resources.ApplyResources(this.SettingDirIncomFiles_textbox, "SettingDirIncomFiles_textbox");
            this.SettingDirIncomFiles_textbox.BackgroundImage = null;
            this.SettingDirIncomFiles_textbox.Font = null;
            this.SettingDirIncomFiles_textbox.Name = "SettingDirIncomFiles_textbox";
            // 
            // SettingDirCoruptFiles_label
            // 
            this.SettingDirCoruptFiles_label.AccessibleDescription = null;
            this.SettingDirCoruptFiles_label.AccessibleName = null;
            resources.ApplyResources(this.SettingDirCoruptFiles_label, "SettingDirCoruptFiles_label");
            this.SettingDirCoruptFiles_label.Font = null;
            this.SettingDirCoruptFiles_label.Name = "SettingDirCoruptFiles_label";
            // 
            // SettingDirIncomFiles_label
            // 
            this.SettingDirIncomFiles_label.AccessibleDescription = null;
            this.SettingDirIncomFiles_label.AccessibleName = null;
            resources.ApplyResources(this.SettingDirIncomFiles_label, "SettingDirIncomFiles_label");
            this.SettingDirIncomFiles_label.Font = null;
            this.SettingDirIncomFiles_label.Name = "SettingDirIncomFiles_label";
            // 
            // SettingDirTempFiles_label
            // 
            this.SettingDirTempFiles_label.AccessibleDescription = null;
            this.SettingDirTempFiles_label.AccessibleName = null;
            resources.ApplyResources(this.SettingDirTempFiles_label, "SettingDirTempFiles_label");
            this.SettingDirTempFiles_label.Font = null;
            this.SettingDirTempFiles_label.Name = "SettingDirTempFiles_label";
            // 
            // SettingDirLogFiles_label
            // 
            this.SettingDirLogFiles_label.AccessibleDescription = null;
            this.SettingDirLogFiles_label.AccessibleName = null;
            resources.ApplyResources(this.SettingDirLogFiles_label, "SettingDirLogFiles_label");
            this.SettingDirLogFiles_label.Font = null;
            this.SettingDirLogFiles_label.Name = "SettingDirLogFiles_label";
            // 
            // SettingDirLogFiles_textbox
            // 
            this.SettingDirLogFiles_textbox.AccessibleDescription = null;
            this.SettingDirLogFiles_textbox.AccessibleName = null;
            resources.ApplyResources(this.SettingDirLogFiles_textbox, "SettingDirLogFiles_textbox");
            this.SettingDirLogFiles_textbox.BackgroundImage = null;
            this.SettingDirLogFiles_textbox.Font = null;
            this.SettingDirLogFiles_textbox.Name = "SettingDirLogFiles_textbox";
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // Settings_DirectoryControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.progDirs_groupbox);
            this.Controls.Add(this.sharedDirs_groupbox);
            this.Font = null;
            this.Name = "Settings_DirectoryControl";
            this.sharedDirs_groupbox.ResumeLayout(false);
            this.sharedDirs_groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedDirectoriesDataGridView)).EndInit();
            this.progDirs_groupbox.ResumeLayout(false);
            this.progDirs_groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox sharedDirs_groupbox;
        private System.Windows.Forms.GroupBox progDirs_groupbox;
        private System.Windows.Forms.TextBox SettingDirLogFiles_textbox;
        private System.Windows.Forms.Label SettingDirLogFiles_label;
        private System.Windows.Forms.Label SettingDirCoruptFiles_label;
        private System.Windows.Forms.Label SettingDirIncomFiles_label;
        private System.Windows.Forms.Label SettingDirTempFiles_label;
        private System.Windows.Forms.TextBox SettingDirIncomFiles_textbox;
        private System.Windows.Forms.TextBox SettingDirTempFiles_textbox;
        private System.Windows.Forms.TextBox SettingDirCoruptFiles_textbox;
        private System.Windows.Forms.Button browseLogFiles_btn;
        private System.Windows.Forms.Button browseTempFiles_btn;
        private System.Windows.Forms.Button browseCorruptFiles_btn;
        private System.Windows.Forms.Button browseIncomFiles_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button browsePrefFiles_btn;
        private System.Windows.Forms.Label SettingDirPrefFiles_label;
        private System.Windows.Forms.TextBox SettingDirPrefFiles_textbox;
        private DoubleBufferedDataGridView sharedDirectoriesDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.Button addSharedDirectoryButton;
        private System.Windows.Forms.Button removeSharedDirectoryButton;
        private System.Windows.Forms.Label sharedDirectoriesLabel;
    }
}
