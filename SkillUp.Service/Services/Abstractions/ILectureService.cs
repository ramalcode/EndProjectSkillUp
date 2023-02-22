using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface ILectureService
    {
        Task<ICollection<Lecture>> GetAllLectureAsync();
        Task<UpdateLectureVM> UpdateLectureById(int id);
        Task<Lecture> GetLectureById(int id);
        Task CreateLectureAsync(CreateLectureVM lectureVM);
        Task DeleteLectureAsync(int id);
        Task<bool> UpdateLectureAsync(int id,UpdateLectureVM lectureVM);
    }
}
