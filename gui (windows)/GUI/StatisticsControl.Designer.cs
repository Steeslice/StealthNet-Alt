//RShare
//Copyright (C) 2006 Roland Moch, Lars Regensburger, T.Norad

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

namespace Regensburger.RShare
{
    partial class StatisticsControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.downloadGraphsControl = new Regensburger.RShare.GraphsControl();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.uploadGraphsControl = new Regensburger.RShare.GraphsControl();
            this.connectionsGraphsControl = new Regensburger.RShare.GraphsControl();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleDescription = null;
            this.splitContainer1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackgroundImage = null;
            this.splitContainer1.Font = null;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleDescription = null;
            this.splitContainer1.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackgroundImage = null;
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            this.splitContainer1.Panel1.Font = null;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleDescription = null;
            this.splitContainer1.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.BackgroundImage = null;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Font = null;
            // 
            // treeView
            // 
            this.treeView.AccessibleDescription = null;
            this.treeView.AccessibleName = null;
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.BackgroundImage = null;
            this.treeView.Font = null;
            this.treeView.HideSelection = false;
            this.treeView.Name = "treeView";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView.Nodes1"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView.Nodes2"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView.Nodes3"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView.Nodes4")))});
            // 
            // splitContainer2
            // 
            this.splitContainer2.AccessibleDescription = null;
            this.splitContainer2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.BackgroundImage = null;
            this.splitContainer2.Font = null;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AccessibleDescription = null;
            this.splitContainer2.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel1.BackgroundImage = null;
            this.splitContainer2.Panel1.Controls.Add(this.downloadGraphsControl);
            this.splitContainer2.Panel1.Font = null;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AccessibleDescription = null;
            this.splitContainer2.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel2.BackgroundImage = null;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Font = null;
            // 
            // downloadGraphsControl
            // 
            this.downloadGraphsControl.AccessibleDescription = null;
            this.downloadGraphsControl.AccessibleName = null;
            resources.ApplyResources(this.downloadGraphsControl, "downloadGraphsControl");
            this.downloadGraphsControl.BackColor = System.Drawing.Color.Transparent;
            this.downloadGraphsControl.BackgroundImage = null;
            this.downloadGraphsControl.DrawBorder = true;
            this.downloadGraphsControl.DrawBottomLabels = false;
            this.downloadGraphsControl.DrawBottomLabelsFromRightToLeft = false;
            this.downloadGraphsControl.DrawGridLines = true;
            this.downloadGraphsControl.DrawLabels = true;
            this.downloadGraphsControl.DrawLeftLabels = true;
            this.downloadGraphsControl.DrawLegends = true;
            this.downloadGraphsControl.DrawOnlyIntegers = false;
            this.downloadGraphsControl.DrawRightLabels = true;
            this.downloadGraphsControl.DrawText = true;
            this.downloadGraphsControl.DrawTopLabels = false;
            this.downloadGraphsControl.DrawTopLabelsFromRightToLeft = false;
            this.downloadGraphsControl.DrawXGridLines = false;
            this.downloadGraphsControl.DrawYGridLines = true;
            this.downloadGraphsControl.Font = null;
            this.downloadGraphsControl.Name = "downloadGraphsControl";
            this.downloadGraphsControl.XGridLines = 10;
            this.downloadGraphsControl.XMaximum = 600F;
            this.downloadGraphsControl.YGridLines = 6;
            this.downloadGraphsControl.YMaximum = 10F;
            // 
            // splitContainer3
            // 
            this.splitContainer3.AccessibleDescription = null;
            this.splitContainer3.AccessibleName = null;
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.BackgroundImage = null;
            this.splitContainer3.Font = null;
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AccessibleDescription = null;
            this.splitContainer3.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer3.Panel1, "splitContainer3.Panel1");
            this.splitContainer3.Panel1.BackgroundImage = null;
            this.splitContainer3.Panel1.Controls.Add(this.uploadGraphsControl);
            this.splitContainer3.Panel1.Font = null;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AccessibleDescription = null;
            this.splitContainer3.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer3.Panel2, "splitContainer3.Panel2");
            this.splitContainer3.Panel2.BackgroundImage = null;
            this.splitContainer3.Panel2.Controls.Add(this.connectionsGraphsControl);
            this.splitContainer3.Panel2.Font = null;
            // 
            // uploadGraphsControl
            // 
            this.uploadGraphsControl.AccessibleDescription = null;
            this.uploadGraphsControl.AccessibleName = null;
            resources.ApplyResources(this.uploadGraphsControl, "uploadGraphsControl");
            this.uploadGraphsControl.BackgroundImage = null;
            this.uploadGraphsControl.DrawBorder = true;
            this.uploadGraphsControl.DrawBottomLabels = false;
            this.uploadGraphsControl.DrawBottomLabelsFromRightToLeft = false;
            this.uploadGraphsControl.DrawGridLines = true;
            this.uploadGraphsControl.DrawLabels = true;
            this.uploadGraphsControl.DrawLeftLabels = true;
            this.uploadGraphsControl.DrawLegends = true;
            this.uploadGraphsControl.DrawOnlyIntegers = false;
            this.uploadGraphsControl.DrawRightLabels = true;
            this.uploadGraphsControl.DrawText = true;
            this.uploadGraphsControl.DrawTopLabels = false;
            this.uploadGraphsControl.DrawTopLabelsFromRightToLeft = false;
            this.uploadGraphsControl.DrawXGridLines = false;
            this.uploadGraphsControl.DrawYGridLines = true;
            this.uploadGraphsControl.Font = null;
            this.uploadGraphsControl.Name = "uploadGraphsControl";
            this.uploadGraphsControl.XGridLines = 10;
            this.uploadGraphsControl.XMaximum = 600F;
            this.uploadGraphsControl.YGridLines = 6;
            this.uploadGraphsControl.YMaximum = 10F;
            // 
            // connectionsGraphsControl
            // 
            this.connectionsGraphsControl.AccessibleDescription = null;
            this.connectionsGraphsControl.AccessibleName = null;
            resources.ApplyResources(this.connectionsGraphsControl, "connectionsGraphsControl");
            this.connectionsGraphsControl.BackColor = System.Drawing.Color.Transparent;
            this.connectionsGraphsControl.BackgroundImage = null;
            this.connectionsGraphsControl.DrawBorder = true;
            this.connectionsGraphsControl.DrawBottomLabels = false;
            this.connectionsGraphsControl.DrawBottomLabelsFromRightToLeft = false;
            this.connectionsGraphsControl.DrawGridLines = true;
            this.connectionsGraphsControl.DrawLabels = true;
            this.connectionsGraphsControl.DrawLeftLabels = true;
            this.connectionsGraphsControl.DrawLegends = true;
            this.connectionsGraphsControl.DrawOnlyIntegers = false;
            this.connectionsGraphsControl.DrawRightLabels = true;
            this.connectionsGraphsControl.DrawText = true;
            this.connectionsGraphsControl.DrawTopLabels = false;
            this.connectionsGraphsControl.DrawTopLabelsFromRightToLeft = false;
            this.connectionsGraphsControl.DrawXGridLines = false;
            this.connectionsGraphsControl.DrawYGridLines = true;
            this.connectionsGraphsControl.Font = null;
            this.connectionsGraphsControl.Name = "connectionsGraphsControl";
            this.connectionsGraphsControl.XGridLines = 10;
            this.connectionsGraphsControl.XMaximum = 600F;
            this.connectionsGraphsControl.YGridLines = 6;
            this.connectionsGraphsControl.YMaximum = 10F;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // StatisticsControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "StatisticsControl";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Timer updateTimer;
        private GraphsControl downloadGraphsControl;
        private GraphsControl connectionsGraphsControl;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private GraphsControl uploadGraphsControl;
    }
}
