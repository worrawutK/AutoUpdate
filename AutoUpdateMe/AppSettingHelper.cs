using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
namespace AutoUpdateMe
{
    internal  class AppSettingHelper
    {
        //private AppSettingHelper() { }
        internal static string GetAppSettingsValue(string key)
        {
            string val = ConfigurationManager.AppSettings[key];
            return val ?? throw new Exception("Application Setting Key was not found [Key=" + key + "]");
        }
        internal static string GetConnectionStringValue(string key)
        {
            string val = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return val ?? throw new Exception("Application Setting Key was not found [Key=" + key + "]");
        }
    }
}
