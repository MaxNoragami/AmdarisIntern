using Task7Exceptions;
using Task7Exceptions.ExceptionClasses;

// Init of laptops or customers instances
var hpLaptop = new Laptop(id: 2, brand: "HP", model: "Aero 13", price: 600m, stock: 1, inStock: true);

var laptops = new List<Laptop>() { 
    new Laptop(id: 1, brand: "IBM", model: "Thinkpad x1", price: 1400m, stock: 2, inStock: true),
    hpLaptop,
    new Laptop(id: 3, brand: "Lenovo", model: "Legion 5", price: 800m, stock: 0, inStock: false)
};

var customers = new List<Customer>()
{
    new Customer(id: 1, name: "Maxim", surname: "Alexei", balance: 700m),
    new Customer(id: 2, name: "John", surname: "Doe", balance: 5000m)
};

// Repositories and shopinit
var laptopRepo = new ListRepository<Laptop>(laptops);
var customerRepo = new ListRepository<Customer>(customers);

Console.WriteLine();

using (var logger = new ExceptionLogger("exceptions.log"))
{
    var shop = new Shop(customerRepo, laptopRepo, logger);

    try
    {
        // Show all laptops
        shop.ShowAllStock();
        Console.WriteLine();

        // Try to purchase a Laptop
        shop.PurchaseLaptop(customerId: 1, laptopId: 1);

        // Purchase of an out of stock laptop
        shop.PurchaseLaptop(customerId: 1, laptopId: 3);

        // Purchase of laptops until stock runs out
        shop.PurchaseLaptop(customerId: 2, laptopId: 1);
        shop.PurchaseLaptop(customerId: 2, laptopId: 1);
        shop.PurchaseLaptop(customerId: 2, laptopId: 1);

        shop.ShowAllStock();
        Console.WriteLine();

        // Purchase of a laptop
        shop.PurchaseLaptop(customerId: 1, laptopId: 2);

        shop.ShowAllStock();
        Console.WriteLine();

        // Removing a laptop
        shop.RemoveFromShelf(hpLaptop);

        shop.ShowAllStock();
        Console.WriteLine();

        // Adding a laptop
        shop.AddOnShelf(hpLaptop);

        shop.ShowAllStock();
        Console.WriteLine();
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine(ex.Message, ex.StackTrace, ex.InnerException);
    }
    catch (DataValidationException<int> ex)
    {
        logger.LogException(ex);
    }
    catch (ArgumentNullException ex)
    {
        logger.LogException(ex);
    }
    catch (ArgumentException ex)
    {
        logger.LogException(ex);
    }
    catch (Exception ex)
    {
        logger.LogException(ex);
        Console.WriteLine(ex.Message, ex.StackTrace, ex.InnerException);
    }

    

}
