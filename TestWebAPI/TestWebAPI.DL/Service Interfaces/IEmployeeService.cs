using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Model.Models.Users;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        public Task<Employee> GetById(int id);

        public Task<UserInfo> GetUSerInfoAsync(string name, string password);
    }
}
