using Items;

namespace OrderSystem
{
    class OrderItem
    {
        private int _quantity;
        public MenuItem Item { get; }
        public string Note { get; }
        public int Quantity
        {
            get { return _quantity; }
            private set { _quantity = (value > 0) ? value : throw new ArgumentNullException(nameof(value)); }
        }

        public OrderItem(MenuItem item, int quantity, string note)
        {
            Item = item;
            Quantity = quantity;
            Note = note;
        }

        public decimal GetSubtotal() { return Item.Price * Quantity; }
    }
}