using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Helpers;
using SkillUp.Service.Services.Abstractions;


namespace SkillUp.Service.Services.Concretes
{
    public class LectureService : ILectureService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IWebHostEnvironment _env;

        public LectureService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task CreateLectureAsync(CreateLectureVM lectureVM)
        {
            Lecture lecture = new Lecture
            {
                Name = lectureVM.Name,
                ParagraphId = lectureVM.ParagraphId,
                IsWatched = false,
                VideoUrl = lectureVM.Video.SaveFile(Path.Combine(_env.WebRootPath, "user", "assets", "coursevideo"))
            };

            await _unitOfWork.GetRepository<Lecture>().AddAsync(lecture);
             await _unitOfWork.SaveAsync();
        }
    

        public Task DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Instructor>> GetAllInstructorAsync()
        {
            throw new NotImplementedException();
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
