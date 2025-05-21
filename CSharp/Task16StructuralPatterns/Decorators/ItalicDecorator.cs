namespace Task16StructuralPatterns.Decorators;

public class ItalicDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"*{_formatter.Format()}*";
}
