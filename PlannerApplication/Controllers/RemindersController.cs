using Microsoft.AspNetCore.Mvc;
using PlannerApplication.Models;
using PlannerApplication.Data;

namespace PlannerApplication.Controllers
{
    public class RemindersController : Controller
    {
        //Come back and change to DbContext file name
        private readonly PlannerApplicationDbContext _context;

        public RemindersController(PlannerApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reminders = _context.Reminders.ToList();
            return View(reminders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reminders reminder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reminder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reminder);
        }

        public IActionResult Edit(int id)
        {
            var reminder = _context.Reminders.Find(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return View(reminder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reminders reminder)
        {
            if (id != reminder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(reminder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reminder);
        }

        public IActionResult Details(int id)
        {
            var reminder = _context.Reminders.Find(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return View(reminder);
        }

        public IActionResult Delete(int id)
        {
            var reminder = _context.Reminders.Find(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return View(reminder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reminder = _context.Reminders.Find(id);
            if (reminder == null)
            {
                return NotFound();
            }

            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}