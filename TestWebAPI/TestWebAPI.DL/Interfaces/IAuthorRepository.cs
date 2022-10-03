using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();

        Author GetById(int id);

        Author AddUsers(Author user);


        Author? UpdateUser(Author user);


        Author? DeletUser(int userId);
    }
}
