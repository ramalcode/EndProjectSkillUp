using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class LectureController : Controller
    {
        readonly IParagraphService _paragraph;
        readonly ICourseService _courseService;
        readonly ILectureService _lectureService;
        readonly IWebHostEnvironment _env;
        readonly AppDbContext _context;

        public LectureController(IParagraphService paragraph, ICourseService course, ILectureService lectureService, IWebHostEnvironment env, AppDbContext context)
        {
            _paragraph = paragraph;
            _courseService = course;
            _lectureService = lectureService;
            _env = env;
            _context = context;
        }

        public IActionResult Paragraphs(int id)
        {
            var paragraphs = _context.Courses.Include(p => p.Paragraphs).ThenInclude(l => l.Lectures).FirstOrDefault(x => x.Id == id);
            return View(paragraphs);
        }

        public async Task<IActionResult> UpdateParagraph(int id)
        {
            var paragraph = await _paragraph.UpdateParagraphById(id);
            return View(paragraph);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateParagraph(int id, UpdateParagraphVM paragraphVM)
        {
            await _paragraph.UpdateParagraphAsync(id, paragraphVM);
            return RedirectToAction("ManageCourses", "Course");
        }

        public async Task<IActionResult> Lectures(int id)
        {
            var lectures = await _context.Paragraphs.Include(l => l.Lectures).FirstOrDefaultAsync(x => x.Id == id);
            return View(lectures);
        }

        public async Task<IActionResult> DeleteParagraph(int id)
        {
            await _paragraph.DeleteParagraphAsync(id);
            return RedirectToAction("ManageCourses", "Course");
        }

        public async Task<IActionResult> DeleteLecture(int id)
        {
            await _lectureService.DeleteLectureAsync(id);
            return RedirectToAction("ManageCourses", "Course");
        }


        public async Task<IActionResult> UpdateLecture(int id)
        {
            var lecture = await _lectureService.UpdateLectureById(id);
            return View(lecture);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLecture(int id, UpdateLectureVM lectureVM)
        {
            Lecture lecture = new Lecture();
            if (lectureVM.Video != null)
            {
                string result = lectureVM.Video.CheckValidate("video/", 50000);
                if (result.Length > 0)
                {
                    ModelState.AddModelError("Preview", result);
                }

                lecture.VideoUrl.DeleteFile(_env.WebRootPath, "user/assets/coursevideo");
                lecture.VideoUrl = lectureVM.Video.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "coursevideo"));
            }
            await _lectureService.UpdateLectureAsync(id, lectureVM);
            return RedirectToAction("ManageCourses", "Course");
        }



    }
}
