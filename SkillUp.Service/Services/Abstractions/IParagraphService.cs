using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
	public interface IParagraphService
	{
        Task<ICollection<Paragraph>> GetAllParagraphAsync();
        Task<UpdateCategoryVM> UpdateParagraphById(int id);
        Task<Paragraph> GetParagraphById(int id);
        Task CreateParagraphAsync(CreateParagraphVM paragraphVM);
        Task DeleteParagraphAsync(int id);
        Task<bool> UpdateParagraphAsync(UpdateParagraphVM paragraphVM);
    }
}
