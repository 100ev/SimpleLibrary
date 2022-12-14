using System.Net;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.DL.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _bookLoger;


        public BookService(IBookRepository bookService, IMapper mapper, ILogger<BookService> bookLoger)
        {
            _bookRepository = bookService;
            _mapper = mapper;
            _bookLoger = bookLoger;
        }
        public async Task<AddBookResponse> AddBook(Model.Request.AddBookRequest bookRequest)
        {
            try
            {
                var book = _bookRepository.GetById(bookRequest.Id);
                if (book != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };


                var bookMapper = _mapper.Map<TestWebAPIModels.Models.Book>(bookRequest);
                _bookRepository.AddBook(bookMapper);


                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Title = bookMapper
                };
            }
            catch (Exception)
            {
                _bookLoger.LogError("Book can't be added");
            }

            return null;

        }

        public async Task<AddBookResponse>? DeletBook(Model.Request.AddBookRequest bookRequest,int id)
        {            
            try
            {
                if (bookRequest != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                
                var mapBook = _mapper.Map<TestWebAPIModels.Models.Book>(bookRequest);

                _bookRepository.RemoveBook(id);

                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                _bookLoger.LogError("");
            }
            return null;
        }

        public async Task<AddBookResponse> GetAllBooks()
        {
            try
            {
                if (_bookRepository == null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.NotFound
                    };
                var result = await _bookRepository.GetAlBooks();
                var books = _mapper.Map<TestWebAPIModels.Models.Book>(result);
                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                _bookLoger.LogError("book collection does not exit");
            }
            return null;

        }

        public async Task<AddBookResponse> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mapBook = _mapper.Map<TestWebAPIModels.Models.Book>(id);

               await _bookRepository.GetById(id);

                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                _bookLoger.LogError("There is no book with the represented Id");
            }
            return null;
        }

        public async Task<AddBookResponse>? UpdateBook(Model.Request.AddBookRequest book, int id)
        {
            try
            {
                var newBook = new TestWebAPIModels.Models.Book();

                if (book != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mapBook = _mapper.Map<TestWebAPIModels.Models.Book>(newBook);
                _bookRepository.UpdateBook(id);

                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                _bookLoger.LogError("The book can't be updated");
            }
            return null;
        }
    }
}
