using GenericMathSupport.Example1;

namespace TestProject.Example1
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
        public void GetVendorReportStatus_ReturnsReportStatus()
        {
            var vendorReport = new VendorReport { VendorName = "Acme Inc", VendorContactName = "Mary" };
            var vdrReportStatus = ic.GetVendorReportStatus(vendorReport);

            Assert.That(vdrReportStatus, Is.EqualTo("Running 'Vendor Summary' for: Acme Inc"));
        }

        [Test]
        public void GetReportStatus_ReturnsReportInfo()
        {
            var employeeReport = new EmployeeReport { Name = "Bob", HireDate = new DateTime(2010, 1, 1) };
            var empReportStatus = ic.GetReportInfo(employeeReport);
            
            var vendorReport = new VendorReport { VendorName = "Acme Inc", VendorContactName = "Mary" };
            var vdrReportStatus = ic.GetReportInfo(vendorReport);

            Assert.Multiple(() =>
            {
                Assert.That(empReportStatus, Is.EqualTo("Employee Profile is a sensitive report."));
                Assert.That(vdrReportStatus, Is.EqualTo("Vendor Summary is not a sensitive report."));
            });
        }
    }
}