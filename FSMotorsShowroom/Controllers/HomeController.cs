using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FSMotorsShowroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FSDbContext _context;
        public HomeController(FSDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }
     
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Admin/Index");
            }
            else { 
                return View(); 
            }
            return View();
        }

        public IActionResult AboutUs()
        {
            return View("~/Views/Home/WebAboutUs.cshtml");
        }
        public IActionResult Careers()
        {
            return View("~/Views/Home/Careers.cshtml");
        }
         public IActionResult CEOMessage()
        {
            return View("~/Views/Home/CEOMessage.cshtml");
        }
        public IActionResult Feedback()
        {
            return View("~/Views/Home/Feedback.cshtml");
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View("~/Views/Home/service.cshtml");
        }
        public IActionResult NotFound404()
        {
            return View("~/Views/Home/404.cshtml");
        }
        public IActionResult blog()
        {
            return View("~/Views/Home/blog.cshtml");
        }
        public IActionResult blogpost()
        {
            return View("~/Views/Home/blogpost.cshtml");
        }
        public IActionResult contact_process()
        {
            return View("~/Views/Home/contact_process.cshtml");
        }
        public IActionResult demo()
        {
            return View("~/Views/Home/demo.cshtml");
        }
        public IActionResult faq()
        {
            return View("~/Views/Home/faq.cshtml");
        }
        public IActionResult index_2()
        {
            return View("~/Views/Home/index-2.cshtml");
        }
        public IActionResult index_footer_2()
        {
            return View("~/Views/Home/index-footer-2.cshtml");
        }
        public IActionResult inventory_2_listing_comparison()
        {
            return View("~/Views/Home/inventory-2-listing-comparison.cshtml");
        }
        public IActionResult inventory_3_listing_comparison()
        {
            return View("~/Views/Home/inventory-3-listing-comparison.cshtml");
        }
        public IActionResult inventory_4_listing_comparison()
        {
            return View("~/Views/Home/inventory-4-listing-comparison.cshtml");
        }
        public IActionResult inventory_boxed_fullwidth()
        {
            return View("~/Views/Home/inventory-boxed-fullwidth.cshtml");
        }
        public IActionResult car_for_sale()
        {
            return View("~/Views/Home/car_for_sale.cshtml");
        }
        public IActionResult inventory_boxed_sidebar_right()
        {
            return View("~/Views/Home/inventory-boxed-sidebar-right.cshtml");
        }
        public IActionResult inventory_listing()
        {
            return View("~/Views/Home/inventory-listing.cshtml");
        }
        public IActionResult inventory_listing_2(int id)
        {
            var model = new InventoryModel { Id = id };
            return View("~/Views/Home/inventory-listing_2.cshtml", model);
        }
        public IActionResult inventory_listing_3(int id)
        {
            var model = new InventoryModel { Id = id };
            return View("~/Views/Home/inventory-listing_3.cshtml", model);
        } 
        public IActionResult inventory_listing_4(int id)
        {
            var model = new InventoryModel { Id = id };
            return View("~/Views/Home/inventory-listing_4.cshtml", model);
        }  
        public IActionResult inventory_listing_5(int id)
        {
            var model = new InventoryModel { Id = id };
            return View("~/Views/Home/inventory-listing_5.cshtml", model);
        } 
        public IActionResult inventory_listing_6(int id)
        {
            var model = new InventoryModel { Id = id };
            return View("~/Views/Home/inventory-listing_6.cshtml", model);
        }
        public IActionResult inventory_listing_inv(int id)
        {
            var model = new InventoryModel { Id = id };
            return View("~/Views/Home/inventory-listing_inv.cshtml", model);
        }
        public IActionResult inventory_wide_fullwidth()
        {
            return View("~/Views/Home/inventory-wide-fullwidth.cshtml");
        }
        public IActionResult cars_in_worksop()
        {
            return View("~/Views/Home/cars_in_worksop.cshtml");
        } 
        public IActionResult cars_investors()
        {
            return View("~/Views/Home/cars_investors.cshtml");
        } 
        public IActionResult sold_cars()
        {
            return View("~/Views/Home/sold_cars.cshtml");
        }   
        public IActionResult sold_cars_investor()
        {
            return View("~/Views/Home/sold_cars_investor.cshtml");
        }
        public IActionResult inventory_wide_sidebar_right()
        {
            return View("~/Views/Home/inventory-wide-sidebar-right.cshtml");
        }
        public IActionResult our_team()
        {
            return View("~/Views/Home/our-team.cshtml");
        } 
        public IActionResult invest_policy()
        {
            return View("~/Views/Home/invest_policy.cshtml");
        }
        public IActionResult page_fullwidth()
        {
            return View("~/Views/Home/page-fullwidth.cshtml");
        }
            public IActionResult page_sidebar()
            {
                return View("~/Views/Home/page-sidebar.cshtml");
            }
        public IActionResult portfolio_2_column()
        {
            return View("~/Views/Home/portfolio-2-column.cshtml");
        }
        public IActionResult portfolio_2_column_details()
        {
            return View("~/Views/Home/portfolio-2-column-details.cshtml");
        }
        public IActionResult portfolio_3_column()
        {
            return View("~/Views/Home/portfolio-3-column.cshtml");
        }
        public IActionResult portfolio_3_column_details()
        {
            return View("~/Views/Home/portfolio-3-column-details.cshtml");
        }
        public IActionResult portfolio_4_column()
        {
            return View("~/Views/Home/portfolio-4-column.cshtml");
        }
        public IActionResult portfolio_4_column_details()
        {
            return View("~/Views/Home/portfolio-4-column-details.cshtml");
        }
        public IActionResult portfolio_single_project_split()
            {
                return View("~/Views/Home/portfolio-single-project-split.cshtml");
            }
        public IActionResult portfolio_single_project_wide()
        {
            return View("~/Views/Home/portfolio-single-project-wide.cshtml");
        }
        public IActionResult pricing_tables()
            {
                return View("~/Views/Home/pricing-tables.cshtml");
            }
            public IActionResult services()
            {
                return View("~/Views/Home/services.cshtml");
            }
        public IActionResult Search_car_list()
        {
            return View("~/Views/Home/search_car_list.cshtml");
        }
        [HttpPost]
        public IActionResult getCar(PostCar searchParams)
        {
            IQueryable<Car> query = _context.cars;

            // Applying conditions based on search parameters
            if (!string.IsNullOrEmpty(searchParams.MakeCompany))
            {
                query = query.Where(car => car.MakeCompany.Contains(searchParams.MakeCompany));
            }
            if (!string.IsNullOrEmpty(searchParams.Name))
            {
                query = query.Where(car => car.Name.Contains(searchParams.Name));
            }

            // Assuming the MakeYear is stored as a DateTime and we are filtering by the year part
            // query = query.Where(car => car.MakeYear.Year == searchParams.MakeYearMinimum);
            if (searchParams.FuelMilageMinimum > 0 && searchParams.FuelMilageMaximum > 0)
            {
                query = query.Where(car => car.FuelMilage >= searchParams.FuelMilageMinimum && car.FuelMilage <= searchParams.FuelMilageMaximum);
            }
            if (searchParams.TotalPriceMinimum > 0 && searchParams.TotalPriceMaximum > 0)
            {
                query = query.Where(car => car.TotalPrice >= searchParams.TotalPriceMinimum && car.TotalPrice <= searchParams.TotalPriceMaximum);
            }

            var foundCar = query.FirstOrDefault();

            if (foundCar != null)
            {
                HttpContext.Session.SetString("FoundCar", System.Text.Json.JsonSerializer.Serialize(foundCar));
                return Json(new { redirectUrl = Url.Action("Search_car_list", "Home") });
            }

            return Json(new { error = "Car not found" }); // Handle error scenario
        }
        [HttpGet]
        public IActionResult GetTenCars()
        {
            var tenCars = _context.cars.Take(10).ToList();
            HttpContext.Session.SetString("FoundTenCar", System.Text.Json.JsonSerializer.Serialize(tenCars));
            return Json(tenCars);
        }  
        [HttpGet]
        public IActionResult GetAllAvailableCars()
        {
            var availableCars = _context.cars.Where(car => car.CarStatus == "Showroom").ToList();
            HttpContext.Session.SetString("GetAllAvailableCars", System.Text.Json.JsonSerializer.Serialize(availableCars));
            return Json(availableCars);
        } 
        [HttpGet]
        public IActionResult GetAllWorkshopCars()
        {
            var workshopCars = _context.cars.Where(car => car.CarStatus == "Workshop").ToList();
            HttpContext.Session.SetString("GetAllWorkshopCars", System.Text.Json.JsonSerializer.Serialize(workshopCars));
            return Json(workshopCars);
        } 
        [HttpGet]
        public IActionResult GetAllInvestorCars()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            var investorsCars = _context.cars.Where(car => car.CarInvestor == userEmail).ToList();
            HttpContext.Session.SetString("GetAllInvestorCars", System.Text.Json.JsonSerializer.Serialize(investorsCars));
            return Json(investorsCars);
        } 
        [HttpGet]
        public IActionResult GetAllSoldCars()
        {
            var soldCars = _context.cars.Where(car => car.CarStatus == "Sold").ToList();
            HttpContext.Session.SetString("GetAllSoldCars", System.Text.Json.JsonSerializer.Serialize(soldCars));
            return Json(soldCars);
        }

    }

}

