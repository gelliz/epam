using System;
using System.Configuration;
using NUnit.Framework;

namespace Framework.Services
{
    public static class TestDataReader
    {
        private static Configuration ConfigFile
        {
            get
            {
                var variableFromConsole = TestContext.Parameters.Get("environment");
                string file = string.IsNullOrEmpty(variableFromConsole) ? "invalidNumber" : variableFromConsole;
                var index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var customConfigMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index)
                                        + @"ConfigFiles\" + file + ".config"
                };
                return ConfigurationManager.OpenMappedExeConfiguration(customConfigMap, ConfigurationUserLevel.None);
            }
        }
        public static string GetTestData(string key)
        {
            return ConfigFile.AppSettings.Settings[key].Value;
        }
    }
}
