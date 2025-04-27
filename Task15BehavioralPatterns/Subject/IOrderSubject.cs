using Task15BehavioralPatterns.Observers;

namespace Task15BehavioralPatterns.Subject;

public interface IOrderSubject
{
    public void NotifyObservers();
    public void Register(IOrderObserver orderObserver);
    public void Unregister(IOrderObserver orderObserver);
}
