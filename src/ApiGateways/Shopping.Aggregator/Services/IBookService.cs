using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetBook();
        Task<IEnumerable<BookModel>> GetBookByName(string name);
        Task<IEnumerable<BookModel>> GetBookByPublisher(string publisher);
        Task<BookModel> GetBook(string id);
    }
}