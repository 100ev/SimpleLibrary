using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TestWebAPI.AutoMapper;
using TestWebAPI.Controllers;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Services;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.Test
{
    public class BookTest
    {
        private IList<Book> _books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "The lord of the rings",
                AuthorId = 1
            },
            new Book()
            {
                Id = 2,
                Title = "Robinson crusoe",
                AuthorId = 1
            }
        };

        private readonly IMapper _mapper;
        private Mock<ILogger<BookService>> _loggerMock;
        private Mock<ILogger<BookController>> _bookControllerMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly IMediator _mediaator;
        public BookTest()
        {
            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapperConfig.CreateMapper();
            _loggerMock = new Mock<ILogger<BookService>>();

            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookControllerMock = new Mock<ILogger<BookController>>();
        }

        [Fact]
        public async Task Book_GetBookOk()
        {
            //setup
            int bookId = 1;
            var expectedBook = _books.FirstOrDefault(bk =>bk.Id == bookId);

              _bookRepositoryMock.Setup(x => x.GetById(bookId))
                .ReturnsAsync(expectedBook);

            //inject
            var service = new BookService(_bookRepositoryMock.Object, _mapper, _loggerMock.Object);
            var controller = new BookController(service, _bookControllerMock.Object, _mapper, _mediaator);

            //act
            var result = await controller.GetBookById(bookId);
            var okObjectResult = result as OkObjectResult;
            //assert
            Assert.NotNull(okObjectResult);
            var book = okObjectResult.Value as AddBookResponse;
            Assert.NotNull(book);
            Assert.Equal(bookId,expectedBook.Id);
        }
    }
}
