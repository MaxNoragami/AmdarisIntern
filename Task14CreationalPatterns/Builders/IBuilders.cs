namespace Task14CreationalPatterns.Builders;

public interface IBeverageBuilder
{
    public void Reset();
    public IBeverageBuilder SetType(CoffeeType coffeeType);
    public IBeverage Make();
    T GetCapability<T>() where T : class;
}

public interface IBlackCoffeeAble
{
    public IBeverageBuilder AddCoffeeShot();
}

public interface IMilkAble
{
    public IBeverageBuilder AddMilkShot(MilkType milkType);
}

public interface ISugarAble
{
    public IBeverageBuilder AddSugarCube();
}