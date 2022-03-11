namespace Basket.API.Entitites
{
    public class ShoppingCardItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemId { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
    }
}
