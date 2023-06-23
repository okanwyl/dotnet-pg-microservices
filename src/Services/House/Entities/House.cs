using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace House.API.Entities
{
    public class House
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("City")] public string City { get; set; }
        public string M2 { get; set; }
        public string YearBuilding { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }

    }
}