using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Car.API.Entities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Brand")] public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public decimal DrivedCountKm { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}