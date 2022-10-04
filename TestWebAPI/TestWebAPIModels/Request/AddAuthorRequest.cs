using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Model.Request
{
    public class AddAuthorRequest
    {
        public string Name { get; set; }
        public string NickName { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }
        public DateTime DateOfBith { get; set; }
    }
}
