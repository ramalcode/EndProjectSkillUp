using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;
using System;

namespace SkillUp.Web.Controllers
{
    public class CourseController : Controller
    {
        readonly AppDbContext _appDbContext;
        readonly UserManager<AppUser> _userManager;

        public CourseController(ICourseService courseService, IParagraphService paragraphService, AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
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
