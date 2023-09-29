using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public TeamController(ApplicationDbContext applicationDbContext, IWebHostEnvironment hostEnvironment)
        {
            _context = applicationDbContext;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Team> teams = _context.teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team, IFormFile logoFile, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                {
                    if (logoFile != null)
                    {
                        if (Path.GetExtension(logoFile.FileName).ToLower() == ".jpg")
                        {
                            //foreach (var logoFile in files)
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);
                            string path = Path.Combine(wwwRootPath, @"images/");
                            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                logoFile.CopyToAsync(fileStream);
                            }
                            team.Logo = @"images/" + fileName;
                        }
                        if (image != null)
                        {
                            if (Path.GetExtension(image.FileName).ToLower() == ".jpg")
                            {
                                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                                string path = Path.Combine(wwwRootPath, @"images/");
                                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                                {
                                    image.CopyToAsync(fileStream);
                                }
                                team.Image = @"images/" + fileName;
                            }
                        }
                        _context.teams.Add(team);
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
            Team team = _context.teams.FirstOrDefault(x => x.TeamId == id);
            if (team == null)
            {
                return NotFound(id);
            }
            return View(team);
        }
        [HttpPost]
        public IActionResult Edit(Team team, IFormFile logoFile, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (logoFile != null)
                {
                    if (Path.GetExtension(logoFile.FileName).ToLower() == ".jpg")
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);
                        string path = Path.Combine(wwwRootPath, @"images/");
                        if (!string.IsNullOrEmpty(team.Logo))
                        {
                            var oldPath = Path.Combine(wwwRootPath, team.Logo);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                        }
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            logoFile.CopyToAsync(fileStream);
                        }
                        team.Logo = @"images/" + fileName;
                    }
                    if (image != null)
                    {
                        if (Path.GetExtension(image.FileName).ToLower() == ".jpg")
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                            string path = Path.Combine(wwwRootPath, @"images/");
                            if (!string.IsNullOrEmpty(team.Logo))
                            {
                                var oldPath = Path.Combine(wwwRootPath, team.Logo);
                                if (System.IO.File.Exists(oldPath))
                                {
                                    System.IO.File.Delete(oldPath);
                                }
                            }
                            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                image.CopyToAsync(fileStream);
                            }
                            team.Image = @"images/" + fileName;
                        }
                    }
                    _context.teams.Update(team);
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
            Team team = _context.teams.FirstOrDefault(x => x.TeamId == id);
            if (team == null)
            {
                return NotFound(id);
            }
            return View(team);
        }
        [HttpPost]
        public IActionResult Delete(Team team)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;

            {
                if (!string.IsNullOrEmpty(team.Logo))
                {
                    var oldPath = Path.Combine(wwwRootPath, team.Logo);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                _context.teams.Remove(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}
