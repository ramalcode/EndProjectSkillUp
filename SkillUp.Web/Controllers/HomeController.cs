using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ICourseService _courseService;
        readonly ICategoryService _categoryService;
        readonly IInstructorService _instructorService;

        public HomeController(ICourseService courseService, ICategoryService categoryService, IInstructorService instructorService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _instructorService = instructorService;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM indexVM = new IndexVM
            {
                Courses = await _courseService.GetAllCourseAsync(),
                Categories = await _categoryService.GetAllCategoryAsync(),
                Instructors = await _instructorService.GetAllInstructorAsync(),
            };
            return View(indexVM);
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