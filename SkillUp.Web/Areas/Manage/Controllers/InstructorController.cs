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


        public IActionResult InstructorsPayouts()
        {
            return View();
        }
    }
}
