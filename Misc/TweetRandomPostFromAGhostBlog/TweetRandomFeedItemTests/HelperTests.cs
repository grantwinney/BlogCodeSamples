using NUnit.Framework;
using TweetRandomFeedItem;

namespace TweetRandomFeedItemTests
{
    public class Tests
    {
        [Test]
        [TestCase("c#", "#csharp")]
        [TestCase(".net", "#dotnet")]
        [TestCase("testing-123", "#testing123")]
        [TestCase("testing 123 456", "#testing123456")]
        [TestCase("1-2 3", "#123")]
        public void SanitizeTagName_ReplacesInvalidCharacters(string input, string expectedOutput)
        {
            Assert.AreEqual(expectedOutput, Helper.SanitizeTagName(input));
        }

        [Test]
        [TestCase("phone#", "#phonesharp")]
        [TestCase("this.that", "#thisdotthat")]
        public void SanitizeTagName_MightHaveUnintendedEffects(string input, string expectedOutput)
        {
            Assert.AreEqual(expectedOutput, Helper.SanitizeTagName(input));
        }

        [Test]
        [TestCase("programming")]
        [TestCase("csharp_8")]
        public void SanitizeTagName_LeavesValidTagsAlone(string tagName)
        {
            Assert.AreEqual($"#{tagName}", Helper.SanitizeTagName(tagName));
        }

        [Test]
        [TestCase(null, "9999999", 9999999)]
        [TestCase("", "9999999", 9999999)]
        [TestCase("3", "9999999", 3)]
        public void ConvertVariableType_ConvertsStringsToNumbers(string variableValue, string defaultValue, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Helper.ConvertVariableType<int>("n/a", variableValue, defaultValue));
        }
    }
}