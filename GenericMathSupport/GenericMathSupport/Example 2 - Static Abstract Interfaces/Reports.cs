namespace GenericMathSupport.Example2
{
    /***********************************
     * BASE REPORT INTERFACE WITH
     * STATIC ABSTRACT MEMBERS
     * *********************************/

    public interface IBaseReport
    {
        static abstract string ReportName { get; }
        static abstract bool IsSensitive { get; }
        static abstract string GenerateUniqueId();
        DateTime RequestedTime { get; set; }
    }

    /***********************************
     * EMPLOYEE REPORT w/ INTERFACE
     * AND IMPLEMENTING STATIC MEMBERS
     * *********************************/

    public interface IEmployeeReport : IBaseReport
    {
        string Name { get; set; }
        DateTime HireDate { get; set; }
        DateTime? TermDate { get; set; }
    }

    public class EmployeeReport : IEmployeeReport
    {
        public static string ReportName => "Employee Profile";
        public static bool IsSensitive => true;
        public DateTime RequestedTime { get; set; }
        public static string GenerateUniqueId() =>
            $"{ReportName.Replace(" ","")}-{DateTime.Now:yyyy-MM-dd-hh-mm-ss:ffffff}";

        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
    }

    /***********************************
     * VENDOR REPORT CLASS w/ INTERFACE
     * AND IMPLEMENTING STATIC MEMBERS
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
        public static bool IsSensitive => false;
        public DateTime RequestedTime { get; set; }
        public static string GenerateUniqueId() => $"{Guid.NewGuid()}";

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
            return $"Running '{VendorReport.ReportName}' for: {rpt.VendorName}";
        }

        public string GetReportInfo<T>(T rpt) where T : IBaseReport
        {
            return $"{T.ReportName} was requested on {rpt.RequestedTime:d}.";
        }

        public string GetNewReportId<T>() where T : IBaseReport
            => T.GenerateUniqueId();
    }
}
