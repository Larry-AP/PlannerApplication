using Microsoft.AspNetCore.Mvc;
using PlannerApplication.Models;
using System.Diagnostics;

namespace PlannerApplication.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            // Pass the current date and time to the view
            var currentDate = DateTime.Now;
            return View(currentDate);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
