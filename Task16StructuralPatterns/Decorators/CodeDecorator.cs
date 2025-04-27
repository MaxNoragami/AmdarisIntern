namespace Task16StructuralPatterns;

public class CodeDecorator(IFormatter formatter) : BaseDecorator(formatter)
{
    public override string Format()
        => $"```{_formatter.Format()}```";
}
