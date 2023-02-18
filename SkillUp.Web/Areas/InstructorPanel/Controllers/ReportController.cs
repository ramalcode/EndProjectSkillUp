using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Areas.InstructorPanel.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
