using BookApi.Application.Commands;
using BookApi.Application.DTOs;
using BookApi.Application.Queries;
using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using Moq;
using Xunit;

namespace BookApi.UnitTest
{
    public class TestBook
    {
        [Fact]
        public async Task TestCreateBookShouldReturnIdAsync()
        {
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(r => r.Create(It.IsAny<Book>(), CancellationToken.None)).ReturnsAsync(new Book());

            var mockBook = new CreateBookCommand()
            {
                BookRequest = new BookRequest()
                {
                    Description = "description",
                    Language = "en",
                    Name = "name",
                    Price = 100000,
                    PublishedAt = DateTime.UtcNow,
                }
            };

            var command = new CreateBookCommanddHandler(mockRepo.Object);
            var id = await command.Handle(mockBook, CancellationToken.None);

            Assert.Equal(0, id);
        }

        [Fact]
        public async Task TestGetBooksShouldReturnBooksAsync()
        {
            var mockRepo = new Mock<IBookRepository>();
            var mockBooks = new List<Book>()
            {
                new Book() {}
            };

            mockRepo.Setup(r => r.GetAllAsync(CancellationToken.None)).ReturnsAsync(mockBooks);

            var handler = new GetBooksQueryHandler(mockRepo.Object);
            var books = await handler.Handle(new GetBooksQuery(), CancellationToken.None);

            Assert.NotNull(books);
        }
    }
}