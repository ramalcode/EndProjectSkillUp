using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
