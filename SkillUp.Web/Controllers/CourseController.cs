using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Controllers
{
    public class CourseController : Controller
    {
        readonly AppDbContext _appDbContext;

        public CourseController(ICourseService courseService, IParagraphService paragraphService, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult FindCourses()
        {
            return View();
        }


        public async Task<IActionResult> CourseDetail(int id)
        {
            var course =  _appDbContext.Courses.Include(p=>p.Paragraphs).ThenInclude(l=>l.Lectures)
                .Include(cc=>cc.CourseCategories).ThenInclude(ctg=>ctg.Category)
                .Include(a=>a.AppUserCourses).ThenInclude(u=>u.AppUser)
                .Include(i=>i.Instructor).FirstOrDefault(x=>x.Id == id);
            return View(course);
        }
    }
}
