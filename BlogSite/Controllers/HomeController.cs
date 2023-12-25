using BlogSite.Context;
using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        BlogDbContext _context { get; }

        public HomeController(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.Select(blogFromDb => new Blog
            {
                Title = blogFromDb.Title,
                CreatedAt = blogFromDb.CreatedAt,
                Creator = blogFromDb.Creator,
                ImageUrl = blogFromDb.ImageUrl,
                Text = blogFromDb.Text
            }).ToListAsync();

            return View(blogs);
        }

    }
}