using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels.BlogViewModel
{
    public class BlogCreateViewModel
    {
        [Required]
        [DisplayName("Image File")]
        public IFormFile? ImageFile { get; set; }
        [Required, MaxLength(64)]
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required, MaxLength(128)]
        public string? Text { get; set; }
        [Required, MaxLength(64)]
        public string? Creator { get; set; }
    }
}
