using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public async Task DeleteUserAsync(string id)
        {
            var student = await _context.AppUsers.FindAsync(id);
             _context.AppUsers.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AppUser>> GetAllUserAsync()
        {
            return await _context.AppUsers.Include(ac => ac.AppUserCourses).ThenInclude(c => c.Course).ThenInclude(i => i.Instructor)
               .Include(ap => ap.AppUserProducts).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(a => a.Id == id);
            return user;
        }

        public async Task<bool> UpdateUserAsync(string id ,UpdateUserVM userVM)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
            user.Name = userVM.Name;
            user.Surname = userVM.Surname;
            user.Email = userVM.Email;

            _context.AppUsers.Update(user);
            _context.SaveChanges();
            return true;
        }

        public async Task<UpdateUserVM> UpdateUserById(string id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u=>u.Id == id);
            UpdateUserVM userVm = new UpdateUserVM
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email, 
                ImageUrl = user.ImageUrl,
                CurrentPassword = user.PasswordHash,
            };
            return userVm;  
        }
    }
}
