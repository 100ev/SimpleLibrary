using System.Net;
using AutoMapper;
using BookStore.BL.Interfaces;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Services
{
    internal class AuthorService : IAuthorService
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        
        public AuthorService(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public AddAuthorResponse AddAutor(AddAuthorRequest autorRequest)
        {
            var auth = _authorService.GetAuthorByName(autorRequest.Name);

            if (auth != null)
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Author already exist"
                };

            var result = _authorService.AddAutor(autorRequest);

            var author = _mapper.Map<Author>(result);

            return new AddAuthorResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
                Author = author
            };
        }

        public AddAuthorResponse? DeletAutor(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddAuthorResponse> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public AddAuthorResponse? GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public AddAuthorResponse GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public AddAuthorResponse? UpdateAutor(AddAuthorRequest autorRequest)
        {
            var auth = _authorService.GetAuthorByName(autorRequest.Name);

            if (auth != null)
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Author already exist"
                };

            var result = _authorService.AddAutor(autorRequest);

            var author = _mapper.Map<Author>(result);

            return new AddAuthorResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
                Author = author
            };
        }

        public AddAuthorResponse GetAuthroById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
