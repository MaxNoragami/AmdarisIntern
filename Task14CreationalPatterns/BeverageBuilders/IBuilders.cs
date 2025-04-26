using Task14CreationalPatterns.Beverages;

namespace Task14CreationalPatterns.BeverageBuilders;

public interface IBeverageBuilder
{
    public void Reset();
    public IBeverageBuilder SetType(CoffeeType coffeeType);
    public IBeverage Make();
    T? GetCapability<T>() where T : class;
}

public interface IBlackCoffeeAble
{
    public IBeverageBuilder AddCoffeeShot();
}

public interface IMilkAble
{
    public IBeverageBuilder AddMilkShot(MilkType milkType = MilkType.RegularMilk);
}

public interface ISugarAble
{
    public IBeverageBuilder AddSugarCube();
}