using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using BookApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BookApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookAppDbContext _context;

        public BookRepository(BookAppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book, CancellationToken cancellation)
        {
            book.CreateAt= DateTime.Now;

            var result = await _context.AddAsync(book, cancellation);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public Task Delete(Book book, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellation) => await _context.Book.ToListAsync(cancellation);

        public Task<Book> GetAsyncById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
