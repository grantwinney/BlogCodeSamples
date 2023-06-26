using NUnit.Framework;
using NUnitConstraintModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NUnitConstraintModelTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EqualityTest()
        {
            var actualResult = 1;
            var actualMessage = "Calculation Succeeded";

            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreNotEqual("Calculation Failed", actualMessage);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(actualMessage, Is.Not.EqualTo("Calculation Failed"));
        }

        [Test]
        public void GreaterOrLessTest()
        {
            var actualResult = 427;
            var expectedMinPossibleValue = 100;
            var expectedMaxPossibleValue = 999;

            Assert.GreaterOrEqual(actualResult, expectedMinPossibleValue);
            Assert.LessOrEqual(actualResult, expectedMaxPossibleValue);

            Assert.That(actualResult, Is.GreaterThanOrEqualTo(expectedMinPossibleValue));
            Assert.That(actualResult, Is.LessThanOrEqualTo(expectedMaxPossibleValue));
        }


        [Test]
        public void GreaterOrLessOopsIGoofedUpTest()
        {
            var actualResult1 = 2;
            var actualResult2 = 20000;
            var expectedMinPossibleValue = 100;
            var expectedMaxPossibleValue = 999;

            Assert.GreaterOrEqual(expectedMinPossibleValue, actualResult1);
            Assert.LessOrEqual(expectedMaxPossibleValue, actualResult2);

            //Assert.That(expectedMinPossibleValue, Is.GreaterThanOrEqualTo(actualResult1));  // um what?
            //Assert.That(expectedMaxPossibleValue, Is.LessThanOrEqualTo(actualResult2));
        }

        [Test]
        public void MultipleAssertsWithClassicSyntax()
        {
            int[] array = { 1, 2, 3 };

            Assert.Multiple(() =>
            {
                Assert.True(array.Count(x => x == 1) == 50);
                Assert.IsTrue(array.Count(x => x > 1) == 500);
                Assert.AreEqual(5000, array.Count(x => x < 100));
            });
        }

        [Test]
        public void MultipleAssertsWithConstraintSyntax()
        {
            int[] array = { 1, 2, 3 };

            Assert.Multiple(() =>
            {
                Assert.That(array, Has.Exactly(50).EqualTo(1));
                Assert.That(array, Has.Exactly(500).GreaterThan(1));
                Assert.That(array, Has.Length.EqualTo(5000));
            });
        }

        [Test]
        public void MultipleAssertsWithClassicSyntaxUsingClass()
        {
            var acme = new Company();
            acme.Employees.Add(new Employee { Name = "Sam" });
            acme.Employees.Add(new Employee { Name = "Sue", IsExec = true });
            acme.Employees.Add(new Employee { Name = "Wile E", IsExec = true, IsCEO = true });
            acme.Employees.Add(new Employee { Name = "Ron" });
            acme.Employees.Add(new Employee { Name = "Gale" });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, acme.Execs.Count);        // pass
                Assert.AreEqual(3, acme.Execs.Count);        // fail
                Assert.Less(5, acme.Execs.Count);            // pass
                Assert.Greater(10, acme.Execs.Count);        // fail
                Assert.True(acme.CEO.Name.StartsWith("R"));  // fail
            });
        }

        [Test]
        public void MultipleAssertsWithConstraintSyntaxUsingClass()
        {
            var acme = new Company();
            acme.Employees.Add(new Employee { Name = "Sam" });
            acme.Employees.Add(new Employee { Name = "Sue", IsExec = true });
            acme.Employees.Add(new Employee { Name = "Wile E", IsExec = true, IsCEO = true });
            acme.Employees.Add(new Employee { Name = "Ron" });
            acme.Employees.Add(new Employee { Name = "Gale" });

            Assert.Multiple(() =>
            {
                Assert.That(acme.Execs, Has.Count.EqualTo(2));       // pass
                Assert.That(acme.Execs, Has.Count.EqualTo(3));       // fail
                Assert.That(acme.Execs, Has.Count.LessThan(5));      // pass
                Assert.That(acme.Execs, Has.Count.GreaterThan(10));  // fail
                Assert.That(acme.CEO.Name, Does.StartWith("R"));     // fail
            });
        }
    }
}
