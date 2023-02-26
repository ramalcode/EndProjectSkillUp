using SkillUp.Entity.Entities.Reviews;
using SkillUp.Entity.Entities.Settings;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IReviewCourseService
    {
        Task CreateReviewAsync(CreateCourseReviewVM reviewVM, string id);
        Task<ICollection<CourseReview>> GetAllCourseReviewAsync();
        Task DeleteReviewAsync(int id);
        Task<bool> ReadReviewAsync(int id);


    }
}
