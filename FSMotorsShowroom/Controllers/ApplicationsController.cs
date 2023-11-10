using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;

namespace FSMotorsShowroom.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly FSDbContext _context;

        public ApplicationsController(FSDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var fSDbContext = _context.applications.Include(a => a.Career);
            return View(await fSDbContext.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.applications == null)
            {
                return NotFound();
            }

            var application = await _context.applications
                .Include(a => a.Career)
                .FirstOrDefaultAsync(m => m.id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            ViewData["careerId"] = new SelectList(_context.careers, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Application application)
        {
            if (ModelState.IsValid)
            {
                // Fetch the corresponding Career based on the careerId
                var career = await _context.careers.FindAsync(application.careerId);

                if (career != null)
                {
                    // Associate the career with the application
                    application.Career = career;

                    // Add the application to the context
                    _context.Add(application);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the case where the specified careerId doesn't exist
                    ModelState.AddModelError("careerId", "Invalid career selection.");
                }
            }

            // Repopulate the career dropdown
            ViewData["careerId"] = new SelectList(_context.careers, "Id", "Id", application.careerId);
            return View(application);
        }


        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.applications == null)
            {
                return NotFound();
            }

            var application = await _context.applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["careerId"] = new SelectList(_context.careers, "Id", "Id", application.careerId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,email,higEducation,Age,careerId")] Application application)
        {
            if (id != application.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.id))
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
            ViewData["careerId"] = new SelectList(_context.careers, "Id", "Id", application.careerId);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.applications == null)
            {
                return NotFound();
            }

            var application = await _context.applications
                .Include(a => a.Career)
                .FirstOrDefaultAsync(m => m.id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.applications == null)
            {
                return Problem("Entity set 'FSDbContext.applications'  is null.");
            }
            var application = await _context.applications.FindAsync(id);
            if (application != null)
            {
                _context.applications.Remove(application);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
          return (_context.applications?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
