using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;
using static FSMotorsShowroom.Models.Car;
using Microsoft.AspNetCore.Authorization;

namespace FSMotorsShowroom.Controllers
{
    [Authorize(Roles = "Admin")]

    public class InvestmentsController : Controller
    {
        private readonly FSDbContext _context;

        public InvestmentsController(FSDbContext context)
        {
            _context = context;
        }

        // GET: Investments
       // [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Index()
        {
            var fSDbContext = _context.investments.Include(i => i.Car).Include(i => i.Investor);
            return View(await fSDbContext.ToListAsync());
        }

        // GET: Investments/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.investments == null)
            {
                return NotFound();
            }

            var investment = await _context.investments
                .Include(i => i.Car)
                .Include(i => i.Investor)
                .FirstOrDefaultAsync(m => m.InvestmentId == id);
            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // GET: Investments/Create
        public IActionResult Create()
        {
            ViewBag.CarStatusEnum = GetCarStatusEnum();
            ViewData["CarId"] = new SelectList(_context.cars, "CarId", "Name");
            ViewData["InvestorId"] = new SelectList(_context.investors, "InvestorId", "InvestorName");
            return View();
        }

        // POST: Investments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvestmentId,BuyingPrice,SellingPrice,MaintananceCost,ShowroomCost,SalesTax,SoldDate,CarStatus,CarId,InvestorId")] Investment investment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.cars, "CarId", "Name", investment.CarId);
            ViewData["InvestorId"] = new SelectList(_context.investors, "InvestorId", "InvestorName", investment.InvestorId);
            return View(investment);
        }

        // GET: Investments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.investments == null)
            {
                return NotFound();
            }

            var investment = await _context.investments.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.cars, "CarId", "Name", investment.CarId);
            ViewData["InvestorId"] = new SelectList(_context.investors, "InvestorId", "InvestorName", investment.InvestorId);
            return View(investment);
        }

        // POST: Investments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvestmentId,BuyingPrice,SellingPrice,MaintananceCost,ShowroomCost,SalesTax,SoldDate,CarStatus,CarId,InvestorId")] Investment investment)
        {
            if (id != investment.InvestmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentExists(investment.InvestmentId))
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
            ViewData["CarId"] = new SelectList(_context.cars, "CarId", "Name", investment.CarId);
            ViewData["InvestorId"] = new SelectList(_context.investors, "InvestorId", "InvestorName", investment.InvestorId);
            return View(investment);
        }

        // GET: Investments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.investments == null)
            {
                return NotFound();
            }

            var investment = await _context.investments
                .Include(i => i.Car)
                .Include(i => i.Investor)
                .FirstOrDefaultAsync(m => m.InvestmentId == id);
            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.investments == null)
            {
                return Problem("Entity set 'FSDbContext.investments'  is null.");
            }
            var investment = await _context.investments.FindAsync(id);
            if (investment != null)
            {
                _context.investments.Remove(investment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentExists(int id)
        {
          return (_context.investments?.Any(e => e.InvestmentId == id)).GetValueOrDefault();
        }
        [HttpGet, ActionName("GetCarDetails")]
        public JsonResult GetCarDetails(int carId)
        {
            // Query your database or data source to retrieve car details
            var carDetails = _context.cars.Where(c => c.CarId == carId).FirstOrDefault();

            if (carDetails != null)
            {
                // Return the data as JSON
                return Json(new
                {
                    BuyingPrice = carDetails.BuyingPrice,
                    SellingPrice = carDetails.SellingPrice,
                    MaintananceCost = carDetails.MaintananceCost,
                    ShowroomCost = carDetails.ShowroomCost,
                    SalesTax = carDetails.SalesTax
                });
            }

            // Handle the case when the car is not found
            return Json(null);
        }
        private List<SelectListItem> GetCarStatusEnum()
        {
            var carStatusEnum = Enum.GetValues(typeof(CarStatusEnum)).Cast<CarStatusEnum>();
            var items = carStatusEnum.Select(type => new SelectListItem
            {
                Text = type.ToString(),
                Value = type.ToString()
            }).ToList();

            return items;
        }
    }
}
