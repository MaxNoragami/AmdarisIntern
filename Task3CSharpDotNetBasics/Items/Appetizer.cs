
using System.Text;

namespace Items
{
    class Appetizer : MenuItem
    {
        private int _servings;
        private bool _isShareable;
        private bool _isSeasonal;

        public int Servings
        {
            get { return _servings; }
            private set { _servings = (value > 0) ? value : throw new ArgumentException("Serving amount cannot be negative"); }
        }

        public bool IsShareable
        {
            get { return _isShareable; }
            private set { _isShareable = value; }
        }

        public bool IsSeasonal
        {
			get { return _isSeasonal; }
			private set { _isSeasonal = value; }
		}


        public Appetizer(string name, List<string> ingredients, decimal price, int servings, bool isShareable, bool isSeasonal) 
            : base(name, ingredients, price)
        {
            Servings = servings;
            IsShareable = isShareable;
            IsSeasonal = isSeasonal;
        }

        public override string GetSpecialRequirements()
        {
            StringBuilder specialRequirements = new StringBuilder();

            specialRequirements.Append((IsShareable)? "Shareable ": "Not Shareable ");
            specialRequirements.Append((IsSeasonal) ? "Seasonal " : "Not Seasonal ");
            
            return specialRequirements.ToString();
        }

        public override void Display()
        {
            base.Display();
			Console.WriteLine("Servings: {0}", Servings);
		}
    }
}