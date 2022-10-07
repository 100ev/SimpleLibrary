using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Model.Models.Users;

namespace TestWebAPI.DL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        public Task<Employee> GetById(int id);

        Task<Employee> AddEmployee(Employee employee);


        public Task<Employee>? UpdateEmployee(int id);


        public Task<Employee>? DeletEMployee(int Id);

        public Task<Employee?> GetEmployeeByName(string name);
        public Task<UserInfo> GetUSerInfoAsync(string name, string password);

    }
}
