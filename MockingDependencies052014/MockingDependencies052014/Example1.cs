using System.IO;
using System.Linq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example1
    {
        public const string LogFile = @"c:\test1.txt";
        public const string JobCompleteMessage = "Job Complete!";

        private readonly Logger1 logger;

        public Example1()
        {
            logger = new Logger1(LogFile);
        }

        public void PerformSomeAction()
        {
            // Do Something

            logger.LogMessage(JobCompleteMessage);
        }
    }

    public class Logger1
    {
        private readonly string logFile;

        public Logger1(string logFile)
        {
            this.logFile = logFile;
        }

        public void LogMessage(string message)
        {
            using (var file = new StreamWriter(logFile, true))
            {
                file.WriteLine(message);
            }
        }
    }

    [TestFixture]
    class Example1Tester
    {
        [Test]
        public void PerformSomeAction_LogsMessage_WhenActionSuccessfullyCompletes()
        {
            var vm = new Example1();
            vm.PerformSomeAction();

            var expectedValue = Example1.JobCompleteMessage;
            var actualValue = File.ReadAllLines(Example1.LogFile).Last();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}