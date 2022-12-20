using BookApi.Domain.Entities;
using BookApi.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
