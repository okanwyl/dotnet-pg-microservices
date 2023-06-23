using System.Threading.Tasks;
using Aggregator.Models;

namespace Aggregator.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);                
    }
}
