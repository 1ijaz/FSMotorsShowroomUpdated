using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSMotorsShowroom.Models;
using System.Runtime.ConstrainedExecution;
using Microsoft.Extensions.Hosting;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace FSMotorsShowroom.Controllers
{

    public class NewsController : Controller
    {
        private readonly FSDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public NewsController(FSDbContext context, IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: News
        public async Task<IActionResult> Index()
        {
              return _context.NewsModel != null ? 
                          View(await _context.NewsModel.ToListAsync()) :
                          Problem("Entity set 'FSDbContext.NewsModel'  is null.");
        }
        [Authorize(Roles = "Admin")]
        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewsModel == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (newsModel == null)
            {
                return NotFound();
            }

            return View(newsModel);
        }
        [Authorize(Roles = "Admin")]
        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsModel newsModel)
        {
            //if (ModelState.IsValid)
            //{
                newsModel.NewsImage = await UploadFileAsync(newsModel.NewsImageFile, "Uploads");
                _context.Add(newsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         //   }
           // return View(newsModel);
        }

        // GET: News/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewsModel == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel.FindAsync(id);
            if (newsModel == null)
            {
                return NotFound();
            }
            newsModel.NewsImageFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes(newsModel.NewsImage)), 0, newsModel.NewsImage.Length, "NewsImage", newsModel.NewsImage);
            return View(newsModel);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsModel newsModel)
        {
            if (id != newsModel.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsModelExists(newsModel.NewsId))
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
            return View(newsModel);
        }
        [Authorize(Roles = "Admin")]
        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewsModel == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (newsModel == null)
            {
                return NotFound();
            }

            return View(newsModel);
        }
        [Authorize(Roles = "Admin")]
        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewsModel == null)
            {
                return Problem("Entity set 'FSDbContext.NewsModel'  is null.");
            }
            var newsModel = await _context.NewsModel.FindAsync(id);
            if (newsModel != null)
            {
                _context.NewsModel.Remove(newsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsModelExists(int id)
        {
          return (_context.NewsModel?.Any(e => e.NewsId == id)).GetValueOrDefault();
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
        [HttpGet]
        public IActionResult GetAllNewsList()
        {
            var newsList = _context.newsModels.Take(5).ToList();
           // HttpContext.Session.SetString("GetAllNewsList", System.Text.Json.JsonSerializer.Serialize(newsList));
            return Json(newsList);
        }
        [HttpPost]
        public IActionResult SaveContactMessage([FromBody] ContactMessage contactMessage)
        {
            try
            {
                // Validate and save the contact message to the database
                if (ModelState.IsValid)
                {
                    // You can save data to the database here using _context
                    _context.ContactMessage.Add(contactMessage);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Message saved successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Invalid data. Please check your input." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }
        public IActionResult GetContactMessages()
        {
            var contactMessages = _context.ContactMessage.ToList();

            return View(contactMessages);
        }
    }
}
