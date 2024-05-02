using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SchoolWeb.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(this.context.Classrooms.ToList());
            //return View();
        }

        public IActionResult List()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var classroom = this.context.Classrooms.Find(id);

            if (classroom == null)
                return View("notFound");

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
            this.context.Classrooms.Add(classroom);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var classroom = this.context.Classrooms.FirstOrDefault(c => c.ClassroomID == id);

            if (classroom == null)
                return View("notFound");

            return View(classroom);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
                return View("Error");

            this.context.Classrooms.Update(classroom);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
       {
            var classroom = this.context.Classrooms.FirstOrDefault(c => c.ClassroomID == id);

            if (classroom == null)
                return View("notFound");

            return View(classroom);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var classroom = this.context.Classrooms.FirstOrDefault(c => c.ClassroomID == id);

            if (classroom == null)
                return View("notFound");

            this.context.Classrooms.Remove(classroom);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
