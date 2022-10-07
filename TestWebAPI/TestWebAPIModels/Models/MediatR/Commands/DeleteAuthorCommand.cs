using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestWebAPIModel.Responses;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record DeleteAuthorCommand : IRequest<AddAuthorResponse>
    {
    }
}
