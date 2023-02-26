using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult MyCoursesLibrary()
        {
            return View();
        }

        public IActionResult MyProductLibrary()
        {
            return View();
        }
    }
}
