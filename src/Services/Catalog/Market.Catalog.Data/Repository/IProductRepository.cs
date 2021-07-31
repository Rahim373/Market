using Market.Catalog.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Catalog.Data.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
        Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetProductByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(string category, CancellationToken cancellationToken = default);
        Task<bool> UpdateProductByAsync(string id, Product product, CancellationToken cancellationToken = default);
        Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> DeleteProduct(string id, CancellationToken cancellationToken = default);

    }
}
