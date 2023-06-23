namespace Book.API.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Entities.Book>> GetBooks();
        Task<Entities.Book> GetBook(string id);
        Task<IEnumerable<Entities.Book>> GetBookByBrand(string brand);
        Task<IEnumerable<Entities.Book>> GetBookByModel(string model);
        Task CreateBook(Entities.Book product);
        Task<bool> UpdateBook(Entities.Book product);
        Task<bool> DeleteBook(string id);
    }
}