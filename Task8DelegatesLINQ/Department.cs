namespace Task8DelegatesLINQ;

public class Department(string name, List<Employee> employees)
{
    public string Name => name;
    public List<Employee> Employees { get; private set; } = employees;

    public void SalaryChange(Transformer transform)
        => Employees.ToList().ForEach(e => e.Salary = transform(e.Salary));
}

public delegate decimal Transformer(decimal val);