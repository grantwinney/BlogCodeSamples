using MockingDependencies.MockLogger;
using NUnit.Framework;

namespace MockingDependenciesTests.MockLogger
{
    public class UsernameValidation_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Bob", Description = "should be valid")]
        [TestCase("JDoe1", Description = "should be invalid")]
        public void Test1(string username)
        {
            var l = new UsernameValidation();

            Assert.True(l.IsUsernameAlphaOnly(username));
        }
    }
}