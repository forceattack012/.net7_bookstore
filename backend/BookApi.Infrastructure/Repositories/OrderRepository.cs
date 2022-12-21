using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using BookApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookAppDbContext _context;

        public OrderRepository(BookAppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order, CancellationToken cancellation)
        {
            var result = await _context.AddAsync(order, cancellation);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Order> CreateRangeAsync(List<Order> orders, CancellationToken cancellation)
        {
            var or = new Order();
            await _context.AddRangeAsync(orders, cancellation);
            return or;
        }

        public Task Delete(Order order, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsyncById(long id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(long userId, CancellationToken cancellation)
        {
            var orders = await _context.Order.Where(r => r.CustomerId == userId)
                        .Include(r => r.Customer)
                        .Include(r => r.Book)
                        .ToListAsync();
            return orders;
        }

        public Task Update(Order order, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
