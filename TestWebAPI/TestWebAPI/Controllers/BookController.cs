using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _bookLoger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BookController(IBookService bookRepository, ILogger<BookController> bookLoger, IMapper mapper, IMediator mediator)
        {
            _bookService = bookRepository;
            _bookLoger = bookLoger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _mediator.Send(new GetAllBooksCommand()));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddBook")]

        public async Task<IActionResult> AddBook([FromBody] AddBookRequest bookRequest)
        {
             _bookLoger.LogInformation("Adding Book");

             var result =await _bookService.AddBook(bookRequest);
            
            if (result.HttpStatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            return Ok(_bookLoger);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetBookById))]
        public async Task<IActionResult> GetBookById(int id)
        {
            if (id <= 0) return BadRequest($"Parameter id {id} must be greater tahn 0");
            var result = await _bookService.GetById(id);
            if (result == null) return NotFound(id);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(UpdateBook))]
        public IActionResult UpdateBook(AddBookRequest bookRequests, int id)
        {
            if (id <= 0) return BadRequest("Id must be greater than 0");
            var result = _bookService.UpdateBook(bookRequests, id);
            return Ok(result);
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(DeLeteBook))]
        public async Task<IActionResult> DeLeteBook(AddBookRequest bookRequest, int id)
        {
            if (id <= 0 || bookRequest == null) return BadRequest("Invalid information");
            var result = _bookService.DeletBook(bookRequest, id);
            var returnDeBook = await _mediator.Send(new DeleteBookCommand(id));
            return Ok(result);
        }

    }
}
