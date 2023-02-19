using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities.Reviews;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
    public class ReviewCourseService : IReviewCourseService
    {
        readonly IUnitOfWork _unitOfWork;

        public ReviewCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateReviewAsync(CreateCourseReviewVM reviewVM, string id)
        {
           CourseReview courseReview = new CourseReview
           {
               AppUserId = id,
               CourseId = reviewVM.CourseId,
               ReviewContent = reviewVM.ReviewContent,  
               ReviewDate = DateTime.Now,
               Status = true,
           };  
            await _unitOfWork.GetRepository<CourseReview>().AddAsync(courseReview);
            await _unitOfWork.SaveAsync();
        }
    }
}
