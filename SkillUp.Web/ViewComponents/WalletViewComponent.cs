using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Web.ViewComponents
{
    public class WalletViewComponent:ViewComponent
    {
        readonly UserManager<AppUser> _userManager;
        readonly UserManager<Instructor> _instructorManager;
        readonly AppDbContext _context;

        public WalletViewComponent(UserManager<AppUser> usermanageer, AppDbContext context, UserManager<Instructor> instructorManager)
        {
            _userManager = usermanageer;
            _context = context;
            _instructorManager = instructorManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? userid = _userManager.GetUserId(HttpContext.User);
            string? instructorid = _instructorManager.GetUserId(HttpContext.User);
            InfoVM info = new InfoVM
            {
                AppUser = await _context.AppUsers.FindAsync(userid),
                Instructor = await _context.Instructors.FindAsync(instructorid)
            };
            return View(info);
        }
    }
}
