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
            Console.WriteLine($"Customer {customer.Id} not found!");
            return false;
        }

        if(laptop == null)
        {
            Console.WriteLine($"Laptop {laptop.Id} not found!");
            return false;
        }

        if(!laptop.InStock)
        {
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

}
