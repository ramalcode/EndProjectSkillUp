using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;
using SkillUp.Service.Services.Concretes;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly IProductService _productService;
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;


        public ProductController(ICategoryService categoryService, IProductService productService, AppDbContext context, IWebHostEnvironment env)
        {
            _categoryService = categoryService;
            _productService = productService;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> ManageProducts()
        {
            var product = await _productService.GetAllProductAsync();
            return View(product);   
        }

        //public async Task<IActionResult> AddNewProduct()
        //{
        //    ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Name));
        //    ViewBag.Instructors = new SelectList( _context.Instructors, nameof(Instructor.Id), nameof(Instructor.Name));

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddNewProduct(CreateProductVM productVM)
        //{
           

        //    if (productVM.Image != null)
        //    {
        //        string result = productVM.Image.CheckValidate("image/", 500);
        //        if (result.Length > 0)
        //        {
        //            ModelState.AddModelError("Image", result);
        //        }
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Name));
        //        ViewBag.Instructors = new SelectList(_context.Instructors, nameof(Instructor.Id), nameof(Instructor.Name));
        //        return View(productVM);
        //    }
        //    await _productService.CreateProductAsync(productVM);    
        //    return View();
            
        //}

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(ManageProducts));
        }

        //public async Task<IActionResult> UpdateProduct(int id)
        //{
        //    ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Name));
        //    ViewBag.Instructors = new SelectList(_context.Instructors, nameof(Instructor.Id), nameof(Instructor.Name));
        //    var product = await _productService.UpdateProductById(id);
        //    return View(product);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateProduct(int id, UpdateProductVM productVM)
        //{
        //    Product product = new Product();
        //    if (productVM.Image != null)
        //    {
        //        string result = productVM.Image.CheckValidate("image/", 500);
        //        if (result.Length > 0)
        //        {
        //            ModelState.AddModelError("Image", result);
        //        }
        //        //product.ImageUrl.DeleteFile(_env.WebRootPath, "user/assets/productimg");
        //        product.ImageUrl = productVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "productimg"));

        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Name));
        //        ViewBag.Instructors = new SelectList(_context.Instructors, nameof(Instructor.Id), nameof(Instructor.Name));
        //    }
        //    await _productService.UpdateProductAsync(id, productVM);
        //    return RedirectToAction(nameof(ManageProducts));
        //}
    
    }
}
