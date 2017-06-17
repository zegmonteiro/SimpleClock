using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClock
{
    public static class ConfigReader
    {
        public static string ReadKey(string key)
        {
            if (System.Configuration.ConfigurationSettings.AppSettings.AllKeys.Contains(key))
            {
                return System.Configuration.ConfigurationSettings.AppSettings[key];
            }
            else
            {
                return "";
            }
        }
    }
}
