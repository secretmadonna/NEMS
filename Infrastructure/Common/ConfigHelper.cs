using System;
using System.Configuration;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    public static class ConfigHelper
    {
        public static string GetString(string key)
        {
            var tempStr = ConfigurationManager.AppSettings[key];
            return tempStr;
        }
        public static int GetInt(string key)
        {
            var tempStr = ConfigurationManager.AppSettings[key];
            var tempInt = int.Parse(tempStr);
            return tempInt;
        }
        public static bool GetBool(string key)
        {
            var tempStr = ConfigurationManager.AppSettings[key];
            var tempBool = bool.Parse(tempStr);
            return tempBool;
        }
        public static bool TryGetString(string key, out string result)
        {
            try
            {
                result = GetString(key);
                return true;
            }
            catch (Exception ex)
            {
                TraceHelper.Exception(ex);
            }
            result = null;
            return false;
        }
        public static bool TryGetInt(string key, out int result)
        {
            try
            {
                result = GetInt(key);
                return true;
            }
            catch (Exception ex)
            {
                TraceHelper.Exception(ex);
            }
            result = 0;
            return false;
        }
        public static bool TryGetBool(string key, out bool result)
        {
            try
            {
                result = GetBool(key);
                return true;
            }
            catch (Exception ex)
            {
                TraceHelper.Exception(ex);
            }
            result = false;
            return false;
        }
    }
}