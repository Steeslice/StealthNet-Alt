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
    public class VideoFileType : FileType
    {
        public VideoFileType()
        {
            FileExtentions = new string[] { ".3g2", ".3gp", ".3gp2", ".3gpp", ".asf", ".avi", ".divx", ".m1v", ".m2v", ".mkv", ".mov", ".mp1v", ".mp2v", ".mp4", ".mpe", ".mpeg", ".mpg", ".mps", ".mpv", ".mpv1", ".mpv2", ".ogm", ".qt", ".ram", ".rm", ".rmvb", ".rv", ".rv9", ".swf", ".ts", ".vivo", ".vob", ".wmv", ".xvid"};
        }

        public override string ToString()
        {
            string fileTypeString;
            switch (Settings.Instance["UICulture"])
            {
                case "en":
                    fileTypeString = "Video";
                    break;

                case "de":
                    fileTypeString = "Videos";
                    break;

                case "fr":
                    fileTypeString = "Vidéos";
                    break;

                case "it":
                    fileTypeString = "Video";
                    break;

                case "tr":
                    fileTypeString = "Görüntü";
                    break;

                default:
                    fileTypeString = "Video";
                    break;
            }
            return fileTypeString;
        }
    }
}
