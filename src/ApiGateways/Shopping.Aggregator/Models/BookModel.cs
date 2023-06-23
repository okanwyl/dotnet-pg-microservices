namespace Shopping.Aggregator.Models
{
    public class CarModel
    { 
        public string Id { get; set; }

        [BsonElement("Name")] public string Name { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Abstract { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}