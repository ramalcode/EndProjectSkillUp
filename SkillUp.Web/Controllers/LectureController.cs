using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Service.Services.Abstractions;
using SkillUp.Service.Services.Concretes;

namespace SkillUp.Web.Controllers
{
    public class LectureController : Controller
    {
        readonly ILectureService _lectureService;
        readonly UserManager<AppUser> _userManager;
        readonly IUserService _userService;
        readonly AppDbContext _context;

        public LectureController(ILectureService lectureService, UserManager<AppUser> userManager, IUserService userService, AppDbContext context)
        {
            _lectureService = lectureService;
            _userManager = userManager;
            _userService = userService;
            _context = context;
        }


        public async Task<IActionResult> Index(int id)
        {
            var lecture = await _lectureService.GetLectureById(id);
            lecture.IsWatched = true;
            return View(lecture);
        }
    }
}
