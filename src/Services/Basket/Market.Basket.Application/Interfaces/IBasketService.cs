using Market.Basket.Data.Entities;
using Market.Common.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Basket.Application.Interfaces
{
    public interface IBasketService
    {
        Task<ResponseViewModel<ShoppingCart>> GetBasketAsync(string username, CancellationToken cancellationToken = default);
        Task<ResponseViewModel<ShoppingCart>> UpdateBasketAsync(ShoppingCart cart, CancellationToken cancellationToken = default);
        Task<ResponseViewModel> DeleteBasketAsync(string username, CancellationToken cancellationToken = default);
    }
}
