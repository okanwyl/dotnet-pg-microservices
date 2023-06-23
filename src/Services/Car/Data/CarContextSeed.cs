using MongoDB.Driver;



namespace Car.API.Data
{
    public class CarContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Car> carCollection)
        {
            bool existCar = carCollection.Find(p => true).Any();
            if (!existCar)
            {
                carCollection.InsertManyAsync(GetPreconfiguredCars());
            }
        }

        private static IEnumerable<Entities.Car> GetPreconfiguredCars()
        {
            return new List<Entities.Car>()
            {
                new Entities.Car()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Brand = "Renault",
                    Model = "Symbol",
                    Price = 300000,
                    Year = "2011",
                    ImageFile = "car-1.png",
                    DrivedCountKm = 120000
                },
                new Entities.Car()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Brand = "Opel",
                    Model = "Astra",
                    Price = 212033,
                    Year = "2010",
                    ImageFile = "car-2.png",
                    DrivedCountKm = 121123
                }
            };
        }
    }
}