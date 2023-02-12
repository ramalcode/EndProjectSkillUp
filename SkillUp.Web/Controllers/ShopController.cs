using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }


        public IActionResult ProductDetail()
        {
            return View();
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
