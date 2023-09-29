using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize]/*(Roles ="Admin")]*/
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ServicesController(ApplicationDbContext applicationDbContext, IWebHostEnvironment hostEnvironment)
        {
            _context = applicationDbContext;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            List<Services> services = _context.services.ToList();
            return View(services);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services services, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg")
                {
                   
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        if (file != null)
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            string path = Path.Combine(wwwRootPath, @"images/");
                            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                file.CopyToAsync(fileStream);
                            }

                            services.Logo = @"images/" + fileName;
                            _context.services.Add(services);
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
            Services services = _context.services.FirstOrDefault(x => x.ServiceId == id);
            if (services == null)
            {
                return NotFound(id);
            }
            return View(services);
        }
        [HttpPost]
        public IActionResult Edit(Services services, IFormFile file)
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
                        if (!string.IsNullOrEmpty(services.Logo))
                        {
                            var oldPath = Path.Combine(wwwRootPath, services.Logo);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                        }
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                        }
                        services.Logo = @"images/" + fileName;
                    }
                    _context.services.Update(services);
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
            Services services = _context.services.FirstOrDefault(x => x.ServiceId == id);
            if (services == null)
            {
                return NotFound(id);
            }
            return View(services);
        }
        [HttpPost]
        public IActionResult Delete(Services services)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;

            {
                if (!string.IsNullOrEmpty(services.Logo))
                {
                    var oldPath = Path.Combine(wwwRootPath, services.Logo);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                _context.services.Remove(services);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}
