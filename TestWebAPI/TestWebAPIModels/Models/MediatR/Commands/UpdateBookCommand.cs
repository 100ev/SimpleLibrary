using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record UpdateBookCommand(int bookId) : IRequest<Book>
    {

    }
}
