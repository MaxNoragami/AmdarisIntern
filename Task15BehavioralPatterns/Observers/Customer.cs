using Task15BehavioralPatterns.Subject;

namespace Task15BehavioralPatterns.Observers;

public record Customer(string FullName, string EmailAddress, string PhoneNumber) : IOrderObserver
{
    public void SubscribeToOrder(Order order)
        => order.Register(this);

    public void UnsubscribeToOrder(Order order)
        => order.Unregister(this);

    public void Update(Order order)
        => Console.WriteLine("**** Email Sent ****\n" +
            $"To: {EmailAddress}\n" +
            $"Message: Your Order #{order.Id} status updated to {order.Status}.\n");
}
