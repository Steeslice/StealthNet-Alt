using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class Settings_DirectoryControl : UserControl
    {
        //private Settings m_Settings = Settings.Instance;
        private Preferences mySettings = new Preferences();
        private Button Applybutton = new Button();

        private void didChanges(bool value)
            // if changes has been made, the apply button becomes enabled
        {
            Applybutton.Enabled = true;
            
        }

        private void updateDirectoyCount()
        {
            sharedDirectoriesLabel.Text = string.Format(Properties.Resources.SharedDirectories, sharedDirectoriesDataGridView.Rows.Count);
        }

        private bool shareAlreadyInList(string Directory)
        {
            bool Result = false;

            foreach (DataGridViewRow CurrentRow in sharedDirectoriesDataGridView.Rows)
            {
                if (String.Compare(CurrentRow.Cells[1].Value.ToString(), Directory, true) == 0)
                    Result = true;
            }
            return Result;
        }




        public Settings_DirectoryControl(Button btnApply)
        {
            InitializeComponent();
            SettingDirPrefFiles_textbox.Text = mySettings.Setting("PreferencesDirectory");
            SettingDirCoruptFiles_textbox.Text = mySettings.Setting("CorruptDirectory");
            SettingDirIncomFiles_textbox.Text = mySettings.Setting("IncomingDirectory");
            SettingDirLogFiles_textbox.Text = mySettings.Setting("LogDirectory");
            SettingDirTempFiles_textbox.Text = mySettings.Setting("TemporaryDirectory");

            UpdateSharedDirs();

            Applybutton = btnApply;
            
        }

        


        private void UpdateSharedDirs()
        {
            sharedDirectoriesLabel.Text = string.Format(Properties.Resources.SharedDirectories, Core.SharedDirectories.Count);
            DataGridViewRow sharedDirectoryRow;
            DataGridViewCell sharedDirectoryCell;
            foreach (string sharedDirectory in Core.SharedDirectories)
            {
                sharedDirectoryRow = null;
                foreach (DataGridViewRow row in sharedDirectoriesDataGridView.Rows)
                    if (row.Tag.Equals(sharedDirectory))
                    {
                        sharedDirectoryRow = row;
                        break;
                    }
                if (sharedDirectoryRow == null)
                {
                    sharedDirectoryRow = new DataGridViewRow();
                    sharedDirectoryRow.Height = 17;
                    sharedDirectoryCell = new DataGridViewImageCell();
                    sharedDirectoryRow.Cells.Add(sharedDirectoryCell);
                    sharedDirectoryCell.Value = Properties.Resources.directory_16x16;
                    sharedDirectoryCell = new DataGridViewTextBoxCell();
                    sharedDirectoryRow.Cells.Add(sharedDirectoryCell);
                    sharedDirectoryCell.Value = sharedDirectory;
                    sharedDirectoryRow.Tag = sharedDirectory;
                    sharedDirectoriesDataGridView.Rows.Add(sharedDirectoryRow);
                    continue;
                }
            }
            
            sharedDirectoriesDataGridView.Sort(sharedDirectoriesDataGridView.Columns[1], sharedDirectoriesDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
        }

        private void addSharedDirtoList(string newDirectory)
        {
            if (System.IO.Directory.Exists(newDirectory))
            {
                DataGridViewRow sharedDirectoryRow;
                DataGridViewCell sharedDirectoryCell;
                sharedDirectoryRow = new DataGridViewRow();
                sharedDirectoryRow.Height = 17;
                sharedDirectoryCell = new DataGridViewImageCell();
                sharedDirectoryRow.Cells.Add(sharedDirectoryCell);
                sharedDirectoryCell.Value = Properties.Resources.directory_16x16;
                sharedDirectoryCell = new DataGridViewTextBoxCell();
                sharedDirectoryRow.Cells.Add(sharedDirectoryCell);
                sharedDirectoryCell.Value = newDirectory;
                sharedDirectoryRow.Tag = newDirectory;
                sharedDirectoriesDataGridView.Rows.Add(sharedDirectoryRow);

                updateDirectoyCount();

            } //if (System.IO.Directory.Exists(path)
        }



        private void addSharedDirectoryButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = "Desktop";
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && !shareAlreadyInList(folderBrowserDialog.SelectedPath))
            {
                addSharedDirtoList(folderBrowserDialog.SelectedPath);
                sharedDirectoriesDataGridView.Sort(sharedDirectoriesDataGridView.Columns[1], sharedDirectoriesDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                didChanges(true);
            }
        }

        private void removeSharedDirectoryButton_Click(object sender, EventArgs e)
        {
            if (sharedDirectoriesDataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow currentRow in sharedDirectoriesDataGridView.SelectedRows)
                {
                    sharedDirectoriesDataGridView.Rows.Remove(currentRow);
                    didChanges(true);
                }
            }
            updateDirectoyCount();
        }

        private void browsePrefFiles_btn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = mySettings.Setting("PreferencesDirectory");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && folderBrowserDialog.SelectedPath != mySettings.Setting("PreferencesDirectory"))
            {
                SettingDirPrefFiles_textbox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseLogFiles_btn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = mySettings.Setting("LogDirectory");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && folderBrowserDialog.SelectedPath != mySettings.Setting("LogDirectory"))
            {
                SettingDirLogFiles_textbox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseIncomFiles_btn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = mySettings.Setting("IncomingDirectory");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && folderBrowserDialog.SelectedPath != mySettings.Setting("IncomingDirectory"))
            {
                SettingDirIncomFiles_textbox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseCorruptFiles_btn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = mySettings.Setting("CorruptDirectory");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && folderBrowserDialog.SelectedPath != mySettings.Setting("CorruptDirectory"))
            {
                SettingDirCoruptFiles_textbox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseTempFiles_btn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = mySettings.Setting("TemporaryDirectory");
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && folderBrowserDialog.SelectedPath != mySettings.Setting("TemporaryDirectory"))
            {
                SettingDirTempFiles_textbox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        
    }
}
