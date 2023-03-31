using GenericMathSupport.Example2;

namespace TestProject.Example2
{
    public class ReportTests
    {
        ISwearImAnInterestingClass ic;

        [SetUp]
        public void Setup()
        {
            ic = new();
        }

        [Test]
        public void ISwearImAnInterestingClass_ReturnsExpectedValues_ForEmployeeReport()
        {
            var employeeReport = new EmployeeReport { Name = "Bob", HireDate = new DateTime(2010, 1, 1), RequestedTime = DateTime.Now };

            Assert.Multiple(() =>
            {
                Assert.That(ic.GetReportInfo(employeeReport), Does.StartWith($"{EmployeeReport.ReportName} was requested on "));
                Assert.That(ic.GetNewReportId<EmployeeReport>(), Does.StartWith("EmployeeProfile-20"));  // will fail in 2100 :p
            });
        }

        [Test]
        public void ISwearImAnInterestingClass_ReturnsExpectedValues_ForVendorReport()
        {
            var vendorReport = new VendorReport { VendorName = "Acme Inc", VendorContactName = "Mary", RequestedTime = DateTime.Now };

            Assert.Multiple(() =>
            {
                Assert.That(ic.GetVendorReportStatus(vendorReport), Is.EqualTo($"Running '{VendorReport.ReportName}' for: {vendorReport.VendorName}"));
                Assert.That(ic.GetReportInfo(vendorReport), Does.StartWith($"{VendorReport.ReportName} was requested on "));
                Assert.That(Guid.TryParse(ic.GetNewReportId<VendorReport>(), out var _), Is.True);
            });
        }
    }
}