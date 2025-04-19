using Task9AdvancedLINQ.Entities;

var farm = new List<Animal>()
{
    // Poultry
    new Animal(1, AnimalCategory.Poultry, "Chicken", 2, 2.5),
    new Animal(2, AnimalCategory.Poultry, "Turkey", 2, 12.4),
    new Animal(3, AnimalCategory.Poultry, "Duck", 2, 3.2),
    new Animal(4, AnimalCategory.Poultry, "Goose", 2, 10.1),

    // Canine
    new Animal(5, AnimalCategory.Canine, "Cocker Spaniel", 4, 35.5),
    new Animal(6, AnimalCategory.Canine, "German Shepherd", 4, 38.1),

    // Feline
    new Animal(7, AnimalCategory.Feline, "Orange Cat", 4, 4.3),

    // Bovine
    new Animal(8, AnimalCategory.Bovine, "Brown Cow", 4, 725.5),
    new Animal(9, AnimalCategory.Bovine, "Bull", 4, 950.2),
    new Animal(10, AnimalCategory.Bovine, "Black & White Cow", 4, 870.1),

    // Caprine
    new Animal(11, AnimalCategory.Caprine, "Irish Goat", 4, 70.5),
    new Animal(12, AnimalCategory.Caprine, "Alpine Goat", 4, 65.3),
    new Animal(13, AnimalCategory.Caprine, "Goat", 4, 90.2),
    new Animal(14, AnimalCategory.Caprine, "Dwarf Goat", 4, 35.7),

    // Ovine
    new Animal(15, AnimalCategory.Ovine, "Welsh Sheep", 4, 85.5),
    new Animal(16, AnimalCategory.Ovine, "Bighorn Sheep", 4, 110.3),
    new Animal(17, AnimalCategory.Ovine, "Sheep", 4, 80.1),

    // Equine
    new Animal(18, AnimalCategory.Equine, "Horse", 4, 900.3),
    new Animal(19, AnimalCategory.Equine, "Donkey", 4, 350.1),
    new Animal(20, AnimalCategory.Equine, "Mule", 4, 410.7),

    // Porcine
    new Animal(21, AnimalCategory.Porcine, "Pig", 4, 270.5),
    new Animal(22, AnimalCategory.Porcine, "Boar", 4, 290.3),

    // Leporine
    new Animal(23, AnimalCategory.Leporine, "Wild Rabbit", 4, 4.5),
    new Animal(24, AnimalCategory.Leporine, "White Rabbit", 4, 4.2),
};

var orders = new List<Order>()
{
    new Order(1, 3, 200.5m),
    new Order(2, 1, 150.75m),
    new Order(3, 2, 320.25m),
    new Order(4, 4, 275.50m),
    new Order(5, 7, 180.0m),
    new Order(6, 23, 95.25m),
    new Order(7, 24, 89.99m),
    new Order(8, 5, 450.0m),
    new Order(9, 1, 125.75m),
    new Order(10, 3, 185.50m),
};


var farm1 = farm.Take(farm.Count / 2).ToList();
var farm2 = farm.Skip(farm.Count / 2).ToList();

farm2.AddRange(new List<Animal>()
        {
            new Animal(25, AnimalCategory.Poultry, "Chicken", 2, 2.5),
            new Animal(26, AnimalCategory.Poultry, "Turkey", 2, 12.4),
            new Animal(27, AnimalCategory.Poultry, "Duck", 2, 3.2),
            new Animal(28, AnimalCategory.Poultry, "Goose", 2, 10.1)
        });

// Sequence In -> Sequence Out

// Joins
var farm1Orders = farm1.Join(orders,
            animal => animal.Id,
            order => order.AnimalId,
            (animal, order) => $"{nameof(farm1)} sold a {animal.Name} at ${order.PaidAmount:F2}");

Console.WriteLine($"Orders from farm1:\n{string.Join('\n', farm1Orders)}\n");

var newPrices = farm2.Where(a => orders.Any(o => o.AnimalId == a.Id))
                     .Zip(orders, (a, o) => a.Name + " $" + o.PaidAmount);
Console.WriteLine($"New prices on some animals from farm2:\n{string.Join('\n', newPrices)}\n");

// Grouping
var animalGroups = farm.GroupBy(a => a.Category);

Console.WriteLine("Animals in 'farm' by animal category:");
animalGroups.ToList().ForEach(category => 
    Console.WriteLine($"* {category.Key}:\n\t{string.Join("\n\t", category)}\n"));

// Set
var bothFarms = farm1.Concat(farm2);
var additionToFarm2 = bothFarms.Except(farm).ToList();
Console.WriteLine($"Animals added to farm2:\n\t{string.Join("\n\t", additionToFarm2)}\n");

// Sequence In -> scalar / bool / TSource

// Aggregation
Console.WriteLine($"Total earnings after VAT: ${orders.Aggregate(0m, (total, n) => total + n.PaidAmount * 0.8m):F2}\n");

// Quantifiers
Console.WriteLine($"Is the union of 'farm1' and 'farm2' w/o additions the same as 'farm'? " +
    $"{farm.SequenceEqual(farm1.Union(farm2.Except(additionToFarm2)))}.\n");

// Nothing In -> Sequence Out
farm = farm.OrderBy(a => a.Id).ToList();
foreach (var i in Enumerable.Range(0, additionToFarm2.Count))
    farm.RemoveAt(i);
Console.WriteLine($"After the removal of first '{additionToFarm2.Count} animals from farm:\n\t{string.Join("\n\t", farm)}'");