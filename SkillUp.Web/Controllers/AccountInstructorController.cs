using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Web.Controllers
{
    public class AccountInstructorController : Controller
    {
        readonly UserManager<Instructor> _userManager;
        readonly SignInManager<Instructor> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;


        public AccountInstructorController(UserManager<Instructor> userManager, SignInManager<Instructor> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult InstructorSignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InstructorSignUp(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);
            Instructor user = await _userManager.FindByNameAsync(register.UserName);
            if (user is not null)
            {
                ModelState.AddModelError("UserName", "UserName already exist");
                return View(register);
            }
            user = new Instructor
            {
                Name = register.Name,
                Surname = register.Surname,
                UserName = register.UserName,
                Email = register.Email,
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return RedirectToAction(nameof(SignIn));
        }


        public IActionResult InstructorSignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InstructorSignIn(LoginVM login, string? returnUrl)
        {
            if (!ModelState.IsValid) return View(login);
            Instructor user = await _userManager.FindByNameAsync(login.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", "Login or Password is wrong");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login or Password is wrong");
                return View();
            }
            if (returnUrl is not null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
