using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FSMotorsShowroom.Controllers
{
    public class AccountController : Controller
    {
        private readonly FSDbContext _context;

        public AccountController(FSDbContext context)
        {
            _context = context;
        }

        // GET: Account/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Account/GetAllAccounts (For DataTable)
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _context.users.Select(a => new
            {
                a.UserId,
                a.FirstName,
                a.LastName,
                a.Email,
                a.Phone,
                a.IsActive,
                //a.IsApproved
            }).ToList();

            return Json(accounts);
        }

        // GET: Account/AddAccount (For modal form)
        [HttpGet]
        public IActionResult AddAccount()
        {
            return PartialView("_AddAccountPartial"); // Replace with your actual partial view
        }

        // POST: Account/AddAccount (For adding a new account)
        [HttpPost]
        public async Task<IActionResult> AddAccount(User model)
        {
            if (ModelState.IsValid)
            {
                // Create and add a new account to the database
                var newAccount = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    IsActive = model.IsActive,
                  //  IsApproved = model.IsApproved
                    // Add any other properties as needed
                };

                _context.users.Add(newAccount);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // GET: Account/EditAccount/{id} (For modal form)
        [HttpGet]
        public async Task<IActionResult> EditAccount(int id)
        {
            var account = await _context.users.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            var model = new User
            {
                UserId = account.UserId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Phone = account.Phone,
                IsActive = account.IsActive,
               // IsApproved = account.IsApproved
                // Add any other properties as needed
            };

            return PartialView("_EditAccountPartial", model); // Replace with your actual partial view
        }

        // POST: Account/EditAccount/{id} (For updating an account)
        [HttpPost]
        public async Task<IActionResult> EditAccount(int id, [FromBody] User model)
        {
            if (id != model.UserId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Update the existing account in the database
                var account = await _context.users.FindAsync(id);
                if (account == null)
                {
                    return NotFound();
                }

                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.Email = model.Email;
                account.Phone = model.Phone;
                account.IsActive = model.IsActive;
               // account.IsApproved = model.IsApproved;
                // Update any other properties as needed

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // POST: Account/DeleteAccount/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.users.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.users.Remove(account);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        private bool AccountExists(int id)
        {
            return _context.users.Any(a => a.UserId == id);
        }
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }
    }
}
