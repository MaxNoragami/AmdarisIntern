namespace Task14CreationalPatterns;

public interface IIngredient;
public record CoffeeShot : IIngredient;
public record MilkShot(MilkType MilkType) : IIngredient;
public record SugarCube : IIngredient;