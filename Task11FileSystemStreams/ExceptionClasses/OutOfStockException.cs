using Task11FileSystemStreams.Entities;

namespace Task11FileSystemStreams.ExceptionClasses;

public class OutOfStockException : Exception
{
    public OutOfStockException() : base("Requested item is out of stock.") { }
    public OutOfStockException(string message) : base(message) { }
    public OutOfStockException(Laptop requestedLaptop) : 
        base(
            $"Laptop : {requestedLaptop.Brand} {requestedLaptop.Model} is out of stock, " +
            $"ID : {requestedLaptop.Id}, " +
            $"Available : {requestedLaptop.StockAmount}."
        ) { }
}
