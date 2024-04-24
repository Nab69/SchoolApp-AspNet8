using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.Controllers
{
    //[Route("Stud")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
