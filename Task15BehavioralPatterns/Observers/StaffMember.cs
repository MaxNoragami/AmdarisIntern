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
        throw new NotImplementedException();
    }
}
