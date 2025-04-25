namespace Task14CreationalPatterns.CoffeeBuilders;

public interface IBeverageBuilder
{
    public void Reset();
    public IBeverage Make();
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