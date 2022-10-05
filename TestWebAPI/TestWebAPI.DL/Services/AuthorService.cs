using System.Net;
using AutoMapper;
using BookStore.BL.Interfaces;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Request;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IAuthorRepository authorService, IMapper mapper, ILogger<AuthorService> loger)
        {
            _authorService = authorService;
            _mapper = mapper;
            _logger = loger;
        }

        public AddAuthorResponse AddAutor(int autorRequest)
        {
            try
            {                
                var auth = _authorService.GetById(autorRequest);

                if (auth != null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                var author = _mapper.Map<Author>(autorRequest);
                _authorService.AddAutor(autorRequest);


                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = author
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Author already exist");
            }

            return null;
            
        }       

        public IEnumerable<AddAuthorResponse> GetAllAuthors()
        {
            List<AddAuthorResponse> autors = new List<AddAuthorResponse>();
            return autors;
        }

        public AddAuthorResponse? GetAuthorByName(AddAuthorRequest author)
        {
            try
            {
                var name = author.Name;
                if (name == null) return null;
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                };

                var autName = _mapper.Map<Author>(author);
                _authorService.GetAuthorByName(autName.Name);
            }
            catch (Exception)
            {
                _logger.LogError("There is no such author");
            }
           
            return null;           
        }            
        
        AddAuthorResponse IAuthorService.GetAuthroById(int authorId)
        {
            try
            {
                var auth = new Author();

                if (auth != null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var author = _mapper.Map<Author>(authorId);

                _authorService.GetById(author.Id);

                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = author
                };
            }
            catch (Exception)
            {
                _logger.LogError("There is no author with the represented Id");
            }
            return null;
        }

        public bool AddMultipleAuthors(IEnumerable<Author> authorsCollection)
        {
            throw new NotFiniteNumberException();
        }

        public AddAuthorResponse AddAutor(AddMultipleAuthosrRequest user)
        {
            throw new NotImplementedException();
        }

        public AddAuthorResponse? UpdateAutor(AddMultipleAuthosrRequest authorRequest, int id)
        {
            try
            {
                var auth = _authorService.GetById(id);

                if (auth != null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var author = _mapper.Map<Author>(authorRequest);

                _authorService.AddAutor(id);

                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = author
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Author already exist");
            }

            return null;
        }
    }
}
