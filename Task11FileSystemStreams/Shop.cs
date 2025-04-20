using Task11FileSystemStreams;
using Task11FileSystemStreams.Entities;
using Task11FileSystemStreams.Repositories;
using Task7Exceptions.ExceptionClasses;

namespace Task7Exceptions;

public class Shop(IRepository<Customer> customerRepository, 
                                        IRepository<Laptop> laptopRepository)
{
    private readonly IRepository<Customer> _customerRepository = customerRepository;
    private readonly IRepository<Laptop> _laptopRepository = laptopRepository;

    public event EventHandler<BusinessOperationEventArgs>? BusinessOperation;

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

            var successMsg = $"The purchase of {laptop.Brand} {laptop.Model} has been completed successfully by {customer.Name} {customer.Surname}.";

            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(PurchaseLaptop),
                                                                   success: true,
                                                                   message: successMsg,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(customerId)] = customerId,
                                                                       [nameof(laptopId)] = laptopId
                                                                   })
            );

            return true;
        }
        catch(ArgumentException ex) when (ex.ParamName == "logFilePath")
        {
            throw new FileNotFoundException("The log file path is incorrect.", innerException: ex);
        }
        catch(DataValidationException<int>)
        {
            throw;
        }
        catch (OutOfStockException ex)
        {
            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(PurchaseLaptop),
                                                                   success: false,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(customerId)] = customerId,
                                                                       [nameof(laptopId)] = laptopId
                                                                   },
                                                                   exception: ex)
            );
            return false;
        }
        catch(InsufficientBalanceException ex)
        {
            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(PurchaseLaptop),
                                                                   success: false,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(customerId)] = customerId,
                                                                       [nameof(laptopId)] = laptopId
                                                                   },
                                                                   exception: ex)
            );
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
            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(PurchaseLaptop),
                                                                   success: false,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(customerId)] = customerId,
                                                                       [nameof(laptopId)] = laptopId
                                                                   },
                                                                   exception: ex)
            );
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
            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(ShowAllStock),
                                                                   success: false,
                                                                   exception: ex)
            );
        }
        
    }

    public void AddOnShelf(Laptop laptop)
    {
        try
        {
            _laptopRepository.Add(laptop);
            var successMsg = $"New latop in stock: {laptop.Brand} {laptop.Model} at only ${laptop.Price}.";

            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(AddOnShelf),
                                                                   success: true,
                                                                   message: successMsg,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(laptop)] = laptop.ToString()!
                                                                   })
            );
        }
        catch (DuplicateIdException ex)
        {
            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(AddOnShelf),
                                                                   success: false,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(laptop)] = laptop.ToString()!,
                                                                   },
                                                                   exception: ex)
            );
        }
    }

    public void RemoveFromShelf(Laptop laptop)
    {
        try 
        {
            _laptopRepository.Delete(laptop);
            var successMsg = $"Laptop {laptop.Brand} {laptop.Model} is not for sale anymore.";

            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(RemoveFromShelf),
                                                                   success: true,
                                                                   message: successMsg,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(laptop)] = laptop.ToString()!
                                                                   })
            );
        }
        catch (ArgumentException ex)
        {
            BusinessOperation?.Invoke(this, new BusinessOperationEventArgs(methodName: nameof(RemoveFromShelf),
                                                                   success: false,
                                                                   parameters: new Dictionary<string, object>
                                                                   {
                                                                       [nameof(laptop)] = laptop.ToString()!
                                                                   },
                                                                   exception: ex)
            );
        }      
    }

    static private void ValidateIds(params int[] ids)
    {
        if (ids.Any(i => i <= 0))
            throw new DataValidationException<int>(ids);
    }
}
