using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class InstructorController : Controller
    {
        readonly IInstructorService _instructorService;


        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }


        public async Task<IActionResult> ManageInstructor()
        {
            var instructors = await _instructorService.GetAllInstructorAsync();
            return View(instructors);
        }


        public async Task<IActionResult> DeleteInstructor(string id)
        {
            await _instructorService.DeleteCourseAsync(id);
            return RedirectToAction(nameof(ManageInstructor));
        }


      
    }
}
