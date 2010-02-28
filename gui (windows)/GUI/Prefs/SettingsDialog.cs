using System;
using System.Windows.Forms;
using Regensburger.RShare.GUI.Preferences;

namespace Regensburger.RShare

{
    /* IF YOU WANT TO ADD YOUR OWN NEW SETTING SUBWINDOW, JUST FOLLOW THE NUMBERS
     * (1,2,3,4) IN THE COMMENTS. YOU ONLY HAVE TO DO SOMETHING THERE TO ADD YOUR
     * OWN MENUITEM!!!
     */
    
    
    //internal sealed partial class SettingsDialog : Form
    public partial class SettingsDialog : Form 
    {
        private Settings_ConnectionCtrl m_ConnectionCtrl;
        private Settings_DirectoryControl m_DirectoryCtrl;
        private Settings_InterfaceCtrl m_InterfaceCtrl;
        private Settings_MiscControl m_MiscCtrl;
        // ********* 1.) DECLARE YOUR NEW CONTROL WINDOW HERE (SEE EXAMPLES ABOVE) *********//



                
        private class mySettingMenuItem
        {
            // *** Attribute ***
            private string m_Description = "";
            private System.Drawing.Image m_Image = null;
            private byte m_ID = 0;

            // *** Properties ***
            public string Description
            {
                set { m_Description = value;}
                get { return m_Description; }
            } //public string Description()

            public System.Drawing.Image SettingImage
            {
                set { m_Image = value; }
                get { return m_Image; }
            } //public System.Drawing.Image SettingImage

            public byte ID
            {
                set
                {
                    if (value < 255)
                        m_ID = value;
                    else
                        m_ID = 1;
                }
                get { return m_ID; }
            }

        } //private class mySettingMenuItem

       
        public SettingsDialog()
        {
            RShare.MainForm.SetUILanguage();
            InitializeComponent();
          
            InitNavigationGrid();

            m_ConnectionCtrl = new Settings_ConnectionCtrl(this.btnApply);
            m_DirectoryCtrl = new Settings_DirectoryControl(this.btnApply);
            m_InterfaceCtrl = new Settings_InterfaceCtrl(this.btnApply);
            m_MiscCtrl = new Settings_MiscControl(this.btnApply);
            // ********* 2.) OPEN YOUR NEW CONTROL WINDOW HERE (SEE EXAMPLES ABOVE) *********//




            /*
            if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is Settings_ConnectionCtrl)))
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(m_ConnectionCtrl);
                m_ConnectionCtrl.Focus();
            }
             */
    
        }


