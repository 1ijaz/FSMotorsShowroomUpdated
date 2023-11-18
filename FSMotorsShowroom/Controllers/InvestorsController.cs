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

    public class InvestorsController : Controller
    {
        private readonly FSDbContext _context;

        public InvestorsController(FSDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: Investors
        public async Task<IActionResult> Index()
        {
              return _context.investors != null ? 
                          View(await _context.investors.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.investors'  is null.");
        }
        [Authorize(Roles = "Admin")]
        // GET: Investors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.investors == null)
            {
                return NotFound();
            }

            var investor = await _context.investors
                .FirstOrDefaultAsync(m => m.InvestorId == id);
            if (investor == null)
            {
                return NotFound();
            }

            return View(investor);
        }
        [Authorize(Roles = "Admin")]
        // GET: Investors/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvestorId,InvestorName,InvestorEmail,InvestorContact,InvestorAddress,InvestUnallocatedAmount,TotalInvestAmount")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investor);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.investors == null)
            {
                return NotFound();
            }

            var investor = await _context.investors.FindAsync(id);
            if (investor == null)
            {
                return NotFound();
            }
            return View(investor);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvestorId,InvestorName,InvestorEmail,InvestorContact,InvestorAddress,InvestUnallocatedAmount,TotalInvestAmount")] Investor investor)
        {
            if (id != investor.InvestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestorExists(investor.InvestorId))
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
            return View(investor);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.investors == null)
            {
                return NotFound();
            }

            var investor = await _context.investors
                .FirstOrDefaultAsync(m => m.InvestorId == id);
            if (investor == null)
            {
                return NotFound();
            }

            return View(investor);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.investors == null)
            {
                return Problem("Entity set 'FSDbContext.investors'  is null.");
            }
            var investor = await _context.investors.FindAsync(id);
            if (investor != null)
            {
                _context.investors.Remove(investor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestorExists(int id)
        {
          return (_context.investors?.Any(e => e.InvestorId == id)).GetValueOrDefault();
        }
        public IActionResult InvestorDashboard()
        {
            return View();
        }
    }
}
