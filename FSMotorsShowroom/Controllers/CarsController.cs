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

namespace FSMotorsShowroom.Controllers
{
    public class CarsController : Controller
    {
        private readonly FSDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CarsController(FSDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Cars added comment
        public async Task<IActionResult> Index()
        {
            return _context.cars != null ?
                        View(await _context.cars.ToListAsync()) :
                        Problem("Entity set 'FSDbContext.cars'  is null.");
        }

        // GET: Cars/Details/5
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

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarModelId"] = new SelectList(_context.carModels, "CarModelId", "CarModelName");
            ViewBag.TransmissionTypes = GetTransmissionTypes();
            ViewBag.CarStatusEnum = GetCarStatusEnum();
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
       // }
            return View(car);
    }
        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,Name,Color,TransmissionMode,FuelType,FuelMilage,Features,Description,EngineNo,BuyingPrice,SellingPrice,MaintananceCost,ShowroomCost,SalesTax,MakeCompany,MakeYear,NoOfCylinders,HorsePower,TransmissionMode,TankCapacity,Doors,PassengerCapacity,FrontImage,BackImage,InteriorImage,EngineImage,BodyImage,CarStatus")] Car car)
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
                    _context.Update(car);
                    await _context.SaveChangesAsync();
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

        // GET: Cars/Delete/5
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

        // POST: Cars/Delete/5
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
    }

}
