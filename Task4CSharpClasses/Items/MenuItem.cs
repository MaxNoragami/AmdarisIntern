using System.Collections.ObjectModel;
namespace Items;

abstract class MenuItem : ICloneable
{
    private List<string> _ingredientsList;

    public string Name { get; set; }
    public ReadOnlyCollection<string> Ingredients { get; private set; }
    public decimal Price { get; private set; }

    protected MenuItem(string name, ReadOnlyCollection<string> ingredients, decimal price)
    {
        Name = name;
        _ingredientsList = [.. ingredients];
        Ingredients = new ReadOnlyCollection<string>(_ingredientsList);
        Price = price;
    }

    public abstract string GetSpecialRequirements();

    public void AddIngredient(string ingredient)
    {
        if (string.IsNullOrEmpty(ingredient)) 
            throw new ArgumentNullException(nameof(ingredient));

        _ingredientsList.Add(ingredient);
    }

    public void RemoveIngredient(string ingredient)
    {
        if (string.IsNullOrEmpty(ingredient))
            throw new ArgumentNullException(nameof(ingredient));

        _ingredientsList.Remove(ingredient);
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Name} : {Price:F2} MDL");
        Console.WriteLine($"Ingredients: {string.Join(", ", Ingredients)}");
    }

    public virtual void Display(bool showRequirements)
    {
        Display();
        if (showRequirements) Console.WriteLine($"Special Requirements: {GetSpecialRequirements()}");
    }

    public object Clone()
    {
        var clone = (MenuItem)MemberwiseClone();
        clone._ingredientsList = [.. _ingredientsList];
        clone.Ingredients = new ReadOnlyCollection<string>(Ingredients);
        return clone;
    }
}