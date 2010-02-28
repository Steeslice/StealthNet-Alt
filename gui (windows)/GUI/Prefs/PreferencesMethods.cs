using System;
using System.Collections.Generic;
using System.Text;

namespace Regensburger.RShare
{
    public sealed class Preferences
    {
        private Settings m_Settings = Settings.Instance;

        private const string DEFAULT_PORT = "6097";
        private const string DEFAULT_AVERAGECONNECTIONSCOUNT = "5";
        private const string DEFAULT_HASDOWNLOADLIMIT = "false";
        private const string DEFAULT_DOWNLOADLIMIT = "512";
        private const string DEFAULT_HASUPLOADLIMIT = "false";
        private const string DEFAULT_UPLOADLIMIT = "64";
        private const string DEFAULT_SYNCHRONIZEWEBCACHES = "true";

        private const string DEFAULT_PROGRESSBARSSHOWPERCENT = "true";
        private const string DEFAULT_PROGRESSBARHASSHADOW = "true";
        private const string DEFAULT_PROGRESSBARSHADOW = "5";
        private const string DEFAULT_DOWNLOADCAPACITY = "768";
        private const string DEFAULT_UPLOADCAPACITY = "128";

        private const string DEFAULT_SHOWMESSAGEWINDOW = "true";
        private const string DEFAULT_USEBYTESINSTEADOFBITS = "false";
        private const string DEFAULT_CLOSETOTRAY = "false";
        private const string DEFAULT_SHOWSYNDIE = "false";
        

        public string Setting(string Key)
        {
            if (m_Settings[Key] == "")
            {
                //if the value for the Key is not present ("") then set the 
                //default value for the given key
                m_Settings[Key] = getKeyDefault(Key);
            }

            return m_Settings[Key];


            

        } //public string Setting(string Key)

     
        public string Setting(string Key, string value)
        {
            //Sets the given value for the Key and returns it
            m_Settings[Key] = value;
            return m_Settings[Key];
        } //public string Setting(string Key, string value)

        public string getKeyDefault(string Setting)
        {
            string myValue = "";

            string lowerSetting = Setting.ToUpper();
            switch (lowerSetting)
            {
                case "PORT":
                    myValue = DEFAULT_PORT;
                    break;

                case "AVERAGECONNECTIONSCOUNT":
                    myValue = DEFAULT_AVERAGECONNECTIONSCOUNT;
                    break;

                case "HASDOWNLOADLIMIT":
                    myValue = DEFAULT_HASDOWNLOADLIMIT;
                    break;

                case "DOWNLOADLIMIT":
                    myValue = DEFAULT_DOWNLOADLIMIT;
                    break;

                case "HASUPLOADLIMIT":
                    myValue = DEFAULT_HASUPLOADLIMIT;
                    break;

                case "UPLOADLIMIT":
                    myValue = DEFAULT_UPLOADLIMIT;
                    break;

                case "SYNCHRONIZEWEBCACHES":
                    myValue = DEFAULT_SYNCHRONIZEWEBCACHES;
                    break;

                case "PROGRESSBARSSHOWPERCENT":
                    myValue = DEFAULT_PROGRESSBARSSHOWPERCENT;
                    break;

                case "PROGRESSBARHASSHADOW":
                    myValue = DEFAULT_PROGRESSBARHASSHADOW;
                    break;

                case "PROGRESSBARSHADOW":
                    myValue = DEFAULT_PROGRESSBARSHADOW;
                    break;

                case "DOWNLOADCAPACITY":
                    myValue = DEFAULT_DOWNLOADCAPACITY;
                    break;

                case "UPLOADCAPACITY":
                    myValue = DEFAULT_UPLOADCAPACITY;
                    break;


                case "SHOWMESSAGEWINDOW":
                    myValue = DEFAULT_SHOWMESSAGEWINDOW;
                    break;

                case "USEBYTESINSTEADOFBITS":
                    myValue = DEFAULT_USEBYTESINSTEADOFBITS;
                    break;

                case "CLOSETOTRAY":
                    myValue = DEFAULT_CLOSETOTRAY;
                    break;

                case "SHOWSYNDIE":
                    myValue = DEFAULT_SHOWSYNDIE;
                    break;
                
                default:
                    myValue = "";
                    break;
            }

            return myValue;
        } //public string SettingDefault(string Setting)



    }
}
