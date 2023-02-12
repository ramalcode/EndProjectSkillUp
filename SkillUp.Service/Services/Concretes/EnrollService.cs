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
            };
            //var courses = await _unitOfWork.GetRepository<Course>().GetAllAsync(c => studentVM.CourseIds.Any());
            //var users = _context.AppUsers.Where(u => studentVM.AppUserIds.Contains(u.Id));

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
    }
}
