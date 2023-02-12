using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllCategoryAsync();
        Task<UpdateCategoryVM> UpdateCategoryById(int id);
        Task<Category> GetCategoryById(int id);
        Task CreateCategoryAsync(CreateCategoryVM categoryVM);
        Task DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(UpdateCategoryVM categoryVM);
    }
}
