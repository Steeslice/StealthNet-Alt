//StealthNet
//Copyright (C) 2009 Lars Regensburger

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
using System.Threading;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed class SplashProvider
        : ApplicationContext
    {
        private static SplashProvider m_Instance;

        private string[] m_Arguments;

        private bool m_IsLoaded = false;

        private IsLoadingDialog m_IsLoadingDialog;

        private MainForm m_MainForm;

        private IsClosingDialog m_IsClosingDialog;

        public static SplashProvider Instance
        {
            get
            {
                if (m_Instance == null)
                    throw new InvalidOperationException();
                return m_Instance;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return m_IsLoaded;
            }
        }

        public SplashProvider(string[] args)
        {
            if (m_Instance != null)
                throw new InvalidOperationException();
            m_Instance = this;

            m_Arguments = args;

            m_IsLoadingDialog = new IsLoadingDialog();
            m_IsLoadingDialog.FormClosed += new FormClosedEventHandler(IsLoadingDialog_FormClosed);
            m_IsLoadingDialog.Show();
            m_IsLoadingDialog.Activate();

            Thread coreThread = new Thread(delegate()
            {
                try
                {
                    if (bool.Parse(Settings.Instance["FirstStart"]))
                        Settings.Instance.Upgrade();

                    Core.Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), String.Format(Constants.Software, Core.Version), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                m_IsLoaded = true;
            });
            coreThread.Name = "coreThread";
            coreThread.IsBackground = true;
            coreThread.Start();
        }

        private void IsLoadingDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_MainForm = new MainForm();
            m_MainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            // T.Norad: BZ 125
            m_MainForm.SetStart();
            m_MainForm.Show();
            m_MainForm.Activate();

            // 2007-10.19 Eroli: Mono-Fix
            if (!UtilitiesForMono.IsRunningOnMono)
            {
                // 2007-10-03 T.Norad: if the client is startet with a stealthnet link (and not startet before)
                // send the stealthnet link to the mainform after activate it
                Program.SendStealthNetLinkToOpenClient(m_Arguments);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_IsClosingDialog = new IsClosingDialog();
            m_IsClosingDialog.FormClosed += new FormClosedEventHandler(IsClosingDialog_FormClosed);
            m_IsClosingDialog.Show();
            m_IsClosingDialog.Activate();

            Thread coreThread = new Thread(delegate()
            {
                try
                {
                    Core.Close();
                    Settings.Instance.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), String.Format(Constants.Software, Core.Version), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                m_IsLoaded = false;
            });
            coreThread.Name = "coreThread";
            coreThread.IsBackground = true;
            coreThread.Start();
        }

        private void IsClosingDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThreadCore();
        }
    }
}