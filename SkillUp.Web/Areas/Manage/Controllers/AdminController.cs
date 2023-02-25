using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.Entities;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminController : Controller
    {
        readonly IUserService _userService;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IUserService userService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> ManageAdmin()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");  
            return View(admins);
        }

        
    }
}
