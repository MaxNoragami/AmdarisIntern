using Task15BehavioralPatterns.Subject;

namespace Task15BehavioralPatterns.Observers;

public class StaffMember : IOrderObserver
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
