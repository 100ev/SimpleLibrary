using BookStore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IPersonService _userInMemoryRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IAuthorRepository _authorRepository;
        public UserController(ILogger<UserController> loger, IPersonService userInMemoryRepository)
        {
            _logger = loger;
            _userInMemoryRepository = userInMemoryRepository;
           
        }       

        [HttpGet("GetID")]
        async Task<Person> GetId(int id)
        {
            return null;//await _userInMemoryRepository.GetById(id)
        }

        [HttpGet("GetBooks")]
        async  Task<IEnumerable<Book>> GetBooks()
        {
            return null;//await _bookRepository.GetAlBooks();

        }
        [HttpGet("GetAuthors")]
        public async Task<IEnumerable<Author>> GetAuthors()
        {

            return await  _authorRepository.GetAllAuthors();

        }
    }
}