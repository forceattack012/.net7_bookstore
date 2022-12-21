namespace BookApi.Application.DTOs
{
    public class OrderResponse
    {
        public string Message { get; set; }
        public long OrderId { get; set; }
        public decimal Total { get; set; }
    }
}
