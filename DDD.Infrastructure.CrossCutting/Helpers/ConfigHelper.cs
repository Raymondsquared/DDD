using System;
using System.Configuration;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class ConfigHelper
    {
        public static string LoadOrDefault(string appSettingKey, string inputDefault)
        {
            var result = inputDefault;

            try
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[appSettingKey]))
                    result = ConfigurationManager.AppSettings[appSettingKey];
            }
            catch (Exception)
            {
                result = inputDefault;
            }

            return result;
        }

        public static int LoadOrDefault(string appSettingKey, int inputDefault)
        {
            var result = inputDefault;

            try
            {
                int intValue;
                if (int.TryParse(ConfigurationManager.AppSettings[appSettingKey], out intValue))
                    result = intValue;
            }
            catch (Exception)
            {
                result = inputDefault;
            }

            return result;
        }
    }
}
