using Basket.API.Entitites;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository: IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task<ShoppingCard?> GetBasket(string username)
        {
            var basket = await _redisCache.GetStringAsync(username);

            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCard>(basket);
        }

        public async Task<ShoppingCardItem?> GetItem(ShoppingCard basket, string itemId)
        {
            var item = basket.Items.FirstOrDefault(p => p.ItemId == itemId);
            if(item == null)
            {
                return null;
            }

            return item;
        }


        public async Task<ShoppingCard?> UpdateBasket(string username, ShoppingCardItem item)
        {
            var basket = await GetBasket(username);

            if(basket == null)
            {
                basket = new ShoppingCard(username);
            }

            basket.Items.Add(item);
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.Username);
        }

        public async Task DeleteItem(ShoppingCard basket, string itemId)
        {
            var item = basket.Items.FirstOrDefault(p => p.ItemId == itemId);
          
            basket.Items.Remove(item);
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));
        }
        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }
    }
}
