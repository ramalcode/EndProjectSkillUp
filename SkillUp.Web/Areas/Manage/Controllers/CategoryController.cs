using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class CategoryController : Controller
    {
        readonly ISubCategoryService _subCategoryService;
        readonly ICategoryService _categoryService;

        public CategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        { 
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        // SubCategory CRUD:

        public async Task<IActionResult> AddNewSubCategory()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubCategory(CreateSubCategoryVM subCategoryVM)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Name));
                return View(subCategoryVM);
            }
            if (subCategoryVM is null) return NotFound();
            await _subCategoryService.CreateSubCategoryAsync(subCategoryVM);
            return RedirectToAction(nameof(AddNewSubCategory));
        }

        //Category CRUD:

        public IActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CreateCategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return View(categoryVM);
            if (categoryVM is null) return NotFound();
            await _categoryService.CreateCategoryAsync(categoryVM);
            return RedirectToAction(nameof(CourseCategory));
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(CourseCategory));
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.UpdateCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int id , UpdateCategoryVM categoryVM)
        {
            await _categoryService.UpdateCategoryAsync(id,categoryVM);
            return RedirectToAction(nameof(CourseCategory));
        }

        public async Task<IActionResult> CourseCategory()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }

    }
}
