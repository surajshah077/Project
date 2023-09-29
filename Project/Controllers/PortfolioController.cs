using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PortfolioController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Portfolio> portfolio = _context.portfolio.ToList();
            return View(portfolio);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio, IFormFile? file)
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
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                        }

                        portfolio.Image = @"images/" + fileName;
                        _context.portfolio.Add(portfolio);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Portfolio portfolio = _context.portfolio.FirstOrDefault(x => x.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound(id);
            }
            return View(portfolio);
        }
        [HttpPost]
        public IActionResult Edit(Portfolio portfolio, IFormFile file)
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
                        if (!string.IsNullOrEmpty(portfolio.Image))
                        {
                            var oldPath = Path.Combine(wwwRootPath, portfolio.Image);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                file.CopyToAsync(fileStream);
                            }

                            portfolio.Image = @"images/" + fileName;
                        }
                    }
                    _context.portfolio.Update(portfolio);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
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
            Portfolio portfolio = _context.portfolio.FirstOrDefault(x => x.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound(id);
            }
            return View(portfolio);
        }
        [HttpPost]
        public IActionResult Delete(Portfolio portfolio)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            {
                if (!string.IsNullOrEmpty(portfolio.Image))
                {
                    var oldPath = Path.Combine(wwwRootPath, portfolio.Image);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    _context.portfolio.Remove(portfolio);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }


                return View();
            }
        }
    }
}
