using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
