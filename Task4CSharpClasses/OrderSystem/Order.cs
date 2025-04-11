using Items;
using System.Collections;

namespace OrderSystem;

class Order : IEnumerable<OrderItem>
{
    private readonly List<OrderItem> _items;

    public int OrderId { get; }
    public DateTime OrderTime { get; }
    public decimal TaxRate { get; }

    public Order(int orderId, decimal taxRate = 0.12m)
    {
        OrderId = orderId;
        OrderTime = DateTime.Now;
        TaxRate = taxRate;
        _items = [];
    }

    public void AddItem(MenuItem item, int quantity = 1, string note = "")
    {
        _items.Add(new OrderItem(item, quantity, note));
    }

    public decimal GetSubtotal()
    {
        decimal subtotal = 0;
        foreach(var item in _items) subtotal += item.GetSubtotal();
        return subtotal;
    }

    public decimal GetTax() { return GetSubtotal() * TaxRate; }

    public decimal GetTotal() { return GetSubtotal() + GetTax(); }

    public void DisplayOrder()
    {
        Console.WriteLine("******** ORDER ********");
        Console.WriteLine("Order ID: {0}", OrderId);
        Console.WriteLine("Date & Time: {0}", OrderTime);
        Console.WriteLine();

        Console.WriteLine("Items:");
        foreach(var item in _items)
        {
            Console.WriteLine("{0}x {1} : {2:F2} MDL", item.Quantity, item.GetName(), item.GetPrice());

            if(!string.IsNullOrWhiteSpace(item.Note))
            {
                Console.WriteLine("Note: {0}", item.Note);
            }
        }
        Console.WriteLine();

        Console.WriteLine("Subtotal: {0:F2} MDL", GetSubtotal());
        Console.WriteLine("Tax: {0:F2} MDL", GetTax());
        Console.WriteLine("TOTAL: {0:F2} MDL", GetTotal());
        Console.WriteLine("******** THANK YOU ********");
    }

    public IEnumerator<OrderItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
