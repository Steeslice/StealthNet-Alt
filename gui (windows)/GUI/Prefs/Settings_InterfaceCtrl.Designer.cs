namespace Regensburger.RShare
{
    partial class Settings_InterfaceCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_InterfaceCtrl));
            this.downcapacity_groupBox = new System.Windows.Forms.GroupBox();
            this.downCapacityCon_label = new System.Windows.Forms.Label();
            this.downCapacity_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.upcapacity_groupBox = new System.Windows.Forms.GroupBox();
            this.upCapacityCon_label = new System.Windows.Forms.Label();
            this.upCapacity_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressbar_groupBox = new System.Windows.Forms.GroupBox();
            this.progressShadow_label = new System.Windows.Forms.Label();
            this.progressShadow_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressPercent_checkBox = new System.Windows.Forms.CheckBox();
            this.progressShadow_checkBox = new System.Windows.Forms.CheckBox();
            this.language_groupBox = new System.Windows.Forms.GroupBox();
            this.language_pictureBox = new System.Windows.Forms.PictureBox();
            this.language_comboBox = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.downcapacity_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downCapacity_numericUpDown)).BeginInit();
            this.upcapacity_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upCapacity_numericUpDown)).BeginInit();
            this.progressbar_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressShadow_numericUpDown)).BeginInit();
            this.language_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.language_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // downcapacity_groupBox
            // 
            this.downcapacity_groupBox.Controls.Add(this.downCapacityCon_label);
            this.downcapacity_groupBox.Controls.Add(this.downCapacity_numericUpDown);
            resources.ApplyResources(this.downcapacity_groupBox, "downcapacity_groupBox");
            this.downcapacity_groupBox.Name = "downcapacity_groupBox";
            this.downcapacity_groupBox.TabStop = false;
            // 
            // downCapacityCon_label
            // 
            resources.ApplyResources(this.downCapacityCon_label, "downCapacityCon_label");
            this.downCapacityCon_label.ForeColor = System.Drawing.Color.Gray;
            this.downCapacityCon_label.Name = "downCapacityCon_label";
            // 
            // downCapacity_numericUpDown
            // 
            resources.ApplyResources(this.downCapacity_numericUpDown, "downCapacity_numericUpDown");
            this.downCapacity_numericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downCapacity_numericUpDown.Name = "downCapacity_numericUpDown";
            this.downCapacity_numericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downCapacity_numericUpDown.ValueChanged += new System.EventHandler(this.downCapacity_numericUpDown_ValueChanged);
            // 
            // upcapacity_groupBox
            // 
            this.upcapacity_groupBox.Controls.Add(this.upCapacityCon_label);
            this.upcapacity_groupBox.Controls.Add(this.upCapacity_numericUpDown);
            resources.ApplyResources(this.upcapacity_groupBox, "upcapacity_groupBox");
            this.upcapacity_groupBox.Name = "upcapacity_groupBox";
            this.upcapacity_groupBox.TabStop = false;
            // 
            // upCapacityCon_label
            // 
            resources.ApplyResources(this.upCapacityCon_label, "upCapacityCon_label");
            this.upCapacityCon_label.ForeColor = System.Drawing.Color.Gray;
            this.upCapacityCon_label.Name = "upCapacityCon_label";
            // 
            // upCapacity_numericUpDown
            // 
            resources.ApplyResources(this.upCapacity_numericUpDown, "upCapacity_numericUpDown");
            this.upCapacity_numericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.upCapacity_numericUpDown.Name = "upCapacity_numericUpDown";
            this.upCapacity_numericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.upCapacity_numericUpDown.ValueChanged += new System.EventHandler(this.upCapacity_numericUpDown_ValueChanged);
            // 
            // progressbar_groupBox
            // 
            this.progressbar_groupBox.Controls.Add(this.progressShadow_label);
            this.progressbar_groupBox.Controls.Add(this.progressShadow_numericUpDown);
            this.progressbar_groupBox.Controls.Add(this.progressPercent_checkBox);
            this.progressbar_groupBox.Controls.Add(this.progressShadow_checkBox);
            resources.ApplyResources(this.progressbar_groupBox, "progressbar_groupBox");
            this.progressbar_groupBox.Name = "progressbar_groupBox";
            this.progressbar_groupBox.TabStop = false;
            // 
            // progressShadow_label
            // 
            resources.ApplyResources(this.progressShadow_label, "progressShadow_label");
            this.progressShadow_label.Name = "progressShadow_label";
            // 
            // progressShadow_numericUpDown
            // 
            resources.ApplyResources(this.progressShadow_numericUpDown, "progressShadow_numericUpDown");
            this.progressShadow_numericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.progressShadow_numericUpDown.Name = "progressShadow_numericUpDown";
            this.progressShadow_numericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.progressShadow_numericUpDown.ValueChanged += new System.EventHandler(this.progressShadow_numericUpDown_ValueChanged);
            // 
            // progressPercent_checkBox
            // 
            resources.ApplyResources(this.progressPercent_checkBox, "progressPercent_checkBox");
            this.progressPercent_checkBox.Name = "progressPercent_checkBox";
            this.progressPercent_checkBox.UseVisualStyleBackColor = true;
            this.progressPercent_checkBox.CheckedChanged += new System.EventHandler(this.progressPercent_checkBox_CheckedChanged);
            // 
            // progressShadow_checkBox
            // 
            resources.ApplyResources(this.progressShadow_checkBox, "progressShadow_checkBox");
            this.progressShadow_checkBox.Name = "progressShadow_checkBox";
            this.progressShadow_checkBox.UseVisualStyleBackColor = true;
            this.progressShadow_checkBox.CheckedChanged += new System.EventHandler(this.progressShadow_checkBox_CheckedChanged);
            // 
            // language_groupBox
            // 
            this.language_groupBox.Controls.Add(this.language_pictureBox);
            this.language_groupBox.Controls.Add(this.language_comboBox);
            resources.ApplyResources(this.language_groupBox, "language_groupBox");
            this.language_groupBox.Name = "language_groupBox";
            this.language_groupBox.TabStop = false;
            // 
            // language_pictureBox
            // 
            resources.ApplyResources(this.language_pictureBox, "language_pictureBox");
            this.language_pictureBox.Name = "language_pictureBox";
            this.language_pictureBox.TabStop = false;
            // 
            // language_comboBox
            // 
            this.language_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.language_comboBox.FormattingEnabled = true;
            this.language_comboBox.Items.AddRange(new object[] {
            resources.GetString("language_comboBox.Items"),
            resources.GetString("language_comboBox.Items1"),
            resources.GetString("language_comboBox.Items2"),
            resources.GetString("language_comboBox.Items3")});
            resources.ApplyResources(this.language_comboBox, "language_comboBox");
            this.language_comboBox.Name = "language_comboBox";
            this.language_comboBox.SelectedIndexChanged += new System.EventHandler(this.language_comboBox_SelectedIndexChanged);
            // 
            // Settings_InterfaceCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.language_groupBox);
            this.Controls.Add(this.progressbar_groupBox);
            this.Controls.Add(this.downcapacity_groupBox);
            this.Controls.Add(this.upcapacity_groupBox);
            this.Name = "Settings_InterfaceCtrl";
            this.downcapacity_groupBox.ResumeLayout(false);
            this.downcapacity_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downCapacity_numericUpDown)).EndInit();
            this.upcapacity_groupBox.ResumeLayout(false);
            this.upcapacity_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upCapacity_numericUpDown)).EndInit();
            this.progressbar_groupBox.ResumeLayout(false);
            this.progressbar_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressShadow_numericUpDown)).EndInit();
            this.language_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.language_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox downcapacity_groupBox;
        private System.Windows.Forms.Label downCapacityCon_label;
        private System.Windows.Forms.NumericUpDown downCapacity_numericUpDown;
        private System.Windows.Forms.GroupBox upcapacity_groupBox;
        private System.Windows.Forms.Label upCapacityCon_label;
        private System.Windows.Forms.NumericUpDown upCapacity_numericUpDown;
        private System.Windows.Forms.GroupBox progressbar_groupBox;
        private System.Windows.Forms.NumericUpDown progressShadow_numericUpDown;
        private System.Windows.Forms.CheckBox progressPercent_checkBox;
        private System.Windows.Forms.CheckBox progressShadow_checkBox;
        private System.Windows.Forms.Label progressShadow_label;
        private System.Windows.Forms.GroupBox language_groupBox;
        private System.Windows.Forms.ComboBox language_comboBox;
        private System.Windows.Forms.PictureBox language_pictureBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
