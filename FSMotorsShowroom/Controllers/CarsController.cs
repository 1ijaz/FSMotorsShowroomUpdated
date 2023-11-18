using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FSMotorsShowroom.Models.Car;
using Microsoft.AspNetCore.Authorization;

namespace FSMotorsShowroom.Controllers
{
    public class CarsController : Controller
    {
        private readonly FSDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        decimal profitPriceCar = 0;
        public CarsController(FSDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.cars != null ?
                        View(await _context.cars.ToListAsync()) :
                        Problem("Entity set 'FSDbContext.cars'  is null.");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CarModelId"] = new SelectList(_context.carModels, "CarModelId", "CarModelName");
            ViewBag.TransmissionTypes = GetTransmissionTypes();
            ViewBag.investorInfo = GetInvestorInfo();
            ViewBag.CarStatusEnum = GetCarStatusEnum();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            //if (ModelState.IsValid)
            //{
                //Save image to wwwroot/image
                car.FrontImage = await UploadFileAsync(car.FrontImageFile, "Uploads");
                car.BackImage = await UploadFileAsync(car.BackImageFile, "Uploads");
                car.InteriorImage = await UploadFileAsync(car.InteriorImageFile, "Uploads");
                car.EngineImage = await UploadFileAsync(car.EngineImageFile, "Uploads");
                car.BodyImage = await UploadFileAsync(car.BodyImageFile, "Uploads");

                car.TotalPrice = car.BuyingPrice + car.MaintananceCost + car.ShowroomCost  + car.SalesTax;
            profitPriceCar = (decimal)(car.SellingPrice - car.TotalPrice);
            car.ProfitPriceOfCarCost = profitPriceCar;
                _context.Add(car);
            await _context.SaveChangesAsync();
            await UpdateInvestorProfit(profitPriceCar, car.CarInvestor);
            return RedirectToAction(nameof(Index));
       // }
            return View(car);
    }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["CarModelId"] = new SelectList(_context.carModels, "CarModelId", "CarModelName");
            ViewBag.TransmissionTypes = GetTransmissionTypes();
            ViewBag.investorInfo = GetInvestorInfo();
            ViewBag.CarStatusEnum = GetCarStatusEnum();
            if (id == null || _context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    car.TotalPrice = car.BuyingPrice + car.MaintananceCost + car.ShowroomCost + car.SalesTax;
                     profitPriceCar = (decimal)(car.SellingPrice - car.TotalPrice);
                    car.ProfitPriceOfCarCost = profitPriceCar;
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                    // Assuming investorId is the ID of the investor related to this car
                    await UpdateInvestorProfit(profitPriceCar, car.CarInvestor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            return View(car);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cars == null)
            {
                return Problem("Entity set 'FSDbContext.cars'  is null.");
            }
            var car = await _context.cars.FindAsync(id);
            if (car != null)
            {
                _context.cars.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_context.cars?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
        private async Task<string> UploadFileAsync(IFormFile file, string uploadDirectory)
        {
            if (file != null && file.Length > 0)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string uniqueFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string filePath = Path.Combine(wwwRootPath, uploadDirectory, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return uniqueFileName;
            }
            return null;
        }
        private List<SelectListItem> GetInvestorInfo()
        {
            // Assuming Investor is the entity representing your "investors" table
            var investors = _context.investors.ToList();

            var items = investors.Select(investor => new SelectListItem
            {
                Text = investor.InvestorName, 
                Value = investor.InvestorEmail
            }).ToList();

            return items;
        }
        private List<SelectListItem> GetTransmissionTypes()
        {
            var transmissionTypes = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>();
            var items = transmissionTypes.Select(type => new SelectListItem
            {
                Text = type.ToString(),
                Value = type.ToString()
            }).ToList();

            return items;
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
        public async Task UpdateInvestorProfit(decimal profitValue, string investorId)
        {
            try
            {
                var investor = await _context.investors.Where(inv => inv.InvestorEmail == investorId).FirstOrDefaultAsync();

                if (investor != null)
                {
                    var profitValueCalcluated = profitValue /2;
                    if (investor.Profit == null)
                    {
                        investor.Profit = 0;
                        investor.Profit += profitValueCalcluated;
                    }
                    else
                    {
                        investor.Profit += profitValueCalcluated;
                    }
                    _context.Update(investor);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where the investor with the given ID is not found.
                    // You may throw an exception, log an error, or handle it according to your application's requirements.
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here, log or rethrow as needed.
                // You may want to add more specific exception handling based on your application's requirements.
                Console.WriteLine($"Error updating investor profit: {ex.Message}");
            }
        }

    }

}
