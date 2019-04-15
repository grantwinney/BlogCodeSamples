using System;
using System.Configuration;

namespace SampleLibrary
{
    public class LogSettings : ConfigurationSection
    {
        public static Settings Instance => (ConfigurationManager.GetSection("appConfiguration/logging") as LogSettings).Settings;

        [ConfigurationProperty("application")]
        public Settings Settings
        {
            get { return (Settings)this["application"]; }
        }
    }

    public class Settings : ConfigurationElement
    {
        public LogLevel Level
        {
            get { return (LogLevel)Enum.Parse(typeof(LogLevel), Convert.ToString(LevelInternal)); }
        }

        [ConfigurationProperty("level", DefaultValue = "1", IsRequired = false)]
        private int LevelInternal
        {
            get { return Convert.ToInt32(this["level"]); }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string ApplicationName
        {
            get { return Convert.ToString(this["name"]); }
        }

        [ConfigurationProperty("logFilePath", IsRequired = true)]
        public string LogFilePath
        {
            get { return Convert.ToString(this["logFilePath"]); }
        }

        [ConfigurationProperty("dateFormat", DefaultValue = "MM/dd/yyyy", IsRequired = false)]
        public string DateFormat
        {
            get { return Convert.ToString(this["dateFormat"]); }
        }

        [ConfigurationProperty("includeDate", DefaultValue = "true", IsRequired = false)]
        public bool IncludeDate
        {
            get { return Convert.ToBoolean(this["includeDate"]); }
        }
    }
}
