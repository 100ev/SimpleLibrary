using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Services
{
    internal class BookService : IBookService
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _bookLoger;

        public BookService(IBookService bookService, IMapper mapper, ILogger<BookService> bookLoger)
        {
            _bookService = bookService;
            _mapper = mapper;
            _bookLoger = bookLoger;
        }
        public AddBookResponse Add(AddBookRequest bookRequest)
        {
            try
            {
                var book = _bookService.GetById(bookRequest.id);

                if (book != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var result = _bookService.AddBook(bookRequest);

                var finalBook = _mapper.Map<Book>(result);

                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Title = finalBook
                };
            }
            catch (Exception)
            {
                _bookLoger.LogError("Book already exists");                
            }

            return null;
            
        }

        public AddBookResponse AddBook(AddBookRequest book)
        {
            throw new NotImplementedException();
        }

        public AddBookResponse? DeletBook(AddBookRequest userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddBookResponse> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AddBookResponse? UpdateBook(AddBookRequest user)
        {
            throw new NotImplementedException();
        }
    }
}
