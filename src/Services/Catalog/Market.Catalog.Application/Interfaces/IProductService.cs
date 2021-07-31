using Market.Catalog.Data.Models;
using Market.Common.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Catalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<ResponseViewModel<Product>> CreateProductAsync(Product product, CancellationToken cancellationToken = default);
        Task<ResponseViewModel> DeleteProductAsync(string id, CancellationToken cancellationToken = default);
        Task<ResponseViewModel<IEnumerable<Product>>> GetProductByCategoryAsync(string category, CancellationToken cancellationToken = default);
        Task<ResponseViewModel<Product>> GetProductByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ResponseViewModel<IEnumerable<Product>>> GetProductByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<ResponseViewModel<IEnumerable<Product>>> GetProductsAsync(CancellationToken cancellationToken = default);
        Task<ResponseViewModel<bool>> UpdateProductByAsync(string id, Product product, CancellationToken cancellationToken = default);
    }
}
