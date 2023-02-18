using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IReviewCourseService
    {
        Task CreateReviewAsync(CreateCourseReviewVM reviewVM, string id);

    }
}
