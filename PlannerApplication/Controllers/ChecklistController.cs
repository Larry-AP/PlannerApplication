using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class ChecklistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
