using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface ICourseService
    {
        Task<ICollection<Course>> GetAllCourseAsync();
        Task<UpdateCourseVM> UpdateCourseById(int id);
        Task<Course> GetCourseById(int id);
        Task CreateCourseAsync(CreateCourseVM courseVM, string id);
        Task DeleteCourseAsync(int id);
        Task<bool> UpdateCourseAsync(int id, UpdateCourseVM updateCourseVM);
    }
}
