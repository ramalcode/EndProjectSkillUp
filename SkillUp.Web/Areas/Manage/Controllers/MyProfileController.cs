﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;
using Stripe;

namespace SkillUp.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MyProfileController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly IUserService _userService;
        readonly IWebHostEnvironment _env;

        public MyProfileController(UserManager<AppUser> userManager, IUserService userService, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _userService = userService;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            var user = await _userService.UpdateUserById(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserVM userVM)
        {
            string id = _userManager.GetUserId(HttpContext.User);
            AppUser user = new AppUser();
            if (userVM.Image != null)
            {
                string imgresult = userVM.Image.CheckValidate("image/", 500);
                if (imgresult.Length > 0)
                {
                    ModelState.AddModelError("Image", imgresult);
                }

                user.ImageUrl.DeleteFile(_env.WebRootPath, "user/assets/userimg");
                user.ImageUrl = userVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "userimg"));

            }
            if (user == null)
            {
                ModelState.AddModelError("", "Login or Password is wrong");
            }
            var result = await _userManager.ChangePasswordAsync(user, userVM.CurrentPassword, userVM.Password);
            await _userService.UpdateUserAsync(id, userVM);
            return RedirectToAction("Index" ,"Dashboard");
        }
        
    }
}
