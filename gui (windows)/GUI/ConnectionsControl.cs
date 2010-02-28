//RShare
//Copyright (C) 2009 Lars Regensburger, T.Norad

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

using Regensburger.RCollections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class ConnectionsControl
        : UserControl
    {
        private MainForm m_MainForm;

        private ICoreSettings m_Settings = Settings.Instance;

        private bool m_start = true;

        public ConnectionsControl(MainForm mainForm)
        {
            if (mainForm == null)
                throw new ArgumentNullException("mainForm");

            m_MainForm = mainForm;
            RShare.MainForm.SetUILanguage();
            InitializeComponent();
            connectionsDataGridView.Sort(connectionsDataGridView.Columns["IPAddress"], ListSortDirection.Ascending);

            //2008-07-28 Nochbaer BZ 56 load order of columns
            try
            {
                connectionsDataGridView.Columns["Icon"].DisplayIndex = Int32.Parse(m_Settings["connectionsIconIndex"]);
                connectionsDataGridView.Columns["Icon"].FillWeight = float.Parse(m_Settings["connectionsIconWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["IPAddress"].DisplayIndex = Int32.Parse(m_Settings["connectionsIPAddressIndex"]);
                connectionsDataGridView.Columns["IPAddress"].FillWeight = float.Parse(m_Settings["connectionsIPAddressWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["Port"].DisplayIndex = Int32.Parse(m_Settings["connectionsPortIndex"]);
                connectionsDataGridView.Columns["Port"].FillWeight = float.Parse(m_Settings["connectionsPortWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["Sent"].DisplayIndex = Int32.Parse(m_Settings["connectionsSentIndex"]);
                connectionsDataGridView.Columns["Sent"].FillWeight = float.Parse(m_Settings["connectionsSentWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["Received"].DisplayIndex = Int32.Parse(m_Settings["connectionsReceivedIndex"]);
                connectionsDataGridView.Columns["Received"].FillWeight = float.Parse(m_Settings["connectionsReceivedWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["SentCommands"].DisplayIndex = Int32.Parse(m_Settings["connectionsSentCommandsIndex"]);
                connectionsDataGridView.Columns["SentCommands"].FillWeight = float.Parse(m_Settings["connectionsSentCommandsWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["ReceivedCommands"].DisplayIndex = Int32.Parse(m_Settings["connectionsReceivedCommandsIndex"]);
                connectionsDataGridView.Columns["ReceivedCommands"].FillWeight = float.Parse(m_Settings["connectionsReceivedCommandsWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                connectionsDataGridView.Columns["EnqueuedCommands"].DisplayIndex = Int32.Parse(m_Settings["connectionsEnqueuedCommandsIndex"]);
                connectionsDataGridView.Columns["EnqueuedCommands"].FillWeight = float.Parse(m_Settings["connectionsEnqueuedCommandsWidth"], System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading style of columns\n\n" + ex.Message, "ConnectionsControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            m_start = false;
        }

        private void connectionsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void connectionsDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "IPAddress":
                    e.SortResult = ((uint)connectionsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<IPAddress>)connectionsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((uint)connectionsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<IPAddress>)connectionsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "EnqueuedCommands":
                    e.SortResult = ((int)connectionsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<IPAddress>)connectionsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((int)connectionsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<IPAddress>)connectionsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
                case "Port":
                case "Sent":
                case "Received":
                case "SentCommands":
                case "ReceivedCommands":
                    e.SortResult = ((long)connectionsDataGridView.Rows[e.RowIndex1].Cells[e.Column.Name].Tag + ((RandomTag<IPAddress>)connectionsDataGridView.Rows[e.RowIndex1].Tag).SortTag).CompareTo((long)connectionsDataGridView.Rows[e.RowIndex2].Cells[e.Column.Name].Tag + ((RandomTag<IPAddress>)connectionsDataGridView.Rows[e.RowIndex2].Tag).SortTag);
                    e.Handled = true;
                    break;
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ConnectDialog connectDialog = new ConnectDialog())
            {
                connectDialog.ShowDialog(this);
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ((System.Windows.Forms.Timer)sender).Stop();
                updateTimer.Interval = Math.Max(1000, connectionsDataGridView.Rows.Count * 10);
                if (m_MainForm.ActiveTab == this && !m_MainForm.IsInTray)
                    try
                    {
                        Core.Connections.Lock();
                        RShare.MainForm.SetUILanguage();
                        connectionsLabel.Text = string.Format(Properties.Resources.Connections, Core.Connections.Count);
                        {
                            DataGridViewRow row;
                            for (int n = connectionsDataGridView.Rows.Count - 1; n >= 0; n--)
                            {
                                row = connectionsDataGridView.Rows[n];
                                if (!Core.Connections.ContainsKey(((RandomTag<IPAddress>)row.Tag).Tag))
                                    connectionsDataGridView.Rows.RemoveAt(n);
                            }
                        }
                        DataGridViewRow connectionRow;
                        DataGridViewCell connectionCell;
                        int a = 0;
                        foreach (Connection connection in Core.Connections.Values)
                        {
                            if (a % 50 == 0)
                                Application.DoEvents();
                            a++;
                            connectionRow = null;
                            foreach (DataGridViewRow row in connectionsDataGridView.Rows)
                                if (((RandomTag<IPAddress>)row.Tag).Tag.Equals(connection.RemoteEndPoint.Address))
                                {
                                    connectionRow = row;
                                    break;
                                }
                            if (connectionRow == null)
                            {
                                connectionRow = new DataGridViewRow();
                                connectionRow.Height = 17;
                                connectionCell = new DataGridViewImageCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = Properties.Resources.connection_16x16;
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.RemoteEndPoint.Address.ToString();
                                byte[] temp = connection.RemoteEndPoint.Address.GetAddressBytes();
                                uint ip = (uint)temp[0] << 24;
                                ip += (uint)temp[1] << 16;
                                ip += (uint)temp[2] << 8;
                                ip += (uint)temp[3];
                                connectionCell.Tag = ip;
                                // 2007-08-15 T.Norad Ticket #42
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.RemoteEndPoint.Port.ToString();
                                connectionCell.Tag = (long)connection.RemoteEndPoint.Port;
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.SentString;
                                connectionCell.Tag = connection.Sent;
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.ReceivedString;
                                connectionCell.Tag = connection.Received;
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.SentCommands.ToString();
                                connectionCell.Tag = connection.SentCommands;
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.ReceivedCommands.ToString();
                                connectionCell.Tag = connection.ReceivedCommands;
                                connectionCell = new DataGridViewTextBoxCell();
                                connectionRow.Cells.Add(connectionCell);
                                connectionCell.Value = connection.EnqueuedCommandsCount.ToString();
                                connectionCell.Tag = connection.EnqueuedCommandsCount;
                                connectionRow.Tag = new RandomTag<IPAddress>(connection.RemoteEndPoint.Address);
                                connectionsDataGridView.Rows.Add(connectionRow);
                                continue;
                            }
                            connectionCell = connectionRow.Cells["Sent"];
                            connectionCell.Value = connection.SentString;
                            connectionCell.Tag = connection.Sent;
                            connectionCell = connectionRow.Cells["Received"];
                            connectionCell.Value = connection.ReceivedString;
                            connectionCell.Tag = connection.Received;
                            connectionCell = connectionRow.Cells["SentCommands"];
                            connectionCell.Value = connection.SentCommands.ToString();
                            connectionCell.Tag = connection.SentCommands;
                            connectionCell = connectionRow.Cells["ReceivedCommands"];
                            connectionCell.Value = connection.ReceivedCommands.ToString();
                            connectionCell.Tag = connection.ReceivedCommands;
                            connectionCell = connectionRow.Cells["EnqueuedCommands"];
                            connectionCell.Value = connection.EnqueuedCommandsCount.ToString();
                            connectionCell.Tag = connection.EnqueuedCommandsCount;
                        }
                        connectionsDataGridView.Sort(connectionsDataGridView.SortedColumn, connectionsDataGridView.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Log(ex, "An exception was thrown! (ConnectionsControl)");
                    }
                    finally
                    {
                        Core.Connections.Unlock();
                    }
            }
            finally
            {
                ((System.Windows.Forms.Timer)sender).Start();
            }
        }

        private void connectionsDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["connectionsIconIndex"] = connectionsDataGridView.Columns["Icon"].DisplayIndex.ToString();
                m_Settings["connectionsIPAddressIndex"] = connectionsDataGridView.Columns["IPAddress"].DisplayIndex.ToString();
                m_Settings["connectionsPortIndex"] = connectionsDataGridView.Columns["Port"].DisplayIndex.ToString();
                m_Settings["connectionsSentIndex"] = connectionsDataGridView.Columns["Sent"].DisplayIndex.ToString();
                m_Settings["connectionsReceivedIndex"] = connectionsDataGridView.Columns["Received"].DisplayIndex.ToString();
                m_Settings["connectionsSentCommandsIndex"] = connectionsDataGridView.Columns["SentCommands"].DisplayIndex.ToString();
                m_Settings["connectionsReceivedCommandsIndex"] = connectionsDataGridView.Columns["ReceivedCommands"].DisplayIndex.ToString();
                m_Settings["connectionsEnqueuedCommandsIndex"] = connectionsDataGridView.Columns["EnqueuedCommands"].DisplayIndex.ToString();
            }
        }

        private void connectionsDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!m_start)
            {
                m_Settings["connectionsIconWidth"] = connectionsDataGridView.Columns["Icon"].FillWeight.ToString( System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsIPAddressWidth"] = connectionsDataGridView.Columns["IPAddress"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsPortWidth"] = connectionsDataGridView.Columns["Port"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsSentWidth"] = connectionsDataGridView.Columns["Sent"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsReceivedWidth"] = connectionsDataGridView.Columns["Received"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsSentCommandsWidth"] = connectionsDataGridView.Columns["SentCommands"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsReceivedCommandsWidth"] = connectionsDataGridView.Columns["ReceivedCommands"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
                m_Settings["connectionsEnqueuedCommandsWidth"] = connectionsDataGridView.Columns["EnqueuedCommands"].FillWeight.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-de"));
            }
        }
    }
}