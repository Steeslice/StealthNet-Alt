using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    public partial class Settings_ConnectionCtrl : UserControl
    {
        private Button Applybutton = new Button();
        Preferences mySettings = new Preferences();

        private void didChanges(bool value)
        // if changes has been made, the apply button becomes enabled
        {
            Applybutton.Enabled = true;

        }

        public Settings_ConnectionCtrl(Button btnApply)
        {
            InitializeComponent();
            
            // *** Loading the port from the settings ***
            // ---------------------------------------------------------------------------
            try
            {
                if (int.Parse(mySettings.Setting("Port")) < port_numericUpDown.Minimum)
                    mySettings.Setting("Port", port_numericUpDown.Minimum.ToString());

                else if (int.Parse(mySettings.Setting("Port")) > port_numericUpDown.Maximum)
                    mySettings.Setting("Port", port_numericUpDown.Maximum.ToString());
                
            }
            catch (Exception)
            {
                mySettings.Setting("Port",mySettings.getKeyDefault("Port"));
            }
            port_numericUpDown.Value = decimal.Parse(mySettings.Setting("Port"));
            // ---------------------------------------------------------------------------
            
            // *** Loading the average connection count ***
            // ---------------------------------------------------------------------------


            int m_avgConCount;
            try
            {
                m_avgConCount = int.Parse(mySettings.Setting("AverageConnectionsCount"));
            }
            catch (Exception)
            {
               mySettings.Setting("AverageConnectionsCount", mySettings.getKeyDefault("AverageConnectionsCount"));
               m_avgConCount = int.Parse(mySettings.Setting("AverageConnectionsCount"));
            }

            if (m_avgConCount < 2)
                conCount_comboBox.Text = conCount_comboBox.Items[0].ToString();
            else if (m_avgConCount < 3)
                conCount_comboBox.Text = conCount_comboBox.Items[1].ToString();
            else if (m_avgConCount < 4)
                conCount_comboBox.Text = conCount_comboBox.Items[2].ToString();
            else if (m_avgConCount < 5)
                conCount_comboBox.Text = conCount_comboBox.Items[3].ToString();
            else if (m_avgConCount < 6)
                conCount_comboBox.Text = conCount_comboBox.Items[4].ToString();
            else if (m_avgConCount < 7)
                conCount_comboBox.Text = conCount_comboBox.Items[5].ToString();
            else if (m_avgConCount < 8)
                conCount_comboBox.Text = conCount_comboBox.Items[6].ToString();
            else if (m_avgConCount < 9)
                conCount_comboBox.Text = conCount_comboBox.Items[7].ToString();
            else if (m_avgConCount < 10)
                conCount_comboBox.Text = conCount_comboBox.Items[8].ToString();
            else
                conCount_comboBox.Text = conCount_comboBox.Items[9].ToString();

            
            // ---------------------------------------------------------------------------


            // *** Loading the Up- and Downloadlimit ***
            // ---------------------------------------------------------------------------
            try
            {
                enableDownLimit_checkBox.Checked = bool.Parse(mySettings.Setting("HasDownloadLimit"));
                int downloadLimit = int.Parse(mySettings.Setting("DownloadLimit")) * 8 / 1024;
                if (downloadLimit < downLimit_numericUpDown.Minimum)
                    downloadLimit = (int)downLimit_numericUpDown.Minimum;
                if (downloadLimit > downLimit_numericUpDown.Maximum)
                    downloadLimit = (int)downLimit_numericUpDown.Maximum;
                downLimit_numericUpDown.Value = downloadLimit;

            }
            catch (Exception)
            {
                mySettings.Setting("HasDownloadLimit", mySettings.getKeyDefault("HasDownloadLimit"));
                mySettings.Setting("DownloadLimit", mySettings.getKeyDefault("DownloadLimit"));
                enableDownLimit_checkBox.Checked = bool.Parse(mySettings.getKeyDefault("HasDownloadLimit"));
                downLimit_numericUpDown.Value = int.Parse(mySettings.getKeyDefault("DownloadLimit"));
            }

            try
            {
                enableUpLimit_checkBox.Checked = bool.Parse(mySettings.Setting("HasUploadLimit"));
                int uploadLimit = int.Parse(mySettings.Setting("UpLimit")) * 8 / 1024;
                if (uploadLimit < upLimit_numericUpDown.Minimum)
                    uploadLimit = (int)upLimit_numericUpDown.Minimum;
                if (uploadLimit > upLimit_numericUpDown.Maximum)
                    uploadLimit = (int)upLimit_numericUpDown.Maximum;
                upLimit_numericUpDown.Value = uploadLimit;

            }
            catch (Exception)
            {
                mySettings.Setting("HasUploadLimit", mySettings.getKeyDefault("HasUploadLimit"));
                mySettings.Setting("UploadLimit", mySettings.getKeyDefault("UploadLimi"));
                enableUpLimit_checkBox.Checked = bool.Parse(mySettings.getKeyDefault("HasUploadLimit"));
                upLimit_numericUpDown.Value = int.Parse(mySettings.getKeyDefault("UploadLimit"));
            }

            //*** Converting the units in the up- and downloadlimit ***
            upLimitCon_label.Text = Utils.BinaryToDecimal(Convert.ToInt32(upLimit_numericUpDown.Value), true, true);
            downLimitCon_label.Text = Utils.BinaryToDecimal(Convert.ToInt32(downLimit_numericUpDown.Value), true, true);

            try
            {
                syncWebcaches_checkBox.Checked = bool.Parse(mySettings.Setting("SynchronizeWebCaches"));
            }
            catch (Exception)
            {
                mySettings.Setting("SynchronizeWebCaches",mySettings.getKeyDefault("SynchronizeWebCaches"));
                syncWebcaches_checkBox.Checked = bool.Parse(mySettings.Setting("SynchronizeWebCaches"));
            }
            
            Applybutton = btnApply;
        }

        private void enableDownLimit_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableDownLimit_checkBox.Checked)
            {
                downLimit_numericUpDown.Enabled = true;
                downLimitCon_label.ForeColor = Color.Black;

            } //if (enableDownLimit_checkBox.Checked)
            else
            {
                downLimit_numericUpDown.Enabled = false;
                downLimitCon_label.ForeColor = Color.Gray;
            }

            didChanges(true);

        }

        private void enableUpLimit_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableUpLimit_checkBox.Checked)
            {
                upLimit_numericUpDown.Enabled = true;
                upLimitCon_label.ForeColor = Color.Black;

            } //if (enableDownLimit_checkBox.Checked)
            else
            {
                upLimit_numericUpDown.Enabled = false;
                upLimitCon_label.ForeColor = Color.Gray;
            }

            didChanges(true);
        }

        private void upLimit_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            upLimitCon_label.Text = Utils.BinaryToDecimal(Convert.ToInt32(upLimit_numericUpDown.Value), true, true);
            didChanges(true);
        }

        private void downLimit_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            downLimitCon_label.Text = Utils.BinaryToDecimal(Convert.ToInt32(downLimit_numericUpDown.Value), true, true);
            didChanges(true);
        }
                
        private void port_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            didChanges(true);
        }

        private void conCount_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            didChanges(true);
        } //private string BinaryToDecimal(long value, bool inBiggestUnit)

    }
}
