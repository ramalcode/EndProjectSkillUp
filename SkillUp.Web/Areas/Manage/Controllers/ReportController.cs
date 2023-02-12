using Microsoft.AspNetCore.Mvc;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ReportController : Controller
    {
        readonly ICourseService _courseService;

        public ReportController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> AdminRevenue()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return View(courses);
        }


        public async Task<IActionResult> InstructorRevenue()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return View(courses);
        }
    }
}
