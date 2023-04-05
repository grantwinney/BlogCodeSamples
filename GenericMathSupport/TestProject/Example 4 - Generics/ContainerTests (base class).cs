using GenericMathSupport.Example4;

namespace TestProject.Example4
{
    public class ContainerTests
    {
        [Test]
        public void GetIdentifierWorksForAllTypesOfContainers()
        {
            var boxId = 4;  // chosen by fair dice roll; randomness guaranteed
            var crateId = "absolutely_unique_id";
            var folderId = Guid.NewGuid();

            var box = new Box(boxId);
            var crate = new Crate(crateId);
            var folder = new Folder(folderId);

            Assert.Multiple(() =>
            {
                Assert.That(box.GetIdentifier(), Is.EqualTo($"The identifier is: {boxId}"));
                Assert.That(crate.GetIdentifier(), Is.EqualTo($"The identifier is: {crateId}"));
                Assert.That(folder.GetIdentifier(), Is.EqualTo($"The identifier is: {folderId}"));
            });
        }
    }
}