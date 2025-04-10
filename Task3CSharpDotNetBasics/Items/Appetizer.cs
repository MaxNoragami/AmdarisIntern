
using System.Collections.ObjectModel;
using System.Text;
namespace Items;

class Appetizer : MenuItem
{
    public int Servings { get; set; }
    public bool IsShareable { get; set; }
    public bool IsSeasonal { get; set; }


    public Appetizer(string name, ReadOnlyCollection<string> ingredients, decimal price, int servings, bool isShareable, bool isSeasonal) 
        : base(name, ingredients, price)
    {
        Servings = servings;
        IsShareable = isShareable;
        IsSeasonal = isSeasonal;
    }

    public override string GetSpecialRequirements()
    {
        var specialRequirements = new StringBuilder();

        specialRequirements.Append((IsShareable)? "Shareable ": "Not Shareable ");
        specialRequirements.Append((IsSeasonal) ? "Seasonal " : "Not Seasonal ");
            
        return specialRequirements.ToString();
    }

    public override void Display()
    {
        base.Display();
		Console.WriteLine("Servings: {0}", Servings);
	}
}
