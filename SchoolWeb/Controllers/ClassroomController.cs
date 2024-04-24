using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SchoolWeb.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
            var classrooms = new List<Classroom>()
            {
                new Classroom()
                {
                    ClassroomID = 1,
                    Name = "Salle Bill Gates",
                    Corridor = "Bleu",
                    Floor = 2
                },
                new Classroom()
                {
                    ClassroomID = 2,
                    Name = "Salle Scott Hanselman",
                    Corridor = "Rouge",
                    Floor = 3
                },
                new Classroom()
                {
                    ClassroomID = 2,
                    Name = "Salle Scott Guthrie",
                    Corridor = "Orange",
                    Floor = 3
                }
            };

            return View(classrooms);
            //return View();
        }

        public IActionResult List()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var classroom = new Classroom()
            {
                ClassroomID = 1,
                Name = "Salle Bill Gates",
                Corridor = "Bleu",
                Floor = 2
            };

            return View(classroom);
            //return Ok();
        }

        [HttpGet("Classroom/Photo/{photoid}")]
        public IActionResult Photo(int photoid, [FromServices] IWebHostEnvironment environment)
        {
            //string path = Path.Join(environment.ContentRootPath, "photos", $"teacher_{photoid}.png");
            string path = Path.Join(environment.ContentRootPath, "photos", "teacher-logo.png");

            return PhysicalFile(path, "image/png", "teacher.png");
        }

        public IActionResult Create()
        {
            return Content("création", "text/plain", Encoding.UTF8);
        }

        [HttpPost]
        public IActionResult Create(Classroom classroom)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
                return View("Error");

            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return View();
        }
    }
}
