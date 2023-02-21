using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class ShopController : Controller
    {
        readonly IReviewProductService _reviewProductService;
        readonly IProductService _productService;
        readonly AppDbContext appDbContext;
        readonly UserManager<AppUser> _userManager;


        public ShopController(AppDbContext appDbContext, UserManager<AppUser> userManager, IReviewProductService reviewProductService, IProductService productService)
        {
            this.appDbContext = appDbContext;
            _userManager = userManager;
            _reviewProductService = reviewProductService;
            _productService = productService;
        }

        public async Task<IActionResult> Products(int page = 1)
        {
            var products = await _productService.GetAllProductAsync();
            IEnumerable<Product> pagination = products.Skip((page - 1) * 1).Take(1);
            PaginationVM<Product> paginationVM = new PaginationVM<Product>
            {
                MaxPageCount = (int)Math.Ceiling((decimal) products.Count / 1),
                CurrentPage = page,
                Items = pagination
            };
            return View(paginationVM);
        }


        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await appDbContext.Products.Include(pc=>pc.ProductCategories).ThenInclude(c=>c.Category)
              .Include(product=>product.ProductReviews).ThenInclude(u=>u.Appuser).FirstOrDefaultAsync(p=>p.Id == id); 
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(CreateProductReviewVM reviewVM)
        {
            string userid = _userManager.GetUserId(HttpContext.User);
            if (!ModelState.IsValid) return View(reviewVM);
            AppUserProduct userProduct = new AppUserProduct();
            if (userProduct.IsBuyed == false) _reviewProductService.CreateReviewAsync(reviewVM, userid);
            return RedirectToAction("Index", "Home");
        }

      


        public IActionResult Wishlist()
        {
            return View();
        }


        
    }
}
