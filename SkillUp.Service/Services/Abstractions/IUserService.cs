using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<ICollection<AppUser>> GetAllUserAsync();

        Task<Instructor> GetInstructorById(string id);

        Task DeleteUserAsync(string id);

        Task<UpdateCourseVM> UpdateCourseById(int id);

        Task<bool> UpdateCourseAsync(UpdateCourseVM updateCourseVM);
    }
}
