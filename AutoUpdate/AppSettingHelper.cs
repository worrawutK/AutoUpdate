using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace AutoUpdate
{
    internal class AppSettingHelper
    {
        private AppSettingHelper() { }

        internal static string GetAppSettingsValue(string key)
        {
            string val = ConfigurationManager.AppSettings[key];
            return val ?? throw new Exception("Application Setting Key was not found [Key=" + key + "]");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static string GetConnectionStringValue(string key)
        {
            string val = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return val ?? throw new Exception("ConnectionString Setting Key was not found [Key=" + key + "]");
          
        }
    }
}
