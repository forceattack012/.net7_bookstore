using BookApi.Application.Commands;
using BookApi.Application.DTOs;
using BookApi.Application.Queries;
using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using Moq;

namespace BookApi.UnitTest
{
    public class TestOrder
    {
        [Fact]
        public async Task TestCreateOrShouldReturnTotalAmountAndOrderIdAsync()
        {
            var orders = new OrderRequest()
            {
                CustomerId = "1",
                bookOrderRequests = new List<BookOrderRequest> {
                    new BookOrderRequest
                    {
                        BookId = "2",
                        Price = 100,
                        Qty = 2
                    },
                    new BookOrderRequest
                    {
                        BookId = "2",
                        Price = 100,
                        Qty = 1
                    },
                    new BookOrderRequest{ 
                        BookId = "3",
                        Price = 300.12m,
                        Qty = 3
                    }
                }
            };

            decimal expectedAmout = 1200.36m;

            var mockOrderRepo = new Mock<IOrderRepository>();
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var mockBookRepo = new Mock<IBookRepository>();

            mockOrderRepo.Setup(r => r.Create(It.IsAny<Order>(), CancellationToken.None)).ReturnsAsync(new Order()
            {
                Id = 1
            });
            mockCustomerRepo.Setup(r => r.GetAsyncById(It.IsAny<long>(), CancellationToken.None))
                .ReturnsAsync(It.IsAny<Customer>());
            mockBookRepo.Setup(r => r.GetAsyncById(It.IsAny<long>(), CancellationToken.None))
                .ReturnsAsync(It.IsAny<Book>());

            var command = new CreateOrderCommand() { 
                Order = orders 
            };
            var handler = new CreateOrderHandler(mockOrderRepo.Object, mockCustomerRepo.Object, mockBookRepo.Object);

            var result = await handler.Handle(command, CancellationToken.None);
            mockBookRepo.Verify(r => r.GetAsyncById(It.IsAny<long>(), CancellationToken.None));
            Assert.NotNull(result);
            Assert.Equal("successful", result.Message);
            Assert.Equal(expectedAmout, result.Total);
        }

        [Fact]
        public async Task TestGetOrderByUserIdShouleReturnOrderHistoryAsync()
        {
            var userId = "1";
            var mockOrder = new List<Order>()
            {
                new Order()
                {
                    CustomerId = 1,
                    Customer = new Customer()
                    {
                        FirstName = "john",
                        LastName = "jim",
                    },
                    Id = 1,
                    Total = 1000,
                    Quailty = 10,
                    Book = new Book()
                    {
                        Price = 1000,
                        Name = "Test1",
                    }
                },
                new Order()
                {
                    
                    CustomerId = 1,
                    Customer = new Customer()
                    {
                        FirstName = "john",
                        LastName = "jim",
                    },
                    Id = 1,
                    Total = 100,
                    Quailty = 1,
                    Book = new Book()
                    {
                        Price = 100,
                        Name = "Test2",
                    }
                },
                new Order()
                {
                    CustomerId = 1,
                    Customer = new Customer()
                    {
                        FirstName = "john",
                        LastName = "jim",
                    },
                    Id = 3,
                    Total = 1000,
                    Quailty = 1,
                    Book = new Book()
                    {
                        Price = 1000,
                        Name = "Test1",
                    }
                }
            };
            var want = new OrderHistory()
            {
                Amount = 12,
                Balance = 2100.00m,
                CustomerId = userId,
                CustomerName = "john",
                OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail()
                    {
                        BookName = "Test1",
                        BookPrice = 1000,
                        OrderId = "1",
                    },
                    new OrderDetail()
                    {
                        BookName = "Test2",
                        OrderId = "1",
                        BookPrice = 100
                    },
                    new OrderDetail()
                    {
                        BookName = "Test1",
                        BookPrice = 1000,
                        OrderId = "3",
                    }
                }
            };
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(r => r.GetOrdersByUserId(It.IsAny<long>(), CancellationToken.None))
                    .ReturnsAsync(mockOrder);

            var query = new GetOrdersByUserIdQuery() { UserId= userId };
            var handler = new GetOrdersByUserIdQueryHandler(mockRepo.Object);
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(want, result);
        }
    }
}
