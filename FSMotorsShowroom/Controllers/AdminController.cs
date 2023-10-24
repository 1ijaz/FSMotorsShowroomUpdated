using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSMotorsShowroom.Controllers
{
    [Authorize]
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
            new RecordCountModel { Name = "Total Users", CountNumber = _context.users.Count(), Link = "link3" },
            new RecordCountModel { Name = "Total Showrooms", CountNumber = _context.workShops.Count(), Link = "link4" },
            new RecordCountModel { Name = "Total Workshops", CountNumber = _context.Showroom.Count(), Link = "link5" },
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
            new RecordCountModel { Name = "Total Users", CountNumber = _context.users.Count(), Link = "link3" },
            new RecordCountModel { Name = "Total Showrooms", CountNumber = _context.workShops.Count(), Link = "link4" },
            new RecordCountModel { Name = "Total Workshops", CountNumber = _context.Showroom.Count(), Link = "link5" },
            // Add more tables as needed
        };

            return Json(recordCounts);
        }
    }
}
