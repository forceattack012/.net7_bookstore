using BookApi.Domain.Entities.Base;

namespace BookApi.Domain.Entities
{
    public class Order : BaseEntity<long>
    {
        public long Id { get; set; }
        public int Quailty { get; set; }
        public decimal Total { get; set; }
        public bool IsPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public long BookId { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
