using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;

namespace SkillUp.Web.ViewComponents
{
    public class WalletViewComponent:ViewComponent
    {
        readonly UserManager<AppUser> _userManager;
        readonly AppDbContext _context;

        public WalletViewComponent(UserManager<AppUser> usermanageer, AppDbContext context)
        {
            _userManager = usermanageer;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            AppUser user = await _context.AppUsers.FindAsync(id);
            return View(user);
        }
    }
}
