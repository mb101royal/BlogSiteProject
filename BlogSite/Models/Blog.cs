using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required, MaxLength(64)]
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required, MaxLength(128)]
        public string? Text { get; set; }
        [Required, MaxLength(64)]
        public string? Creator { get; set; }
    }
}
