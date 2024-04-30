using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using System.Net;
using System;
using DomainModel;

namespace SchoolWeb.Controllers
{
    //[Route("Stud")]
    public class StudentController : Controller
    {
        private static List<Student> students = new()
        {
            new Student() {
                PersonID = 1,
                FirstName = "Joey",
                LastName = "Tribbiani",
                Average = 8.5,
                IsClassDelegate = false,
            },
            new Student() {
                PersonID = 2,
                FirstName = "Monica",
                LastName = "Geller",
                Average = 13.5,
                IsClassDelegate = true,
            },
            new Student() {
                PersonID = 3,
                FirstName = "Chandler",
                LastName = "Bing",
                Average = 10.0,
                IsClassDelegate = false,
            },
        };

        public IActionResult Index()
        {
            return View("_StudentList", StudentController.students);
        }

        //[Route("Info/{studentid}")]
        public IActionResult Details(int id)
        {
            var student = StudentController.students.SingleOrDefault(s => s.PersonID == id);

            if (student == null)
                return View("Error");

            return View(student);
        }

        //[HttpGet("Add")]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List() 
        {
            return View(StudentController.students);
        }

        public IActionResult Edit(int id)
        {
            var student = StudentController.students.SingleOrDefault(s => s.PersonID == id);

            if (student == null)
                return View("Error");

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = StudentController.students.SingleOrDefault(s => s.PersonID == id);

            if (student == null)
                return View("Error");

            return View(student);
        }
    }
}
