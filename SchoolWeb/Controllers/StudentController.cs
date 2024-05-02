using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using System.Net;
using System;
using DomainModel;
using Dal;

namespace SchoolWeb.Controllers
{
    //[Route("Stud")]
    public class StudentController : Controller
    {
        private readonly SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View("_StudentList", this.context.Students.ToList());
        }

        //[Route("Info/{studentid}")]
        public IActionResult Details(int id)
        {
            var student = this.context.Students.Find(id);

            if (student == null)
                return View("NotFound");

            return View(student);
        }

        //[HttpGet("Add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public IActionResult List() 
        {
            return View(this.context.Students.ToList());
        }

        public IActionResult Edit(int id)
        {
            var student = this.context.Students.Find(id);

            if (student == null)
                return View("NotFound");

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if(id != student.PersonID)
                return View("Error");

            if (ModelState.IsValid)
            {
                this.context.Students.Update(student);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = this.context.Students.Find(id);

            if (student == null)
                return View("Error");

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = this.context.Students.Find(id);

            if (student == null)
                return View("Error");

            this.context.Students.Remove(student);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
