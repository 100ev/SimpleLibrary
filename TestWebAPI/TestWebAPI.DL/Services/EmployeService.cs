using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.MsSql;
using TestWebAPI.Model.Models.Users;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.DL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IConfiguration _configuration;
        public EmployeeService(IEmployeeRepository employeeRepository, IConfiguration configuration, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _configuration = configuration;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
              _logger = logger; ;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var allEmployees = await _employeeRepository.GetAllEmployees();
            return allEmployees;
            
        }

        public async Task<Employee> GetById(int id)
        {
            var getEmployeeById = await _employeeRepository.GetById(id);
            return getEmployeeById;
        }

        public async Task<UserInfo> GetUSerInfoAsync(string name, string password)
        {
            var getEmployeeInfo = _employeeRepository.GetUSerInfoAsync(name, password);
            return await getEmployeeInfo;
        }
    }
}
