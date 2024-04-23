using Microsoft.AspNetCore.Mvc;
using PlannerApplication.Data;

namespace PlannerApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly PlannerApplicationDbContext _context;

        public AccountController(PlannerApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
\            var userId = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound(); // User not found, handle appropriately
            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Implement logic to authenticate user
           

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
\            return RedirectToAction("Index", "Home");
        }
    }
}