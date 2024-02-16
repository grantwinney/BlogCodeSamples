using NUnit.Framework;
using SampleLibrary;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConfigFile_Loads_ApplicationName()
        {
            //var defaultConfigFilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;

            Assert.AreEqual("test_logger", LogSettings.Instance.ApplicationName);
        }

        [Test]
        public void ConfigFile_Loads_Level()
        {
            Assert.AreEqual(LogLevel.Warn, LogSettings.Instance.Level);
        }

        [Test]
        public void ConfigFile_Loads_LogFilePath()
        {
            Assert.AreEqual(@"C:\ProgramData\MyApp\TestLogs\", LogSettings.Instance.LogFilePath);
        }

        [Test]
        public void ConfigFile_Loads_DateFormat()
        {
            Assert.AreEqual("MM/dd/yyyy", LogSettings.Instance.DateFormat);
        }

        [Test]
        public void ConfigFile_Loads_IncludeDate()
        {
            Assert.IsFalse(LogSettings.Instance.IncludeDate);
        }
    }
}