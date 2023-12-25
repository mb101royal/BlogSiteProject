using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels.AuthViewModel
{
    public class Login
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
