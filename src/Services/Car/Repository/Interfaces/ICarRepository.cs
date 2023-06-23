namespace Car.API.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Entities.Car>> GetCars();
        Task<Entities.Car> GetCar(string id);
        Task<IEnumerable<Entities.Car>> GetCarByBrand(string brand);
        Task<IEnumerable<Entities.Car>> GetCarByModel(string model);
        Task CreateCar(Entities.Car product);
        Task<bool> UpdateCar(Entities.Car product);
        Task<bool> DeleteCar(string id);
    }
}