using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.Context;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        readonly ICourseService _courseService;
        readonly IProductService _productService;
        readonly IInstructorService _instructorService;
        readonly ILectureService _lectureService;   
        readonly AppDbContext _appDbContext; //


        public DashboardController(ICourseService courseService, IProductService productService, AppDbContext appDbContext, IInstructorService instructorService, ILectureService lectureService)
        {
            _courseService = courseService;
            _productService = productService;
            _appDbContext = appDbContext;
            _instructorService = instructorService;
            _lectureService = lectureService;
        }


        //Admin Dashboard
        public async Task<IActionResult> Index()
        {
            DashboardVM dashboardVM = new DashboardVM
            {
                Courses = await _courseService.GetAllCourseAsync(),
                Products = await _productService.GetAllProductAsync(),
                Instructors = await _instructorService.GetAllInstructorAsync(), 
                AppUsers = _appDbContext.AppUsers.ToList(),
                Lectures = await _lectureService.GetAllLectureAsync(),
            };
            return View(dashboardVM);
        }
    }
}
