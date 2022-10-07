using MediatR;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record GetAuthorByIdCommand(int id) : IRequest<AddAuthorResponse>
    {

    }
}
