using TestWebAPI.Model.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IPersonService
    {
       
        IEnumerable<AddAuthorResponse> GetAllUsers();

        public Task<AddAuthorResponse> GetById(int id);

        public Task<AddAuthorResponse> AddUsers(AddAuthorResponse user);


        public Task<AddAuthorResponse>? UpdateUser(AddAuthorRequest user);


        public Task<AddAuthorResponse>? DeletUser(int userId);
    }
}
