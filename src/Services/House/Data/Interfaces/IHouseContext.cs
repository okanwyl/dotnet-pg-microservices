using MongoDB.Driver;

namespace House.API.Data.Interfaces
{
    public interface IHouseContext
    {
        IMongoCollection<Entities.House> Houses { get; }
    }
}