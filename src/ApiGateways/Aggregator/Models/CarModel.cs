namespace Aggregator.Models
{
    public class CarModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public decimal DrivedCountKm { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}