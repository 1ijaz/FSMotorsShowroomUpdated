using FSMotorsShowroom.Models;
using FSMotorsShowroom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FSMotorsShowroom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly FSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(FSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
           _context = context;
           
        }

        public async Task<IActionResult> Index()
        {
            var ulist= await _context.applicationUsers.ToListAsync();
            var users = await _userManager.Users.ToListAsync();
            return View(ulist);
            //var usersWithRoles = new List<UserWithRolesViewModel>();

            //var users = _userManager.Users.ToList();

            //foreach (var user in users)
            //{
            //    var roles = await _userManager.GetRolesAsync(user);
            //    var userWithRoles = new UserWithRolesViewModel
            //    {
            //        UserName = user.UserName,
            //        Email = user.Email,
            //        Password = user.PasswordHash,
            //        PhoneNumber = user.PhoneNumber,
            //        EmailConfirmed = user.EmailConfirmed,
            //        Roles = roles.ToList()
            //    };
            //    usersWithRoles.Add(userWithRoles);
       // }

            //return View(usersWithRoles);
        }


        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _context.applicationUsers.Select(a => new
            {
                a.Id,
                a.FirstName,
                a.LastName ,             
                a.Email,
                a.EmailConfirmed,
                a.Role
                //a.IsApproved
            }).ToList();

            return Json(accounts);
        }

        // GET: Account/AddAccount (For modal form)
        [HttpGet]
        public IActionResult AddAccount()
        {
            return PartialView("_AddAccountPartial"); 
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                //Create and add a new account to the database
               var newAccount = new ApplicationUser
               {
                   FirstName = model.FirstName,
                   LastName = model.LastName,
                   Email = model.Email,
                  // PasswordHash = hasher.HashPassword(null, "model.PasswordHash"),
                   PasswordHash = model.PasswordHash,
                   EmailConfirmed = model.EmailConfirmed
                   // Add any other properties as needed
               };

                _context.applicationUsers.Add(newAccount);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // GET: Account/EditAccount/{id} (For modal form)
        [HttpGet]
        public async Task<IActionResult> EditAccount(int id)
        {
            var account = await _context.applicationUsers.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            var model = new ApplicationUser
            {
               
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                // IsApproved = account.IsApproved
                // Add any other properties as needed
            };

            return PartialView("_EditAccountPartial", model); // Replace with your actual partial view
        }

        // POST: Account/EditAccount/{id} (For updating an account)
        [HttpPost]
        public async Task<IActionResult> EditAccount(int id, [FromBody] ApplicationUser model)
        {
            //if (id != model.UserId)
            //{
            //    return BadRequest();
            //}

            //if (ModelState.IsValid)
            //{
            //    // Update the existing account in the database
            //    var account = await _context.users.FindAsync(id);
            //    if (account == null)
            //    {
            //        return NotFound();
            //    }

            //    account.FirstName = model.FirstName;
            //    account.LastName = model.LastName;
            //    account.Email = model.Email;
            //    account.Phone = model.Phone;
            //    account.IsActive = model.IsActive;
            //   // account.IsApproved = model.IsApproved;
            //    // Update any other properties as needed

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!AccountExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return Json(new { success = true });
            //}

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // POST: Account/DeleteAccount/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.applicationUsers.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.applicationUsers.Remove(account);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        //private bool AccountExists(int id)
        //{
        //    return _context.users.Any(a => a.UserId == id);
        //}
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }
    }
}
