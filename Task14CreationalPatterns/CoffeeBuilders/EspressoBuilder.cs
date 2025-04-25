namespace Task14CreationalPatterns.CoffeeBuilders;

public class EspressoBuilder : IBeverageBuilder, IBlackCoffeeAble
{
    private IBeverage _beverage;

    public EspressoBuilder()
        => Reset();

    public IBeverageBuilder AddCoffeeShot()
    {
        _beverage.Add(new CoffeeShot());
        return this;
    }

    public IBeverage Make()
    {
        var beverage = _beverage;
        Reset();
        return beverage;
    }

    public void Reset()
        => _beverage = new Coffee(CoffeeType.Espresso);
}
