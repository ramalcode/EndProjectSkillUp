using Microsoft.AspNetCore.Mvc;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class HomeController : Controller
    {
      readonly ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
           var course =await _courseService.GetAllCourseAsync();
            return View(course);
        }


        public IActionResult About()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult FAQs()
        {
            return View();
        }

    }
}