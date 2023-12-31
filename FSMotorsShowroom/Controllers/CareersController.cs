﻿using System;
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
    public class CareersController : Controller
    {
        private readonly FSDbContext _context;

        public CareersController(FSDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return _context.careers != null ? 
                          View(await _context.careers.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.careers'  is null.");
        }
        public async Task<IActionResult> AllCareers()
        {
              return _context.careers != null ? 
                          View(await _context.careers.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.careers'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.careers == null)
            {
                return NotFound();
            }

            var career = await _context.careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }
            ViewBag.careerId = new SelectList(_context.careers, "Id", "Position");
            return View(career);
        }

        // GET: Careers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Position,Description")] Career career)
        {
            if (ModelState.IsValid)
            {
                _context.Add(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.careers == null)
            {
                return NotFound();
            }

            var career = await _context.careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }
            return View(career);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position,Description")] Career career)
        {
            if (id != career.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(career);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerExists(career.Id))
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
            return View(career);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.careers == null)
            {
                return NotFound();
            }

            var career = await _context.careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.careers == null)
            {
                return Problem("Entity set 'FSDbContext.careers'  is null.");
            }
            var career = await _context.careers.FindAsync(id);
            if (career != null)
            {
                _context.careers.Remove(career);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerExists(int id)
        {
          return (_context.careers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
