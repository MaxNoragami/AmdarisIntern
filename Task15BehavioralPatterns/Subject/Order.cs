using Task15BehavioralPatterns.Observers;

namespace Task15BehavioralPatterns.Subject;

public partial class Order(int orderId) : IOrderSubject
{
    private OrderStatus _status;
    private List<IOrderObserver> _orderObservers = new List<IOrderObserver>();
    private readonly List<Book> _books = new List<Book>();

    public int Id => orderId;
    public OrderStatus Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                NotifyObservers();
            }
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in _orderObservers)
            observer.Update(this);
    }

    public void Register(IOrderObserver orderObserver)
        => _orderObservers.Add(orderObserver);

    public void Unregister(IOrderObserver orderObserver)
        => _orderObservers.Remove(orderObserver);
}
