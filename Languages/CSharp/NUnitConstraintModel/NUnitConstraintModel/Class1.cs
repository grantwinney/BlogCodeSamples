namespace NUnitConstraintModel
{
    public class Employee
    {
        public string Name { get; set; }
        public bool IsExec { get; set; }
        public bool IsCEO { get; set; }
    }

    public class Company
    {
        public List<Employee> Employees { get; } = new List<Employee>();

        public List<Employee> Execs => Employees.Where(x => x.IsExec).ToList();

        public Employee CEO => Employees.Single(x => x.IsCEO);
    }
}