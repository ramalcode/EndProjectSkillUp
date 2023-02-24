using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {
        public IActionResult WebsiteSettings()
        {
            return View();
        }


        public IActionResult SystemSettings()
        {
            return View();
        }


        public IActionResult PaymentSettings()
        {
            return View();
        }

      
    }
}
