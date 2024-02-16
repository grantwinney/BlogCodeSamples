using MockingDependencies.MockXDocument;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MockingDependencies
{
    public class Books_MockXDocument
    {
        private readonly IXDocument xDoc;

        public Books_MockXDocument()
        {
            xDoc = XDocument.LoadEx(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MockXDocument", "books.xml"));
        }

        public Books_MockXDocument(IXDocument xDoc)
        {
            this.xDoc = xDoc;
        }

        public decimal? GetPrice(string bookId)
        {
            var book = xDoc.Descendants("book")
                           .Where(x => x.Attribute("id").Value == bookId)
                           .SingleOrDefault();

            return decimal.TryParse(book?.Element("price")?.Value, out decimal price) ? price : (decimal?)null;
        }
    }
}