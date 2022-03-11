namespace Basket.API.Entitites
{
    public class ShoppingCard
    {
        public string Username { get; set; } = string.Empty;
        public List<ShoppingCardItem> Items { get; set; } = new List<ShoppingCardItem>();

        public ShoppingCard() { }

        public ShoppingCard(string username)
        {
            this.Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }
    }
}
