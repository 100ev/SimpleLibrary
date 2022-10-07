using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Model.Models.Users
{
    public class Employee
    {
        public int NationalIDNumber { get; set; }
        public string EmployeeName { get; set; }
        public int LoginID { get; set; }
        public string JobTitle { get; set; }

        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }

        public string Gender { get; set; }

        public DateTime HireDate { get; set; }
        public int VacationHours { get; set; }

        public int SickLeaveHours { get; set; }
        public Guid Rowguid{ get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
