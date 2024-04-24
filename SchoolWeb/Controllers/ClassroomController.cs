using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SchoolWeb.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            return Ok();
        }

        public IActionResult Create()
        {
            return Content("création", "text/plain", Encoding.UTF8);
        }

        [HttpGet("Classroom/Photo/{photoid}")]
        public IActionResult Photo(int photoid, [FromServices] IWebHostEnvironment environment)
        {
            //string path = Path.Join(environment.ContentRootPath, "photos", $"teacher_{photoid}.png");
            string path = Path.Join(environment.ContentRootPath, "photos", "teacher-logo.png");

            return PhysicalFile(path, "image/png", "teacher.png");
        }
    }
}
