using House.API.Data.Interfaces;
using House.API.Repository.Interfaces;
using MongoDB.Driver;

namespace House.API.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly IHouseContext _context;

        public HouseRepository(IHouseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.House>> GetHouses()
        {
            return await _context.Houses.Find(p => true).ToListAsync();
        }

        public async Task<Entities.House> GetHouse(string id)
        {
            return await _context.Houses.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.House>> GetHouseByCity(string City)
        {
            FilterDefinition<Entities.House> filter = Builders<Entities.House>.Filter.Eq(p => p.City, city);

            return await _context.House.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.House>> GetHouseByModel(string model)
        {
            FilterDefinition<Entities.House> filter = Builders<Entities.House>.Filter.Eq(p => p.Model, model);

            return await _context.House.Find(filter).ToListAsync();
        }

        public async Task CreateHouse(Entities.House house)
        {
            await _context.Houses.InsertOneAsync(house);
        }

        public async Task<bool> UpdateHouse(Entities.House product)
        {
            var updateResult = await _context
                .Houses
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                   && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteHouse(string id)
        {
            FilterDefinition<Entities.House> filter = Builders<Entities.House>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                .Houses
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                   && deleteResult.DeletedCount > 0;
        }
    }
}