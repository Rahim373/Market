using Market.Catalog.Data.Context;
using Market.Catalog.Data.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Catalog.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogDbContext _context;

        public ProductRepository(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.InsertOneAsync(
                document: product,
                cancellationToken: cancellationToken
            );
            return await Task.FromResult(product);
        }

        public async Task<bool> DeleteProduct(string id, CancellationToken cancellationToken = default)
        {
            var result = await _context.Products.DeleteOneAsync(
                filter: x => x.Id == id,
                cancellationToken: cancellationToken
            );
            return await Task.FromResult(result.DeletedCount > 0 && result.IsAcknowledged);
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            var result = await _context.Products.FindAsync(
                filter: x => x.Category.ToLower() == category.ToLower(),
                cancellationToken: cancellationToken
            );
            return await result.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _context.Products.FindAsync(
                filter: x => x.Id == id,
                cancellationToken: cancellationToken
            );
            return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var result = await _context.Products.FindAsync(
                filter: x => x.Name.ToLower() == name.ToLower(),
                cancellationToken: cancellationToken
            );
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.Products.FindAsync(
                filter: p => true,
                cancellationToken: cancellationToken
            );
            return await result.ToListAsync();
        }

        public async Task<bool> UpdateProductByAsync(string id, Product product, CancellationToken cancellationToken = default)
        {
            var response = await _context.Products.ReplaceOneAsync(
                filter: x => x.Id == id, 
                replacement: product,
                cancellationToken: cancellationToken
            );
            return await Task.FromResult(response.IsAcknowledged && response.ModifiedCount > 0);
        }
    }
}
