using System.ComponentModel.DataAnnotations;


namespace BookApi.Domain.Entities.Base
{
    public abstract class BaseEntity<TId> : IEntity<TId>
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
