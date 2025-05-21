using Items;

namespace OrderSystem;

class OrderItem (MenuItem item, int quantity, string note)
{
    public string Note => note;
    public int Quantity => quantity;

    public decimal GetPrice() { return item.Price; }
    public string GetName() { return item.Name; }
    public decimal GetSubtotal() { return item.Price * quantity; }
}
