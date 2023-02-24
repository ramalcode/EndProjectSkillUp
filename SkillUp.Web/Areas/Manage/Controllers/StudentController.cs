using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;
using SkillUp.Service.Services.Concretes;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class StudentController : Controller
    {
        readonly IUserService _userService; 


        public StudentController(IUserService userService)
        {
            _userService = userService;
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
    }
}
