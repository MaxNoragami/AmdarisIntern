namespace Task16StructuralPatterns.Decorators;

public class ConcreteDecorator(string baseText) : IFormatter
{
    private string _baseText = baseText;
    public string Format()
        => $"{_baseText}";
}
