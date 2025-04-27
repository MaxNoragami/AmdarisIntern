using System.Xml.Serialization;
using Task15BehavioralPatterns.Subject;

namespace Task15BehavioralPatterns.Observers;

public interface IOrderObserver
{
    public void Update(Order order);
    public void SubscribeToOrder(Order order);
    public void UnsubscribeToOrder(Order order);
}
