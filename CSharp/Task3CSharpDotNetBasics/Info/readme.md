# C# and .NET Basics
## Requirements

Requirements for my assignment on the Git and Version Control Lesson
- [x] Create a C# program which uses classes to model real world objects
- [x] Use methods and fields to encapsulate class implementation
- [x] Use properties to make some properties accessible or replace trivial methods (getters/setters)
- [x] Create a class hierarchy to model real world Hierarchies (Animals in zoo, Shapes in drawing system, etc)
- [x] Create a method and make its overloaded and overridden versions
- [x] Read C# code conventions https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
- [x] **Bonus** 
	- [x] Implement .NET IEnumerable interface
	- [x] Implement .NET ICloneable interface

## Solution

- In order to satisfy the ***Real-world object modeling*** requirement, I have decided to create a simple *restaurant ordering system* with menus, menu items, and an ordering system.

- While, creating the classes I have aimed for a proper ***encapsulation*** of the internal state of the instances, via ***getters and setters***, while also being mindful regarding the use of the right ***C# code conventions***.

- Moreover, as for ***class hierarchy***, I have implemented a base abstract class `MenuItem`, that gets inherited and its abstract and virtual methods ***overridden*** within classes, such as `MainCourse` or `Appetizer`.

- At the same time, I made sure not to forget about the *static polymorphism* implementation as well, as I have ***overloaded*** the `Display()` method within the `MenuItem` class, for either a simple or detailed print of the details regarding an dish.

- Last but not least, I have also decided to adventure a little with something that I hadn't been that knowledgeable of prior to doing this assignment, those topic being the **IEnumerable** and ***ICloneable*** interfaces. Those have been mainly used to create clones of existing dishes from the `Menu`, if we talk about the `ICloneable`, and as for the `IEnumerable`, it has mainly been used to allow iteration through the items of the `Menu` or `Order` classes.

#### Classes Explanation
##### `MenuItem`

This has been mainly used as an abstract base class representing any item that can be ordered from a menu. Therefore, it can store basic information like name, price, and ingredients. Moreover, it implements the `ICloneable` interface, to allow creating custom variants of `MenuItems`.  Last but not least, it also provides abstract methods that derived classes must implement to specify special requirements.

##### Specialized classes `Appetizer` & `MainCourse`

Used to represent the starters or appetizers within a restaurant, so it extends `MenuItem` with specific properties like *number of servings*, whether it's *shareable*, and if it's *seasonal*. Also, it implements its own version of special requirements display.

As for `MainCourse`, it is basically a menu item representing the main dishes that are served to the customers. As `Appetizer`, it also extends `MenuItem` with properties indicating if the dish is *served hot* and if it's *gluten-free*.

##### `Menu`

With the help of the *IEnumerable* interface, which also allows for easy iteration, I managed to make `Menu` represent a collection of `MenuItems`. Besides, I have also made it provide methods to add items and search for items by name, while also including a display functionality to show the entire `Menu` to customers.

##### `OrderItem`

This is basically used to represent a specific `MenuItem` that has been ordered, with additional information like *quantity* and special *notes* from the customer. While, it also provides a method to calculate the subtotal for this specific item.

##### `Order`

As `Menu` represents a collection of `MenuItems`, `Order` represents a complete customer order, containing multiple `OrderItems`. As it implements `IEnumerable`, it allows iteration through items. Moreover, it provides methods to calculate *subtotal*, *tax*, and *total* price, while it also includes methods to display the full order with all items and totals.

##### Program

Last but not least, the main entry point for the application that demonstrates the functionality of the system is written within this class. I have mainly used it to creates sample menus and orders, as I needed to show how to clone and customize menu items, and demonstrate the use of *IEnumerable* to iterate through collections.