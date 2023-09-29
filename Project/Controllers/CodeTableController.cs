using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize]
    public class CodeTableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CodeTableController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<CodeTable> code = _context.staticData.ToList();
            return View(code);
        }

        [HttpGet]
        //[Route("Index")]
        public IActionResult Edit()
        {

            CodeTable code = _context.staticData.FirstOrDefault();
            if (code == null)
            {
                return NotFound();
            }
            return View(code);
        }
        [HttpPost]
        public IActionResult Edit(CodeTable code)
        {
            if (ModelState.IsValid)
            {
                _context.staticData.Update(code);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
