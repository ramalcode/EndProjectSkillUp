using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Settings;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ICourseService _courseService;
        readonly ICategoryService _categoryService;
        readonly IInstructorService _instructorService;
        readonly IProductService _productService;
        readonly IContactService _contactService;
        readonly IReviewCourseService _reviewCourseService;
        readonly IUnitOfWork _unitOfWork;

        public HomeController(ICourseService courseService, ICategoryService categoryService, IInstructorService instructorService, IProductService productService, IContactService contactService, IReviewCourseService reviewCourseService, IUnitOfWork unitOfWork)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _instructorService = instructorService;
            _productService = productService;
            _contactService = contactService;
            _reviewCourseService = reviewCourseService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM indexVM = new IndexVM
            {
                Courses = await _courseService.GetAllCourseAsync(),
                Categories = await _categoryService.GetAllCategoryAsync(),
                Instructors = await _instructorService.GetAllInstructorAsync(),
                Products = await _productService.GetAllProductAsync(),  
                CourseReviews = await _reviewCourseService.GetAllCourseReviewAsync(),
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

        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactVM contactVM)
        {
            await _contactService.CreateContactAsync(contactVM);    
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> FAQs()
        {
            var faqs = await _unitOfWork.GetRepository<Faq>().GetAllAsync();  
            return View(faqs);
        }

    }
}