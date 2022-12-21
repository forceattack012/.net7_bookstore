using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Domain.Entities.Base
{
    public interface IEntity<TId>
    {
        DateTime CreateAt { get; set; }
        DateTime? UpdateAt { get; set; }
        DateTime? DeleteAt { get; set; }
    }
}
