using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels.AuthViewModel
{
    public class Register : IdentityUser
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required, RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$")]
        public string? Password { get; set; }

        [Required, RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"), Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
