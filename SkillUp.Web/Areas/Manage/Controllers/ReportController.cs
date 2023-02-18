using Microsoft.AspNetCore.Mvc;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ReportController : Controller
    {
        readonly ICourseService _courseService;
        readonly IProductService _productService;

        public ReportController(ICourseService courseService, IProductService productService)
        {
            _courseService = courseService;
            _productService = productService;
        }

        public async Task<IActionResult> AdminCourseRevenue()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return View(courses);
        }


        public async Task<IActionResult> InstructorCourseRevenue()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return View(courses);
        }

        public async Task<IActionResult> AdminProductRevenue()
        {
            var products = await _productService.GetAllProductAsync();
            return View(products);
        }


        public async Task<IActionResult> InstructorProductRevenue()
        {
            var products = await _productService.GetAllProductAsync();
            return View(products);
        }
    }
}
