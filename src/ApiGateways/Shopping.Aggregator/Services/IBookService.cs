using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ICarService
    {
        Task<IEnumerable<BookModel>> GetBook();
        Task<IEnumerable<BookModel>> GetBookByName(string name);
        Task<IEnumerable<BookModel>> GetBookByPublisher(string Publisher);
        Task<BookModel> GetBook(string id);
    }
}