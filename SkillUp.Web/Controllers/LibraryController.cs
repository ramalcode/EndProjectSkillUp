using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class LibraryController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly AppDbContext _context;

        public LibraryController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            var courses = await _context.AppUserCourses.Where(c => c.AppUserId == id).Include(c=>c.Course).ThenInclude(i=>i.Instructor).ToListAsync();
            return View(courses);
        }
    }
}
