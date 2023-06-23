namespace House.API.Repository.Interfaces
{
    public interface IHouseRepository
    {
        Task<IEnumerable<Entities.House>> GetHouses();
        Task<Entities.House> GetHouse(string id);
        Task<IEnumerable<Entities.House>> GetCarByCity(string brand);
        Task CreateHouse(Entities.House product);
        Task<bool> UpdateHouse(Entities.House product);
        Task<bool> DeleteHouse(string id);
    }
}