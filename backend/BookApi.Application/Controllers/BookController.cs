using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book, CancellationToken cancellationToken)
        {
            var newBook = await _bookRepository.Create(book, cancellationToken);
            return Ok(newBook);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync(cancellationToken);
            return Ok(books);
        }
    }
}
