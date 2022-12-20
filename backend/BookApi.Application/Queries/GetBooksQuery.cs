using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<Book>>
    {
    }

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
    }

}
