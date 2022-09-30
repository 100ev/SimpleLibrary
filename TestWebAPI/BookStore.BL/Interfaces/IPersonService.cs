namespace BookStore.BL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<Person> GetAllUsers();

        Person GetById(int id);

        Person AddUsers(Person user);


        Person? UpdateUser(Person user);


        Person? DeletUser(int userId);
    }
}
