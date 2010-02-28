using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class Settings_InterfaceCtrl : UserControl
    {
        Preferences mySettings = new Preferences();
        private Button Applybutton = new Button();

        private void didChanges(bool value)
        // if changes has been made, the apply button becomes enabled
        {
            Applybutton.Enabled = true;

        }

        public Settings_InterfaceCtrl(Button btnApply)
        {
            InitializeComponent();
            
            progressPercent_checkBox.Checked = bool.Parse(mySettings.Setting("ProgressBarsShowPercent"));
            progressShadow_checkBox.Checked = bool.Parse(mySettings.Setting("ProgressBarsHaveShadow"));

            int m_ProgressbarShadow;
            try
            {
                m_ProgressbarShadow = int.Parse(mySettings.Setting("ProgressBarsShadow"));
            }
            catch (Exception)
            {
                m_ProgressbarShadow = int.Parse(mySettings.Setting("ProgressBarsShadow", mySettings.getKeyDefault("ProgressBarsShadow")));
            }

            if (m_ProgressbarShadow < progressShadow_numericUpDown.Minimum)
                mySettings.Setting("ProgressBarsShadow", progressShadow_numericUpDown.Minimum.ToString());
            if (m_ProgressbarShadow > progressShadow_numericUpDown.Maximum)
                mySettings.Setting("ProgressBarsShadow", progressShadow_numericUpDown.Maximum.ToString());
            progressShadow_numericUpDown.Value = decimal.Parse(mySettings.Setting("ProgressBarsShadow"));
            
            // Capacities
            int downloadCapacity = int.Parse(mySettings.Setting("DownloadCapacity")) * 8 / 1024;
            if (downloadCapacity < downCapacity_numericUpDown.Minimum)
                downloadCapacity = (int)downCapacity_numericUpDown.Minimum;
            if (downloadCapacity > downCapacity_numericUpDown.Maximum)
                downloadCapacity = (int)downCapacity_numericUpDown.Maximum;
            downCapacity_numericUpDown.Value = downloadCapacity;
            downCapacityCon_label.Text = Utils.BinaryToDecimal(downloadCapacity,true,true);
            int uploadCapacity = int.Parse(mySettings.Setting("UploadCapacity")) * 8 / 1024;
            if (uploadCapacity < upCapacity_numericUpDown.Minimum)
                uploadCapacity = (int)upCapacity_numericUpDown.Minimum;
            if (uploadCapacity > upCapacity_numericUpDown.Maximum)
                uploadCapacity = (int)upCapacity_numericUpDown.Maximum;
            upCapacity_numericUpDown.Value = uploadCapacity;
            upCapacityCon_label.Text = Utils.BinaryToDecimal(uploadCapacity, true, true);

            progressShadowUpdate();
            getCurrentLanguage();
                        
            Applybutton = btnApply;
        }

        private void progressShadow_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            progressShadowUpdate();
            didChanges(true);
        }

        private void getCurrentLanguage()
        //determines the current language and fills it in the language combobox
        //Also loading the correct language picuture
        {
            string Language = RShare.MainForm.GetUILanguage();

            switch (Language)
            {
                case "en":
                    language_comboBox.Text = language_comboBox.Items[0].ToString();
                    language_pictureBox.Image = RShare.Properties.Resources.flag_en_32x48;
                    break;

                case "de":
                    language_comboBox.Text = language_comboBox.Items[1].ToString();
                    language_pictureBox.Image = RShare.Properties.Resources.flag_germany_32x48;
                    break;

                case "fr":
                    language_comboBox.Text = language_comboBox.Items[2].ToString();
                    language_pictureBox.Image = RShare.Properties.Resources.flag_france_32x48;
                    break;

                case "tr":
                    language_comboBox.Text = language_comboBox.Items[2].ToString();
                    language_pictureBox.Image = RShare.Properties.Resources.flag_turkey_32x46;
                    break;

                default:
                    language_comboBox.Text = language_comboBox.Items[3].ToString();
                    language_pictureBox.Image = RShare.Properties.Resources.flag_en_32x48;
                    break;
            }
        }

        private void progressShadowUpdate()
            // if the shadow is checked, the shadowlevel becomes enabled.
            // if the shadow is disabled, the shadowlevel becomes disabled.
        {
            if (progressShadow_checkBox.Checked)
            {
                progressShadow_label.Enabled = true;
                progressShadow_numericUpDown.Enabled = true;
            }
            else
            {
                progressShadow_label.Enabled = false;
                progressShadow_numericUpDown.Enabled = false;
            }
        }

        private void downCapacity_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            downCapacityCon_label.Text = Utils.BinaryToDecimal(Convert.ToInt32(downCapacity_numericUpDown.Value), true, true);
            didChanges(true);
        }

        private void upCapacity_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            upCapacityCon_label.Text = Utils.BinaryToDecimal(Convert.ToInt32(upCapacity_numericUpDown.Value), true, true);
            didChanges(true);
        }

        private void progressPercent_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void progressShadow_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void language_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void messageWindow_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            didChanges(true);

        }

        private void format_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void previewParameters_textbox_TextChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void browsePreviewPlayer_button_Click(object sender, EventArgs e)
        {

        }

        private void previewPlayer_textbox_TextChanged(object sender, EventArgs e)
        {

        }

     
    }
}
