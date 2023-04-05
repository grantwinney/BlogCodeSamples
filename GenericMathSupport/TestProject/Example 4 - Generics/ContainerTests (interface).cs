using GenericMathSupport.Example4b;

namespace TestProject.Example4b
{
    public class ContainerTests
    {
        [Test]
        public void GetDescriptionWorksForAllTypesOfContainers()
        {
            var boxId = 4;  // chosen by fair dice roll; randomness guaranteed
            var crateId = Guid.NewGuid();

            var box = new Box { Identifier = boxId };
            var crate = new Crate { Identifier = crateId };

            Assert.Multiple(() =>
            {
                Assert.That(box.GetDescription(), Is.EqualTo($"The box id is {boxId}."));
                Assert.That(crate.GetDescription(), Is.EqualTo($"The guid is: {crateId}"));
            });
        }
    }
}