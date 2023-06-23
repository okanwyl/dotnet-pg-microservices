using House.API.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace House.API.Data
{
    public class HouseContext : IHouseContext
    {
        public HouseContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Houses = database.GetCollection<Entities.House>(
                configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            HouseContextSeed.SeedData(Houses);
        }

        public IMongoCollection<Entities.House> Houses { get; }
    }
}