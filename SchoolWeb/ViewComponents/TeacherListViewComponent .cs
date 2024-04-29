using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.ViewComponents
{
    public class TeacherListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    FirstName = "Ross",
                    LastName = "Geller",
                    Discipline = "Paléontologie 101",
                    Salary = 2400
                },
                new Teacher()
                {
                    FirstName = "Rachel",
                    LastName = "Green",
                    Discipline = "La mode 101",
                    Salary = 2000
                },
            };

            return View(teachers);
        }
    }
}
