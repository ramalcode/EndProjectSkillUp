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
               Status = false,
           };  
            await _unitOfWork.GetRepository<CourseReview>().AddAsync(courseReview);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _unitOfWork.GetRepository<CourseReview>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();  
        }

        public Task<ICollection<CourseReview>> GetAllCourseReviewAsync()
        {
           var reviews = _unitOfWork.GetRepository<CourseReview>().GetAllAsync(null,u=>u.AppUser);   
           return reviews;
        }
    }
}
