using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class RemindersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
