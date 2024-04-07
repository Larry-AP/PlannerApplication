using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
