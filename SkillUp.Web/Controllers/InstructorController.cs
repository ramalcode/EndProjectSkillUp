using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;

namespace SkillUp.Web.Controllers
{
    public class InstructorController : Controller
    {
        readonly AppDbContext appDbContext;

        public InstructorController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult FindInstructor()
        {
            return View();
        }


        public IActionResult InstructorDetail(int id)
        {
            var instructor = appDbContext.Instructors.Include(ip=>ip.InstructorProfessions)
                .ThenInclude(p=>p.Profession).Include(ai=>ai.AppUserInstructors).ThenInclude(a=>a.AppUser)
                .Include(c=>c.Courses).ThenInclude(p=>p.Paragraphs).ThenInclude(l=>l.Lectures).FirstOrDefault(i=>i.Id == id);
            return View(instructor);
        }


    }
}
