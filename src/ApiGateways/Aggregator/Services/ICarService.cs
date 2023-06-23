using System.Collections.Generic;
using System.Threading.Tasks;
using Aggregator.Models;

namespace Aggregator.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarModel>> GetCar();
        Task<IEnumerable<CarModel>> GetCarByBrand(string brand);
        Task<IEnumerable<CarModel>> GetCarByModel(string model);
        Task<CarModel> GetCar(string id);
    }
}