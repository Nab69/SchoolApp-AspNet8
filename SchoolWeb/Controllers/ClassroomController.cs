using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SchoolWeb.Controllers
{
    public class ClassroomController : Controller
    {
        private static List<Classroom> classrooms = new List<Classroom>()
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
                ClassroomID = 3,
                Name = "Salle Scott Guthrie",
                Corridor = "Orange",
                Floor = 3
            }
        };

        public IActionResult Index()
        {
            return View(ClassroomController.classrooms);
            //return View();
        }

        public IActionResult List()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var classroom = ClassroomController.classrooms.FirstOrDefault(c => c.ClassroomID == id);

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
            return View();
            //return Content("création", "text/plain", Encoding.UTF8);
        }

        [HttpPost]
        public IActionResult Create(Classroom classroom)
        {
            classroom.ClassroomID = ClassroomController.classrooms.Select(c => c.ClassroomID).Max() + 1;
            ClassroomController.classrooms.Add(classroom);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var classroom = ClassroomController.classrooms.FirstOrDefault(c => c.ClassroomID == id);

            return View(classroom);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
                return View("Error");

            var classroomToChange = ClassroomController.classrooms.FirstOrDefault(c => c.ClassroomID == id);

            classroomToChange.Name = classroom.Name;
            classroomToChange.Floor = classroom.Floor;
            classroomToChange.Corridor = classroom.Corridor;

            return View();
        }

        public IActionResult Delete(int id)
       {
            var classroom = ClassroomController.classrooms.FirstOrDefault(c => c.ClassroomID == id);

            return View(classroom);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var classroom = ClassroomController.classrooms.FirstOrDefault(c => c.ClassroomID == id);
            ClassroomController.classrooms.Remove(classroom);

            return RedirectToAction(nameof(Index));
        }
    }
}
