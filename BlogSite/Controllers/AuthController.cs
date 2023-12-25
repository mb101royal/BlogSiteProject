using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AuthController : Controller
    {

        // Register:

        // Get
        public IActionResult Register()
        {
            return View();
        }

        /*// Post
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return View();
        }*/

        // Login:

        // Get
        public IActionResult Login()
        {
            return View();
        }

        /*// Post
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return View();
        }*/
    }
}
