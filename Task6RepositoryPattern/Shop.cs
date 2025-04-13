namespace Task6RepositoryPattern;

internal class Shop(IRepository<Customer> customerRepository, IRepository<Laptop> laptopRepository)
{
    IRepository<Customer> _customerRepository = customerRepository;
    IRepository<Laptop> _laptopRepository = laptopRepository;

    public bool PurchaseLaptop(int customerId, int laptopId)
    {
        var customer = _customerRepository.GetById(customerId);
        var laptop = _laptopRepository.GetById(laptopId);

        if(customer == null)
        {
            Console.WriteLine($"Customer {customerId} not found!");
            return false;
        }

        if(laptop == null)
        {
            Console.WriteLine($"Laptop {laptopId} not found!");
            return false;
        }

        if(!laptop.InStock)
        {
            RemoveFromShelf(laptop);
            Console.WriteLine($"There are no more {laptop.Brand} {laptop.Model} in stock.");
            return false;
        }

        if(customer.Balance < laptop.Price)
        {
            Console.WriteLine("You are broke...");
            return false;
        }

        customer.Balance -= laptop.Price;
        laptop.StockAmount -= 1;
        laptop.InStock = laptop.StockAmount != 0;

        _customerRepository.Update(customer);
        _laptopRepository.Update(laptop);

        Console.WriteLine($"The purchase of {laptop.Brand} {laptop.Model} has been completed successfully by {customer.Name} {customer.Surname}.");
        return true;
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
}
