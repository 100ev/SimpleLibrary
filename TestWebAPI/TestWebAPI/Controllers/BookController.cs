using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Request;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _bookLoger;


        public BookController(IBookService bookRepository, ILogger<BookController> bookLoger)
        {
            _bookService = bookRepository;
            _bookLoger = bookLoger;
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddBook")]

        public IActionResult AddBook([FromBody] AddBookRequest bookRequest)
        {
            //if (authorRequest == null) return BadRequest(authorRequest);

            //var authorExist = _authorService.GetAuthorByName(authorRequest.Name);

            //if (authorExist != null) return BadRequest("Author Already Exist!");
            _bookLoger.LogInformation("Adding Book");

            var result = _bookService.AddBook(bookRequest);

            if (result.HttpStatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            return Ok(_bookLoger);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetBookById))]
        public IActionResult GetBookById(int id)
        {
            if (id <= 0) return BadRequest($"Parameter id {id} must be greater tahn 0");
            var result = _bookService.GetById(id);
            if (result == null) return NotFound(id);
            return Ok(result);
        }

    }
}
