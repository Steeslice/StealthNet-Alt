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

using Regensburger.RCollections.ArrayBased;
using System;
using System.Drawing;

namespace Regensburger.RShare
{
    partial class GraphsControl
    {
        public sealed class Graph
        {
            private string m_Description = string.Empty;

            private bool m_DrawFromRightToLeft = false;

            private float m_Maximum = 100.0F;

            private Pen m_Pen = new Pen(Color.Red);

            private RList<float> m_Values = new RList<float>();

            private int m_ValuesToShow = 10;

            public string Description
            {
                get
                {
                    return m_Description;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentException("value");

                    m_Description = value;
                }
            }

            public bool DrawFromRightToLeft
            {
                get
                {
                    return m_DrawFromRightToLeft;
                }
                set
                {
                    m_DrawFromRightToLeft = value;
                }
            }

            public float Maximum
            {
                get
                {
                    return m_Maximum;
                }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("value");

                    m_Maximum = value;
                }
            }

            public Pen Pen
            {
                get
                {
                    return m_Pen;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");

                    m_Pen = value;
                }
            }

            public RList<float> Values
            {
                get
                {
                    return m_Values;
                }
            }

            public int ValuesToShow
            {
                get
                {
                    return m_ValuesToShow;
                }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("value");

                    m_ValuesToShow = value;
                }
            }

            public Graph()
            {
            }
        }
    }
}