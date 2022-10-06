using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestWebAPIModels.Models;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record GetAuthorByIdCommand(int id) : IRequest<Author>
    {

    }
}
