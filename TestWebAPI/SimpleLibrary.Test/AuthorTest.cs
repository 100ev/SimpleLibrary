
using AutoMapper;
using BookStore.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TestWebAPI.AutoMapper;
using TestWebAPI.Controllers;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace SimpleLibrary.Test
{
    public class AuthorTest
    {
        private IList<Author> _authors = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Age = 74,
                Name = "authorName",
                NickName = "Nickname"
            },
            new Author()
            {
                Id = 2,
                Age = 54,
                Name = "authorName2",
                NickName = "Nickname2"
            }
        };            

        private readonly IMapper _mapper;
        private Mock<ILogger<AuthorService>> _loggerMock;
        private Mock<ILogger<AuthorController>> _authorControlleroggerMock;
        private readonly Mock<IAuthorRepository> _authorRepositoryMock;
        private readonly Mock<IBookRepository> _bookRepositoryMock;

        //AuthorService(IAuthorService authorService, IMapper mapper)
        public AuthorTest()
        {
            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapperConfig.CreateMapper();

            _loggerMock = new Mock<ILogger<AuthorService>>();

            _authorRepositoryMock = new Mock<IAuthorRepository>();
            _bookRepositoryMock = new Mock<IBookRepository>();
            _authorControlleroggerMock = new Mock<ILogger<AuthorController>>();
        }

        [Fact]
        public async Task Author_GetAll_CountCheck()
        {
            //setup
            var expectedCount = 2;

            _authorRepositoryMock.Setup(x => x.GetAllAuthors())
                .ReturnsAsync(_authors);

            //inject
            var service = new AuthorService(_authorRepositoryMock.Object, _mapper, _loggerMock.Object);
            var controller = new AuthorController(service, _authorControlleroggerMock.Object, _mapper);

            //Act
            var result = await controller.GetAllAuthors();
            //Asset
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var authors = okObjectResult.Value as IEnumerable<Author>;
            Assert.NotNull(authors);
            Assert.NotEmpty(authors);
            Assert.Equal(expectedCount, authors.Count());
            
        }

        [Fact]
        public async Task Author_GetAuthorById_Ok()
        {
            //setup
            var authorId = 1;
            var expectedAuthor = _authors.First(x => x.Id == authorId);

            _authorRepositoryMock.Setup(x => x.GetById(authorId))
                .ReturnsAsync(expectedAuthor);

            //inject
            var service = new AuthorService(_authorRepositoryMock.Object, _mapper, _loggerMock.Object);
            var controller = new AuthorController(service, _authorControlleroggerMock.Object, _mapper);

            //act
            var result = await controller.GetAuthroById(authorId);
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var author = okObjectResult.Value as AddAuthorResponse;
            Assert.NotNull(author);
            Assert.Equal(authorId, author.Author.Id);
        }

        [Fact]
        public async Task Author_GetAuthorById_NotFound()
        {
            //setup
            var authorId = 3;
            var expectedAuthor = _authors.FirstOrDefault(x => x.Id == authorId);

            _authorRepositoryMock.Setup(x => x.GetById(authorId))
               .ReturnsAsync(expectedAuthor);

            //inject
            var service = new AuthorService(_authorRepositoryMock.Object, _mapper, _loggerMock.Object);
            var controller = new AuthorController(service, _authorControlleroggerMock.Object, _mapper);

            //act
            var result = await controller.GetAuthroById(authorId);
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            var returnedAuthorId = (int)notFoundObjectResult.Value;
            Assert.Equal(authorId, returnedAuthorId);
        }

        [Fact]
        public async Task AddAuthorOk()
        {
            //setup
            var authorRequest = new AddAuthorRequest()
            {
                NickName = "New nickname",
                Age = 22,
                DateOfBith = DateTime.Now,
                Name = "Name"
            };

            var expectedAuthorId = 3;
            _authorRepositoryMock.Setup(x => x.AddAutor(It.IsAny<Author>()))
            .Callback(() =>
            {
                _authors.Add(new Author()
                {
                    Id = expectedAuthorId,
                    Name = authorRequest.Name,
                    DateOfBirth = authorRequest.DateOfBith,
                    NickName = authorRequest.NickName
                });
            })!.ReturnsAsync(_authors.FirstOrDefault(x=>x.Id == 3));

            var service = new AuthorService(_authorRepositoryMock.Object, _mapper, _loggerMock.Object);
            var controller = new AuthorController(service, _authorControlleroggerMock.Object, _mapper);

            //act
            var result = await controller.AddAuthor(authorRequest);
            //assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var resultValue = okObjectResult.Value as AddAuthorResponse;
            Assert.NotNull(resultValue);
            Assert.Equal(expectedAuthorId, resultValue.Author.Id);

            
        }
        [Fact]        
        public async Task Author_AddAuthorByName()
        {
            //setup
            var authorRequest = new AddAuthorRequest()
            {
                NickName = "New nickname",
                Age = 22,
                DateOfBith = DateTime.Now,
                Name = "Name"
            };

           
            _authorRepositoryMock.Setup(x =>
            x.GetAuthorByName(authorRequest.Name))
                .ReturnsAsync(_authors.FirstOrDefault(x => x.Name == authorRequest.Name));
                     
            var service = new AuthorService(_authorRepositoryMock.Object, _mapper, _loggerMock.Object);
            var controller = new AuthorController(service, _authorControlleroggerMock.Object, _mapper);

            //act
            var result = await controller.AddAuthor(authorRequest);
            //assert
            var badRequestObjectResult = result as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);

            var resultValue = badRequestObjectResult.Value as AddAuthorResponse;
            Assert.NotNull(resultValue);
            Assert.Equal("Author already exist", resultValue.Message);
        }        
    }
}