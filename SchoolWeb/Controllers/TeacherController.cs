using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolWeb.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolContext context;

        public TeacherController(SchoolContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.context.Teachers.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var teacher = await this.context.Teachers.FindAsync(id);

            if (teacher == null)
                return View("NotFound");

            return View(teacher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if(ModelState.IsValid)
            {
                this.context.Teachers.Add(teacher);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            return View(teacher);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await this.context.Teachers.FindAsync(id);

            if (teacher == null)
                return View("NotFound");

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Teacher teacher)
        {
            if (id != teacher.PersonID)
                return View("Error");

            if (ModelState.IsValid)
            {
                this.context.Teachers.Update(teacher);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await this.context.Teachers.FindAsync(id);

            if (teacher == null)
                return View("NotFound");

            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await this.context.Teachers.FindAsync(id);

            if (teacher == null)
                return View("NotFound");

            this.context.Teachers.Remove(teacher);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
