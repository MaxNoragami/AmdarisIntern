using Task16StructuralPatterns.Decorators;

namespace Task16StructuralPatterns;

public class FormattingService()
{
    private readonly List<Func<IFormatter, IFormatter>> _formatters = [];

    public void AddFormattingMethod(Func<IFormatter, IFormatter> formatter)
        => _formatters.Add(formatter);

    public string Format(string text)
    {
        IFormatter formattedText = new ConcreteDecorator(text);
        foreach(var formatter in _formatters)
            formattedText = formatter(formattedText);
        return formattedText.Format();
    }
}
