namespace Items
{
    abstract class MenuItem : ICloneable
    {
        private string _name = string.Empty;
        private List<string> _ingredients = [];
        private decimal _price;

        public string Name
        {
            get { return _name; }
            set { _name = value ?? throw new ArgumentNullException(nameof(value)); }
        }
        public List<string> Ingredients
        {
            get { return [.. _ingredients]; }
            private set { _ingredients = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public decimal Price 
        { 
            get { return _price; }
            set { _price = (value > 0) ? value : throw new ArgumentException("Positive price only"); }
        }

        protected MenuItem(string name, List<string> ingredients, decimal price)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }

        public abstract string GetSpecialRequirements();

        public void AddIngredient(string ingredient)
        {
            if (string.IsNullOrEmpty(ingredient)) 
                throw new ArgumentNullException(nameof(ingredient));

            _ingredients.Add(ingredient);
        }

        public void RemoveIngredient(string ingredient)
        {
            if (string.IsNullOrEmpty(ingredient))
                throw new ArgumentNullException(nameof(ingredient));

            _ingredients.Remove(ingredient);
        }

        public virtual void Display()
        {
            Console.WriteLine("{0} : {1:F2} MDL", Name, Price);
            Console.WriteLine("Ingredients: {0}", string.Join(", ", Ingredients));
        }

        public virtual void Display(bool showRequirements)
        {
            Display();
            if (showRequirements) Console.WriteLine("Special Requirements: {0}", GetSpecialRequirements());
        }

        public object Clone()
        {
            var clone = (MenuItem)MemberwiseClone();
            clone.Ingredients = [.. Ingredients];
            return clone;
        }
    }
}