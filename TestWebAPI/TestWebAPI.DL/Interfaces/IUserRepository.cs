using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IPersonRepository
    {
         Task<IEnumerable<Person>> GetAllUsers();

         Task<Person> GetById(int id);

         Task<Person> AddUsers(Person person);


         Task<Person>? UpdateUser(Person person);

        Task<Person> DeletePerson(Person person);
       
    }
}
