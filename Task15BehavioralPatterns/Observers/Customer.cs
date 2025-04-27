using Task15BehavioralPatterns.Subject;

namespace Task15BehavioralPatterns.Observers;

public class Customer : IOrderObserver
{
    public void SubscribeToOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public void UnsubscribeToOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public void Update(Order order)
    {
        throw new NotImplementedException();
    }
}
