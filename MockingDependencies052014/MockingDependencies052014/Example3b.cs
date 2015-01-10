using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example3b
    {
        public const string LogFile = @"c:\test3b.txt";
        public const string LogFileTimeStamp = "Timestamp: ";

        private readonly IFile file;

        public Example3b()
        {
            file = new FileEx();

            file.WriteAllText(LogFile, LogFileTimeStamp);
        }

        public Example3b(IFile file)
        {
            this.file = file;

            file.WriteAllText(LogFile, LogFileTimeStamp);
        }

        public IEnumerable<string> GetLogFileEntries(string logPath)
        {
            return file.ReadAllLines(logPath)
                       .Where(x => x.StartsWith(LogFileTimeStamp));
        }
    }

    public interface IFile
    {
        IEnumerable<string> ReadAllLines(string path);

        void WriteAllText(string path, string contents);
    }

    public class FileEx : IFile
    {
        public IEnumerable<string> ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }

    [TestFixture]
    public class Example3bTester
    {
        private Mock<IFile> fileMock;

        [SetUp]
        public void Setup()
        {
            fileMock = new Mock<IFile>();
        }

        [Test]
        public void GetLogFileEntries_ReturnsLogEntries()
        {
            var fileContents = new List<string>
                               {
                                   "Timestamp: 03:30 - FileNotFoundException occurred",
                                   "Some informational message, blah.",
                                   "Timestamp: 13:22 - User MJ123 access denied."
                               };

            fileMock.Setup(x => x.ReadAllLines(Example3b.LogFile))
                    .Returns(fileContents);

            var vm = new Example3b(fileMock.Object);

            var results = vm.GetLogFileEntries(Example3b.LogFile);

            Assert.AreEqual(results.Count(), 2);
        }
    }
}
