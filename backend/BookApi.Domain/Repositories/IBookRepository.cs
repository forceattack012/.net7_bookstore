using BookApi.Domain.Entities;
using BookApi.Domain.Repositories.Base;

namespace BookApi.Domain.Repositories {
    public interface IBookRepository : IRepository<Book> {
    }
}