using Microsoft.AspNetCore.Hosting;
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

        public InstructorService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task CreateInstructorAsync(CreateInstructorVM instructorVM)
        {
            Instructor instructor = new Instructor
            {
                Name = instructorVM.Name,
                Surname = instructorVM.Surname,
                UserName = instructorVM.UserName,
                Description = instructorVM.Description,
                Email = instructorVM.Email,
                Password = instructorVM.Password,
                StripeKey = instructorVM.StripeKey,
                ImageUrl = instructorVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorimg")),
                PreviewVideoUrl = instructorVM.Preview.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "instructorpreview")),
                InstagramUrl = instructorVM.InstagramUrl,
                FaceBookUrl = instructorVM.FacebookURL,
                TwitterUrl = instructorVM.TwitterURL,
                LinkedInUrl = instructorVM.LinkedInUrl,
            }; 

            await _unitOfWork.GetRepository<Instructor>().AddAsync(instructor);
            await _unitOfWork.SaveAsync();
            
        }

        public Task DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Instructor>> GetAllInstructorAsync()
        {
            var instructor = await _unitOfWork.GetRepository<Instructor>().GetAllAsync(null,c=>c.Courses);
            return instructor;
        }

        public Task<Course> GetCourseById(int id)
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