        private void InitNavigationGrid()
        {
            // Defining the Columns
            NavigationDataGridview.Columns.Add("ColSetIcon", "");
            NavigationDataGridview.Columns["ColSetIcon"].Width = 17;

            NavigationDataGridview.Columns.Add("ColSetText", "");
            NavigationDataGridview.Columns["ColSetText"].Width = 100;

            // The invisible cell "ColSetID" is an _unique_ Identifier for each Setting-Screen
            NavigationDataGridview.Columns.Add("ColSetID", "");
            NavigationDataGridview.Columns["ColSetID"].Width = 0;
            NavigationDataGridview.Columns["ColSetID"].Visible = false;

            System.Collections.ArrayList mySettingList = new System.Collections.ArrayList();

            mySettingMenuItem myItem = new mySettingMenuItem();

            // *** Adding "Connections" (ID: 101) to navigation ***
            myItem = new mySettingMenuItem();
            myItem.Description = RShare.Properties.Resources.SettingsNavigationConnections;
            myItem.SettingImage = Properties.Resources.connections_16x16;
            myItem.ID = 101;
            mySettingList.Add(myItem);

            // *** Adding "Directories" (ID: 102) to navigation ***
            myItem = new mySettingMenuItem();
            myItem.Description = RShare.Properties.Resources.SettingsNavigationDirs;
            myItem.SettingImage = Properties.Resources.directories_16x16;
            myItem.ID = 102;
            mySettingList.Add(myItem);

            // *** Adding "Interface" (ID: 103) to navigation ***
            myItem = new mySettingMenuItem();
            myItem.Description = RShare.Properties.Resources.SettingsNavigationInterface;
            myItem.SettingImage = Properties.Resources.application_xp;
            myItem.ID = 103;
            mySettingList.Add(myItem);

            // *** Adding "Misc" (ID: 104) to navigation ***
            myItem = new mySettingMenuItem();
            myItem.Description = RShare.Properties.Resources.SettingsNavigationMisc;
            myItem.SettingImage = Properties.Resources.misc_16x16;
            myItem.ID = 104;
            mySettingList.Add(myItem);

            // ********* 3.) ADD THE NAVIGATION ITEM HERE (NEXT FREE ID IS 105) - SEE EXAMPLES ABOVE//



            DataGridViewRow settingsRow;
            DataGridViewCell settingsCell;

            for (int i = 0; i < mySettingList.Count; i++)
            {
                settingsRow = new DataGridViewRow();
                settingsRow.Height = 17;

                settingsCell = new DataGridViewImageCell();
                settingsRow.Cells.Add(settingsCell);
                settingsCell.Value = ((mySettingMenuItem)mySettingList[i]).SettingImage;

                settingsCell = new DataGridViewTextBoxCell();
                settingsRow.Cells.Add(settingsCell);
                settingsCell.Value = ((mySettingMenuItem)mySettingList[i]).Description;
                settingsCell.Tag = ((mySettingMenuItem)mySettingList[i]).Description;

                settingsCell = new DataGridViewTextBoxCell();
                settingsRow.Cells.Add(settingsCell);
                settingsCell.Value = ((mySettingMenuItem)mySettingList[i]).ID.ToString();

                NavigationDataGridview.Rows.Add(settingsRow);

            } //for (int i = 0; i < mySettingList.Count; i++)

        } //private void InitNavigationGrid()

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        
        private void NavigationDataGridview_SelectionChanged(object sender, EventArgs e)
        {
            if (NavigationDataGridview.SelectedRows.Count == 1)
            {
                byte SelectedNavID = Convert.ToByte(NavigationDataGridview.CurrentRow.Cells["ColSetID"].Value);

                switch (SelectedNavID)
                {
                    case 101: //ConnectionCtrl
                        if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is Settings_ConnectionCtrl)))
                        {
                            toolStripContainer.ContentPanel.Controls.Clear();
                            toolStripContainer.ContentPanel.Controls.Add(m_ConnectionCtrl);
                            m_ConnectionCtrl.Focus();
                        }
                        break;

                    case 102: //DirectoryCtrl
                        if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is Settings_DirectoryControl)))
                        {
                            toolStripContainer.ContentPanel.Controls.Clear();
                            toolStripContainer.ContentPanel.Controls.Add(m_DirectoryCtrl);
                            m_DirectoryCtrl.Focus();
                        }
                        break;

                    case 103:
                        if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is Settings_InterfaceCtrl)))
                        {
                            toolStripContainer.ContentPanel.Controls.Clear();
                            toolStripContainer.ContentPanel.Controls.Add(m_InterfaceCtrl);
                            m_InterfaceCtrl.Focus();
                        }
                        break;

                    case 104:
                        if (toolStripContainer.ContentPanel.Controls.Count == 0 || (toolStripContainer.ContentPanel.Controls.Count > 0 && !(toolStripContainer.ContentPanel.Controls[0] is Settings_MiscControl)))
                        {
                            toolStripContainer.ContentPanel.Controls.Clear();
                            toolStripContainer.ContentPanel.Controls.Add(m_MiscCtrl);
                            m_MiscCtrl.Focus();
                        }
                        break;


                    // ********* 4.) ADD AN CASE WITH THE ID (SEE 3.) OF YOUR NAVIGATION ITEM AND OPEN YOUR CONTROL *********//


                    
                    default:
                        break;
                }
                


            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
        }


        





        

        
    }
}