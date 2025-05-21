namespace Task8DelegatesLINQ;

public static class DepartmentExtensions
{
    public static void GetReport(this Department department, Action<string, List<Employee>> reportMethod)
        => reportMethod(department.Name, department.Employees);
}
