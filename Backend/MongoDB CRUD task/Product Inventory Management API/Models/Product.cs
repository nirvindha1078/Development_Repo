using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product_Inventory_Management_API.Models
{
    public class Product
    {
        [BsonId]

        public ObjectId Id { get; set; }

        [BsonElement("ProductId")]
        public int ProductId { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonElement("ProductBrand")]
        public string ProductBrand { get; set; }

        [BsonElement("ProductReleaseYear")]
        public int ProductReleaseYear { get; set; }

        [BsonElement("ProductPrice")]
        public decimal ProductPrice { get; set; }
    }
}
