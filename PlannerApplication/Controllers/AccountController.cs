using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
