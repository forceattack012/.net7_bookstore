using BookApi.Application.Commands;
using BookApi.Application.DTOs;
using BookApi.Application.Queries;
using BookApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookRequest book, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateBookCommand(){ BookRequest = book }, cancellationToken);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
        {
            var books = await _mediator.Send(new GetBooksQuery(), cancellationToken);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(long id, CancellationToken cancellationToken)
        {
            var book = await _mediator.Send(new GetBookByIdQuery() { id = id }, cancellationToken);
            return Ok(book);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(string id, [FromBody] BookRequest bookRequest, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new UpdateBookCommand() { Id = id, BookRequest = bookRequest });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(string id, CancellationToken cancellationToken)
        {
            var book = await _mediator.Send(new DeleteBookCommand() { Id = id }, cancellationToken);
            return Ok(book);
        }
    }
}
