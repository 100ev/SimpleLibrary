using TestWebAPI.Model.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IPersonService
    {
       
        IEnumerable<AddAuthorResponse> GetAllUsers();

        AddAuthorResponse GetById(int id);

        AddAuthorResponse AddUsers(AddAuthorResponse user);


        AddAuthorResponse? UpdateUser(AddAuthorRequest user);


        AddAuthorResponse? DeletUser(int userId);
    }
}
