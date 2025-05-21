using System.Text.RegularExpressions;
using Task8DelegatesLINQ;

// Some lambda expressions and anonymous methods used later on for reporting
var consoleReport = (string departmentName, List<Employee> employees)
    => Console.WriteLine($"{departmentName}:\n\t{string.Join("\n\t", employees)}");

var fileReport = delegate (string departmentName, List<Employee> employees)
{
    string filePath = "report.txt";
    if (!File.Exists(filePath))
        File.Create(filePath);

    using (var reportWriter = new StreamWriter(File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read)))
    {
        reportWriter.WriteLine($"{departmentName}:");
        reportWriter.WriteLine($"\t{string.Join("\n\t", employees)}");
        reportWriter.Flush();
        reportWriter.Close();
    }
};

// Collection of 'Department' with a list of 'Employee' each
var departments = new List<Department>()
{
    new Department("Development", new List<Employee>()
        {
            new Employee("John", "Doe", "Team Lead", 32000) {},
            new Employee("Sony", "Ko", "Developer", 24000) {},
            new Employee("Tim", "Cook", "QA Engineer", 19900) {},
            new Employee("Ben", "Smith", "Web Developer", 22080) {},
        }
    ),
    new Department("Business", new List<Employee>()
        {
            new Employee("Freddy", "Krug", "Business Analyst", 27128) {},
            new Employee("Jim", "Chuck", "HR", 18233) {},
            new Employee("Jim", "Book", "Marketing Manager", 19322) {},
            new Employee("Zin", "Crook", "Marketing Manager", 17222) {},
            new Employee("John", "Pork", "Business Analyst", 22000) {},
        }
    ),
};

// List of employees within 'Development' departement 
departments[0].GetReport(consoleReport + fileReport);

// Via the usage of Lambda Expressions
Transformer bonus = s => s + s * 0.05m;

// Via the usage of Anonymous Methods
Func<decimal, decimal> taxes = delegate (decimal val)
    { return val - val * 0.12m; };

// Usage of Multicast delegates, Bonus to Salary + Subtract the Taxes
departments[0].SalaryChange(bonus + new Transformer(taxes));

// List of employees after change
departments[0].GetReport(consoleReport + fileReport);


// Deferred Exec
var pplSmallEarnings = departments.SelectMany(d => d.Employees.Where(e => e.Salary < 20000m)
                                                              .OrderBy(e => e.Name)
                                                              .ThenBy(e => e.Surname)
                                                              .Select(e => e.Name + ' ' + e.Surname));

pplSmallEarnings = pplSmallEarnings.SkipWhile(e => !Regex.IsMatch(e, @"[A-Za-z]+im [A-Za-z]+"));

departments[0].Employees.Add(new Employee("Bim", "Joe", "Mobile Developer", 18033));

// Evaluation of the query takes place here
Console.WriteLine(string.Join(", ", pplSmallEarnings));