using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using BookApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
            var result = await _context.AddAsync(book, cancellation);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Book book, CancellationToken cancellation)
        {
            _context.Remove(book);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellation)
        {
            return await _context.Book.ToListAsync();
        }

        public async Task<Book> GetAsyncById(long id, CancellationToken cancellation) => await _context.Book.SingleOrDefaultAsync(r => r.Id == id, cancellation);

        public async Task Update(Book book, CancellationToken cancellation)
        {
            _context.Book.Update(book);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
