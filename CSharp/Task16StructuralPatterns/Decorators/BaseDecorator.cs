namespace Task16StructuralPatterns.Decorators;

public abstract class BaseDecorator(IFormatter formatter) : IFormatter
{
    protected IFormatter _formatter = formatter;

    public abstract string Format();
}
