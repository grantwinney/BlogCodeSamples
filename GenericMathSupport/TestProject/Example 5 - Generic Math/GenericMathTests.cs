using GenericMathSupport.Example5;

namespace TestProject.Example5
{
    public class GenericMathTests
    {
        [Test]
        public void CanFindTheSumOfAllTheThings()
        {
            var boxes = new List<Box>
            {
                new Box(2, 7, 2),
                new Box(10, 10, 10),
                new Box(3, 4, 3),
            };

            var folders = new List<Folder>
            {
                new Folder { Files = new List<string> { "c:/file1.txt", "c:/file2.txt" } },
                new Folder { Files = new List<string> { "d:/fileA.txt", "d:/fileB.txt" } }
            };

            var fractions = new List<Fraction>
            {
                new Fraction(1, 3),
                new Fraction(2, 6),
                new Fraction(2, 5),
            };

            Assert.Multiple(() =>
            {
                Assert.That(boxes.Sum().Height, Is.EqualTo(21));
                Assert.That(folders.Sum().Files, Has.Count.EqualTo(4));
                Assert.That(fractions.Sum().Numerator, Is.EqualTo(96));  // 96/90
            });
        }

        [Test]
        public void CanPerformComparisonsOnBoxes()
        {
            var box1 = new Box(1, 2, 10);
            var box2 = new Box(3, 4, 5);

            Assert.Multiple(() =>
            {
                Assert.True(box1 != box2);
                Assert.False(box1 == box2);
                Assert.True(box1 < box2);
                Assert.False(box1 > box2);
                Assert.True(box1 <= box2);
                Assert.False(box1 >= box2);
            });
        }

        [Test]
        public void CanPerformComparisonsOnFolders()
        {
            var folder1 = new Folder { Files = new List<string> { "c:/file1.txt", "c:/file2.txt" } };
            var folder2 = new Folder { Files = new List<string> { "d:/fileA.txt", "d:/fileB.txt" } };

            Assert.Multiple(() =>
            {
                Assert.True(folder1 == folder2);
                Assert.False(folder1 != folder2);
                Assert.False(folder1 > folder2);
                Assert.False(folder1 < folder2);
                Assert.True(folder1 >= folder2);
                Assert.True(folder1 <= folder2);
            });
        }

        [Test]
        public void CanPerformComparisonsOnFractions()
        {
            var fraction1 = new Fraction(2, 5);
            var fraction2 = new Fraction(4, 10);

            Assert.Multiple(() =>
            {
                Assert.True(fraction1 == fraction2);
                Assert.False(fraction1 != fraction2);
                Assert.False(fraction1 > fraction2);
                Assert.False(fraction1 < fraction2);
                Assert.True(fraction1 >= fraction2);
                Assert.True(fraction1 <= fraction2);
            });
        }

        [Test]
        public void CanFindTheLeastOfAllTheThings()
        {
            var boxes = new List<Box>
            {
                new Box(2, 1, 2),
                new Box(10, 10, 10),
                new Box(3, 4, 3),
            };

            var folders = new List<Folder>
            {
                new Folder { Files = new List<string> { "c:/file1.txt", "c:/file2.txt", "c:/file3.txt" } },
                new Folder { Files = new List<string> { "d:/fileA.txt", "d:/fileB.txt" } }
            };

            var fractions = new List<Fraction>
            {
                new Fraction(2, 3),
                new Fraction(1, 10),
                new Fraction(3, 4),
            };

            Assert.Multiple(() =>
            {
                Assert.That(boxes.Least().Height, Is.EqualTo(1));
                Assert.That(folders.Least().Files, Has.Count.EqualTo(2));
                Assert.That(fractions.Least().Denominator, Is.EqualTo(10));
            });
        }

        [Test]
        public void GettingValueOfFraction_ThrowsException_WhenDenominatorIsZero()
        {
            var fraction = new Fraction(4, 0);

            Assert.Throws<DivideByZeroException>(() => { var _ = fraction.Value; });
        }
    }
}