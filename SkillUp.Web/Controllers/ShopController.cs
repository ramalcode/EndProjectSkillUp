using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;

namespace SkillUp.Web.Controllers
{
    public class ShopController : Controller
    {
        readonly AppDbContext appDbContext;
        readonly UserManager<AppUser> _userManager;

        public ShopController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            this.appDbContext = appDbContext;
            _userManager = userManager;
        }

        public IActionResult Products()
        {
            return View();
        }


        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await appDbContext.Products.Include(pc=>pc.ProductCategories).ThenInclude(c=>c.Category)
                .Include(au=>au.ProductInstructors).ThenInclude(a=>a.Instructor).FirstOrDefaultAsync(p=>p.Id == id); 
            return View(product);
        }


        public async Task<IActionResult> BuyProduct(int productid)
        {
            Product product = await appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productid);
            string id =  _userManager.GetUserId(HttpContext.User);
            AppUser user = appDbContext.AppUsers.FirstOrDefault(x => x.Id == id);
            if (user.Wallet > product.Price*100)
            {
                AppUserProduct userProduct = new AppUserProduct
                {
                    AppUserId = user.Id,
                    ProductId = productid,
                };

                user.Wallet = user.Wallet - product.Price*100;

                await appDbContext.AddAsync(userProduct);
                await appDbContext.SaveChangesAsync(); 
            }

            return RedirectToAction("Index", "Home");
            
        }


        public IActionResult Wishlist()
        {
            return View();
        }


        public IActionResult Checkout()
        {
            return View();
        }
    }
}
