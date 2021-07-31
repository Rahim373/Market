using Market.Catalog.Application.Interfaces;
using Market.Catalog.Data.Models;
using Market.Catalog.Data.Repository;
using Market.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Catalog.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("[action]", Name = "CreateProduct")]
        [ProducesResponseType(typeof(ResponseViewModel<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProductAsync([FromBody] Product product, CancellationToken cancellationToken = default)
        {
            var result = await _productService.CreateProductAsync(product, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpDelete]
        [Route("[action]/{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _productService.DeleteProductAsync(id, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(ResponseViewModel<IEnumerable<Product>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            var result = await _productService.GetProductByCategoryAsync(category, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("[action]/{id:length(24)}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ResponseViewModel<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _productService.GetProductByIdAsync(id, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("[action]/{name}", Name = "GetProductByName")]
        [ProducesResponseType(typeof(ResponseViewModel<IEnumerable<Product>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var result = await _productService.GetProductByNameAsync(name, cancellationToken);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("[action]", Name = "GetProducts")]
        [ProducesResponseType(typeof(ResponseViewModel<IEnumerable<Product>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var result = await _productService.GetProductsAsync(cancellationToken);
            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("[action]/{id:length(24)}", Name = "UpdateProduct")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductByAsync(string id, Product product, CancellationToken cancellationToken = default)
        {
            var result = await _productService.UpdateProductByAsync(id, product, cancellationToken);
            return new ObjectResult(result);
        }
    }
}
