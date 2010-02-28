//StealthNet
//Copyright (C) 2009 T.Norad

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
    public static class SortHelper
    {
        /// <summary>
        /// Compares the passed datetime objects. One or both parameters can be null. In this
        /// case the default value 0 is taken for the compare.
        /// </summary>
        /// <param name="date1">DateTime object or null</param>
        /// <param name="date2">DateTime object or null</param>
        /// <returns></returns>
        public static int compareDates(object date1, object date2)
        {
            // 2007-09-29 T.Norad
            long compareValue1 = 0;
            long compareValue2 = 0;

            // check if date1 is not empty and a valid DateTime object. otherwise use the value 0 for compare
            if (date1 != null && date1 is DateTime)
            {
                compareValue1 = ((DateTime)date1).Ticks;
            }
            // check if date2 is not empty and a valid DateTime object. otherwise use the value 0 for compare
            if (date2 != null && date2 is DateTime)
            {
                compareValue2 = ((DateTime)date2).Ticks;
            }

            // return compare result
            return compareValue1.CompareTo(compareValue2);
        }
    }
}
