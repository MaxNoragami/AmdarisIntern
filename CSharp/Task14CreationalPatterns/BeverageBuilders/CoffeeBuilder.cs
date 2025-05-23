﻿using Task14CreationalPatterns.Beverages;

namespace Task14CreationalPatterns.BeverageBuilders;

public class CoffeeBuilder : IBeverageBuilder, IBlackCoffeeAble, IMilkAble, ISugarAble
{
    private Coffee _beverage;

    public CoffeeBuilder()
        => _beverage = new Coffee();

    public IBeverageBuilder SetType(CoffeeType coffeeType)
    {
        _beverage.Type = coffeeType;
        return this;
    }
    public IBeverageBuilder AddCoffeeShot()
    {
        _beverage.Add(new CoffeeShot());
        return this;
    }

    public IBeverageBuilder AddMilkShot(MilkType milkType = MilkType.RegularMilk)
    {
        _beverage.Add(new MilkShot(milkType));
        return this;
    }

    public IBeverageBuilder AddSugarCube()
    {
        _beverage.Add(new SugarCube());
        return this;
    }

    public IBeverage Make()
    {
        var beverage = _beverage;
        Reset();
        return beverage;
    }

    public void Reset()
        => _beverage = new Coffee();

    public T? GetCapability<T>() where T : class
        => this as T;
}
