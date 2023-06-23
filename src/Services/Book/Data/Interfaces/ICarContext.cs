using MongoDB.Driver;

namespace Book.API.Data.Interfaces
{
    public interface IBookContext
    {
        IMongoCollection<Entities.Book> Books { get; }
    }
}