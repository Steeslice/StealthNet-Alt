namespace Regensburger.RShare
{
    partial class Settings_ConnectionCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_ConnectionCtrl));
            this.port_groupBox = new System.Windows.Forms.GroupBox();
            this.port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.conCount_groupBox = new System.Windows.Forms.GroupBox();
            this.conCount_comboBox = new System.Windows.Forms.ComboBox();
            this.uplimit_groupBox = new System.Windows.Forms.GroupBox();
            this.upLimitCon_label = new System.Windows.Forms.Label();
            this.upLimit_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.enableUpLimit_checkBox = new System.Windows.Forms.CheckBox();
            this.downlimit_groupBox = new System.Windows.Forms.GroupBox();
            this.downLimitCon_label = new System.Windows.Forms.Label();
            this.downLimit_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.enableDownLimit_checkBox = new System.Windows.Forms.CheckBox();
            this.misc_groupBox = new System.Windows.Forms.GroupBox();
            this.syncWebcaches_checkBox = new System.Windows.Forms.CheckBox();
            this.port_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port_numericUpDown)).BeginInit();
            this.conCount_groupBox.SuspendLayout();
            this.uplimit_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upLimit_numericUpDown)).BeginInit();
            this.downlimit_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downLimit_numericUpDown)).BeginInit();
            this.misc_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_groupBox
            // 
            this.port_groupBox.Controls.Add(this.port_numericUpDown);
            resources.ApplyResources(this.port_groupBox, "port_groupBox");
            this.port_groupBox.Name = "port_groupBox";
            this.port_groupBox.TabStop = false;
            // 
            // port_numericUpDown
            // 
            resources.ApplyResources(this.port_numericUpDown, "port_numericUpDown");
            this.port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.port_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.port_numericUpDown.Name = "port_numericUpDown";
            this.port_numericUpDown.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.port_numericUpDown.ValueChanged += new System.EventHandler(this.port_numericUpDown_ValueChanged);
            // 
            // conCount_groupBox
            // 
            this.conCount_groupBox.Controls.Add(this.conCount_comboBox);
            resources.ApplyResources(this.conCount_groupBox, "conCount_groupBox");
            this.conCount_groupBox.Name = "conCount_groupBox";
            this.conCount_groupBox.TabStop = false;
            // 
            // conCount_comboBox
            // 
            this.conCount_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conCount_comboBox.FormattingEnabled = true;
            this.conCount_comboBox.Items.AddRange(new object[] {
            resources.GetString("conCount_comboBox.Items"),
            resources.GetString("conCount_comboBox.Items1"),
            resources.GetString("conCount_comboBox.Items2"),
            resources.GetString("conCount_comboBox.Items3"),
            resources.GetString("conCount_comboBox.Items4"),
            resources.GetString("conCount_comboBox.Items5"),
            resources.GetString("conCount_comboBox.Items6"),
            resources.GetString("conCount_comboBox.Items7"),
            resources.GetString("conCount_comboBox.Items8"),
            resources.GetString("conCount_comboBox.Items9")});
            resources.ApplyResources(this.conCount_comboBox, "conCount_comboBox");
            this.conCount_comboBox.Name = "conCount_comboBox";
            this.conCount_comboBox.SelectedIndexChanged += new System.EventHandler(this.conCount_comboBox_SelectedIndexChanged);
            // 
            // uplimit_groupBox
            // 
            this.uplimit_groupBox.Controls.Add(this.upLimitCon_label);
            this.uplimit_groupBox.Controls.Add(this.upLimit_numericUpDown);
            this.uplimit_groupBox.Controls.Add(this.enableUpLimit_checkBox);
            resources.ApplyResources(this.uplimit_groupBox, "uplimit_groupBox");
            this.uplimit_groupBox.Name = "uplimit_groupBox";
            this.uplimit_groupBox.TabStop = false;
            // 
            // upLimitCon_label
            // 
            resources.ApplyResources(this.upLimitCon_label, "upLimitCon_label");
            this.upLimitCon_label.ForeColor = System.Drawing.Color.Gray;
            this.upLimitCon_label.Name = "upLimitCon_label";
            // 
            // upLimit_numericUpDown
            // 
            resources.ApplyResources(this.upLimit_numericUpDown, "upLimit_numericUpDown");
            this.upLimit_numericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.upLimit_numericUpDown.Name = "upLimit_numericUpDown";
            this.upLimit_numericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.upLimit_numericUpDown.ValueChanged += new System.EventHandler(this.upLimit_numericUpDown_ValueChanged);
            // 
            // enableUpLimit_checkBox
            // 
            resources.ApplyResources(this.enableUpLimit_checkBox, "enableUpLimit_checkBox");
            this.enableUpLimit_checkBox.Name = "enableUpLimit_checkBox";
            this.enableUpLimit_checkBox.UseVisualStyleBackColor = true;
            this.enableUpLimit_checkBox.CheckedChanged += new System.EventHandler(this.enableUpLimit_checkBox_CheckedChanged);
            // 
            // downlimit_groupBox
            // 
            this.downlimit_groupBox.Controls.Add(this.downLimitCon_label);
            this.downlimit_groupBox.Controls.Add(this.downLimit_numericUpDown);
            this.downlimit_groupBox.Controls.Add(this.enableDownLimit_checkBox);
            resources.ApplyResources(this.downlimit_groupBox, "downlimit_groupBox");
            this.downlimit_groupBox.Name = "downlimit_groupBox";
            this.downlimit_groupBox.TabStop = false;
            // 
            // downLimitCon_label
            // 
            resources.ApplyResources(this.downLimitCon_label, "downLimitCon_label");
            this.downLimitCon_label.ForeColor = System.Drawing.Color.Gray;
            this.downLimitCon_label.Name = "downLimitCon_label";
            // 
            // downLimit_numericUpDown
            // 
            resources.ApplyResources(this.downLimit_numericUpDown, "downLimit_numericUpDown");
            this.downLimit_numericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downLimit_numericUpDown.Name = "downLimit_numericUpDown";
            this.downLimit_numericUpDown.Value = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.downLimit_numericUpDown.ValueChanged += new System.EventHandler(this.downLimit_numericUpDown_ValueChanged);
            // 
            // enableDownLimit_checkBox
            // 
            resources.ApplyResources(this.enableDownLimit_checkBox, "enableDownLimit_checkBox");
            this.enableDownLimit_checkBox.Name = "enableDownLimit_checkBox";
            this.enableDownLimit_checkBox.UseVisualStyleBackColor = true;
            this.enableDownLimit_checkBox.CheckedChanged += new System.EventHandler(this.enableDownLimit_checkBox_CheckedChanged);
            // 
            // misc_groupBox
            // 
            this.misc_groupBox.Controls.Add(this.syncWebcaches_checkBox);
            resources.ApplyResources(this.misc_groupBox, "misc_groupBox");
            this.misc_groupBox.Name = "misc_groupBox";
            this.misc_groupBox.TabStop = false;
            // 
            // syncWebcaches_checkBox
            // 
            resources.ApplyResources(this.syncWebcaches_checkBox, "syncWebcaches_checkBox");
            this.syncWebcaches_checkBox.Name = "syncWebcaches_checkBox";
            this.syncWebcaches_checkBox.UseVisualStyleBackColor = true;
            // 
            // Settings_ConnectionCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.misc_groupBox);
            this.Controls.Add(this.downlimit_groupBox);
            this.Controls.Add(this.uplimit_groupBox);
            this.Controls.Add(this.conCount_groupBox);
            this.Controls.Add(this.port_groupBox);
            this.Name = "Settings_ConnectionCtrl";
            this.port_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.port_numericUpDown)).EndInit();
            this.conCount_groupBox.ResumeLayout(false);
            this.uplimit_groupBox.ResumeLayout(false);
            this.uplimit_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upLimit_numericUpDown)).EndInit();
            this.downlimit_groupBox.ResumeLayout(false);
            this.downlimit_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downLimit_numericUpDown)).EndInit();
            this.misc_groupBox.ResumeLayout(false);
            this.misc_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox port_groupBox;
        private System.Windows.Forms.NumericUpDown port_numericUpDown;
        private System.Windows.Forms.GroupBox conCount_groupBox;
        private System.Windows.Forms.ComboBox conCount_comboBox;
        private System.Windows.Forms.GroupBox uplimit_groupBox;
        private System.Windows.Forms.NumericUpDown upLimit_numericUpDown;
        private System.Windows.Forms.CheckBox enableUpLimit_checkBox;
        private System.Windows.Forms.Label upLimitCon_label;
        private System.Windows.Forms.GroupBox downlimit_groupBox;
        private System.Windows.Forms.Label downLimitCon_label;
        private System.Windows.Forms.NumericUpDown downLimit_numericUpDown;
        private System.Windows.Forms.CheckBox enableDownLimit_checkBox;
        private System.Windows.Forms.GroupBox misc_groupBox;
        private System.Windows.Forms.CheckBox syncWebcaches_checkBox;




    }
}
