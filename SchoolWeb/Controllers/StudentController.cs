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
        public IActionResult Index()
        {
            var students = new List<Student>()
            {
                new Student() {
                    FirstName = "Joey",
                    LastName = "Tribbiani",
                    Average = 8.5,
                    IsClassDelegate = false,
                },
                new Student() {
                    FirstName = "Monica",
                    LastName = "Geller",
                    Average = 13.5,
                    IsClassDelegate = true,
                },
                new Student() {
                    FirstName = "Chandler",
                    LastName = "Bing",
                    Average = 10.0,
                    IsClassDelegate = false,
                },
            };

            return View("_StudentList", students);
        }

        //[Route("Info/{studentid}")]
        public IActionResult Details(int studentid)
        {
            return View();
        }

        //[HttpGet("Add")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
