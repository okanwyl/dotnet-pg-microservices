using MongoDB.Driver;

namespace Car.API.Data.Interfaces
{
    public interface ICarContext
    {
        IMongoCollection<Entities.Car> Cars { get; }
    }
}