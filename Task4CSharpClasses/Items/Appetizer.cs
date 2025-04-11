using System.Collections.ObjectModel;
using System.Text;
namespace Items;

class Appetizer(string name, 
                ReadOnlyCollection<string> ingredients, 
                decimal price, int servings, 
                bool isShareable, 
                bool isSeasonal) : MenuItem(name, ingredients, price) 
{
    public int Servings => servings;
    public bool IsShareable => isShareable;
    public bool IsSeasonal => isSeasonal;

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
