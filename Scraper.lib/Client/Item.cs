using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Scraper.lib.Client
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProductLink { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Store { get; set; }
    }
}