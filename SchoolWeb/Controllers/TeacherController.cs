﻿using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
