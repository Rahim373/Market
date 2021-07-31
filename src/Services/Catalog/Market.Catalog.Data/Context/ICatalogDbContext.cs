using Market.Catalog.Data.Models;
using MongoDB.Driver;

namespace Market.Catalog.Data.Context
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; }
    }
}