using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels.BlogViewModel
{
    public class BlogDetailsViewModel
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Text { get; set; }
        public string? Creator { get; set; }
    }
}
