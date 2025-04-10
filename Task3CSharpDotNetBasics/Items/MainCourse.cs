
using System.Collections.ObjectModel;
using System.Text;
namespace Items;

class MainCourse : MenuItem
{
    public bool IsServedHot { get; set; }
	public bool IsGlutenFree { get; set; }

	public MainCourse(string name, ReadOnlyCollection<string> ingredients, decimal price, bool isServedHot, bool isGlutenFree) 
        : base(name, ingredients, price)
    {
        IsServedHot = isServedHot;
        IsGlutenFree = isGlutenFree;
    }

    public override string GetSpecialRequirements()
    {
		var specialRequirements = new StringBuilder();

		specialRequirements.Append((IsServedHot) ? "Served Hot " : "Served Cold ");
		specialRequirements.Append((IsGlutenFree) ? "Gluten Free " : "Has Gluten ");

		return specialRequirements.ToString();
	}
}
