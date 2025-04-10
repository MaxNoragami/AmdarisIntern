using Items;
using OrderSystem;
using MenuSystem;
using System.Collections.ObjectModel;

// Menu instance
var menu = CreateExampleMenu();
menu.DisplayMenu();

Console.WriteLine();

// Order instance
var order = CreateExampleOrder(menu);
order.DisplayOrder();

Console.WriteLine();

// All menu items, usage of IEnumerable
Console.WriteLine("All Menu Items:");
foreach (MenuItem item in menu)
    item.Display(true);
    Console.WriteLine();
                
Console.WriteLine();

// All order items, usage of IEnumerable
Console.WriteLine("All Order Items:");
foreach (var item in order)
    Console.WriteLine("{0}x {1} : {2:F2} MDL", item.Quantity, item.Item.Name, item.Item.Price);


// Helper methods
Menu CreateExampleMenu()
{
    var menu = new Menu("British Cusine");

    var deviledEgg = new Appetizer("Deviled Eggs", new ReadOnlyCollection<string>(new List<string>() { "Eggs", "Mayo", "Mustard", "Pepper" } ), 75m, 4, true, false);
    var vegetablesSoup = new MainCourse("Veggies Soup", new ReadOnlyCollection<string>( new List<string> { "Water", "Potatoes", "Cucumbers", "Bell Pepper" } ), 90m, true, false);
    var pizza = new MainCourse("Pizza", new ReadOnlyCollection<string>( new List<string>() { "Dough", "Cheese", "Tomatoes" } ), 100m, false, false);

    // Cloned 'MainCourse'
    var chickenSoup = (MenuItem)vegetablesSoup.Clone();
    chickenSoup.AddIngredient("Chicken");


    menu.AddItem(vegetablesSoup);
    menu.AddItem(deviledEgg);
    menu.AddItem(chickenSoup);
    menu.AddItem(pizza);

    return menu;
}

Order CreateExampleOrder(Menu menu)
{
    var order = new Order(1234);

    var pizza = (MainCourse)menu.GetItemByName("Pizza");

    // Custom Order
    if(pizza != null)
    {
        var pizzaMario = (MainCourse)pizza.Clone();
        pizzaMario.AddIngredient("Chicken Breast");
        pizzaMario.AddIngredient("Broccoli");
        order.AddItem(pizzaMario, 2, "Extra chicken please :p");

        order.AddItem(pizza);
    }

    return order;
}
