using BlogSite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
