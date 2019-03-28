using System;
using System.Configuration;

namespace eGandalf.Episerver.Criteria.Weather.Settings
{
    internal class AssemblySettings
    {
        public static string OpenWeatherMapApiKey => GetAppSetting("OpenWeatherMapApiKey");
        public static string FallbackGeolocationIP => GetAppSetting("FallbackGeolocationIP");

        private static string GetAppSetting(string key)
        {
            try
            {
                var setting = ConfigurationManager.AppSettings[key];
                return setting;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error reading configuration setting", e);
            }
        }
    }
}
