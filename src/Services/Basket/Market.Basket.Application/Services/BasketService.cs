using Market.Basket.Application.Interfaces;
using Market.Basket.Data.Entities;
using Market.Basket.Data.Repository;
using Market.Common.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<ResponseViewModel> DeleteBasketAsync(string username, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel();
            await _basketRepository.DeleteBasketAsync(username, cancellationToken);
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<ShoppingCart>> GetBasketAsync(string username, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<ShoppingCart>();
            var basket = await _basketRepository.GetBasketAsync(username, cancellationToken);
            response.Entity = basket ?? new ShoppingCart(username);
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<ShoppingCart>> UpdateBasketAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<ShoppingCart>();
            response.Entity = await _basketRepository.UpdateBasketAsync(cart.UserName, cart, cancellationToken);
            response.Succeed();
            return await Task.FromResult(response);
        }
    }
}
