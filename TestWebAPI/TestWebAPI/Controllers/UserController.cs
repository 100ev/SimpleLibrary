using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userInMemoryRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        public UserController(ILogger<UserController> loger, IUserRepository userInMemoryRepository, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _logger = loger;
            _userInMemoryRepository = userInMemoryRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }       

        [HttpGet("GetID")]
        public IEnumerable<Person> GetId()
        {
            return _userInMemoryRepository.GetAllUsers();
        }

        [HttpGet("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetAlBooks();

        }
        [HttpGet("GetAuthors")]
        public IEnumerable<Author> GetAuthors()
        {
            return _authorRepository.GetAllAuthors();

        }
    }
}