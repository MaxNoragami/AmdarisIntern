using Task15BehavioralPatterns.Subject;

namespace Task15BehavioralPatterns.Observers;

public record StaffMember(string FullName, string EmailAddress, Department Department) : IOrderObserver
{
    public void SubscribeToOrder(Order order)
        => order.Register(this);

    public void UnsubscribeToOrder(Order order)
        => order.Unregister(this);

    public void Update(Order order)
    {
        if(Department == Department.Warehouse && order.Status == OrderStatus.Paid)
            Console.WriteLine("**** Email Sent ****\n" +
            $"To: {EmailAddress}\n" +
            $"Message: Order #{order.Id} needs to to be proccessed.\n");
        else if(Department == Department.Delivery && order.Status == OrderStatus.Processed)
            Console.WriteLine("**** Email Sent ****\n" +
            $"To: {EmailAddress}\n" +
            $"Message: Order #{order.Id} needs to to be shipped.\n");
    }
}
