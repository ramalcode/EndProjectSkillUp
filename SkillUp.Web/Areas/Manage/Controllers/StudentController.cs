using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class StudentController : Controller
    {
        readonly AppDbContext dbContext;

        public StudentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> ManageStudents()
        {
            var student = await dbContext.AppUsers.Include(ac=>ac.AppUserCourses).ThenInclude(c=>c.Course).ThenInclude(i=>i.Instructor)
                .Include(ap=>ap.AppUserProducts).ThenInclude(p=>p.Product).ToListAsync();   
            return View(student);
        }
    }
}
