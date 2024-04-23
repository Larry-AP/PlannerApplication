using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerApplication.Data;
using PlannerApplication.Models;
using System.Diagnostics;

namespace PlannerApplication.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            // Pass the current date and time to the view
            /*var currentDate = DateTime.Now;
            return View(currentDate);*/

            // Pass SQL data to view
            var model = new HomePageViewModel();

            using (var context = new PlannerApplicationDbContext())
            {
                SQLUserData sqlData = new SQLUserData(context);
                model.Users = sqlData.GetAll();
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Adding in SQL classes and methods
        public class SQLUserData
        {
            private PlannerApplicationDbContext _context { get; set; }
            public SQLUserData(PlannerApplicationDbContext context)
            {
                _context = context;
            }
            public void Add(User use) { _context.Add(use); _context.SaveChanges(); }
            public User Get(string id)
            {
                return _context.Users.FirstOrDefault(u => u.Id == id);
            }
            public IEnumerable<User> GetAll()
            {
                return _context.Users.ToList<User>();
            }
        }
        // Displaying SQL data
        public class HomePageViewModel
        {
            public IEnumerable<User> Users { get; set; }
        }
    }

}
