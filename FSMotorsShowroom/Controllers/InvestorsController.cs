using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Authorization;
using static FSMotorsShowroom.Models.Car;
using static FSMotorsShowroom.Models.Investor;

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
        public async Task<IActionResult> GetInvestor()
        {
            return _context.investors != null ?
                        View(await _context.investors.ToListAsync()) :
                        Problem("Entity set 'FSDbContext.investors'  is null.");
        }
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
            ViewBag.StatusList = GetStatusList();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Investor investor)
        {
            //  if (ModelState.IsValid)
            //  {
            investor.InvestUnallocatedAmount = investor.TotalInvestAmount - investor.InvestAllocatedAmount;
                _context.Add(investor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         //   }
          //  return View(investor);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.investors == null)
            {
                return NotFound();
            }
            ViewBag.StatusList = GetStatusList();
            var investor = await _context.investors.FindAsync(id);
            if (investor == null)
            {
                return NotFound();
            }
            investor.InvestUnallocatedAmount = investor.TotalInvestAmount - investor.InvestAllocatedAmount;
            return View(investor);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Investor investor)
        {
            if (id != investor.InvestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    investor.InvestUnallocatedAmount = investor.TotalInvestAmount - investor.InvestAllocatedAmount;
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
        private List<SelectListItem> GetStatusList()
        {
            var statusList = Enum.GetValues(typeof(StatusList)).Cast<StatusList>();
            var items = statusList.Select(type => new SelectListItem
            {
                Text = type.ToString(),
                Value = type.ToString()
            }).ToList();

            return items;
        }
        public IActionResult FindInvestors(decimal minProfit)
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            var investors = _context.investors
                                     .Where(i => i.InvestorEmail == userEmail)
                                     .ToList();

            return View(investors);
        }
    }
}
