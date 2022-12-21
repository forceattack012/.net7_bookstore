namespace BookApi.Application.DTOs
{
    public class OrderHistory
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }

    public class OrderDetail
    {
        public string OrderId { get; set; }
        public string BookName { get; set;}
        public decimal BookPrice { get; set;}
        public int Qty { get; set; }
    }
}
