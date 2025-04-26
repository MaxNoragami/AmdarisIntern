using Task14CreationalPatterns.BeverageBuilders;
using Task14CreationalPatterns.Beverages;

var builder = new CoffeeBuilder();
var barista = new Barista(builder);

Console.WriteLine("******* Base Coffee *******\n");
Console.WriteLine(barista.MakeEspresso());
Console.WriteLine(barista.MakeCappuccino(MilkType.OatMilk));
Console.WriteLine(barista.MakeFlatWhite(MilkType.SoyMilk));

Console.WriteLine("\n******* Custom Coffee *******\n");
Console.WriteLine(barista.MakeCustomCoffee(CoffeeType.Cappuccino, 3, MilkType.SoyMilk, 7));

