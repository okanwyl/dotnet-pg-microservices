using System.Net;
using Book.API.Data;
using Book.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly ILogger<BookController> _logger;


        public BookController(IBookRepository repository, ILogger<BookController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Book>>> GetBooks()
        {
            var books = await _repository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id:length(24)}", Name = "GetBooks")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Book>> GetBookById(string id)
        {
            var book = await _repository.GetBook(id);

            if (book == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(book);
        }

        [Route("[action]/{category}", Name = "GetBookByModel")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Book>>> GetBookByModel(string model)
        {
            var books = await _repository.GetBookByModel(model);
            return Ok(books);
        }

        [Route("[action]/{name}", Name = "GetBookByBrand")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Book>>> GetBookByBrand(string brand)
        {
            var books = await _repository.GetBookByBrand(brand);
            if (books == null)
            {
                _logger.LogError($"Products with name: {brand} not found.");
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Book>> CreateBook([FromBody] Entities.Book book)
        {
            await _repository.CreateBook(book);

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBook([FromBody] Entities.Book toUpdateBook)
        {
            var book = await _repository.UpdateBook(toUpdateBook);
            if (book == true)
            {
                return Ok();
            }

            return Forbid();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Entities.Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBookById(string id)
        {
            var book = await _repository.DeleteBook(id);
            if (book == true)
            {
                return Ok();
            }

            return Forbid();
        }
    }
}