using Microsoft.AspNetCore.Mvc;

namespace SkillUp.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
