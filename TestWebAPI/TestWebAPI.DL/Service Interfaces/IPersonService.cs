using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IPersonService
    {
       
        IEnumerable<Person> GetAllUsers();

        Person GetById(int id);

        void AddUsers(Person user);


        Person? UpdateUser(Person user);


        Person? DeletUser(int userId);
    }
}
