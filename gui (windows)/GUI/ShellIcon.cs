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
using System.IO;
using System.Runtime.InteropServices;

namespace Regensburger.RShare
{
    internal static class ShellIcon
    {
        private const int FILE_ATTRIBUTE_NORMAL = 0x80;

        private const int ILD_TRANSPARENT = 0x1;

        private static RHashtable<string, Image> m_LargeSystemIconsCache = new RHashtable<string, Image>();

        private static RHashtable<string, Image> m_SmallSystemIconsCache = new RHashtable<string, Image>();

        [DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public static Image GetLargeSystemIcon(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            string extension = Path.GetExtension(fileName);
            Image image;
            if (m_LargeSystemIconsCache.TryGetValue(extension, out image))
                return image;
            SHFILEINFO shfileinfo = new SHFILEINFO();
            IntPtr himl = SHGetFileInfo(fileName, FILE_ATTRIBUTE_NORMAL, out shfileinfo, (uint)Marshal.SizeOf(shfileinfo), SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_SYSICONINDEX | SHGFI.SHGFI_LARGEICON);
            IntPtr hIcon = ImageList_GetIcon(himl, shfileinfo.iIcon, ILD_TRANSPARENT);
            Icon icon = Icon.FromHandle(hIcon);
            image = icon.ToBitmap();
            DestroyIcon(hIcon);
            m_LargeSystemIconsCache.Add(extension, image);
            return image;
        }

        public static Image GetSmallSystemIcon(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            string extension = Path.GetExtension(fileName);
            Image image;
            if (m_SmallSystemIconsCache.TryGetValue(extension, out image))
                return image;
            SHFILEINFO shfileinfo = new SHFILEINFO();
            IntPtr himl = SHGetFileInfo(fileName, FILE_ATTRIBUTE_NORMAL, out shfileinfo, (uint)Marshal.SizeOf(shfileinfo), SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_SYSICONINDEX | SHGFI.SHGFI_SMALLICON);
            IntPtr hIcon = ImageList_GetIcon(himl, shfileinfo.iIcon, ILD_TRANSPARENT);
            Icon icon = Icon.FromHandle(hIcon);
            image = icon.ToBitmap();
            DestroyIcon(hIcon);
            m_SmallSystemIconsCache.Add(extension, image);
            return image;
        }

        [DllImport("comctl32")]
        private extern static IntPtr ImageList_GetIcon(IntPtr himl, int i, int flags);

        [DllImport("shell32.dll")]
        private extern static IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribs, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [Flags]
        private enum SHGFI
        {
            SHGFI_ICON = 0x000000100,
            SHGFI_DISPLAYNAME = 0x000000200,
            SHGFI_TYPENAME = 0x000000400,
            SHGFI_ATTRIBUTES = 0x000000800,
            SHGFI_ICONLOCATION = 0x000001000,
            SHGFI_EXETYPE = 0x000002000,
            SHGFI_SYSICONINDEX = 0x000004000,
            SHGFI_LINKOVERLAY = 0x000008000,
            SHGFI_SELECTED = 0x000010000,
            SHGFI_ATTR_SPECIFIED = 0x000020000,
            SHGFI_LARGEICON = 0x000000000,
            SHGFI_SMALLICON = 0x000000001,
            SHGFI_OPENICON = 0x000000002,
            SHGFI_SHELLICONSIZE = 0x000000004,
            SHGFI_PIDL = 0x000000008,
            SHGFI_USEFILEATTRIBUTES = 0x000000010,
            SHGFI_ADDOVERLAYS = 0x000000020,
            SHGFI_OVERLAYINDEX = 0x000000040
        }

        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
    }
}