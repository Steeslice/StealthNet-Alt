//RShare
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
using System.Drawing;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class IsClosingDialog
        : Form
    {
        public IsClosingDialog()
        {
            MainForm.SetUILanguage();
            InitializeComponent();
            Text = string.Format(Text, String.Format(Constants.Software, Core.Version));
        }

        private void IsLoadingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SplashProvider.Instance.IsLoaded)
                e.Cancel = true;
        }

        private void IsLoadingDialog_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Font font = new Font(Font.FontFamily, 18F);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            gr.DrawString(String.Format(RShare.Properties.Resources.StealthNetIsClosing,Core.Version), font, Brushes.AntiqueWhite, new RectangleF(new PointF(16F, 302F), new SizeF(489F, 37F)), sf);
            sf.Dispose();
            font.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 100;
            if (!SplashProvider.Instance.IsLoaded)
                Close();
        }
    }
}