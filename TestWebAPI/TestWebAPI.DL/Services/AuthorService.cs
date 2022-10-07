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
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;


        public AuthorService(IAuthorRepository authorService, IMapper mapper, ILogger<AuthorService> loger)
        {
            _authorRepository = authorService;
            _mapper = mapper;
            _logger = loger;
        }
        public async Task<AddAuthorResponse>? GetAuthorByName(AddAuthorRequest author)
        {
            try
            {
                var autName = await _authorRepository.GetAuthorByName(author.Name);
                if (author == null)
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                };              
                else              
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = autName
                };
            }
            catch (Exception)
            {
                _logger.LogError("There is no such author");
            }

            return null;
        }

        public async Task<AddAuthorResponse> GetAuthroById(int authorId)
        {
            try
            {
                var reslt = await _authorRepository.GetById(authorId);

                if (reslt == null)
                return new AddAuthorResponse()
                {
                   HttpStatusCode = HttpStatusCode.NotFound
                };
                else
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = reslt
                };
            }
            catch (Exception)
            {
                _logger.LogError("There is no author with the represented Id");
            }
            return null;
        }

        public async Task<AddAuthorResponse>? UpdateAutor(AddMultipleAuthosrRequest authorRequest, int id)
        {
            try
            {
                var auth = _authorRepository.GetById(id);

                if (auth != null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var author = _mapper.Map<Author>(authorRequest);

                await _authorRepository.AddAutor(author);

                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = author
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Cannot update author");
            }

            return null;
        }

        public async Task<AddAuthorResponse> GetAllAuthors()
        {
            try
            {
                if (_authorRepository == null)
                {
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.NotFound
                    };
                }
                var result = await _authorRepository.GetAllAuthors();
                var books = _mapper.Map<TestWebAPIModels.Models.Book>(result);
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                _logger.LogError("Author collection does not exit");
            }
            return null;
        }           

        public async Task<AddAuthorResponse> DeleteAuthor(AddAuthorRequest authorRequest)
        {
            try
            {
                var author = _mapper.Map<Author>(authorRequest);
                var authId = authorRequest.Id;

                var authorToDelete = await _authorRepository.DeletAutor(authId);
                if (authId <= 0)
                {
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                }
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Cannot delete author");
            }

            return null;
        }

        public async Task<AddAuthorResponse> AddAutor(AddAuthorRequest authorRequest)
        {
            try
            {                    
                var author = _mapper.Map<Author>(authorRequest);

                var returnedAuthor = await _authorRepository.AddAutor(author);
                if (returnedAuthor == null)
                {
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Author = author
                    };
                }
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = author
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Cannot add Author");
            }

            return null;
        }

        public async Task<AddAuthorResponse> AddMultipleAuthors(IEnumerable<AddAuthorRequest> authorRequest)
        {
            List<AddAuthorResponse> authors = new List<AddAuthorResponse>();
            try
            {
                if (authorRequest == null)
                {
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                }
                var author = _mapper.Map<Author>(authorRequest);

                await _authorRepository.AddMultipleAuthors(author);

                
                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                };               
            }
            catch (Exception e)
            {
                _logger.LogError("There is no collection");
            }
            var result = _mapper.Map<AddAuthorResponse>(authors);

            return result;
        }
    }
}
