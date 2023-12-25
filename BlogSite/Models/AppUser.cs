using Microsoft.AspNetCore.Identity;

namespace BlogSite.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
