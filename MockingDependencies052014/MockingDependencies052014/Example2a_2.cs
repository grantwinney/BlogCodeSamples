using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Moq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example2a_2
    {
        public const string SettingsFile = @"c:\test2a_2.xml";
        public const int TheAnswerToLifeUniverseAndEverything = 42;

        private readonly IXDocument xDoc;

        public Example2a_2()
        {
            File.WriteAllText(SettingsFile,
                @"<?xml version=""1.0"" encoding=""utf-8"" ?><root><someNodeName /></root>");

            xDoc = XDocumentExt.Load(SettingsFile);
        }

        public Example2a_2(IXDocument iXDocument, string initialXmlString = null)
        {
            File.WriteAllText(SettingsFile,
                initialXmlString ?? @"<?xml version=""1.0"" encoding=""utf-8"" ?><root><someNodeName /></root>");

            xDoc = iXDocument.LoadEx(SettingsFile);
        }

        public void WriteSettingsFile()
        {
            if (!xDoc.Descendants("someNodeName").Any())
                return;

            foreach (var desc in xDoc.Descendants("someNodeName"))
                desc.SetValue(TheAnswerToLifeUniverseAndEverything);

            xDoc.Save(SettingsFile);
        }
    }

    public interface IXDocument
    {
        IXDocument LoadEx(string fileName);

        void Save(string fileName);

        IEnumerable<XElement> Descendants(XName name);
    }

    public class XDocumentExt : XDocument, IXDocument
    {
        public IXDocument LoadEx(string fileName)
        {
            return Load(fileName);
        }

        public new static IXDocument Load(string fileName)
        {
            return (IXDocument)XDocument.Load(fileName);
        }

        public new void Save(string fileName)
        {
            base.Save(fileName);
        }

        public new IEnumerable<XElement> Descendants(XName name)
        {
            return base.Descendants(name);
        }
    }

    [TestFixture]
    class Example2a_2Tester
    {
        Mock<IXDocument> xDoc;

        [SetUp]
        public void Setup()
        {
            xDoc = new Mock<IXDocument>();
        }

        [Test]
        public void WriteSettingsFile_DoesNotSaveFile_WhenNoNodesAvailable()
        {
            xDoc.Setup(x => x.LoadEx(Example2a_2.SettingsFile))
                .Returns(xDoc.Object);
            xDoc.Setup(x => x.Descendants("someNodeName"))
                .Returns(new List<XElement>());

            var vm = new Example2a_2(xDoc.Object);

            vm.WriteSettingsFile();

            xDoc.Verify(x => x.Save(Example2a_2.SettingsFile), Times.Never);
        }

        [Test]
        public void WriteSettingsFile_SavesFile_WhenNodesAvailable()
        {
            xDoc.Setup(x => x.LoadEx(Example2a_2.SettingsFile))
                .Returns(xDoc.Object);
            xDoc.Setup(x => x.Descendants("someNodeName"))
                .Returns(new List<XElement> {new XElement("someNodeName")});

            var vm = new Example2a_2(xDoc.Object);

            vm.WriteSettingsFile();

            xDoc.Verify(x => x.Save(Example2a_2.SettingsFile), Times.Once());
        }
    }
}