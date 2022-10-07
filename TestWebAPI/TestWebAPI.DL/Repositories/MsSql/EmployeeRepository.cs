using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.BL.Services;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.Users;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.MsSql
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IMapper mapper, ILogger<EmployeeRepository> logger, IConfiguration configuration)
        {
            
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        string query =
                       @"UPDATE [dbo].[Employee]
                       SET [EmployeeID] = @EmployeeID
                          ,[NationalIDNumber] = @NationalIDNumber
                          ,[EmployeeName] = @EmployeeName
                          ,[LoginID] = @LoginID
                          ,[JobTitle] = @JobTitle
                          ,[BirthDate] = @BirthDate
                          ,[MaritalStatus] = @MaritalStatus
                          ,[Gender] = @Gender
                          ,[HireDate] = @HireDate
                          ,[VacationHours] = @VacationHours
                          ,[SickLeaveHours] = @SickLeaveHours
                          ,[rowguid] = @rowguid
                          ,[ModifiedDate] = @ModifiedDate
                     WHERE EmployeeID = @EmployeeID";

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var results = new List<Employee>();
            results.Add(employee);
            return null;
        }

        public async Task<Employee>? DeletEMployee(int Id)
        {
            var employees = new List<Employee>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    var author = await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", new { EmployeeID = Id });
                    foreach (var employee in employees)
                    {
                        if (employee.LoginID == Id)
                        {
                            employees.Remove(employee);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(DeletEMployee)}-{e.Message}", e);
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    await conn.OpenAsync();
                    return await conn.QueryAsync<Employee>("SELECT * FROM Employee");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllEmployees)}-{e.Message}", e);
            }

            return null;
        }

        public async Task<Employee> GetById(int id)
        {
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    await conn.OpenAsync();
                    var result = await conn.QueryFirstOrDefaultAsync<Employee>("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", new { EmployeeID = id });
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetById)}-{e.Message}", e);
            }

            return null;

        }

        public async Task<Employee?> GetEmployeeByName(string name)
        {
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    var result = await conn.QueryFirstOrDefaultAsync<Employee>("SELECT * FROM Employee WHERE EmployeeName = @EmployeeName", new { EmployeeName = name });
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetEmployeeByName)}-{e.Message}", e);
            }
            return null;
        }

        public async Task<Employee>? UpdateEmployee(int id)
        {            
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    var result = await conn.QueryFirstOrDefaultAsync<Employee>("SELECT * FROM Employee WHERE EmployeeID = @EmployeeID", new { EmployeeID = id });
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(UpdateEmployee)}-{e.Message}", e);
            }

            return null;
        }

        public async Task<UserInfo> GetUSerInfoAsync(string email, string password)
        {
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    await conn.OpenAsync();
                    var result = await conn.QueryFirstOrDefaultAsync<UserInfo>("SELECT * FROM UserInfo WHERE Email = @Email AND  Password = @Password", new { Email = email, Password = password});
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetUSerInfoAsync)}-{e.Message}", e);
            }

            return null;
        }
    }
}
