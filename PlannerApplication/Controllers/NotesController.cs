using Microsoft.AspNetCore.Mvc;

namespace PlannerApplication.Controllers
{
    public class NotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
