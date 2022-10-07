using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Model.Models.Users;

namespace TestWebAPI.DL.Interfaces
{
    public interface IUserService
    {
       

        public Task<UserInfo> GetUSerInfoAsync(string name, string email);
    }
}
