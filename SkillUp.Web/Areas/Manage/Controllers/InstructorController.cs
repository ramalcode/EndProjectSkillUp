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

        public IActionResult AddNewInstructor()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInstructor(CreateInstructorVM instructorVM)
        {
            if (instructorVM.Image != null)
            {
                string result = instructorVM.Image.CheckValidate("image/", 500);
                if (result.Length > 0)
                {
                    ModelState.AddModelError("Image", result);
                }
            }
            if (instructorVM.Preview != null)
            {
                string result = instructorVM.Preview.CheckValidate("video/", 50000);
                if (result.Length > 0)
                {
                    ModelState.AddModelError("Preview", result);
                }
            }
            await _instructorService.CreateInstructorAsync(instructorVM);
            return RedirectToAction(nameof(ManageInstructor));
        }


        public IActionResult InstructorsPayouts()
        {
            return View();
        }
    }
}
