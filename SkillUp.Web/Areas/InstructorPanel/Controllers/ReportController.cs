using Microsoft.AspNetCore.Mvc;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.InstructorPanel.Controllers
{
    [Area("InstructorPanel")]
    public class ReportController : Controller
    {
        readonly ICourseService _courseService;
        readonly IProductService _productService;

        public ReportController(ICourseService courseService, IProductService productService)
        {
            _courseService = courseService;
            _productService = productService;
        }


        public async Task<IActionResult> MyCourseRevenue()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return View(courses);
        }


        public async Task<IActionResult> MyProductRevenue()
        {
            var products = await _productService.GetAllProductAsync();
            return View(products);
        }
    }
}
