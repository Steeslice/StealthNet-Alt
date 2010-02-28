using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    public partial class Settings_MiscControl : UserControl
    {
        //private Settings m_Settings = Settings.Instance;
        private Preferences mySettings = new Preferences();
        private Button Applybutton = new Button();


        private void didChanges(bool value)
        // if changes has been made, the apply button becomes enabled
        {
            Applybutton.Enabled = true;

        }

        public Settings_MiscControl(Button btnApply)
        {
            InitializeComponent();

            previewPlayer_textbox.Text = mySettings.Setting("PreviewPlayer");
            previewParameters_textbox.Text = mySettings.Setting("PreviewParams");

            messageWindow_checkBox.Checked = bool.Parse(mySettings.Setting("ShowMessageBoxes"));
            format_checkBox.Checked = bool.Parse(mySettings.Setting("UseBytesInsteadOfBits"));

            closeToTray_checkBox.Checked = bool.Parse(mySettings.Setting("AlwaysCloseToTray"));
            Applybutton = btnApply;
        }

        private void browsePreviewPlayer_button_Click(object sender, EventArgs e)
        {

        }

        private void messageWindow_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void format_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void showSyndie_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (showSyndie_checkbox.Checked)
            {
                syndieProgPath_textBox.Enabled = true;
                browseSyndiePath_button.Enabled = true;
            }
            else
            {
                syndieProgPath_textBox.Enabled = false;
                browseSyndiePath_button.Enabled = false;
            }




        }

        
    }
}
