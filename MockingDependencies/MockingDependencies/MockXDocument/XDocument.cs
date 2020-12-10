using System.Collections.Generic;

namespace MockingDependencies.MockXDocument
{
    public interface IXDocument
    {
        IXDocument Load(string fileName);

        IEnumerable<System.Xml.Linq.XElement> Descendants(System.Xml.Linq.XName name);
    }

    public class XDocument : IXDocument
    {
        private System.Xml.Linq.XDocument XDoc;

        public IXDocument Load(string uri)
        {
            XDoc = System.Xml.Linq.XDocument.Load(uri);
            return this;
        }

        public static IXDocument LoadEx(string fileName)
        {
            return new XDocument().Load(fileName);
        }

        public IEnumerable<System.Xml.Linq.XElement> Descendants(System.Xml.Linq.XName name)
        {
            return XDoc.Descendants(name);
        }
    }
}
