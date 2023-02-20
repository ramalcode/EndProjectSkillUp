using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Areas.InstructorPanel.Controllers
{
    public class MyProfile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
