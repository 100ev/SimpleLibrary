using System.Net;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

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
        public AddBookResponse AddBook(AddBookRequest bookRequest)
        {
            try
            {
                var book = _bookRepository.GetById(bookRequest.Id);
                if (book != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };


                var bookMapper = _mapper.Map<Book>(bookRequest);
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

        public AddBookResponse? DeletBook(AddBookRequest bookRequest,int id)
        {
            
            try
            {
                var book = new Book();

                if (book != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                
                var mapBook = _mapper.Map<Book>(bookRequest);

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

        public IEnumerable<AddBookResponse> GetAllBooks(IEnumerable<AddBookRequest> bookRequests)
        {

            List<AddBookResponse> autors = new List<AddBookResponse>();
            return autors;
        }

        public AddBookResponse GetById(int id)
        {
            try
            {
                var book = new Book();

                if (book != null || id >= 0)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mapBook = _mapper.Map<Book>(id);

                _bookRepository.GetById(book.Id);

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

        public AddBookResponse? UpdateBook(AddBookRequest book, int id)
        {
            try
            {
                var newBook = new Book();

                if (book != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mapBook = _mapper.Map<Book>(newBook);
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
