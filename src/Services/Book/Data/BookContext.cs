using Book.API.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Book.API.Data
{
    public class BookContext : IBookContext
    {
        public BookContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Books = database.GetCollection<Entities.Book>(
                configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            BookContextSeed.SeedData(Books);
        }

        public IMongoCollection<Entities.Book> Books { get; }
    }
}