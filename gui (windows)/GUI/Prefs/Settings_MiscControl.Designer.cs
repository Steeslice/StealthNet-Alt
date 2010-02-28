namespace Regensburger.RShare
{
    partial class Settings_MiscControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_MiscControl));
            this.preview_groupBox = new System.Windows.Forms.GroupBox();
            this.previewParams_label = new System.Windows.Forms.Label();
            this.previewPlayer_label = new System.Windows.Forms.Label();
            this.browsePreviewPlayer_button = new System.Windows.Forms.Button();
            this.previewParameters_textbox = new System.Windows.Forms.TextBox();
            this.previewPlayer_textbox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.misc_groupBox = new System.Windows.Forms.GroupBox();
            this.closeToTray_checkBox = new System.Windows.Forms.CheckBox();
            this.format_checkBox = new System.Windows.Forms.CheckBox();
            this.messageWindow_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseSyndiePath_button = new System.Windows.Forms.Button();
            this.syndieProgPath_textBox = new System.Windows.Forms.TextBox();
            this.PathtoSyndie_label = new System.Windows.Forms.Label();
            this.showSyndie_checkbox = new System.Windows.Forms.CheckBox();
            this.preview_groupBox.SuspendLayout();
            this.misc_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // preview_groupBox
            // 
            this.preview_groupBox.Controls.Add(this.previewParams_label);
            this.preview_groupBox.Controls.Add(this.previewPlayer_label);
            this.preview_groupBox.Controls.Add(this.browsePreviewPlayer_button);
            this.preview_groupBox.Controls.Add(this.previewParameters_textbox);
            this.preview_groupBox.Controls.Add(this.previewPlayer_textbox);
            resources.ApplyResources(this.preview_groupBox, "preview_groupBox");
            this.preview_groupBox.Name = "preview_groupBox";
            this.preview_groupBox.TabStop = false;
            // 
            // previewParams_label
            // 
            resources.ApplyResources(this.previewParams_label, "previewParams_label");
            this.previewParams_label.Name = "previewParams_label";
            // 
            // previewPlayer_label
            // 
            resources.ApplyResources(this.previewPlayer_label, "previewPlayer_label");
            this.previewPlayer_label.Name = "previewPlayer_label";
            // 
            // browsePreviewPlayer_button
            // 
            this.browsePreviewPlayer_button.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            resources.ApplyResources(this.browsePreviewPlayer_button, "browsePreviewPlayer_button");
            this.browsePreviewPlayer_button.Name = "browsePreviewPlayer_button";
            this.browsePreviewPlayer_button.UseVisualStyleBackColor = true;
            this.browsePreviewPlayer_button.Click += new System.EventHandler(this.browsePreviewPlayer_button_Click);
            // 
            // previewParameters_textbox
            // 
            resources.ApplyResources(this.previewParameters_textbox, "previewParameters_textbox");
            this.previewParameters_textbox.Name = "previewParameters_textbox";
            // 
            // previewPlayer_textbox
            // 
            resources.ApplyResources(this.previewPlayer_textbox, "previewPlayer_textbox");
            this.previewPlayer_textbox.Name = "previewPlayer_textbox";
            // 
            // misc_groupBox
            // 
            this.misc_groupBox.Controls.Add(this.closeToTray_checkBox);
            this.misc_groupBox.Controls.Add(this.format_checkBox);
            this.misc_groupBox.Controls.Add(this.messageWindow_checkBox);
            resources.ApplyResources(this.misc_groupBox, "misc_groupBox");
            this.misc_groupBox.Name = "misc_groupBox";
            this.misc_groupBox.TabStop = false;
            // 
            // closeToTray_checkBox
            // 
            resources.ApplyResources(this.closeToTray_checkBox, "closeToTray_checkBox");
            this.closeToTray_checkBox.Name = "closeToTray_checkBox";
            this.closeToTray_checkBox.UseVisualStyleBackColor = true;
            // 
            // format_checkBox
            // 
            resources.ApplyResources(this.format_checkBox, "format_checkBox");
            this.format_checkBox.Name = "format_checkBox";
            this.format_checkBox.UseVisualStyleBackColor = true;
            this.format_checkBox.CheckedChanged += new System.EventHandler(this.format_checkBox_CheckedChanged);
            // 
            // messageWindow_checkBox
            // 
            resources.ApplyResources(this.messageWindow_checkBox, "messageWindow_checkBox");
            this.messageWindow_checkBox.Name = "messageWindow_checkBox";
            this.messageWindow_checkBox.UseVisualStyleBackColor = true;
            this.messageWindow_checkBox.CheckedChanged += new System.EventHandler(this.messageWindow_checkBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseSyndiePath_button);
            this.groupBox1.Controls.Add(this.syndieProgPath_textBox);
            this.groupBox1.Controls.Add(this.PathtoSyndie_label);
            this.groupBox1.Controls.Add(this.showSyndie_checkbox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // browseSyndiePath_button
            // 
            resources.ApplyResources(this.browseSyndiePath_button, "browseSyndiePath_button");
            this.browseSyndiePath_button.Image = global::Regensburger.RShare.Properties.Resources.directory_16x16;
            this.browseSyndiePath_button.Name = "browseSyndiePath_button";
            this.browseSyndiePath_button.UseVisualStyleBackColor = true;
            // 
            // syndieProgPath_textBox
            // 
            resources.ApplyResources(this.syndieProgPath_textBox, "syndieProgPath_textBox");
            this.syndieProgPath_textBox.Name = "syndieProgPath_textBox";
            // 
            // PathtoSyndie_label
            // 
            resources.ApplyResources(this.PathtoSyndie_label, "PathtoSyndie_label");
            this.PathtoSyndie_label.Name = "PathtoSyndie_label";
            // 
            // showSyndie_checkbox
            // 
            resources.ApplyResources(this.showSyndie_checkbox, "showSyndie_checkbox");
            this.showSyndie_checkbox.Name = "showSyndie_checkbox";
            this.showSyndie_checkbox.UseVisualStyleBackColor = true;
            this.showSyndie_checkbox.CheckedChanged += new System.EventHandler(this.showSyndie_checkbox_CheckedChanged);
            // 
            // Settings_MiscControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.misc_groupBox);
            this.Controls.Add(this.preview_groupBox);
            this.Name = "Settings_MiscControl";
            this.preview_groupBox.ResumeLayout(false);
            this.preview_groupBox.PerformLayout();
            this.misc_groupBox.ResumeLayout(false);
            this.misc_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox preview_groupBox;
        private System.Windows.Forms.Label previewParams_label;
        private System.Windows.Forms.Label previewPlayer_label;
        private System.Windows.Forms.Button browsePreviewPlayer_button;
        private System.Windows.Forms.TextBox previewParameters_textbox;
        private System.Windows.Forms.TextBox previewPlayer_textbox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox misc_groupBox;
        private System.Windows.Forms.CheckBox format_checkBox;
        private System.Windows.Forms.CheckBox messageWindow_checkBox;
        private System.Windows.Forms.CheckBox closeToTray_checkBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox showSyndie_checkbox;
        private System.Windows.Forms.Button browseSyndiePath_button;
        private System.Windows.Forms.TextBox syndieProgPath_textBox;
        private System.Windows.Forms.Label PathtoSyndie_label;
    }
}
