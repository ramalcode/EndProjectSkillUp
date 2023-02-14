using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;

namespace SkillUp.Web.Controllers
{
    public class ShopController : Controller
    {
        readonly AppDbContext appDbContext;

        public ShopController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
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
