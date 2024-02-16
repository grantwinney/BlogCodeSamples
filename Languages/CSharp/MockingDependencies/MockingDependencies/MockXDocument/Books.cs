using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace MockingDependencies
{
    public class Books
    {
        private readonly XDocument xDoc;

        public Books()
        {
            xDoc = XDocument.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MockXDocument", "books.xml"));
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