using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminController : Controller
    {
        public IActionResult ManageAdmin()
        {
            return View();
        }

        
    }
}
