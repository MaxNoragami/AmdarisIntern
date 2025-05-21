using Task7Exceptions.ExceptionClasses;

namespace Task7Exceptions;

public class Shop(IRepository<Customer> customerRepository, 
                                        IRepository<Laptop> laptopRepository, 
                                        ExceptionLogger exceptionLogger)
{
    private readonly IRepository<Customer> _customerRepository = customerRepository;
    private readonly IRepository<Laptop> _laptopRepository = laptopRepository;
    private readonly ExceptionLogger _exceptionLogger = exceptionLogger;

    public bool PurchaseLaptop(int customerId, int laptopId)
    {
        try
        {
            var customer = _customerRepository.GetById(customerId);
            var laptop = _laptopRepository.GetById(laptopId);

            ValidateIds(customerId, laptopId);

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
        catch(ArgumentException ex) when (ex.ParamName == "logFilePath")
        {
            throw new FileNotFoundException("The log file path is incorrect.", innerException: ex);
        }
        catch(DataValidationException<int> ex)
        {
            _exceptionLogger.LogException(ex);
            throw;
        }
        catch (OutOfStockException ex)
        {
            _exceptionLogger.LogException(ex);
            return false;
        }
        catch(InsufficientBalanceException ex)
        {
            _exceptionLogger.LogException(ex);
            return false;
        }
        catch (ArgumentNullException)
        {
            throw;
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _exceptionLogger.LogException(ex);
            return false;
        }
    }

    public void ShowAllStock()
    {
        try
        {
            Console.WriteLine("All Laptops in stock: ");
            foreach(var laptop in _laptopRepository.FindAll())
                Console.WriteLine($"{laptop.Brand} {laptop.Model} : ${laptop.Price} : {laptop.StockAmount} units");
        }
        catch (ArgumentException ex)
        {
            _exceptionLogger.LogException(ex);
        }
        
    }

    public void AddOnShelf(Laptop laptop)
    {
        try
        {
            _laptopRepository.Add(laptop);
            Console.WriteLine($"New latop in stock: {laptop.Brand} {laptop.Model} at only ${laptop.Price}.");
        }
        catch (DuplicateIdException ex)
        {
            _exceptionLogger.LogException(ex);
        }
    }

    public void RemoveFromShelf(Laptop laptop)
    {
        try 
        {
            _laptopRepository.Delete(laptop);
            Console.WriteLine($"Laptop {laptop.Brand} {laptop.Model} is not for sale anymore.");
        }
        catch (ArgumentException ex)
        {
            _exceptionLogger.LogException(ex);
        }
        
    }
    static private void ValidateIds(params int[] ids)
    {
        if (ids.Any(i => i <= 0))
            throw new DataValidationException<int>(ids);
    }
}
