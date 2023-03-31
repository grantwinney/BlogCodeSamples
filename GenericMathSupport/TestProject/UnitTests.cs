using GenericMathSupport;
using System.Drawing;
using System.Linq;

namespace TestProject
{
    public class Tests
    {
        [Test]
        public void AddingTwoFolders_CombinesTheirFiles()
        {
            var folder1 = new Folder
            {
                Files = new List<Document>
                {
                    new Document { Name = "Doc 1" },
                    new Document { Name = "Doc 2" },
                    new Document { Name = "Doc 3" }
                }
            };

            var folder2 = new Folder
            {
                Files = new List<Document>
                {
                    new Document { Name = "Doc A" },
                    new Document { Name = "Doc B" },
                    new Document { Name = "Doc C" }
                }
            };

            var bigFolder = folder1 + folder2;

            Assert.Multiple(() =>
            {
                Assert.That(bigFolder.Files, Has.Count.EqualTo(6));
                Assert.That(bigFolder.Files.SingleOrDefault(x => x.Name == "Doc 2"), Is.Not.Null);
                Assert.That(bigFolder.Files.SingleOrDefault(x => x.Name == "Doc B"), Is.Not.Null);
            });
        }

        [Test]
        public void AddingTwoSwatches_CombinesTheirShades()
        {
            var swatch1 = new ColorSwatch("Yellow", new List<Color>
                {
                    Color.LightYellow,
                    Color.Goldenrod,
                    Color.DarkGoldenrod,
                }
            );

            var swatch2 = new ColorSwatch("Blue", new List<Color>
                {
                    Color.AliceBlue,
                    Color.DodgerBlue,
                    Color.Navy,
                }
             );

            var mixedSwatch = swatch1 + swatch2;

            Assert.Multiple(() =>
            {
                Assert.That(mixedSwatch.ToList(), Has.Count.EqualTo(6));
            });
        }

        [Test]
        public void MultiplyingColors_CreatesNewCombinations()
        {
            var swatch1 = new ColorSwatch("Yellow", new List<Color>
                {
                    Color.LightYellow,    // 255,255,224
                    Color.Goldenrod,      // 218,165, 32
                    Color.DarkGoldenrod,  // 184,134, 11
                }
            );

            var swatch2 = new ColorSwatch("Blue", new List<Color>
                {
                    Color.AliceBlue,      // 240,248,255
                    Color.DodgerBlue,     //  30,144,255
                    Color.Navy,           //   0,  0,128
                }
             );

            var mixedSwatch = swatch1 * swatch2;

            Assert.Multiple(() =>
            {
                Assert.That(mixedSwatch, Has.Count.EqualTo(9));
            });
        }

    }
}