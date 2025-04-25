namespace Task14CreationalPatterns.Builders;

public static class BeverageBuilderExtensions
{
    public static IBeverageBuilder AddCoffeeShot(this IBeverageBuilder builder)
    {
        var coffeeAble = builder.GetCapability<IBlackCoffeeAble>();
        coffeeAble?.AddCoffeeShot();
        return builder;
    }

    public static IBeverageBuilder AddMilkShot(this IBeverageBuilder builder, MilkType milkType = MilkType.RegularMilk)
    {
        var milkAble = builder.GetCapability<IMilkAble>();
        milkAble?.AddMilkShot(milkType);
        return builder;
    }

    public static IBeverageBuilder AddSugarCube(this IBeverageBuilder builder)
    {
        var sugarAble = builder.GetCapability<ISugarAble>();
        sugarAble?.AddSugarCube();
        return builder;
    }
}
