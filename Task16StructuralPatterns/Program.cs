using System.Runtime.Serialization;
using Task16StructuralPatterns;

var text = new ConcreteDecorator("This is some T E X T.");
var boldText = new BoldDecorator(text);
var italicText = new ItalicDecorator(boldText).Format();

Console.WriteLine(italicText);
