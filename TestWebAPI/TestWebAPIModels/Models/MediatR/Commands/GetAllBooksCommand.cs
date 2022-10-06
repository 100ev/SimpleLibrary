using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestWebAPI.Model.Request;
using TestWebAPIModels.Models;
using Book = TestWebAPIModels.Models.Book;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record GetAllBooksCommand : IRequest<IEnumerable<Book>>
    {

    }
}
