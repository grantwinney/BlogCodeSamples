using MockingDependencies.MockLogger;
using Moq;
using NLog;
using NUnit.Framework;

namespace MockingDependenciesTests.MockLogger
{
    public class UsernameValidation_MockLogger_Tests
    {
        [TestCase("Bob", Description = "should be valid")]
        [TestCase("JDoe1", Description = "should be invalid")]
        public void Test1(string username)
        {
            var mock = new Mock<ILogger>();

            var l = new UsernameValidation_MockLogger(mock.Object);

            Assert.True(l.IsUsernameAlphaOnly(username));
        }
    }
}