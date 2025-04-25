using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Product_Inventory_Management_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product_Inventory_Management_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public ProductRepository(IOptions<MongoSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _productsCollection = database.GetCollection<Product>(mongoSettings.Value.CollectionName);
        }

        public void InsertInitialData()
        {
            if (_productsCollection.CountDocuments(product => true) == 0)
            {
                var products = new List<Product>
                {
                    new Product { ProductId = 1, ProductName = "Nokia 8910", ProductBrand = "Nokia", ProductReleaseYear = 2003, ProductPrice = 30945 },
                    new Product { ProductId = 2, ProductName = "LG Watch Urbane W150", ProductBrand = "LG", ProductReleaseYear = 2015, ProductPrice = 21808 },
                    new Product { ProductId = 3, ProductName = "Samsung J400", ProductBrand = "Samsung", ProductReleaseYear = 2008, ProductPrice = 28717 }
                };
                _productsCollection.InsertMany(products);
            }
        }

        public IEnumerable<Product> GetAllProducts() => _productsCollection.Find(product => true).ToList();

        public Product GetProductById(int id) => _productsCollection.Find(product => product.ProductId == id).FirstOrDefault();

        public void AddProduct(Product product) => _productsCollection.InsertOne(product);

        public void UpdateProduct(int id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ProductId, id);
            var update = Builders<Product>.Update
                .Set(p => p.ProductName, product.ProductName)
                .Set(p => p.ProductBrand, product.ProductBrand)
                .Set(p => p.ProductReleaseYear, product.ProductReleaseYear)
                .Set(p => p.ProductPrice, product.ProductPrice);

            _productsCollection.UpdateOne(filter, update);
        }

        public void DeleteProduct(int id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.ProductId, id);
            _productsCollection.DeleteOne(filter);
        }
    }
}
