namespace Task16StructuralPatterns;

public class CutDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"~~{_formatter.Format()}~~";
}
