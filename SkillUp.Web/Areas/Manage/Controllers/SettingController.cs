using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities.Settings;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {
        readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        //public IActionResult WebsiteSettings()
        //{
            
        //}

        //[HttpPost]
        //public IActionResult WebsiteSettings()
        //{
           
        //}


        public IActionResult SystemSettings()
        {
           
            return View();
        }


      
    }
}
