using Task15BehavioralPatterns.Observers;

namespace Task15BehavioralPatterns.Subject;

public class Order(int orderId) : IOrderSubject
{
    private OrderStatus _status;
    private List<IOrderObserver> orderObservers = new List<IOrderObserver>();

    public int Id => orderId;
    public List<Book> Books { get; private set; } = new List<Book>();
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
        throw new NotImplementedException();
    }

    public void Register(IOrderObserver orderObserver)
        => orderObservers.Add(orderObserver);

    public void Unregister(IOrderObserver orderObserver)
        => orderObservers.Remove(orderObserver);

    // Business Logic

    public void AddBooks(List<Book> books)
        => Books.AddRange(books);
}
