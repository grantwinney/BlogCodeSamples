using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example3
    {
        public const string LogFile = @"c:\test3.txt";
        public const string LogFileTimeStamp = "Timestamp: ";

        public Example3()
        {
            File.WriteAllText(LogFile, LogFileTimeStamp);
        }

        public IEnumerable<string> GetLogFileEntries(string logPath)
        {
            return File.ReadAllLines(logPath)
                       .Where(x => x.StartsWith(LogFileTimeStamp));
        }
    }

    [TestFixture]
    public class Example3Tester
    {
        [Test]
        public void GetLogFileEntries_ReturnsLogEntries()
        {
            var vm = new Example3();

            var results = vm.GetLogFileEntries(Example3.LogFile);

            Assert.AreEqual(results.Count(), File.ReadAllLines(Example3.LogFile)
                                                 .Count(x => x.StartsWith(Example3.LogFileTimeStamp)));
        }
    }
}
