using Microsoft.AspNetCore.Identity;

namespace TestWebAPI.Model.Models.Users
{
    public class UserRole : IdentityRole
    {
        public int UserId { get; set; }
    }
}
