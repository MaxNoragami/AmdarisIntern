using Task15BehavioralPatterns;
using Task15BehavioralPatterns.Subject;
using Task15BehavioralPatterns.Observers;

var customer = new Customer("John Doe", "john.doe.intern@amdaris.com", "+37361234567");
var warehouseStaff = new StaffMember("Johnny Joe", "johhny.joe.warehouse@bookstore.com", Department.Warehouse);
var deliveryStaff = new StaffMember("Bobby Bob", "bobby.bob.delivery@bookstore.com", Department.Delivery);

var books = new List<Book>()
{
    new Book("C# in a nutshell", "Joseph Albahari", 60.99m),
    new Book("Adaptive Code Via C#", "Gary McLean hall", 37.99m),
    new Book("ASP.NET Core in Action", "Andrew Lock", 39.19m)
};

var orderService = new OrderService();


var order = orderService.CreateOrder(customer, books);
order.Register(deliveryStaff);
order.Register(warehouseStaff);

orderService.UpdateOrderStatus(order, OrderStatus.Paid);

orderService.UpdateOrderStatus(order, OrderStatus.Processed);

orderService.UpdateOrderStatus(order, OrderStatus.Shipped);

orderService.UpdateOrderStatus(order, OrderStatus.Delivered);

order.Unregister(deliveryStaff);
order.Unregister(warehouseStaff);