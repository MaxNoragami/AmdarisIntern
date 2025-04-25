namespace Task14CreationalPatterns.CoffeeBuilders;

public class FlatWhiteBuilder : IBeverageBuilder, IBlackCoffeeAble, IMilkAble
{
    private IBeverage _beverage;

    public FlatWhiteBuilder()
        => Reset();

    public IBeverageBuilder AddCoffeeShot()
    {
        _beverage.Add(new CoffeeShot());
        _beverage.Add(new CoffeeShot());
        return this;
    }

    public IBeverageBuilder AddMilkShot(MilkType milkType)
    {
        _beverage.Add(new MilkShot(milkType));
        return this;
    }
    public IBeverage Make()
    {
        var beverage = _beverage;
        Reset();
        return beverage;
    }

    public void Reset()
        => _beverage = new Coffee(CoffeeType.FlatWhite);
}
