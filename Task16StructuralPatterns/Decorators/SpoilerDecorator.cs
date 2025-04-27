namespace Task16StructuralPatterns.Decorators;

public class SpoilerDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"||{_formatter.Format()}||";
}
