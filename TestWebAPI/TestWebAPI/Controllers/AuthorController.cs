using System.Net;
using System.Net.NetworkInformation;
using AutoMapper;
using BookStore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Model.Request;
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
        public async Task<IActionResult> GetAllAuthors()
        {
             _logger.LogInformation("Log in");
            return Ok(_authorService.GetAllAuthors());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddAutorRange")]
        public async Task<IActionResult> AddAuthorrange([FromBody] 
        AddMultipleAuthosrRequest addMultipleAuthors)
        {
            if (addMultipleAuthors == null && !addMultipleAuthors.AuthorRequest.Any())
                return  BadRequest(addMultipleAuthors);

            var result =await _authorService.AddMultipleAuthors(addMultipleAuthors.AuthorRequest);
            if(result == null) return BadRequest(result);

            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddAuthor")]

        public async  Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest authorRequest)
        {          
            var result =await _authorService.AddAutor(authorRequest);

            if (result.HttpStatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetAuthroById))]
        public async Task<IActionResult> GetAuthroById(int id)
        {            
            if (id <= 0) return BadRequest($"Parameter id {id} must be greater tahn 0");
            var result =await _authorService.GetAuthroById(id);
            if (result == null) return NotFound(id);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(UpdateAuthor))]
        public async Task<IActionResult> UpdateAuthor(AddAuthorRequest autName)
        {
            var name = _authorService.GetAuthorByName(autName);
            await name;
            return Ok(name);
        }

    }
}
