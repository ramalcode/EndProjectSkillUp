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


        public IActionResult Wishlist()
        {
            return View();
        }


        
    }
}
