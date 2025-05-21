namespace Task8DelegatesLINQ;

public class Employee(string name, string surname, string position, decimal salary)
{
    public string Name => name;
    public string Surname => surname;
    public string Position { get; set; } = position;
    public decimal Salary { get; set; } = salary;

    public override string ToString()
        => $"{Name} {Surname} ({Position}) : ${Salary:F2}";
}
