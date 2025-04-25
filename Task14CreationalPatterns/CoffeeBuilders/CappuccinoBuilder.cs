namespace Task14CreationalPatterns.CoffeeBuilders;

public class CappuccinoBuilder : IBeverageBuilder, IBlackCoffeeAble, IMilkAble
{
    private IBeverage _beverage;

    public CappuccinoBuilder()
        => Reset();

    public IBeverageBuilder AddCoffeeShot()
    {
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
        => _beverage = new Coffee(CoffeeType.Cappuccino);
}
