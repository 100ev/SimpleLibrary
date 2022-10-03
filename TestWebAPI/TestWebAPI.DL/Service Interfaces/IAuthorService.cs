using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AddAuthorResponse> GetAllAuthors();

        AddAuthorResponse GetAuthroById(int id);

        AddAuthorResponse AddAutor(AddAuthorRequest user);


        AddAuthorResponse? UpdateAutor(AddAuthorRequest user);


        AddAuthorResponse? DeletAutor(int userId);

        AddAuthorResponse? GetAuthorByName(string name);
    }

}
