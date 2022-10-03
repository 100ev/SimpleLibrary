using BookStore.BL.Interfaces;
using TestWebAPIModels.Models;

namespace BookStore.BL.Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _personRepository;
        public void AddUsers(Person user)
        {
            _personRepository.Add(user);
        }

        public void DeletUser(int userId)
        {
            var user = _personRepository.FirstOrDefault(u => u.Id == userId);
            _personRepository.Remove(user);
        }

        public IEnumerable<Person> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Person? UpdateUser(Person user)
        {
            throw new NotImplementedException();
        }

       

        Person? IPersonService.DeletUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}