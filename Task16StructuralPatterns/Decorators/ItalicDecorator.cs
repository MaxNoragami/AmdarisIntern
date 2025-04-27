namespace Task16StructuralPatterns;

public class ItalicDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"*{_formatter.Format()}*";
}
