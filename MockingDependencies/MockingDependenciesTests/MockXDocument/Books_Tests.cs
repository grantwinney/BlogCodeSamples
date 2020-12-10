using MockingDependencies;
using NUnit.Framework;

namespace MockingDependenciesTests.MockXDocument
{
    public class Books_Tests
    {
        Books books;

        [SetUp]
        public void Setup()
        {
            books = new Books();
        }

        [TestCase("bk102", 5.95)]
        [TestCase("bk111", 36.95)]
        [TestCase("bk999", null, Description = "not a book")]
        public void Test1(string bookId, decimal? bookPrice)
        {
            Assert.AreEqual(bookPrice, books.GetPrice(bookId));
        }
    }
}