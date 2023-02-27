using SkillUp.DAL.Context;
using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.Entities.Relations.ManyToMany;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
    public class EnrollService : IEnrollService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly AppDbContext _context;  //

        public EnrollService(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task EnrollStudentAsync(EnrollStudentVM studentVM)
        {
            AppUserCourse userCourse = new AppUserCourse
            {
                AppUserId = studentVM.AppUserId,
                CourseId = studentVM.CourseId,
                IsSold = false
            };
            await _unitOfWork.GetRepository<AppUserCourse>().AddAsync(userCourse);
            await _unitOfWork.SaveAsync();
        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AppUserCourse>> GetAllEnrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(UpdateCategoryVM categoryVM)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateCategoryVM> UpdateCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EnrollProductAsync(EnrollProductVM productVM)
        {
            AppUserProduct userProduct = new AppUserProduct
            {
                AppUserId = productVM.AppUserId,
                ProductId = productVM.ProductId,
                IsBuyed = false
                
            };
            await _unitOfWork.GetRepository<AppUserProduct>().AddAsync(userProduct);
            await _unitOfWork.SaveAsync();
        }
    }
}
