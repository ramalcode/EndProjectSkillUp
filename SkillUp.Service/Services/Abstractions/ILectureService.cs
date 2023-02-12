using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface ILectureService
    {
        Task<ICollection<Instructor>> GetAllInstructorAsync();
        Task<UpdateCourseVM> UpdateCourseById(int id);
        Task<Course> GetCourseById(int id);
        Task CreateLectureAsync(CreateLectureVM lectureVM);
        Task DeleteCourseAsync(int id);
        Task<bool> UpdateCourseAsync(UpdateCourseVM updateCourseVM);
    }
}
