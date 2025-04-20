using Task7Exceptions;

namespace Task11FileSystemStreams.Entities;

public class Customer(int id, string name, string surname, decimal balance) : Entity(id) 
{
    public string Name { get; private set; } = name;
    public string Surname { get; private set; } = surname;
    public decimal Balance { get; set; } = balance;

    public override object Clone() => ((Customer)base.Clone()).MemberwiseClone();
}

