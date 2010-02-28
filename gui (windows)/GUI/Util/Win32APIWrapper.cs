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
using System.Runtime.InteropServices;

namespace Regensburger.RShare
{
    class Win32APIWrapper
    {
        public const int WM_COPYDATA = 0x004A;
        public struct CopyDataStruct : IDisposable
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;

            public void Dispose()
            {
                if (this.lpData != IntPtr.Zero)
                {
                    LocalFree(this.lpData);
                    this.lpData = IntPtr.Zero;
                }
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalAlloc(int flag, int size);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr p);

        /// <summary>
        /// The SendMessage API
        /// </summary>
        /// <param name="hWnd">handle to the required window</param>
        /// <param name="Msg">the system/Custom message to send</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyDataStruct lParam);

        /// <summary>
        /// The FindWindow function retrieves a handle to the top-level 
        /// window whose class name and window name match the specified strings.
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="strClassName">the class name for the window to search for</param>
        /// <param name="strWindowName">the name of the window to search for</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int FindWindow(string strClassName, string strWindowName);

        /// <summary>
        /// Sends string to running instance of passed handle. 
        /// The handle must override the method WndProc
        /// </summary>
        /// <param name="targetHWnd">handle to send the message</param>
        /// <param name="args">message to send</param>
        /// <returns></returns>
        public static bool SendArgs(IntPtr targetHWnd, string args)
        {
            Win32APIWrapper.CopyDataStruct copyDataStruct = new Win32APIWrapper.CopyDataStruct();
            try
            {
                copyDataStruct.cbData = (args.Length + 1) * 2;
                copyDataStruct.lpData = Win32APIWrapper.LocalAlloc(0x40, copyDataStruct.cbData);
                Marshal.Copy(args.ToCharArray(), 0, copyDataStruct.lpData, args.Length);
                copyDataStruct.dwData = (IntPtr)1;
                Win32APIWrapper.SendMessage(targetHWnd, Win32APIWrapper.WM_COPYDATA, IntPtr.Zero, ref copyDataStruct);
            }
            finally
            {
                copyDataStruct.Dispose();
            }

            return true;
        }
    }
}
