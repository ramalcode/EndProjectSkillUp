using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface ISubCategoryService
    {
        Task<ICollection<SubCategory>> GetAllSubCategoryAsync();
        Task<SubCategory> GetSubCategoryById(int id);    
        Task CreateSubCategoryAsync(CreateSubCategoryVM subCategoryVM);
        Task DeleteSubCategoryAsync(int id);
        Task<string> UpdateSubCategoryAsync(UpdateSubCategoryVM subCategoryVM);




    }
}
