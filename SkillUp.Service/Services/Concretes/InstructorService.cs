using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SkillUp.DAL.Context;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
    public class InstructorService : IInstructorService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IWebHostEnvironment _env;
        readonly AppDbContext appDbContext;


        public InstructorService(IUnitOfWork unitOfWork, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            this.appDbContext = appDbContext;
        }

        //public async Task CreateInstructorAsync(CreateInstructorVM instructorVM)
        //{
        //    Instructor instructor = new Instructor
        //    {
        //        Name = instructorVM.Name,
        //        Surname = instructorVM.Surname,
        //        UserName = instructorVM.UserName,
        //        Description = instructorVM.Description,
        //        Email = instructorVM.Email,
        //        StripeKey = instructorVM.StripeKey,
        //        ImageUrl = instructorVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorimg")),
        //        PreviewVideoUrl = instructorVM.Preview.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorpreview")),
        //        InstagramUrl = instructorVM.InstagramUrl,
        //        FaceBookUrl = instructorVM.FacebookURL,
        //        TwitterUrl = instructorVM.TwitterURL,
        //        LinkedInUrl = instructorVM.LinkedInUrl,
        //    }; 

        //    await _unitOfWork.GetRepository<Instructor>().AddAsync(instructor);
        //    await _unitOfWork.SaveAsync();

        //}

        public Task DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Instructor>> GetAllInstructorAsync()
        {
            var instructor = await appDbContext.Instructors.Include(c=>c.Courses).ToListAsync();
            return instructor;
        }

        public async Task<Instructor> GetInstructorById(string id)
        {
            
            var instructor = await appDbContext.Instructors.Include(c=>c.Courses).ThenInclude(ap=>ap.AppUserCourses).Include(c => c.Courses)
                .ThenInclude(c=>c.CourseCategories).ThenInclude(c=>c.Category).
                Include(c=>c.Courses).ThenInclude(p=>p.Paragraphs).
                Include(p=>p.Products).Include(ia=>ia.AppUserInstructors).ThenInclude(a=>a.AppUser).FirstOrDefaultAsync(i=>i.Id == id);
            return instructor;
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
