namespace Task15BehavioralPatterns.Subject;

public partial class Order
{
    public void AddBooks(List<Book> books)
        => _books.AddRange(books);

    public decimal CalculateTotals()
        => _books.Sum(b => b.Price);

    public override string ToString()
    {
        string booksInfo = $"{string.Join("\n\t", _books)}";

        string info = $"Order #{Id}\n" +
                $"\tStatus: {_status}\n" +
                $"\tBooks: {booksInfo}\n";

        return info;
    }
}
