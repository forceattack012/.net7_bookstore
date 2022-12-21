using BookApi.Application.DTOs;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<OrderHistory>
    {
        public string UserId { get; set; }
    }

    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, OrderHistory>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderHistory> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var result = await _orderRepository.GetOrdersByUserId(userId, cancellationToken);
            var response = new OrderHistory();
            decimal amount = 0;
            decimal balance = 0;

            result = result.OrderBy(r => r.Id);
            foreach (var order in result)
            {
                response.CustomerId = "" + order.CustomerId;
                response.CustomerName = order.Customer.FirstName;
                response.OrderDetails.Add(new OrderDetail()
                {
                    BookName = order.Book.Name,
                    BookPrice = order.Book.Price,
                    OrderId = "" + order.Id,
                    Qty = order.Quailty,
                });
                amount += order.Quailty;
                balance += order.Total;
            }
            response.Amount = amount;
            response.Balance = balance;

            return response;
        }
    }
}
