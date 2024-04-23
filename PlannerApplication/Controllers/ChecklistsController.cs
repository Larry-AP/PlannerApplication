using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerApplication.Data;
using PlannerApplication.Models;

namespace PlannerApplication.Controllers
{
    public class ChecklistsController : Controller
    {
        //Come back and change to DbContext file name

        private readonly PlannerApplicationDbContext _context;

        public ChecklistsController(PlannerApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checklists
        public async Task<IActionResult> Index()
        {
            var checklists = await _context.Checklists.ToListAsync();
            return View(checklists);
        }

        // GET: Checklists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checklists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checklist);
        }

        // GET: Checklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklists
                .FirstOrDefaultAsync(m => m.Id == id);

            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }

        // GET: Checklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklists.FindAsync(id);

            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }

        // POST: Checklists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Checklist checklist)
        {
            if (id != checklist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChecklistExists(checklist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(checklist);
        }

        // GET: Checklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklists
                .FirstOrDefaultAsync(m => m.Id == id);

            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }

        // POST: Checklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checklist = await _context.Checklists.FindAsync(id);
            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChecklistExists(int id)
        {
            return _context.Checklists.Any(e => e.Id == id);
        }
    }
}