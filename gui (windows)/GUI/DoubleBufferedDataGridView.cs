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

using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed class DoubleBufferedDataGridView
        : DataGridView
    {
        public DoubleBufferedDataGridView()
        {
            DoubleBuffered = true;
            MouseDown += new MouseEventHandler(DoubleBufferedDataGridView_MouseDown);
        }

        private void DoubleBufferedDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridView.HitTestInfo hti = HitTest(e.X, e.Y);
                    if (hti.Type == DataGridViewHitTestType.Cell)
                    {
                        if (!Rows[hti.RowIndex].Selected)
                        {
                            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                                Rows[hti.RowIndex].Selected = true;
                            else
                                ClearSelection(-1, hti.RowIndex, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}