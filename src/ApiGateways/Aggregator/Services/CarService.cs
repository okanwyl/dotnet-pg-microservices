using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Aggregator.Extensions;
using Aggregator.Models;

namespace Aggregator.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _client;

        public CarService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CarModel>> GetCar()
        {
            var response = await _client.GetAsync("/api/v1/Car");
            return await response.ReadContentAs<List<CarModel>>();
        }

        public async Task<CarModel> GetCar(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Car/{id}");
            return await response.ReadContentAs<CarModel>();
        }

        public async Task<IEnumerable<CarModel>> GetCarByBrand(string brand)
        {
            var response = await _client.GetAsync($"/api/v1/Car/GetCarByBrand/{brand}");
            return await response.ReadContentAs<List<CarModel>>();
        }

        public async Task<IEnumerable<CarModel>> GetCarByModel(string model)
        {
            var response = await _client.GetAsync($"/api/v1/Car/GetCarByModel/{model}");
            return await response.ReadContentAs<List<CarModel>>();
        }
    }
}