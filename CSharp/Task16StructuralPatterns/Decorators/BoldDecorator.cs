namespace Task16StructuralPatterns.Decorators;

public class BoldDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"**{_formatter.Format()}**";
}
