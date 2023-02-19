using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
    public class InstructorService : IInstructorService
    {
        readonly AppDbContext _context;


        public InstructorService(AppDbContext context)
        {
            _context = context;
        }


        //GetAll Instructor
        public async Task<ICollection<Instructor>> GetAllInstructorAsync()
        {
            return await _context.Instructors.Include(c=>c.Courses).ToListAsync();
        }


        //Get Instructor By Id
        public async Task<Instructor> GetInstructorById(string id)
        {

            return await _context.Instructors.Include(c => c.Courses).ThenInclude(ap => ap.AppUserCourses).Include(c => c.Courses)
                .ThenInclude(c => c.CourseCategories).ThenInclude(c => c.Category).
                Include(c => c.Courses).ThenInclude(p => p.Paragraphs).ThenInclude(l=>l.Lectures).
                Include(p => p.Products).Include(ia => ia.AppUserInstructors).ThenInclude(a => a.AppUser).Include(p => p.Products).ThenInclude(pc => pc.ProductCategories)
                .ThenInclude(c=>c.Category).Include(p=>p.Products).ThenInclude(ap=>ap.AppUserProducts).FirstOrDefaultAsync(i=>i.Id == id);
        }


        //Delete Instructor
        public async Task DeleteCourseAsync(string id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();  
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
