using MockingDependencies;
using MockingDependencies.MockXDocument;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MockingDependenciesTests.MockXDocument
{
    public class Books_MockXDocument_Tests
    {
        Books_MockXDocument books;
        Mock<IXDocument> mockDoc;

        [SetUp]
        public void Setup()
        {
            mockDoc = new Mock<IXDocument>();
            books = new Books_MockXDocument(mockDoc.Object);
        }

        [TestCase("bk102", 5.95)]
        [TestCase("bk111", 36.95)]
        [TestCase("bk999", null)]
        public void Test1(string bookId, decimal? bookPrice)
        {
            if (bookPrice.HasValue)
            {
                var testBook = $@"<book id=""{bookId}""><price>{bookPrice}</price></book>";

                mockDoc.Setup(x => x.Descendants("book"))
                    .Returns(new List<XElement> { System.Xml.Linq.XDocument.Parse(testBook).Root });
            }

            Assert.AreEqual(bookPrice, books.GetPrice(bookId));
        }
    }
}