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
    public class AudioFileType : FileType
    {
        public AudioFileType()
        {
            FileExtentions = new string[] { ".669", ".aac", ".aif", ".aiff", ".amf", ".ams", ".ape", ".au", ".dbm", ".dmf", ".dsm", ".far", ".flac", ".it", ".m4a", ".mdl", ".med", ".mid", ".midi", ".mka", ".mod", ".mol", ".mp1", ".mp2", ".mp3", ".mpa", ".mpc", ".mpp", ".mtm", ".nst", ".ogg", ".okt", ".psm", ".ptm", ".ra", ".rmi", ".s3m", ".stm", ".ult", ".umx", ".wav", ".wma", ".wow", ".xm" };
        }

        public override string ToString()
        {
            string fileTypeString;
            switch (Settings.Instance["UICulture"])
            {
                case "en":
                    fileTypeString = "Audio";
                    break;

                case "de":
                    fileTypeString = "Audio";
                    break;

                case "fr":
                    fileTypeString = "Audio";
                    break;

                case "it":
                    fileTypeString = "Audio";
                    break;

                case "tr":
                    fileTypeString = "Ses";
                    break;

                default:
                    fileTypeString = "Audio";
                    break;
            }
            return fileTypeString;
        }
    }
}
