namespace GenericMathSupport.Example1
{
    /***********************************
     * BASE REPORT INTERFACE
     * *********************************/

    public interface IBaseReport
    {
        static string ReportName { get; }
        bool IsSensitive { get; }
    }

    /***********************************
     * EMPLOYEE REPORT w/ INTERFACE
     * *********************************/

    public interface IEmployeeReport : IBaseReport
    {
        string Name { get; set; }
        DateTime HireDate { get; set; }
        DateTime? TermDate { get; set; }
    }

    public class EmployeeReport : IEmployeeReport
    {
        public string ReportName => "Employee Profile";
        public bool IsSensitive => true;

        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
    }

    /***********************************
     * VENDOR REPORT CLASS w/ INTERFACE
     * *********************************/

    public interface IVendorReport : IBaseReport
    {
        string VendorName { get; set; }
        string VendorContactName { get; set; }
        string VendorContactPhone { get; set; }
    }

    public class VendorReport : IVendorReport
    {
        public static string ReportName => "Vendor Summary";
        public bool IsSensitive => false;

        public string VendorName { get; set; }
        public string VendorContactName { get; set; }
        public string VendorContactPhone { get; set; }
    }

    /***********************************
     * A CLASS THAT PROCESSES REPORTS
     * *********************************/

    public class ISwearImAnInterestingClass
    {
        public string GetVendorReportStatus(IVendorReport rpt)
        {
            return $"Running '{rpt.ReportName}' for: {rpt.VendorName}";
        }

        public string GetReportInfo(IBaseReport rpt)
        {
            return $"{rpt.ReportName} {(rpt.IsSensitive ? "is" : "is not")} a sensitive report.";
        }
    }
}
