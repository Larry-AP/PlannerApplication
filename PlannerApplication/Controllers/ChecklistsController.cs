using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class ChecklistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
