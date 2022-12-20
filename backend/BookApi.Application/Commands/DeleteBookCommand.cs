using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Commands
{
    public class DeleteBookCommand : IRequest<string>
    {
        public string Id { get; set; }
    }

    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == null)
            {
                return "ID's not empty";
            }

            long lId = Convert.ToInt64(request.Id);
            var bookDeleted = await _bookRepository.GetAsyncById(lId, cancellationToken);
            if (bookDeleted == null)
            {
                return "ID's not found";
            }

            await _bookRepository.Delete(bookDeleted, cancellationToken);
            return "Success";
        }
    }
}
