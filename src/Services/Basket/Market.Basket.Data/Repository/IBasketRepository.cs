using Market.Basket.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Basket.Data.Repository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default);
        Task<ShoppingCart> UpdateBasketAsync(string username, ShoppingCart cart, CancellationToken cancellationToken = default);
        Task DeleteBasketAsync(string username, CancellationToken cancellationToken);
    }
}
