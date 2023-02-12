using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IEnrollService
    {
        Task<ICollection<AppUserCourse>> GetAllEnrollAsync();
        Task<UpdateCategoryVM> UpdateCategoryById(int id);
        Task<Category> GetCategoryById(int id);
        Task EnrollStudentAsync(EnrollStudentVM studentVM);
        Task DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(UpdateCategoryVM categoryVM);
    }
}
