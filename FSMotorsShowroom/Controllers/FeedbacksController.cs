using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Authorization;

namespace FSMotorsShowroom.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly FSDbContext _context;

        public FeedbacksController(FSDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
              return _context.feedbacks != null ? 
                          View(await _context.feedbacks.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.feedbacks'  is null.");
        }

        // GET: Feedbacks/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Contact,Description")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                try
                {
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Thank you for Feedback!";
                }
                catch (DbUpdateException ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving to the database: " + ex.Message;
                }

                return View();

               // return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }
        [Authorize(Roles = "Admin")]
        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,Description")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Id))
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
            return View(feedback);
        }
        [Authorize(Roles = "Admin")]
        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }
        [Authorize(Roles = "Admin")]
        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.feedbacks == null)
            {
                return Problem("Entity set 'FSDbContext.feedbacks'  is null.");
            }
            var feedback = await _context.feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.feedbacks.Remove(feedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
          return (_context.feedbacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
