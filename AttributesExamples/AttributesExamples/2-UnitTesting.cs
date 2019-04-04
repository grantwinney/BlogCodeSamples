using NUnit.Framework;

namespace AttributesExamples
{
    [TestFixture]
    public class UnitTesting
    {
        Employee emp;

        [SetUp]
        public void AnyNameWeWant()
        {
            emp = new Employee();
        }

        [TearDown]
        public void SomeOtherName()
        {
            emp = null;
        }

        [Test]
        [TestCase("Lucky", "Day", "Lucky Day")]
        [TestCase("Dusty", "Bottoms", "Dusty Bottoms")]
        [TestCase("Ned", "Nederlander", "Ned Nederlander")]
        public void GetFullName_ReturnsFullName(string firstName, string lastName, string expectedFullName)
        {
            emp.SetName(firstName, lastName);

            Assert.AreEqual(expectedFullName, emp.GetFullName());
        }
    }

    public class Employee
    {
        private string firstName;
        private string lastName;

        public void SetName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string GetFullName()
        {
            return $"{firstName} {lastName}";
        }
    }
}
