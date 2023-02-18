using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;
using SkillUp.Service.Helpers;

namespace SkillUp.Web.Areas.InstructorPanel.Controllers
{
    [Area("InstructorPanel")]
    public class LectureController : Controller
    {
        readonly IParagraphService _paragraph;
        readonly ICourseService _courseService;
        readonly ILectureService _lectureService;

        public LectureController(IParagraphService paragraph, ICourseService course, ILectureService lectureService)
        {
            _paragraph = paragraph;
            _courseService = course;
            _lectureService = lectureService;
        }

        public async Task<IActionResult> AddNewCourseParagraph()
        {
            ViewBag.Course = new SelectList(await _courseService.GetAllCourseAsync(), nameof(Course.Id), nameof(Course.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCourseParagraph(CreateParagraphVM paragraphVM)
        {
            if (!ModelState.IsValid) return View();
            await _paragraph.CreateParagraphAsync(paragraphVM);
            return RedirectToAction(nameof(AddNewCourseParagraph));
        }

        public async Task<IActionResult> AddNewCourseLectures()
        {
            ViewBag.Paragraph = new SelectList(await _paragraph.GetAllParagraphAsync(), nameof(Paragraph.Id), nameof(Paragraph.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCourseLectures(CreateLectureVM lectureVM)
        {
            ViewBag.Paragraph = new SelectList(await _paragraph.GetAllParagraphAsync(), nameof(Paragraph.Id), nameof(Paragraph.Name));

            if (lectureVM.Video != null)
            {
                string result = lectureVM.Video.CheckValidate("video/", 50000);
                if (result.Length > 0)
                {
                    ModelState.AddModelError("Preview", result);
                }
            }

            await _lectureService.CreateLectureAsync(lectureVM);
            return View();
        }
    }
}
