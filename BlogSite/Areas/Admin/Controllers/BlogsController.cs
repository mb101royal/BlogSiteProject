using BlogSite.Context;
using BlogSite.Models;
using BlogSite.ViewModels.BlogViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {

        BlogDbContext _context { get; }
        IWebHostEnvironment _environment { get; }

        public BlogsController(BlogDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // Index:

        public async Task<IActionResult> Index()
        {
            var blogsFromDb = await _context.Blogs.Select(blog => new BlogDetailsViewModel
            {
                CreatedAt = blog.CreatedAt,
                Title = blog.Title,
                Text = blog.Text,
                Id = blog.Id,
                ImageUrl = blog.ImageUrl,
                Creator = blog.Creator,
            }).ToListAsync();

            return View(blogsFromDb);
        }

        // Create:

        // Get
        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            string? uniqueFileName = null;

            if (vm.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.ImageFile.FileName;

                using var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Create);

                await vm.ImageFile.CopyToAsync(fs);
            }

            Blog newBlog = new()
            {
                Title = vm.Title,
                Text = vm.Text,
                CreatedAt = vm.CreatedAt,
                ImageUrl = uniqueFileName,
                Creator = vm.Creator,
            };

            await _context.AddAsync(newBlog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Update:

        // Get
        public IActionResult Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            return View();
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> Update(int? id, BlogUpdateViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            string? uniqueFileName = null;

            if (vm.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.ImageFile.FileName;

                using var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Create);

                await vm.ImageFile.CopyToAsync(fs);
            }

            Blog? blogToUpdate = await _context.Blogs.FindAsync(id);

            blogToUpdate.Text = vm.Text;
            blogToUpdate.Title = vm.Title;
            blogToUpdate.ImageUrl = uniqueFileName;
            blogToUpdate.Creator = vm.Creator;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            var blogFromDb = await _context.Blogs.FindAsync(id);

            if (blogFromDb == null) return NotFound();

            _context.Blogs.Remove(blogFromDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // TODO: 

        /* public void DeleteFile(string filePath)
         {
             var filePath = Server.MapPath("~/Images/" + uniquefilename);

             if (File.Exists(filePath))
             {
                 File.Delete(filePath);
             }
         }*/
    }
}
