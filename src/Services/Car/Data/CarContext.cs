using Car.API.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Car.API.Data
{
    public class CarContext : ICarContext
    {
        public CarContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Cars = database.GetCollection<Entities.Car>(
                configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CarContextSeed.SeedData(Cars);
        }

        public IMongoCollection<Entities.Car> Cars { get; }
    }
}