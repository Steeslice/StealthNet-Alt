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
using System.Collections.Generic;
using System.Text;

namespace Regensburger.RShare
{

    internal static partial class Utils
    {
        public static string BinaryToDecimal(long value, bool inBiggestUnit, bool addUnit)
        // This method converts values in KiBit to a metric value (bit, kBit, MBit)
        // If "inBiggestUnit" is false, the output value is always kBit/s
        {
            string result = null;
            string myUnit = "kBit/s";
            double x = Convert.ToSingle(value) * 1.024;


            if (inBiggestUnit)
            {
                if (x < 1000)
                {
                    result = String.Format("{0:F1}", x);
                    myUnit = "kBit/s";
                }
                else if (x >= 1000)
                {
                    result = String.Format("{0:F1}", x / 1000);
                    myUnit = "Mbit/s";
                } //if (value > 985)
                else if (x >= 1000000)
                {
                    result = String.Format("{0:F1}", x / 1000000);
                    myUnit = "Gbit/s";

                }

            }
            else
            {
                result = String.Format("{0:F1}", x);
            }

            if (addUnit)
                return result + " " + myUnit;
            else
                return result;
        }
        

    }
}
