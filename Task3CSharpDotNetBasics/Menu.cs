using Items;
using System.Collections;

namespace MenuSystem
{
    class Menu : IEnumerable<MenuItem>
    {
        private string _name = string.Empty;
        private readonly List<MenuItem> _items;

        public string Name 
        { 
            get { return _name; }
            private set { _name = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public Menu(string name)
        {
            Name = name;
            _items = new List<MenuItem>();
        }

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        public MenuItem GetItemByName(string name)
        {
            return _items.Find(i => i.Name.ToLower() == name.ToLower()) ?? throw new ArgumentNullException(nameof(name));
        }

        public void DisplayMenu()
        {
            Console.WriteLine("******** {0} ********", Name);
            
            if(_items.Count == 0)
            {
                Console.WriteLine("No items in the menu, yet.");
                return;
            }

            foreach(var item in _items)
            {
                item.Display();
                Console.WriteLine();
            }

            Console.WriteLine("******** ******** ********");
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator<MenuItem> IEnumerable<MenuItem>.GetEnumerator()
        {
            return (IEnumerator<MenuItem>)GetEnumerator();
        }
    }
}