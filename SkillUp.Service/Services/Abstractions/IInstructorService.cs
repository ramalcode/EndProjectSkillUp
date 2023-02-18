using SkillUp.Entity.Entities;
using SkillUp.Entity.ViewModels;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IInstructorService
    {
        Task<ICollection<Instructor>> GetAllInstructorAsync();
        Task<UpdateCourseVM> UpdateCourseById(int id);
        Task<Instructor> GetInstructorById(string id);
        //Task CreateInstructorAsync(CreateInstructorVM instructorVM);
        Task DeleteCourseAsync(int id);
        Task<bool> UpdateCourseAsync(UpdateCourseVM updateCourseVM);

    }
}
