using Task11FileSystemStreams.Entities;

namespace Task7Exceptions.ExceptionClasses;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException() : base("Customer has insufficient balance for this purchase.") { }
    public InsufficientBalanceException(string message) : base(message) { }
    public InsufficientBalanceException(Customer customer,  Laptop requestedLaptop) :
        base(
            $"Customer : {customer.Name} {customer.Surname} has insufficient balance, " +
            $"Customer ID : {customer.Id}, " +
            $"Available : {customer.Balance}, " +
            $"Deficit : {requestedLaptop.Price - customer.Balance}."
        )
    { }
}
