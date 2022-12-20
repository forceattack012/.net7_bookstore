using BookApi.Domain.Entities;
using BookApi.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Domain.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsyncById(long id, CancellationToken cancellation);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellation);
        Task<T> Create(T T, CancellationToken cancellation);
        Task Update(T T, CancellationToken cancellation);
        Task Delete(T T, CancellationToken cancellation);
    }
}
