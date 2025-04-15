namespace Task7Exceptions;

internal class Laptop(int id, string brand, string model, decimal price, int stock, bool inStock) : Entity(id)
{
    public string Brand { get; private set; } = brand;
    public string Model { get; private set; } = model;
    public decimal Price { get; private set; } = price;
    public int StockAmount { get; set; } = stock;
    public bool InStock { get; set; } = inStock;

    public override object Clone() => ((Laptop)base.Clone()).MemberwiseClone();
}

