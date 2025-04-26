using Task14CreationalPatterns.Beverages;

namespace Task14CreationalPatterns.BeverageBuilders;

public class Barista(IBeverageBuilder builder)
{
    private readonly IBeverageBuilder _builder = builder;


    private IBeverageBuilder PrepEspresso()
        => _builder.SetType(CoffeeType.Espresso)
                       .AddCoffeeShot();

    private IBeverageBuilder PrepCappuccino(MilkType milkType)
        => _builder.SetType(CoffeeType.Cappuccino)
                       .AddCoffeeShot()
                       .AddMilkShot(milkType);


    private IBeverageBuilder PrepFlatWhite(MilkType milkType)
        => _builder.SetType(CoffeeType.FlatWhite)
                       .AddCoffeeShot()
                       .AddCoffeeShot()
                       .AddMilkShot(milkType);

    public IBeverage MakeEspresso()
        => PrepEspresso().Make();

    public IBeverage MakeCappuccino(MilkType milkType = MilkType.RegularMilk)
        => PrepCappuccino(milkType).Make();

    public IBeverage MakeFlatWhite(MilkType milkType = MilkType.RegularMilk)
        => PrepFlatWhite(milkType).Make();

    public IBeverage MakeCustomCoffee(CoffeeType baseType,
                                      int extraMilkShots = 0,
                                      MilkType milkType = MilkType.RegularMilk,
                                      int sugarCubes = 0)
    {
        IBeverageBuilder beverageBuilder = baseType switch
        {
            CoffeeType.Espresso => PrepEspresso(),
            CoffeeType.Cappuccino => PrepCappuccino(milkType),
            CoffeeType.FlatWhite => PrepFlatWhite(milkType),
            _ => throw new NotImplementedException()
        };

        for (int i = 0; i < extraMilkShots; i++)
            beverageBuilder.AddMilkShot(milkType);

        for (int i = 0; i < sugarCubes; i++)
            beverageBuilder.AddSugarCube();

        return beverageBuilder.Make();
    }
}
