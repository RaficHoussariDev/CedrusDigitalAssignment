using Basket.API.Entitites;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCard?> GetBasket(string username);
        Task<ShoppingCardItem?> GetItem(ShoppingCard basket, string itemId);
        Task<ShoppingCard?> UpdateBasket(string username, ShoppingCardItem basket);
        Task DeleteItem(ShoppingCard basket, string productId);
        Task DeleteBasket(string username);
    }
}
