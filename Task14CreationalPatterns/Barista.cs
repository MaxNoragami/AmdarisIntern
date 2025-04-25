using Task14CreationalPatterns.Builders;

namespace Task14CreationalPatterns;

public class Barista(IBeverageBuilder builder)
{
    private readonly IBeverageBuilder _builder = builder;

    public IBeverage MakeEspresso()
    {
        return _builder.SetType(CoffeeType.Espresso)
                       .AddCoffeeShot()
                       .Make(); 
    }

    public IBeverage MakeCappuccino()
    {
        return _builder.SetType(CoffeeType.Cappuccino)
                       .AddCoffeeShot()
                       .AddMilkShot()
                       .Make();
    }

    public IBeverage MakeFlatWhite()
    {
        return _builder.SetType(CoffeeType.FlatWhite)
                       .AddCoffeeShot()
                       .AddCoffeeShot()
                       .AddMilkShot()
                       .Make();
    }
}
