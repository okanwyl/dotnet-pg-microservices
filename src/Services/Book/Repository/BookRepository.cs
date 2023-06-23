using Book.API.Data.Interfaces;
using Book.API.Repository.Interfaces;
using MongoDB.Driver;

namespace Book.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _context;

        public BookRepository(IBookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.Book>> GetBooks()
        {
            return await _context.Books.Find(p => true).ToListAsync();
        }

        public async Task<Entities.Book> GetBook(string id)
        {
            return await _context.Books.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Book>> GetBookByBrand(string brand)
        {
            FilterDefinition<Entities.Book> filter = Builders<Entities.Book>.Filter.Eq(p => p.Brand, brand);

            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Book>> GetBookByModel(string model)
        {
            FilterDefinition<Entities.Book> filter = Builders<Entities.Book>.Filter.Eq(p => p.Model, model);

            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task CreateBook(Entities.Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<bool> UpdateBook(Entities.Book product)
        {
            var updateResult = await _context
                .Books
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                   && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteBook(string id)
        {
            FilterDefinition<Entities.Book> filter = Builders<Entities.Book>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                .Books
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                   && deleteResult.DeletedCount > 0;
        }
    }
}