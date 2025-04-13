using System.Collections.ObjectModel;
using System.Text;
namespace Items;

class MainCourse(string name, 
                List<string> ingredients, 
                decimal price, 
                bool isServedHot, 
                bool isGlutenFree) : MenuItem(name, ingredients, price)
{
    public bool IsServedHot => isServedHot;
    public bool IsGlutenFree => isGlutenFree;

    public override string GetSpecialRequirements()
    {
		var specialRequirements = new StringBuilder();

		specialRequirements.Append((IsServedHot) ? "Served Hot " : "Served Cold ");
		specialRequirements.Append((IsGlutenFree) ? "Gluten Free " : "Has Gluten ");

		return specialRequirements.ToString();
	}
}
