using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using System.Diagnostics;

namespace SchoolWeb.Controllers
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
            ViewBag.Message = "Bonjour à tous !";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ActionName("Info")]
        public IActionResult Information()
        {
            return View();
        }

        public IActionResult CreateDb([FromServices] SchoolContext context)
        {
            context.Database.EnsureCreated();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
