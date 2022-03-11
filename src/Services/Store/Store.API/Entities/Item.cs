using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.API.Entities
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("Category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("Quantity")]
        public int Quantity{ get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("IsAvailable")]
        public bool IsAvailable { get; set; }
    }
}
