namespace Task14CreationalPatterns;

public class Coffee : IBeverage
{
    private readonly List<IIngredient> _ingredients = [];
    public CoffeeType Type { get; set; }

    public void Add(IIngredient ingredient)
        => _ingredients.Add(ingredient);
    public override string ToString()
    {
        var coffeeShots = _ingredients.Where(i => i is CoffeeShot)?.Count();
        var sugarCubes = _ingredients.Where(i => i is SugarCube)?.Count();
        var milkShots = _ingredients.Where(i => i is MilkShot)
                                    .Cast<MilkShot>()
                                    .GroupBy(m => m.MilkType)
                                    .ToDictionary(m => m.Key, m => m.Count())
                                    .Select(m => $"{m.Key} : {m.Value}");

        string result = $"Coffee Type: {Type}\n" +
                    $"\tCoffee Shots: {coffeeShots}\n" +
                    $"\tMilk Shots: {string.Join(", ", milkShots)}\n" +
                    $"\tSugar Cubes: {sugarCubes}\n";

        return result;
    }
}
