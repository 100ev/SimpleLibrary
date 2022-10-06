using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IPersonRepository
    {
         Task<IEnumerable<Person>> GetAllUsers();

         Task<Person> GetById(int id);

         Task<Person> AddUsers(Person person);


         Task<Person>? UpdateUser(int person);

        Task<Person> DeletePerson(int id);
       
    }
}
