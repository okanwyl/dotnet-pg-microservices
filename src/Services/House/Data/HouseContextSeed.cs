using MongoDB.Driver;



namespace House.API.Data
{
    public class HouseContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.House> houseCollection)
        {
            bool existHouse = houseCollection.Find(p => true).Any();
            if (!existHouse)
            {
                houseCollection.InsertManyAsync(GetPreconfiguredHouse());
            }
        }

        private static IEnumerable<Entities.House> GetPreconfiguredHouse()
        {
            return new List<Entities.House>()
            {
                new Entities.House()
                {
                    Id = "house1",
                    City = "İstanbul",
                    m2 = "150",
                    Price = 3000000,
                    YearBuilding = "2011",
                    ImageFile = "house-1.png"
                },
                new Entities.House()
                {
                    Id = "house2",
                    City = "Ankara",
                    m2 = "130",
                    Price = 2500000,
                    YearBuilding = "2022",
                    ImageFile = "house-2.png"
                },
                new Entities.House()
                {
                    Id = "house3",
                    City = "İzmir",
                    m2 = "120",
                    Price = 1900000,
                    YearBuilding = "2008",
                    ImageFile = "house-3.png"
                },


            };
        }
    }
}