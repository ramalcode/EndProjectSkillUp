using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EnrollmentController : Controller
    {
        readonly IEnrollService _enrollService;
        readonly ICourseService _courseService;
        readonly AppDbContext _context;  //


        public EnrollmentController(IEnrollService enrollService, AppDbContext context, ICourseService courseService)
        {
            _enrollService = enrollService;
            _context = context;
            _courseService = courseService;
        }

        public async  Task<IActionResult> EnrollStudent()
        {
            ViewBag.AppUsers = new SelectList(_context.AppUsers, nameof(AppUser.Id), nameof(AppUser.Name));
            ViewBag.Courses = new SelectList(await _courseService.GetAllCourseAsync(), nameof(Course.Id), nameof(Course.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudent(EnrollStudentVM studentVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AppUsers = new SelectList(_context.AppUsers, nameof(AppUser.Id), nameof(AppUser.Name));
                ViewBag.Courses = new SelectList(await _courseService.GetAllCourseAsync(), nameof(Course.Id), nameof(Course.Name));
                return View();
            }
            if (studentVM is null) return NotFound();
            await _enrollService.EnrollStudentAsync(studentVM); 
            return RedirectToAction(nameof(EnrollStudent));
        }
    }
}
