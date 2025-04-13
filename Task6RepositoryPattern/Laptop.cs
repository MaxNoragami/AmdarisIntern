namespace Task6RepositoryPattern;

internal class Laptop(int id, string brand, string model, decimal price, bool inStock) : Entity(id)
{
    public string Brand { get; private set; } = brand;
    public string Model { get; private set; } = model;
    public decimal Price { get; private set; } = price;
    public bool InStock { get; private set; } = inStock;
}

