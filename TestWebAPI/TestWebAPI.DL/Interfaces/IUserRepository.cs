using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IUserRepository
    {
         IEnumerable<Person> GetAllUsers();

         Person GetById(int id);

         Person AddUsers(Person user);


         Person? UpdateUser(Person user);

       
    }
}
