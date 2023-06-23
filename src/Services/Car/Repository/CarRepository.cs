using Car.API.Data.Interfaces;
using Car.API.Repository.Interfaces;
using MongoDB.Driver;

namespace Car.API.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ICarContext _context;

        public CarRepository(ICarContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.Car>> GetCars()
        {
            return await _context.Cars.Find(p => true).ToListAsync();
        }

        public async Task<Entities.Car> GetCar(string id)
        {
            return await _context.Cars.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Car>> GetCarByBrand(string brand)
        {
            FilterDefinition<Entities.Car> filter = Builders<Entities.Car>.Filter.Eq(p => p.Brand, brand);

            return await _context.Cars.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Car>> GetCarByModel(string model)
        {
            FilterDefinition<Entities.Car> filter = Builders<Entities.Car>.Filter.Eq(p => p.Model, model);

            return await _context.Cars.Find(filter).ToListAsync();
        }

        public async Task CreateCar(Entities.Car car)
        {
            await _context.Cars.InsertOneAsync(car);
        }

        public async Task<bool> UpdateCar(Entities.Car product)
        {
            var updateResult = await _context
                .Cars
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                   && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteCar(string id)
        {
            FilterDefinition<Entities.Car> filter = Builders<Entities.Car>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                .Cars
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                   && deleteResult.DeletedCount > 0;
        }
    }
}