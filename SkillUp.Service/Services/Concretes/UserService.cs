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

        public Task<Instructor> GetInstructorById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseAsync(UpdateCourseVM updateCourseVM)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateCourseVM> UpdateCourseById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
