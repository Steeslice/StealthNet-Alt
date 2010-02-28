//RShare
//Copyright (C) 2009 T.Norad

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Resources;

namespace Regensburger.RShare.GUI.Preferences
{
    // Added 2007-04-30 by T.Norad
    public partial class MiscControl : UserControl
    {
        private ICoreSettings m_Settings = Settings.Instance;
        
        public MiscControl()
        {
            RShare.MainForm.SetUILanguage();
            // LoadLanguageSettings();
            InitializeComponent();
            
            // set the value for the property "Write logfile"
            // Added 2007-05-06 by T.Norad
            writeLogCheckBox.Checked = bool.Parse(m_Settings["WriteLogfile"]);
            txtBoxPreviewPlayer.Text = m_Settings["PreviewPlayer"];
            if (bool.Parse(m_Settings["ActivateOnlineSignature"]))
            {
                ActiveOnlineSignatureCheckBox.Checked = true;
                OnlineSignatureLabel1.Visible = true;
                OnlineSignatureUpdateIntervallNumericUpDown.Visible = true;
                OnlineSignatureLabel2.Visible = true;
            }
            else
            {
                ActiveOnlineSignatureCheckBox.Checked = false;
                OnlineSignatureLabel1.Visible = false;
                OnlineSignatureUpdateIntervallNumericUpDown.Visible = false;
                OnlineSignatureLabel2.Visible = false;
            }
            OnlineSignatureUpdateIntervallNumericUpDown.Value = decimal.Parse(m_Settings["OnlineSignatureUpdateIntervall"]);
            //2009-01-25 Nochbaer
            if (bool.Parse(m_Settings["ActivateSearchDB"]))
            {
                ActivateSearchDBCheckBox.Checked = true;
                SearchDBLabel1.Visible = true;
                SearchDBCleanUpDaysNumericUpDown.Visible = true;
                SearchDBLabel2.Visible = true;
            }
            else
            {
                ActivateSearchDBCheckBox.Checked = false;
                SearchDBLabel1.Visible = false;
                SearchDBCleanUpDaysNumericUpDown.Visible = false;
                SearchDBLabel2.Visible = false;
            }
            SearchDBCleanUpDaysNumericUpDown.Value = decimal.Parse(m_Settings["SearchDBCleanUpDays"]);

            int downloads = int.Parse(Properties.Settings.Default.MaximumDownloadsCount);
            switch (downloads)
            {
                case 1:
                    Properties.Settings.Default.MaximumDownloadsCount = 1.ToString();
                    downloadsComboBox.SelectedIndex = 0;
                    break;
                case 2:
                    Properties.Settings.Default.MaximumDownloadsCount = 2.ToString();
                    downloadsComboBox.SelectedIndex = 1;
                    break;
                case 3:
                    Properties.Settings.Default.MaximumDownloadsCount = 3.ToString();
                    downloadsComboBox.SelectedIndex = 2;
                    break;
                case 4:
                    Properties.Settings.Default.MaximumDownloadsCount = 4.ToString();
                    downloadsComboBox.SelectedIndex = 3;
                    break;
                default:
                    Properties.Settings.Default.MaximumDownloadsCount = 6.ToString();
                    downloadsComboBox.SelectedIndex = 4;
                    break;
                case 12:
                    Properties.Settings.Default.MaximumDownloadsCount = 12.ToString();
                    downloadsComboBox.SelectedIndex = 5;
                    break;
            }
        }

        /// <summary>
        /// Added 2007-05-06 by T.Norad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.writeLogCheckBox.Checked != bool.Parse(m_Settings["WriteLogfile"]))
            {
                m_Settings["WriteLogfile"] = this.writeLogCheckBox.Checked.ToString();
            }
        }

        private void LoadLanguageSettings()
        {
            switch(m_Settings["UICulture"])
            {
                case "de":
                    rbtGermanLanguage.Checked = true;
                    break;

                case "en":
                    rbtEnglishLanguage.Checked = true;
                    break;

                case "fr":
                    rbtFrenchLanguage.Checked = true;
                    break;
                    
                case "tr":
                    rbtTurkishLanguage.Checked = true;
                    break;

                case "es":
                    rbtSpanishLanguage.Checked = true;
                    break;

                default:
                    rbtEnglishLanguage.Checked = true;
                    break;
            }
        }

        private void SaveLanguageSettings(string Language)
        {
            m_Settings["UICulture"] = Language;
        }

