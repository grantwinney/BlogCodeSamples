using GenericMathSupport;
using GenericMathSupport.Example3;
using System.Drawing;

namespace TestProject.Example3
{
    public class BoxTests
    {
        [Test]
        public void BoxesAreEqual_WhenAllDimensionsAreEqual()
        {
            var box1 = new Box(2, 4, 7);
            var box2 = new Box(2, 4, 7);

            Assert.That(box1, Is.EqualTo(box2));
        }

        [Test]
        public void BoxesAreNotEqual_WhenNotAllDimensionsAreEqual()
        {
            var box1 = new Box(2, 3, 7);
            var box2 = new Box(2, 4, 7);

            Assert.That(box2, Is.Not.EqualTo(box1));
        }

        [Test]
        public void AddingTwoBoxes_ReturnsBoxToFitBoth()
        {
            var box1 = new Box(2, 3, 7);
            var box2 = new Box(4, 6, 5);

            var box3 = box1 + box2;

            Assert.Multiple(() =>
            {
                Assert.That(box3.Width, Is.EqualTo(4));   // larger width from box2
                Assert.That(box3.Depth, Is.EqualTo(7));   // larger depth from box1
                Assert.That(box3.Height, Is.EqualTo(9));  // combined height
            });
        }

        [Test]
        public void AddingTwoFolders_CombinesTheirFiles()
        {
            var folder1 = new Folder
            {
                Files = new List<string> { "c:/file1.txt", "c:/file2.txt" }
            };

            var folder2 = new Folder
            {
                Files = new List<string> { "d:/fileA.txt", "d:/fileB.txt" }
            };

            var bigFolder = folder1 + folder2;

            Assert.Multiple(() =>
            {
                Assert.That(bigFolder.Files, Has.Count.EqualTo(4));
                Assert.That(bigFolder.Files.SingleOrDefault(f => f.Contains("file2")), Is.Not.Null);
                Assert.That(bigFolder.Files.SingleOrDefault(f => f.Contains("fileA")), Is.Not.Null);
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

            Assert.That(swatch1 * swatch2, Has.Count.EqualTo(9));
        }

        [Test]
        public void Box1IsLessThanBox2_WhenAreaIsSmaller()
        {
            var box1 = new Box(2, 3, 7);
            var box2 = new Box(2, 4, 7);

            Assert.Multiple(() =>
            {
                Assert.That(box1 < box2);
                Assert.That(box2 > box1);
            });
        }
    }
}