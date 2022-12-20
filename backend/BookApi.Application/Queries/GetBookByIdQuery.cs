using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public long id { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAsyncById(request.id, cancellationToken);
        }
    }
}
