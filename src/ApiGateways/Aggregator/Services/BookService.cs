using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Aggregator.Extensions;
using Aggregator.Models;

namespace Aggregator.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _client;

        public BookService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<BookModel>> GetBook()
        {
            var response = await _client.GetAsync("/api/v1/Book");
            return await response.ReadContentAs<List<BookModel>>();
        }

        public async Task<BookModel> GetBook(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Book/{id}");
            return await response.ReadContentAs<BookModel>();
        }

        public async Task<IEnumerable<BookModel>> GetBookByPublisher(string publisher)
        {
            var response = await _client.GetAsync($"/api/v1/Book/GetBookByPublisher/{publisher}");
            return await response.ReadContentAs<List<BookModel>>();
        }

        public async Task<IEnumerable<BookModel>> GetBookByName(string name)
        {
            var response = await _client.GetAsync($"/api/v1/Book/GetBookByName/{name}");
            return await response.ReadContentAs<List<BookModel>>();
        }
    }
}