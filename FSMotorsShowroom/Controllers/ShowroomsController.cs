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
    [Authorize(Roles = "Admin")]
    public class ShowroomsController : Controller
    {
        private readonly FSDbContext _context;

        public ShowroomsController(FSDbContext context)
        {
            _context = context;
        }

        // GET: Showrooms
        public async Task<IActionResult> Index()
        {
              return _context.Showroom != null ? 
                          View(await _context.Showroom.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.Showroom'  is null.");
        }

        // GET: Showrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Showroom == null)
            {
                return NotFound();
            }

            var showroom = await _context.Showroom
                .FirstOrDefaultAsync(m => m.ShowroomId == id);
            if (showroom == null)
            {
                return NotFound();
            }

            return View(showroom);
        }

        // GET: Showrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Showrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowroomId,ShowroomName,ShowroomAddress")] Showroom showroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showroom);
        }

        // GET: Showrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Showroom == null)
            {
                return NotFound();
            }

            var showroom = await _context.Showroom.FindAsync(id);
            if (showroom == null)
            {
                return NotFound();
            }
            return View(showroom);
        }

        // POST: Showrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowroomId,ShowroomName,ShowroomAddress")] Showroom showroom)
        {
            if (id != showroom.ShowroomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowroomExists(showroom.ShowroomId))
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
            return View(showroom);
        }

        // GET: Showrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Showroom == null)
            {
                return NotFound();
            }

            var showroom = await _context.Showroom
                .FirstOrDefaultAsync(m => m.ShowroomId == id);
            if (showroom == null)
            {
                return NotFound();
            }

            return View(showroom);
        }

        // POST: Showrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Showroom == null)
            {
                return Problem("Entity set 'FSDbContext.Showroom'  is null.");
            }
            var showroom = await _context.Showroom.FindAsync(id);
            if (showroom != null)
            {
                _context.Showroom.Remove(showroom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowroomExists(int id)
        {
          return (_context.Showroom?.Any(e => e.ShowroomId == id)).GetValueOrDefault();
        }
    }
}
