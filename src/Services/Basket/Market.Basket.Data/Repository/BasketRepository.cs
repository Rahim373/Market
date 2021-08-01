using Market.Basket.Data.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Basket.Data.Repository
{
    public class BasketRepository : IBasketRepository
    {
        public readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasketAsync(string username, CancellationToken cancellationToken)
        {
            await _redisCache.RemoveAsync(username, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default)
        {
            ShoppingCart cart = null;
            var basket = await _redisCache.GetStringAsync(username, cancellationToken);

            if (!string.IsNullOrEmpty(basket))
            {
                cart = JsonConvert.DeserializeObject<ShoppingCart>(basket);
            }

            return await Task.FromResult(cart);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(string username, ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            var basket = JsonConvert.SerializeObject(cart);
            await _redisCache.SetStringAsync(username, basket, cancellationToken);
            return await GetBasketAsync(username);
        }
    }
}
