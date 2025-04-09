
using System.Text;

namespace Items
{
    class MainCourse : MenuItem
    {
        private bool _isServedHot;
        private bool _isGlutenFree;

        public bool IsServedHot
        {
            get { return _isServedHot; }
            set { _isServedHot = value; }
        }

		public bool IsGlutenFree
		{
			get { return _isGlutenFree; }
			set { _isGlutenFree = value; }
		}

		public MainCourse(string name, List<string> ingredients, decimal price, bool isServedHot, bool isGlutenFree) 
            : base(name, ingredients, price)
        {
            _isServedHot = isServedHot;
            _isGlutenFree = isGlutenFree;
        }

        public override string GetSpecialRequirements()
        {
			StringBuilder specialRequirements = new StringBuilder();

			specialRequirements.Append((IsServedHot) ? "Served Hot " : "Served Cold ");
			specialRequirements.Append((IsGlutenFree) ? "Gluten Free " : "Has Gluten ");

			return specialRequirements.ToString();
		}
    }
}