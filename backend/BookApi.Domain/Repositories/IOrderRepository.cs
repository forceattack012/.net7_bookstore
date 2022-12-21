using BookApi.Domain.Entities;
using BookApi.Domain.Repositories.Base;

namespace BookApi.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<Order> CreateRangeAsync(List<Order> orders, CancellationToken cancellation);
        public Task<IEnumerable<Order>> GetOrdersByUserId(long userId, CancellationToken cancellation);
    }
}
