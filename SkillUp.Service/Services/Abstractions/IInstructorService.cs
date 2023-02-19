using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IInstructorService
    {
        Task<ICollection<Instructor>> GetAllInstructorAsync();

        Task<Instructor> GetInstructorById(string id);

        Task DeleteCourseAsync(string id);
        
        Task<UpdateCourseVM> UpdateCourseById(int id);
        
        Task<bool> UpdateCourseAsync(UpdateCourseVM updateCourseVM);

    }
}
