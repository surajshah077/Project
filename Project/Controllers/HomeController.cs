using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var services = _context.services.ToList();
            var portfolio = _context.portfolio.ToList();
            var about = _context.abouts.ToList();
            var contact = _context.contacts.ToList();
            var team = _context.teams.ToList();
            var code = _context.staticData.FirstOrDefault();

            HomeVM homeVM = new HomeVM
            {
                services = services,
                portfolio = portfolio,
                about = about,
                code = code,
                teams = team
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}