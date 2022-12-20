using BookApi.Application.DTOs;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Commands
{
    public class UpdateBookCommand : IRequest<string>
    {
        public string Id { get; set; }
        public BookRequest BookRequest { get; set; }
    }

    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.BookRequest == null)
            {
                return "ID isn't empty";
            }

            var bookUpdated = await _bookRepository.GetAsyncById(Convert.ToInt64(request.Id), cancellationToken);
            if(bookUpdated == null)
            {
                return "book's not found";
            }

            bookUpdated.UpdateAt = DateTime.Now;
            bookUpdated.Name = request.BookRequest.Name;
            bookUpdated.Description = request.BookRequest.Description;
            bookUpdated.Language = request.BookRequest.Language;
            bookUpdated.Price = request.BookRequest.Price;

            await _bookRepository.Update(bookUpdated, cancellationToken);

            return "successful";

        }
    }
}
