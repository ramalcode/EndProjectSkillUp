using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.Entities.Reviews;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;
using System;

namespace SkillUp.Web.Controllers
{
    public class CourseController : Controller
    {
        readonly AppDbContext _appDbContext;
        readonly UserManager<AppUser> _userManager;
        readonly ICourseService _courseService;
        readonly IReviewCourseService _reviewcourseService;

        public CourseController(AppDbContext appDbContext, UserManager<AppUser> userManager, IReviewCourseService reviewcourseService, ICourseService courseService)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _reviewcourseService = reviewcourseService;
            _courseService = courseService;
        }

        public async Task<IActionResult> FindCourses()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return View(courses);
        }


        public async Task<IActionResult> CourseDetail(int id)
        {
            var course =  _appDbContext.Courses.Include(p=>p.Paragraphs).ThenInclude(l=>l.Lectures)
                .Include(cc=>cc.CourseCategories).ThenInclude(ctg=>ctg.Category)
                .Include(a=>a.AppUserCourses).ThenInclude(u=>u.AppUser)
                .Include(i=>i.Instructor).Include(c=>c.CourseReviews).ThenInclude(u=>u.AppUser).FirstOrDefault(x=>x.Id == id);
            
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(CreateCourseReviewVM review)
        {
            string userid =  _userManager.GetUserId(HttpContext.User);
            if (!ModelState.IsValid) return View(review);
            AppUserCourse userCourse = new AppUserCourse();
            if (userCourse.IsBuyed == false) await  _reviewcourseService.CreateReviewAsync(review, userid);
            return RedirectToAction("Index", "Home");
        }

    }
}
