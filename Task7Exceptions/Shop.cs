using Task7Exceptions.ExceptionClasses;

namespace Task7Exceptions;

public class Shop(IRepository<Customer> customerRepository, IRepository<Laptop> laptopRepository)
{
    private readonly IRepository<Customer> _customerRepository = customerRepository;
    private readonly IRepository<Laptop> _laptopRepository = laptopRepository;

    public bool PurchaseLaptop(int customerId, int laptopId)
    {
        try
        {
            var customer = _customerRepository.GetById(customerId);
            var laptop = _laptopRepository.GetById(laptopId);

            ValidateIds();

            if (!laptop.InStock)
                throw new OutOfStockException(laptop);

            if (customer.Balance < laptop.Price)
                throw new InsufficientBalanceException(customer, laptop);

            customer.Balance -= laptop.Price;
            laptop.StockAmount -= 1;
            laptop.InStock = laptop.StockAmount != 0;

            _customerRepository.Update(customer);
            _laptopRepository.Update(laptop);

            Console.WriteLine($"The purchase of {laptop.Brand} {laptop.Model} has been completed successfully by {customer.Name} {customer.Surname}.");
            return true;
        }
        catch(DataValidationException<int> ex)
        {
            throw;
        }
        catch (OutOfStockException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        catch(InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public void ShowAllStock()
    {
        Console.WriteLine("All Laptops in stock: ");
        foreach(var laptop in _laptopRepository.FindAll())
            Console.WriteLine($"{laptop.Brand} {laptop.Model} : ${laptop.Price} : {laptop.StockAmount} units");
    }

    public void AddOnShelf(Laptop laptop)
    {
        _laptopRepository.Add(laptop);
        Console.WriteLine($"New latop in stock: {laptop.Brand} {laptop.Model} at only ${laptop.Price}.");
    }

    public void RemoveFromShelf(Laptop laptop)
    {
        _laptopRepository.Delete(laptop);
        Console.WriteLine($"Laptop {laptop.Brand} {laptop.Model} is not for sale anymore.");
    }
    private void ValidateIds(params int[] ids)
    {
        if (ids.Any(i => i <= 0))
            throw new DataValidationException<int>(ids);
    }
}
