using Market.Basket.Application.Interfaces;
using Market.Basket.Data.Entities;
using Market.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Route("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ResponseViewModel<ShoppingCart>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasketAsync(string username, CancellationToken cancellationToken)
        {
            var result = await _basketService.GetBasketAsync(username, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel<ShoppingCart>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasketAsync([FromBody] ShoppingCart cart, CancellationToken cancellationToken)
        {
            var result = await _basketService.UpdateBasketAsync(cart, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [Route("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasketAsync(string username, CancellationToken cancellationToken)
        {
            var result = await _basketService.DeleteBasketAsync(username, cancellationToken);
            return new ObjectResult(result);
        }
    }
}
