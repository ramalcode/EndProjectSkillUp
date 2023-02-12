using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class StudentController : Controller
    {
        public IActionResult ManageStudents()
        {
            return View();
        }
    }
}
