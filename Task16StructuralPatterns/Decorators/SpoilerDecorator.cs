namespace Task16StructuralPatterns;

public class SpoilerDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"||{_formatter.Format()}||";
}
