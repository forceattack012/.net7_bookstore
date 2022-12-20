using BookApi.Application.DTOs;
using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Commands
{
    public class CreateBookCommand : IRequest<long>
    {
        public BookRequest BookRequest { get; set;}
    }

    public class CreateBookCommanddHandler : IRequestHandler<CreateBookCommand, long>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommanddHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var newBook = new Book
            {
                CreateAt = DateTime.Now,
                Description = request.BookRequest.Name,
                Name = request.BookRequest.Name,
                Price = request.BookRequest.Price,
                PublishedAt = request.BookRequest.PublishedAt
            };

            var result = await _bookRepository.Create(newBook, cancellationToken);
            return result.Id;
        }
    }
}
