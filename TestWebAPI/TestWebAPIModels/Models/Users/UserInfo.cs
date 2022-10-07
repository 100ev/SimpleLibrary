using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Model.Models.Users
{
    public class UserInfo
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        
    }
}
