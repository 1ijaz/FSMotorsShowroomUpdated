using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Mvc;

namespace FSMotorsShowroom.Controllers
{
    //  [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly FSDbContext _context;

        public AdminController(FSDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<RecordCountModel> recordCounts = new List<RecordCountModel>
    {
           new RecordCountModel { Name = "Total Cars", CountNumber = _context.cars.Count(), Link = "/cars/index" },
            new RecordCountModel { Name = "Total Investors", CountNumber = _context.investors.Count(), Link = "/investors/index" },
            new RecordCountModel { Name = "Total Transactions", CountNumber = _context.transactions.Count(), Link = "/Transactions/index" },
            new RecordCountModel { Name = "Total Car Model", CountNumber = _context.carModels.Count(), Link = "/CarModels/index" },
            new RecordCountModel { Name = "Total Feedbacks", CountNumber = _context.feedbacks.Count(), Link = "/Feedbacks/index" },
        // Add more tables as needed
    };

            return View(recordCounts);
        }
        // Action to retrieve record counts
        [HttpGet]
        public JsonResult GetRecordCounts()
        {
            List<RecordCountModel> recordCounts = new List<RecordCountModel>
            {
            new RecordCountModel { Name = "Total Cars", CountNumber = _context.cars.Count(), Link = "link1" },
            new RecordCountModel { Name = "Total Investors", CountNumber = _context.investors.Count(), Link = "link2" },
            new RecordCountModel { Name = "Total Users", CountNumber = _context.applicationUsers.Count(), Link = "link3" },
            new RecordCountModel { Name = "Total Showrooms", CountNumber = _context.workShops.Count(), Link = "link4" },
            new RecordCountModel { Name = "Total Workshops", CountNumber = _context.Showroom.Count(), Link = "link5" },
            // Add more tables as needed
        };

            return Json(recordCounts);
        }
    }
}
