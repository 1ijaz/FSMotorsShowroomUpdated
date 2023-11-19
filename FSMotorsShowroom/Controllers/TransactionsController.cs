using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;
using static FSMotorsShowroom.Models.Investor;
using static FSMotorsShowroom.Models.Transaction;
using Microsoft.AspNetCore.Authorization;

namespace FSMotorsShowroom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TransactionsController : Controller
    {
        private readonly FSDbContext _context;

        public TransactionsController(FSDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
              return _context.transactions != null ? 
                          View(await _context.transactions.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.transactions'  is null.");
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewBag.carInfo = GetCarInfo();
            ViewBag.TransactionTypeList = GetTransactionTypeList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transactions == null)
            {
                return Problem("Entity set 'FSDbContext.transactions'  is null.");
            }
            var transaction = await _context.transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
          return (_context.transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
        private List<SelectListItem> GetTransactionTypeList()
        {
            var transactionTypeList = Enum.GetValues(typeof(TransactionTypeList)).Cast<TransactionTypeList>();
            var items = transactionTypeList.Select(type => new SelectListItem
            {
                Text = type.ToString(),
                Value = type.ToString()
            }).ToList();

            return items;
        }
        private List<SelectListItem> GetCarInfo()
        {
            // Assuming Investor is the entity representing your "investors" table
            var car = _context.cars.ToList();

            var items = car.Select(car => new SelectListItem
            {
                Text = car.Name,
                Value = car.Name
            }).ToList();

            return items;
        }

    }
}
