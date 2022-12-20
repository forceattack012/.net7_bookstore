using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using BookApi.Infrastructure.Context;

namespace BookApi.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookAppDbContext _context;

        public CustomerRepository(BookAppDbContext context)
        {
            _context = context;
        }

        public Task<Customer> Create(Customer customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Customer customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsyncById(long id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
