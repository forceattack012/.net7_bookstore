using BookApi.Application.DTOs;
using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public OrderRequest Order { get; set;}
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IBookRepository _bookRepository;

        public CreateOrderHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _CustomerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            decimal total = 0.0m;
            var response = new OrderResponse();

            var customerId = request.Order?.CustomerId;
            if(string.IsNullOrEmpty(customerId))
            {
                response.Message = "customerId's not found";
                return response;
            }

            if(request.Order == null) 
            {
                response.Message = "should buy 1 item or more";
                return response;
            }

            var customer = await _CustomerRepository.GetAsyncById(Convert.ToInt64(customerId), cancellationToken);
            var newOrders = new List<Order>();
            foreach (var order in request.Order.bookOrderRequests)
            {
                decimal currentTotal = order.Price * order.Qty;
                total += currentTotal;

                var book = await _bookRepository.GetAsyncById(Convert.ToInt64(order.BookId), cancellationToken);
                newOrders.Add(new Order()
                {
                    Book = book,
                    Total= currentTotal,
                    Quailty= order.Qty,
                    Customer = customer,
                    CreateAt = DateTime.Now,
                });
            }

            var responseOrder = new Order();
            foreach(var order in newOrders)
            {
                responseOrder = await _orderRepository.Create(order, cancellationToken).ConfigureAwait(false);
            }
            response.Message = "successful";
            response.Total = total;
            response.OrderId = responseOrder.Id;
            return response;
             
        }
    }
}
