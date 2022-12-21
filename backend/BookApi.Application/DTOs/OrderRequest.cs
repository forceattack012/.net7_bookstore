namespace BookApi.Application.DTOs
{
    public class OrderRequest
    {
        public string CustomerId { get; set; }
        public List<BookOrderRequest> bookOrderRequests { get; set; }
    }
    public class BookOrderRequest
    {
        public string BookId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}
