namespace GenericMathSupport.Example3
{
    /******************************
     * ABSTRACT BASE CLASS
     *  w/ INTERFACE
     * ****************************/

    public interface IBaseReport
    {
        string ReportName { get; }
    }

    public abstract class BaseReport : IBaseReport
    {
        public abstract string ReportName { get; }
        public abstract bool Sensitive { get; }
    }

    /******************************
     * EMPLOYEE REPORT CLASS
     *  w/ INTERFACE
     * ****************************/

    public interface IEmployeeReport
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime HireDate { get; set; }
        DateTime? TermDate { get; set; }
    }

    public class EmployeeReport : IEmployeeReport
    {
        public string ReportName => "Employee Profile";
        public bool Sensitive => true;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
    }

    /******************************
     * SALES REPORT CLASS
     *  w/ INTERFACE
     * ****************************/

    public class SalesReport : IBaseReport
    {
        public string ReportName => "Sales Report";
        public bool Sensitive => false;

        public decimal MonthToDateSales { get; set; }
        public decimal YearToDateSales { get; set; }
    }

    /******************************
     * VENDOR REPORT CLASS
     *  w/ INTERFACE
     * ****************************/

    public class VendorReport : BaseReport
    {
        public override string ReportName => "Vendor Summary";
        public override bool Sensitive => false;

        public string VendorName { get; set; }
        public string VendorContactName { get; set; }
        public string VendorContactPhone { get; set; }
    }
}
