using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace MockingDependencies052014
{
    public class Example2a
    {
        public const string SettingsFile = @"c:\test2a.xml";
        public const int TheAnswerToLifeUniverseAndEverything = 42;

        private readonly XDocument xDoc;

        public Example2a()
        {
            // We need a file with a root element to read or we'll get an error
            File.WriteAllText(SettingsFile,
                @"<?xml version=""1.0"" encoding=""utf-8"" ?><root><someNodeName /></root>");

            xDoc = XDocument.Load(SettingsFile);
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

    [TestFixture]
    class Example2aTester
    {
        [Test]
        public void WriteSettingsFile_SavesFile()
        {
            var vm = new Example2a();

            vm.WriteSettingsFile();

            var xDoc = XDocument.Load(Example2a.SettingsFile);

            var insertedValue = xDoc.Descendants().Single(x => x.Name == "someNodeName").Value;
            Assert.AreEqual(Example2a.TheAnswerToLifeUniverseAndEverything, int.Parse(insertedValue));
        }
    }
}