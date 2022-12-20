using BookApi.Application.Commands;
using BookApi.Domain.Repositories;
using Moq;
using Xunit;

namespace BookApi.UnitTest
{
    public class TestCreateBook
    {
        [Fact]
        public void TestCreateBookShouldReturnId()
        {
            var mockRepo = new Mock<IBookRepository>();

            var command = new CreateBookCommanddHandler(mockRepo.Object);
            var id = command.Handle(new CreateBookCommand(), CancellationToken.None);

            Assert.NotNull(id);
        }
    }
}