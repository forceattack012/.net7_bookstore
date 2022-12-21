using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using BookApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookAppDbContext _context;

        public CustomerRepository(BookAppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer, CancellationToken cancellation)
        {
            var result = await _context.Customer.AddAsync(customer, cancellation);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task Delete(Customer customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetAsyncById(long id, CancellationToken cancellation)
        {
            return await _context.Customer.SingleOrDefaultAsync(r => r.Id == id);
        }

        public Task Update(Customer customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
