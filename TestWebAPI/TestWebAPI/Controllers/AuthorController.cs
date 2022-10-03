using System.Net;
using System.Net.NetworkInformation;
using AutoMapper;
using BookStore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestWebAPIModel.Request;
using TestWebAPIModels.Models;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorRepository, ILogger<AuthorController> logger, IMapper mapper)
        {
            _authorService = authorRepository;
            _logger = logger;
        _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            _logger.LogInformation("Log in");
            return Ok(_authorService.GetAllAuthors());

        }

        public IActionResult AddAuthorrange([FromBody] 
        AddMultipleAuthosrRequest addMultipleAuthors)
        {
            if (addMultipleAuthors == null && !addMultipleAuthors.AuthorRequest.Any())
                return BadRequest(addMultipleAuthors);
            var authroCollection = _mapper.Map<IEnumerable<Author>>(addMultipleAuthors);

            var result = _authorService.AddMultipleAuthors(authroCollection);
            if(!result) return BadRequest(result);

            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddAuthor")]

        public IActionResult AddAuthor([FromBody] AddMultipleAuthosrRequest authorRequest)
        {
            //if (authorRequest == null) return BadRequest(authorRequest);

            //var authorExist = _authorService.GetAuthorByName(authorRequest.Name);

            //if (authorExist != null) return BadRequest("Author Already Exist!");

            var result = _authorService.AddAutor(authorRequest);

            if (result.HttpStatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetAuthroById))]
        public IActionResult GetAuthroById(int id)
        {
            if (id <= 0) return BadRequest($"Parameter id {id} must be greater tahn 0");
            var result = _authorService.GetAuthroById(id);
            if (result == null) return NotFound(id);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(UpdateAuthor))]

        public IActionResult UpdateAuthor(string autName)
        {
            var name = _authorService.GetAuthorByName(autName);
            return Ok(name);
        }

    }
}
