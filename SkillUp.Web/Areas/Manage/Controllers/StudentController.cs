using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class StudentController : Controller
    {
        readonly IUserService _userService;
        readonly UserManager<AppUser> _userManager;


        public StudentController(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ManageStudents()
        {
            var students = await _userService.GetAllUserAsync();
            return View(students);
        }

        public async Task<IActionResult> DeleteStudent(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction(nameof(ManageStudents));
        }


        public async Task<IActionResult> UpdateStudent(string id)
        {
            return View();
        }

        public async Task<IActionResult> UpdateStudent(string id, UpdateUserVM userVM)
        {
            return View();
        }

        public async Task<IActionResult> UpgradeRole(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _userManager.RemoveFromRoleAsync(user, "Student");
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, "Admin");
            }

            return RedirectToAction("manageadmin", "admin");
        }
    }
}
