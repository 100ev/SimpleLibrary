using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPIModels;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IUserRepository
    {
         IEnumerable<Person> GetAllUsers();

         Person GetById(int id);

         Person AddUsers(Person user);


         Person? UpdateUser(Person user);


         Book? DeletUser(int userId);
       
    }
}
