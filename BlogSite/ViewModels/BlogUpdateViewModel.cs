using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels
{
    public class BlogUpdateViewModel
    {
        [Required]
        public IFormFile? ImageFile { get; set; }
        [Required, MaxLength(64)]
        public string? Title { get; set; }
        [Required, MaxLength(128)]
        public string? Text { get; set; }
        [Required, MaxLength(64)]
        public string? Creator { get; set; }
    }
}