        // Activate languages
        private void rbtEnglishLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEnglishLanguage.Checked)
            {
                SaveLanguageSettings("en");
            }
        }

        private void rbtFrenchLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFrenchLanguage.Checked)
            {
                SaveLanguageSettings("fr");
            }
        }

        private void rbtGermanLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtGermanLanguage.Checked)
            {
                SaveLanguageSettings("de");
            }
        }

        private void rbtTurkishLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTurkishLanguage.Checked)
            {
                SaveLanguageSettings("tr");
            }
        }

        private void rbtItalianLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtItalianLanguage.Checked)
            {
                SaveLanguageSettings("it");
            }
        }

        private void rbtSpanishLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSpanishLanguage.Checked)
            {
                SaveLanguageSettings("es");
            }
        }

        private void MiscControl_Load(object sender, EventArgs e)
        {
            string Language = RShare.MainForm.GetUILanguage();
            if (Language == "en")
            {
                rbtEnglishLanguage.Checked = true;
            }
            else
            if (Language == "de")
            {
                rbtGermanLanguage.Checked = true;
            }
            else
            if (Language == "fr")
            {
                rbtFrenchLanguage.Checked = true;
            }
            else
            if (Language == "tr")
            {
                rbtTurkishLanguage.Checked = true;
            }
            else
            if (Language == "it")
            {
                rbtItalianLanguage.Checked = true;
            }
            else
            if (Language == "es")
            {
                rbtSpanishLanguage.Checked = true;
            }
        }

        private void btnBrowsePreviewPlayer_Click(object sender, EventArgs e)
        {
            PreviewPlayerBrowseDialog.ShowDialog();
            txtBoxPreviewPlayer.Text = PreviewPlayerBrowseDialog.FileName;

            m_Settings["PreviewPlayer"] = txtBoxPreviewPlayer.Text;
        }

        private void ActiveOnlineSignatureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveOnlineSignatureCheckBox.Checked)
            {
                OnlineSignatureLabel1.Visible = true;
                OnlineSignatureLabel2.Visible = true;
                OnlineSignatureUpdateIntervallNumericUpDown.Visible = true;
                m_Settings["ActivateOnlineSignature"] = "True";
            }
            else
            {
                OnlineSignatureLabel1.Visible = false;
                OnlineSignatureLabel2.Visible = false;
                OnlineSignatureUpdateIntervallNumericUpDown.Visible = false;
                m_Settings["ActivateOnlineSignature"] = "False";
            }
        }

        private void OnlineSignatureUpdateIntervallNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (OnlineSignatureUpdateIntervallNumericUpDown.Value.ToString() != m_Settings["OnlineSignatureUpdateIntervall"])
                m_Settings["OnlineSignatureUpdateIntervall"] = OnlineSignatureUpdateIntervallNumericUpDown.Value.ToString();
        }

        //2009-01-25 Nochbaer
        private void ActivateSearchDBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivateSearchDBCheckBox.Checked)
            {
                SearchDBLabel1.Visible = true;
                SearchDBCleanUpDaysNumericUpDown.Visible = true;
                SearchDBLabel2.Visible = true;
                m_Settings["ActivateSearchDB"] = "True";
            }
            else
            {
                SearchDBLabel1.Visible = false;
                SearchDBCleanUpDaysNumericUpDown.Visible = false;
                SearchDBLabel2.Visible = false;
                m_Settings["ActivateSearchDB"] = "False";
            }
        }

        //2009-01-25 Nochbaer
        private void SearchDBCleanUpDaysNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (SearchDBCleanUpDaysNumericUpDown.Value.ToString() != m_Settings["SearchDBCleanUpDays"])
                m_Settings["SearchDBCleanUpDays"] = SearchDBCleanUpDaysNumericUpDown.Value.ToString();
        }

        private void downloadsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (downloadsComboBox.SelectedIndex)
            {
                case 0:
                    Properties.Settings.Default.MaximumDownloadsCount = 1.ToString();
                    break;
                case 1:
                    Properties.Settings.Default.MaximumDownloadsCount = 2.ToString();
                    break;
                case 2:
                    Properties.Settings.Default.MaximumDownloadsCount = 3.ToString();
                    break;
                case 3:
                    Properties.Settings.Default.MaximumDownloadsCount = 4.ToString();
                    break;
                default:
                    Properties.Settings.Default.MaximumDownloadsCount = 6.ToString();
                    break;
                case 5:
                    Properties.Settings.Default.MaximumDownloadsCount = 12.ToString();
                    break;
            }
        }
    }
}
