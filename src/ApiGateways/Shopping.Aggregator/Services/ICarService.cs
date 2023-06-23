using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarModel>> GetCar();
        Task<IEnumerable<CarModel>> GetCarByBrand(string brand);
        Task<IEnumerable<CarModel>> GetCarByModel(string model);
        Task<CarModel> GetCar(string id);
    }
}