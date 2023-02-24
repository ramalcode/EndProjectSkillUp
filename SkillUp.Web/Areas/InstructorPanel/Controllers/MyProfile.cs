using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;
using SkillUp.Service.Services.Concretes;

namespace SkillUp.Web.Areas.InstructorPanel.Controllers
{
        [Area("InstructorPanel")]
    public class MyProfile : Controller
    {
        readonly UserManager<Instructor> _userManager;
        readonly IInstructorService _instructorService;
        readonly IWebHostEnvironment _env;

        public MyProfile(UserManager<Instructor> userManager, IInstructorService instructorService, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _instructorService = instructorService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            var instructor = await _instructorService.UpdateInstructorById(id);

            return View(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateInstructorVM instructorVM)
        {
            string id = _userManager.GetUserId(HttpContext.User);
            Instructor instructor = new Instructor();
            if (instructorVM.Image != null)
            {
                string imgresult = instructorVM.Image.CheckValidate("image/", 500);
                if (imgresult.Length > 0)
                {
                    ModelState.AddModelError("Image", imgresult);
                }

                //instructor.ImageUrl.DeleteFile(_env.WebRootPath, "user/assets/instructorimg");
                instructor.ImageUrl = instructorVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorimg"));

            }
            if (instructorVM.Preview != null)
            {
                string prevresult = instructorVM.Preview.CheckValidate("video/", 500000);
                if (prevresult.Length > 0)
                {
                    ModelState.AddModelError("Image", prevresult);
                }

                //instructor.PreviewVideoUrl.DeleteFile(_env.WebRootPath, "user/assets/instructorpreview");
                instructor.PreviewVideoUrl = instructorVM.Preview.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorpreview"));
            }
            await _instructorService.UpdateInstructorAsync(id, instructorVM);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
