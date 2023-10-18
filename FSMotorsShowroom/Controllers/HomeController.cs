using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult inventory_boxed_sidebar_left()
        {
            return View("~/Views/Home/inventory-boxed-sidebar-left.cshtml");
        }
        public IActionResult inventory_boxed_sidebar_right()
        {
            return View("~/Views/Home/inventory-boxed-sidebar-right.cshtml");
        }
        public IActionResult inventory_listing()
        {
            return View("~/Views/Home/inventory-listing.cshtml");
        }
        public IActionResult inventory_wide_fullwidth()
        {
            return View("~/Views/Home/inventory-wide-fullwidth.cshtml");
        }
        public IActionResult inventory_wide_sidebar_left()
        {
            return View("~/Views/Home/inventory-wide-sidebar-left.cshtml");
        }
        public IActionResult inventory_wide_sidebar_right()
        {
            return View("~/Views/Home/inventory-wide-sidebar-right.cshtml");
        }
        public IActionResult our_team()
        {
            return View("~/Views/Home/our-team.cshtml");
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
     
        }
    
    }

