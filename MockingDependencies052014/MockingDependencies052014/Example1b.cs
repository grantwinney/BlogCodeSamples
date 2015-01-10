using System.IO;
using Moq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example1b
    {
        private const string LogFile = @"c:\test1b.txt";
        public const string JobCompleteMessage = "Job Completed again!";

        private readonly ILogger1b logger;

        public Example1b()
        {
            this.logger = new Logger1b(LogFile);
        }

        public Example1b(ILogger1b logger)
        {
            this.logger = logger;
        }

        public void PerformSomeAction()
        {
            // Do Something

            logger.LogMessage(JobCompleteMessage);
        }
    }

    public interface ILogger1b
    {
        void LogMessage(string message);
    }

    public class Logger1b : ILogger1b
    {
        private readonly string logFile;

        public Logger1b(string logFile)
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
    class Example1bTester
    {
        private Mock<ILogger1b> logger;

        [SetUp]
        public void Setup()
        {
            logger = new Mock<ILogger1b>();
        }

        [Test]
        public void PerformSomeAction_LogsMessage_WhenActionSuccessfullyCompletes()
        {
            var vm = new Example1b(logger.Object);
            vm.PerformSomeAction();

            logger.Verify(x => x.LogMessage(Example1b.JobCompleteMessage), Times.Once());
        }
    }
}