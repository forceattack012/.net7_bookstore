using BookApi.Domain.Entities;

namespace BookApi.Domain.Repositories {
    public interface IBookRepository {
        Task<Book> GetAsyncById(int id, CancellationToken cancellation);
        Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellation);
        Task<Book> Create(Book book, CancellationToken cancellation);
        Task Update(Book book, CancellationToken cancellation);
        Task Delete(Book book, CancellationToken cancellation);
    }
}