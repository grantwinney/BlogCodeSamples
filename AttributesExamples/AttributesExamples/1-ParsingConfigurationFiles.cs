using System;
using System.Configuration;

namespace AttributesExamples
{
    public enum Severity
    {
        Info = 1,
        Warn = 2,
        Error = 3
    }

    public class Application : ConfigurationSection
    {
        public static LogSettings LoggingConfig => (ConfigurationManager.GetSection("application") as Application).LogSettings;

        [ConfigurationProperty("logging", Options = ConfigurationPropertyOptions.IsRequired)]
        public LogSettings LogSettings
        {
            get { return (LogSettings)this["logging"]; }
        }
    }

    public class LogSettings : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = false, DefaultValue = @"log.txt")]
        [StringValidator(InvalidCharacters = @":;()!@3$%^&*'""<>", MinLength = 1, MaxLength = 32)]
        public string LogName
        {
            get { return Convert.ToString(this["name"]); }
        }

        [ConfigurationProperty("location", IsRequired = true)]
        public string LogPath
        {
            get { return Convert.ToString(this["location"]); }
        }

        [ConfigurationProperty("level", IsRequired = false, DefaultValue = Severity.Info)]
        public Severity SeverityLevel
        {
            get { return (Severity)Enum.Parse(typeof(Severity), Convert.ToString(this["level"])); }
        }

        [ConfigurationProperty("enabled", IsRequired = false, DefaultValue = true)]
        public bool LoggingEnabled
        {
            get { return Convert.ToBoolean(this["enabled"]); }
        }
    }
}
