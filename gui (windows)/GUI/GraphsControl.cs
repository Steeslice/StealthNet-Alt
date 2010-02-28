//RShare
//Copyright (C) 2009 Lars Regensburger, Roland Moch

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

using Regensburger.RCollections.ArrayBased;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Regensburger.RShare
{
    internal sealed partial class GraphsControl
        : Control
    {
        volatile private Pen m_BorderPen = new Pen(Color.Black);

        volatile private bool m_DrawBorder = true;

        volatile private bool m_DrawBottomLabels = true;

        volatile private bool m_DrawBottomLabelsFromRightToLeft = false;

        volatile private bool m_DrawGridLines = true;

        volatile private bool m_DrawLabels = true;

        volatile private bool m_DrawLeftLabels = true;

        volatile private bool m_DrawLegends = true;

        //Only Integer-Values??
        volatile private bool m_DrawOnlyIntegers = false;

        volatile private bool m_DrawRightLabels = true;

        volatile private bool m_DrawText = true;

        volatile private bool m_DrawTopLabels = true;

        volatile private bool m_DrawTopLabelsFromRightToLeft = false;

        volatile private bool m_DrawXGridLines = true;

        volatile private bool m_DrawYGridLines = true;

        volatile private RList<Graph> m_Graphs = new RList<Graph>();

        volatile private int m_XGridLines = 10;

        volatile private Pen m_XGridLinesPen;

        volatile private float m_XMaximum = 100.0F;

        volatile private int m_YGridLines = 10;

        volatile private Pen m_YGridLinesPen;

        volatile private float m_YMaximum = 100.0F;

        public Pen BorderPen
        {
            get
            {
                return m_BorderPen;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (value != m_BorderPen)
                {
                    m_BorderPen = value;
                    Refresh();
                }
            }
        }

        public bool DrawBorder
        {
            get
            {
                return m_DrawBorder;
            }
            set
            {
                if (value != m_DrawBorder)
                {
                    m_DrawBorder = value;
                    Refresh();
                }
            }
        }

        public bool DrawBottomLabels
        {
            get
            {
                return m_DrawBottomLabels;
            }
            set
            {
                if (value != m_DrawBottomLabels)
                {
                    m_DrawBottomLabels = value;
                    Refresh();
                }
            }
        }

        public bool DrawBottomLabelsFromRightToLeft
        {
            get
            {
                return m_DrawBottomLabelsFromRightToLeft;
            }
            set
            {
                if (value != m_DrawBottomLabelsFromRightToLeft)
                {
                    m_DrawBottomLabelsFromRightToLeft = value;
                    Refresh();
                }
            }
        }

        public bool DrawGridLines
        {
            get
            {
                return m_DrawGridLines;
            }
            set
            {
                if (value != m_DrawGridLines)
                {
                    m_DrawGridLines = value;
                    Refresh();
                }
            }
        }

        public bool DrawLabels
        {
            get
            {
                return m_DrawLabels;
            }
            set
            {
                if (value != m_DrawLabels)
                {
                    m_DrawLabels = value;
                    Refresh();
                }
            }
        }

        public bool DrawLeftLabels
        {
            get
            {
                return m_DrawLeftLabels;
            }
            set
            {
                if (value != m_DrawLeftLabels)
                {
                    m_DrawLeftLabels = value;
                    Refresh();
                }
            }
        }

        public bool DrawLegends
        {
            get
            {
                return m_DrawLegends;
            }
            set
            {
                m_DrawLegends = DrawLegends;
                Refresh();
            }
        }

        //Only Integer-Values?
        public bool DrawOnlyIntegers
        {
            get
            {
                return m_DrawOnlyIntegers;
            }
            set
            {
                if (value != m_DrawOnlyIntegers)
                {
                    m_DrawOnlyIntegers = value;
                    Refresh();
                }
            }
        }

        public bool DrawRightLabels
        {
            get
            {
                return m_DrawRightLabels;
            }
            set
            {
                if (value != m_DrawRightLabels)
                {
                    m_DrawRightLabels = value;
                    Refresh();
                }
            }
        }

        public bool DrawText
        {
            get
            {
                return m_DrawText;
            }
            set
            {
                if (value != m_DrawText)
                {
                    m_DrawText = value;
                    Refresh();
                }
            }
        }

        public bool DrawTopLabels
        {
            get
            {
                return m_DrawTopLabels;
            }
            set
            {
                if (value != m_DrawTopLabels)
                {
                    m_DrawTopLabels = value;
                    Refresh();
                }
            }
        }

        public bool DrawTopLabelsFromRightToLeft
        {
            get
            {
                return m_DrawTopLabelsFromRightToLeft;
            }
            set
            {
                if (value != m_DrawTopLabelsFromRightToLeft)
                {
                    m_DrawTopLabelsFromRightToLeft = value;
                    Refresh();
                }
            }
        }

        public bool DrawXGridLines
        {
            get
            {
                return m_DrawXGridLines;
            }
            set
            {
                if (value != m_DrawXGridLines)
                {
                    m_DrawXGridLines = value;
                    Refresh();
                }
            }
        }

        public bool DrawYGridLines
        {
            get
            {
                return m_DrawYGridLines;
            }
            set
            {
                if (value != m_DrawYGridLines)
                {
                    m_DrawYGridLines = value;
                    Refresh();
                }
            }
        }

        public RList<Graph> Graphs
        {
            get
            {
                return m_Graphs;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value != base.Text)
                {
                    base.Text = value;
                    Refresh();
                }
            }
        }

        public int XGridLines
        {
            get
            {
                return m_XGridLines;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                if (value != m_XGridLines)
                {
                    m_XGridLines = value;
                    Refresh();
                }
            }
        }

        public Pen XGridLinesPen
        {
            get
            {
                return m_XGridLinesPen;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (value != m_XGridLinesPen)
                {
                    m_XGridLinesPen = value;
                    Refresh();
                }
            }
        }

        public float XMaximum
        {
            get
            {
                return m_XMaximum;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException("value");

                if (value != m_XMaximum)
                {
                    m_XMaximum = value;
                    Refresh();
                }
            }
        }

        public int YGridLines
        {
            get
            {
                return m_YGridLines;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                if (value != m_YGridLines)
                {
                    m_YGridLines = value;
                    Refresh();
                }
            }
        }

        public Pen YGridLinesPen
        {
            get
            {
                return m_YGridLinesPen;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (value != m_YGridLinesPen)
                {
                    m_YGridLinesPen = value;
                    Refresh();
                }
            }
        }

        public float YMaximum
        {
            get
            {
                return m_YMaximum;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException("value");

                if (value != m_YMaximum)
                {
                    m_YMaximum = value;
                    Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //basic declarations
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            float widthMargin = ((float)Width * 10.0F) / 100.0F;
            float heightMargin = ((float)Height * 10.0F) / 100.0F;
            RectangleF rectangle = new RectangleF(new PointF(widthMargin, heightMargin), new SizeF((float)Width - widthMargin * 2.0F, (float)Height - heightMargin * 2.0F));
            Brush brush = new SolidBrush(ForeColor);
            //Draw Text or not?
            if (m_DrawText)
            {
                //Set the information for the text (format, allignment,...)
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near;
                graphics.DrawString(Text, Font, brush, new RectangleF(new PointF(rectangle.Left, 0), new SizeF(rectangle.Width, rectangle.Top)), stringFormat);
                stringFormat.Dispose();
            }
            float m;
            //Draw Labels or not?
            if (m_DrawLabels)
            {
                SizeF size;
                string nm;
                //Draw the Top and Bottom Labels or not?
                if (m_DrawTopLabels || m_DrawBottomLabels)
                {
                    //Set the information for the labels
                    StringFormat topStringFormat = null;
                    if (m_DrawTopLabels)
                    {
                        topStringFormat = new StringFormat();
                        topStringFormat.Alignment = StringAlignment.Center;
                        topStringFormat.LineAlignment = StringAlignment.Far;
                    }
                    StringFormat bottomStringFormat = null;
                    if (m_DrawBottomLabels)
                    {
                        bottomStringFormat = new StringFormat();
                        bottomStringFormat.Alignment = StringAlignment.Center;
                        bottomStringFormat.LineAlignment = StringAlignment.Near;
                    }
                    m = 0.0F;
                    //inscribing the X-Axes
                    for (int n = 0; n <= m_XGridLines; n++)
                    {
                        //Get Value to inscribe:
                        nm = ((m_XMaximum / (float)m_XGridLines) * (float)n).ToString();
                        size = graphics.MeasureString(nm, Font, new PointF(0.0F, 0.0F), bottomStringFormat);
                        //Draw Top Label
                        if (m_DrawTopLabels)
                        {
                            if (!m_DrawTopLabelsFromRightToLeft)
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(rectangle.Left + m - size.Width / 2, rectangle.Top - size.Height), new SizeF(size.Width, size.Height)), bottomStringFormat);
                            else
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(rectangle.Left + rectangle.Width - m - size.Width / 2, rectangle.Top - size.Height), new SizeF(size.Width, size.Height)), bottomStringFormat);
                        }
                        //Draw Bottom Label
                        if (m_DrawBottomLabels)
                        {
                            if (!m_DrawBottomLabelsFromRightToLeft)
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(rectangle.Left + m - size.Width / 2, rectangle.Top + rectangle.Height), new SizeF(size.Width, size.Height)), bottomStringFormat);
                            else
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(rectangle.Left + rectangle.Width - m - size.Width / 2, rectangle.Top + rectangle.Height), new SizeF(size.Width, size.Height)), bottomStringFormat);
                        }
                        //Create a distance between the Labels
                        m += rectangle.Width / (float)m_XGridLines;
                    }
                    if (m_DrawTopLabels)
                        topStringFormat.Dispose();
                    if (m_DrawBottomLabels)
                        bottomStringFormat.Dispose();
                }
                //Draw the Right- and Left-Labels or not?
                if (m_DrawLeftLabels || m_DrawRightLabels)
                {
                    //Set the information for the labels
                    StringFormat leftStringFormat = null;
                    if (m_DrawLeftLabels)
                    {
                        leftStringFormat = new StringFormat();
                        leftStringFormat.Alignment = StringAlignment.Far;
                        leftStringFormat.LineAlignment = StringAlignment.Center;
                    }
                    StringFormat rightStringFormat = null;
                    if (m_DrawRightLabels)
                    {
                        rightStringFormat = new StringFormat();
                        rightStringFormat.Alignment = StringAlignment.Near;
                        rightStringFormat.LineAlignment = StringAlignment.Center;
                    }
                    m = 0.0F;
                    //inscribing the Y-Axes
                    if (!m_DrawOnlyIntegers)
                    {
                        for (int n = 0; n <= m_YGridLines; n++)
                        {
                            //Calculating the best distance between the GridLines
                            nm = ((m_YMaximum / (float)m_YGridLines) * (float)n).ToString("N1");
                            size = graphics.MeasureString(nm, Font, new PointF(0.0F, 0.0F), leftStringFormat);
                            //Left Labels
                            if (m_DrawLeftLabels)
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(0, rectangle.Bottom - m - size.Height / 2), new SizeF(((float)Width * 10.0F) / 100.0F, size.Height)), leftStringFormat);
                            //Right Labels
                            if (m_DrawRightLabels)
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(rectangle.Left + rectangle.Width, rectangle.Bottom - m - size.Height / 2), new SizeF(((float)Width * 10.0F) / 100.0F, size.Height)), rightStringFormat);
                            //Create a distance between the Labels
                            m += rectangle.Height / (float)m_YGridLines;
                        }
                    }
                    //inscribing the Y-Axes for Only-integer Values
                    else
                    {
                        for (int n = 0; n <= m_YMaximum; n = n + 2) //To draw all Gridlines, just increment bei n++
                        {
                            nm = n.ToString("N1");
                            size = graphics.MeasureString(nm, Font, new PointF(0.0F, 0.0F), leftStringFormat);
                            //Left Labels
                            if (m_DrawLeftLabels)
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(0, rectangle.Bottom - m - size.Height / 2), new SizeF(((float)Width * 10.0F) / 100.0F, size.Height)), leftStringFormat);
                            //Right Labels
                            if (m_DrawRightLabels)
                                graphics.DrawString(nm, Font, brush, new RectangleF(new PointF(rectangle.Left + rectangle.Width, rectangle.Bottom - m - size.Height / 2), new SizeF(((float)Width * 10.0F) / 100.0F, size.Height)), rightStringFormat);
                            //Create a distance between the Labels
                            m += (rectangle.Height / m_YMaximum) * 2;//And multiplicate here by 1
                        }
                    }
                    if (m_DrawLeftLabels)
                        leftStringFormat.Dispose();
                    if (m_DrawRightLabels)
                        rightStringFormat.Dispose();
                }
            }
            //Draw Legends
            if (m_DrawLegends)
            {
                for (float n = 0; n != Graphs.Count; n++)
                {
                    graphics.DrawLine(new Pen(Graphs[(int)n].Pen.Color, Graphs[(int)n].Pen.Width), new PointF(rectangle.Left + ((rectangle.Width / Graphs.Count) * n), Bottom - Font.Height), new PointF(rectangle.Left + ((rectangle.Width / Graphs.Count)) * (n + (float)0.25), Bottom - Font.Height));
                    float LineLength = rectangle.Left + ((rectangle.Width / Graphs.Count)) * (n + (float)0.25) - (rectangle.Left + ((rectangle.Width / Graphs.Count) * n));
                    graphics.DrawString(Graphs[(int)n].Description, Font, brush, new PointF(rectangle.Left + ((rectangle.Width / Graphs.Count) * n) + LineLength, Bottom - Font.Height - Font.Height / 2));
                }
            }
            brush.Dispose();
            //Draw a border for the graphs-area
            if (m_DrawBorder)
                graphics.DrawRectangle(m_BorderPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            //Draw the Axes        
            if (m_DrawGridLines)
            {
                //Normal Gridlines with rational numbers (X-Gridlines [from button to the top!!!!!])
                if (m_DrawXGridLines)
                    for (float n = rectangle.Width / (float)m_XGridLines + 1.0F; n < rectangle.Width - 1.0F; n += rectangle.Width / (float)m_XGridLines)
                        graphics.DrawLine(m_XGridLinesPen, new PointF(rectangle.Left + n, rectangle.Top + 1.0F), new PointF(rectangle.Left + n, rectangle.Bottom - 1.0F));
                //Normal Axes with rational numbers (Y-Gridlines [from left to right!!!!!!!!])
                if (m_DrawYGridLines)
                    //Just integer values?
                    if (!m_DrawOnlyIntegers)
                        for (float n = rectangle.Height / (float)m_YGridLines + 1.0F; n < rectangle.Height - 1.0F; n += rectangle.Height / (float)m_YGridLines)
                            graphics.DrawLine(m_YGridLinesPen, new PointF(rectangle.Left + 1.0F, rectangle.Top + n), new PointF(rectangle.Right - 1.0F, rectangle.Top + n));
                    //Special Y-Axe for only-integer values
                    else
                        //Gridlines for only-integer values
                        for (int n = 2; n <= m_YMaximum; n = n + 2) //for(int n = 1; n <= m_YMaximum; n++) für alle Gridlines!    
                        {
                            graphics.DrawLine(m_YGridLinesPen, new PointF(rectangle.Left + 1.0F, rectangle.Bottom - 1.0F - ((rectangle.Height / m_YMaximum) * n)), new PointF(rectangle.Right - 1.0F, rectangle.Bottom - 1.0F - ((rectangle.Height / m_YMaximum) * n)));
                        }
            }
            //Declerations for drawing the graph
            Graph graph;
            PointF[] points;
            float x;
            float y;
            //Calculating the Position of the Value-Pairs
            for (int g = 0; g < m_Graphs.Count; g++)
            {
                graph = m_Graphs[g];
                points = new PointF[Math.Min(graph.ValuesToShow, graph.Values.Count)];
                if (points.Length >= 2)
                {
                    m = 0.0F;
                    for (int n = 0; n < points.Length; n++)
                    {
                        //Calculating the Positions in X- and Y-Orientation
                        if (!graph.DrawFromRightToLeft)
                            x = rectangle.Left + 1.0F + m;
                        else
                            x = rectangle.Left + 1.0F + rectangle.Width - 2.0F - m;
                        if (!m_DrawOnlyIntegers)
                            y = rectangle.Bottom - 1.0F - ((rectangle.Height - 2) / graph.Maximum) * graph.Values[n];
                        else
                            y = rectangle.Bottom - 1.0F - ((rectangle.Height / m_YMaximum) * graph.Values[n]);
                        if (x <= rectangle.Left)
                            x = rectangle.Left + 1.0F;
                        else if (x >= rectangle.Right)
                            x = rectangle.Right - 1.0F;
                        if (y <= rectangle.Top)
                            y = rectangle.Top + 1.0F;
                        else if (y >= rectangle.Bottom)
                            y = rectangle.Bottom - 1.0F;
                        // Fix...
                        if (float.IsNaN(y))
                            y = 0;
                        // Defining the Points with the calculated value-pairs
                        if (!m_DrawOnlyIntegers)
                            points[n] = new PointF(x, y);
                        // Defining the Points with the calculated value-pairs for only-integer values
                        else
                            points[n] = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                        m += (rectangle.Width - 2.0F) / (float)(graph.ValuesToShow - 1);
                    }
                    graphics.DrawCurve(graph.Pen, points, 0.0F);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (BackgroundImage != null)
                Invalidate();
        }

        public GraphsControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            Pen pen = new Pen(Color.Gray);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            m_YGridLinesPen = m_XGridLinesPen = pen;
        }
    }
}