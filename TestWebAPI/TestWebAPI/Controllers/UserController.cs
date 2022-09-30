using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.MemoryRepository;
using TestWebAPIModels;
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
        public UserController(ILogger<UserController> loger, IUserRepository userInMemoryRepository, IBookRepository bookRepository)
        {
            _logger = loger;
            _userInMemoryRepository = userInMemoryRepository;
            _bookRepository = bookRepository;
        }       

        [HttpGet("GetID")]
        public IEnumerable<Person> GetId()
        {
            return _userInMemoryRepository.GetAllUsers();

        }       
     }
}