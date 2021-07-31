using Market.Catalog.Application.Interfaces;
using Market.Catalog.Data.Models;
using Market.Catalog.Data.Repository;
using Market.Common.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Catalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<IProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<IProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ResponseViewModel<Product>> CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<Product>();
            response.Entity = await _productRepository.CreateProductAsync(product, cancellationToken);
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel> DeleteProductAsync(string id, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel();
            var success = await _productRepository.DeleteProduct(id, cancellationToken);
            if (!success)
            {
                response.AddMessage("Cannot delete product.", ResponseMessageType.Warning);
                return await Task.FromResult(response);
            }
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<IEnumerable<Product>>> GetProductByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<IEnumerable<Product>>();
            response.Entity = await _productRepository.GetProductByCategoryAsync(category, cancellationToken);
            if (response.Entity is null)
            {
                response.AddMessage("No product is found.", ResponseMessageType.Warning);
                return await Task.FromResult(response);
            }
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<Product>> GetProductByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<Product>();
            response.Entity = await _productRepository.GetProductByIdAsync(id, cancellationToken);
            if (response.Entity is null)
            {
                response.AddMessage("No product is found with this ID.", ResponseMessageType.Warning);
                return await Task.FromResult(response);
            }
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<IEnumerable<Product>>> GetProductByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<IEnumerable<Product>>();
            response.Entity = await _productRepository.GetProductByNameAsync(name, cancellationToken);
            if (response.Entity is null)
            {
                response.AddMessage("No product is found with this name.", ResponseMessageType.Warning);
                return await Task.FromResult(response);
            }
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<IEnumerable<Product>>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<IEnumerable<Product>>();
            response.Entity = await _productRepository.GetProductsAsync(cancellationToken);
            if (response.Entity is null)
            {
                response.AddMessage("No product is found.", ResponseMessageType.Warning);
                return await Task.FromResult(response);
            }
            response.Succeed();
            return await Task.FromResult(response);
        }

        public async Task<ResponseViewModel<bool>> UpdateProductByAsync(string id, Product product, CancellationToken cancellationToken = default)
        {
            var response = new ResponseViewModel<bool>();
            var success = await _productRepository.UpdateProductByAsync(id, product, cancellationToken);
            if (!success)
            {
                response.AddMessage("Product cannot be updated.", ResponseMessageType.Warning);
                return await Task.FromResult(response);
            }
            response.Succeed();
            return await Task.FromResult(response);
        }
    }
}
