namespace Book.API.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Entities.Book>> GetBook();
        Task<Entities.Book> GetBook(string id);
        Task<IEnumerable<Entities.Book>> GetBookByPublisher(string publisher);
        Task<IEnumerable<Entities.Book>> GetBookByName(string name);
        Task CreateBook(Entities.Book product);
        Task<bool> UpdateBook(Entities.Book product);
        Task<bool> DeleteBook(string id);
    }
}