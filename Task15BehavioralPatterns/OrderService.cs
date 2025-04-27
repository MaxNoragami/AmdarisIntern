using Task15BehavioralPatterns.Observers;
using Task15BehavioralPatterns.Subject;

namespace Task15BehavioralPatterns;

public class OrderService
{
    private static int _nextOrderId = 0;

    public Order CreateOrder(Customer customer, List<Book> books)
    {
        var order = new Order(_nextOrderId++);

        order.AddBooks(books);
        customer.SubscribeToOrder(order);

        return order;
    }

    public void UpdateOrderStatus(Order order, OrderStatus newStatus)
    {
        Console.WriteLine($"Updating the status of Order : {order.Id}, {order.Status} => {newStatus}.");
        order.Status = newStatus;
    }
}
