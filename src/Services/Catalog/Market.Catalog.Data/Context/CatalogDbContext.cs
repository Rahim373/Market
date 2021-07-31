using Market.Catalog.Data.Models;
using Market.Catalog.Data.Settings;
using MongoDB.Driver;

namespace Market.Catalog.Data.Context
{
    public class CatalogDbContext : ICatalogDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly DatabaseSetting _setting;

        public CatalogDbContext(DatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            _database = client.GetDatabase(setting.DatabaseName);
            _setting = setting;
        }

        public IMongoCollection<Product> Products
        {
            get => _database.GetCollection<Product>(_setting.ProductCollectionName);
        }
    }
}
