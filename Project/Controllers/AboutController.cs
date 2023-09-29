using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AboutController(ApplicationDbContext applicationDbContext, IWebHostEnvironment hostEnvironment)
        {
            _context = applicationDbContext;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<About> abouts = _context.abouts.ToList();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension == ".jpg" || fileExtension == ".png")
                    {
                        string fileName = Guid.NewGuid().ToString() + fileExtension;
                        string path = Path.Combine(wwwRootPath, @"images/");
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        about.Image = @"images/" + fileName;
                        _context.abouts.Add(about);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["ErrorMessage"] = "An error occurred.Please upload image of format jpg or png";
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            About about = _context.abouts.FirstOrDefault(x => x.AboutId == id);
            if (about == null)
            {
                return NotFound(id);
            }
            return View(about);
        }
        [HttpPost]
        public IActionResult Edit(About about, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg")
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string path = Path.Combine(wwwRootPath, @"images/");
                        if (!string.IsNullOrEmpty(about.Image))
                        {
                            var oldPath = Path.Combine(wwwRootPath, about.Image);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                        }
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                        }

                        about.Image = @"images/" + fileName;
                        _context.abouts.Update(about);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            About about = _context.abouts.FirstOrDefault(x => x.AboutId == id);
            if (about == null)
            {
                return NotFound(id);
            }
            return View(about);
        }
        [HttpPost]
        public IActionResult Delete(About about)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;

            {
                if (!string.IsNullOrEmpty(about.Image))
                {
                    var oldPath = Path.Combine(wwwRootPath, about.Image);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                _context.abouts.Remove(about);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
          
        }
    }
}