using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;

namespace SkillUp.Web.Controllers
{
    public class AccountInstructorController : Controller
    {
        readonly UserManager<Instructor> _userManager;
        readonly SignInManager<Instructor> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly IWebHostEnvironment _env;


        public AccountInstructorController(UserManager<Instructor> userManager, SignInManager<Instructor> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
        }

        public IActionResult InstructorSignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InstructorSignUp(InstructorRegisterVM registerVM)
        {

            if (registerVM.Image != null)
            {
                string imageresult = registerVM.Image.CheckValidate("image/", 500);
                if (imageresult.Length > 0)
                {
                    ModelState.AddModelError("Image", imageresult);
                }
            }
            if (registerVM.Preview != null)
            {
                string previewresult = registerVM.Preview.CheckValidate("video/", 50000);
                if (previewresult.Length > 0)
                {
                    ModelState.AddModelError("Preview", previewresult);
                }
            }
            if (!ModelState.IsValid) return View(registerVM);
            Instructor user = await _userManager.FindByNameAsync(registerVM.UserName);
            if (user is not null)
            {
                ModelState.AddModelError("UserName", "UserName already exist");
                return View(registerVM);
            }
            user = new Instructor
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                Description = registerVM.Description,
                LinkedInUrl = registerVM.LinkedInUrl,
                FaceBookUrl = registerVM.FacebookUrl,
                InstagramUrl = registerVM.InstagramUrl,
                TwitterUrl = registerVM.TwitterUrl,
                Experince = registerVM.Experience,
                ImageUrl = registerVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorimg")),
                PreviewVideoUrl = registerVM.Preview.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorpreview")),

            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);
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
