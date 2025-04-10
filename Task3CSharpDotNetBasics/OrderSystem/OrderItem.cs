using Items;

namespace OrderSystem;

class OrderItem
{
    public MenuItem Item { get; }
    public string Note { get; }
    public int Quantity { get; }

    public OrderItem(MenuItem item, int quantity, string note)
    {
        Item = item;
        Quantity = quantity;
        Note = note;
    }

    public decimal GetSubtotal() { return Item.Price * Quantity; }
}
