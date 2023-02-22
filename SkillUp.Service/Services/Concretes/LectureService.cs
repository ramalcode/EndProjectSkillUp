using Microsoft.AspNetCore.Hosting;
using SkillUp.DAL.UnitOfWorks;
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
    

        public async Task DeleteLectureAsync(int id)
        {
            await _unitOfWork.GetRepository<Lecture>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Lecture>> GetAllLectureAsync()
        {
            var lectures = await _unitOfWork.GetRepository<Lecture>().GetAllAsync(); 
            return lectures;
        }

        public Task<Lecture> GetLectureById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateLectureAsync(int id ,UpdateLectureVM lectureVM)
        {
            var lecture = _unitOfWork.GetRepository<Lecture>().GetByIdAsync(id);
            lecture.Name = lectureVM.Name;
            await _unitOfWork.GetRepository<Lecture>().UpdateAsync(lecture);
            await _unitOfWork.SaveAsync();
            return true;    
        }

        public async Task<UpdateLectureVM> UpdateLectureById(int id)
        {
            var lecture = _unitOfWork.GetRepository<Lecture>().GetByIdAsync(id);
            UpdateLectureVM lectureVM = new UpdateLectureVM
            {
                Name = lecture.Name,
                VideoUrl = lecture.VideoUrl
            };
            return lectureVM;
        }
    }
}
