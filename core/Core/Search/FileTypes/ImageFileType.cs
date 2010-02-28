//RShare
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
    /**
     * This class defines the file extentions for this file type category 
     */
    public class ImageFileType : FileType
    {
        public ImageFileType()
        {
            FileExtentions = new string[] { ".bmp", ".dcx", ".emf", ".gif", ".ico", ".jpeg", ".jpg", ".pct", ".pcx", ".pic", ".pict", ".png", ".psd", ".psp", ".tga", ".tif", ".tiff", ".wmf", ".xif"};
        }

        public override string ToString()
        {
            string fileTypeString;
            switch (Settings.Instance["UICulture"])
            {
                case "en":
                    fileTypeString = "Picture";
                    break;

                case "de":
                    fileTypeString = "Bilder";
                    break;

                case "fr":
                    fileTypeString = "Images";
                    break;

                case "it":
                    fileTypeString = "Immagini";
                    break;

                case "tr":
                    fileTypeString = "Resim";
                    break;

                default:
                    fileTypeString = "Picture";
                    break;
            }
            return fileTypeString;
        }
    }
}
