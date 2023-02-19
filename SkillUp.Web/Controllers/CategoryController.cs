using Microsoft.AspNetCore.Mvc;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //Get All Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync(); 
            return View(categories);
        }
    }
}
