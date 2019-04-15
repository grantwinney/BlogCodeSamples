using NUnit.Framework;
using SampleLibrary;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConfigFileLogSettingsAreLoadedCorrectly()
        {
            var defaultConfigFilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;

            Assert.AreEqual("test_logger", LogSettings.Instance.ApplicationName);
            Assert.AreEqual(LogLevel.Warn, LogSettings.Instance.Level);
            Assert.AreEqual(@"C:\ProgramData\MyApp\TestLogs\", LogSettings.Instance.LogFilePath);
            Assert.AreEqual("MM/dd/yyyy", LogSettings.Instance.DateFormat);
            Assert.IsFalse(LogSettings.Instance.IncludeDate);
        }
    }
}