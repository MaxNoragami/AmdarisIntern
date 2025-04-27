using Task16StructuralPatterns;
using Task16StructuralPatterns.Decorators;

var text = new ConcreteDecorator("This is some T E X T.");
var boldText = new BoldDecorator(text);
var italicText = new ItalicDecorator(boldText).Format();

Console.WriteLine(italicText);

// Via the service
var formattingService = new FormattingService();

formattingService.AddFormattingMethod(t => new CodeDecorator(t));
formattingService.AddFormattingMethod(t => new ItalicDecorator(t));
formattingService.AddFormattingMethod(t => new CutDecorator(t));

Console.WriteLine(formattingService.Format("var name = \"John Doe\";"));