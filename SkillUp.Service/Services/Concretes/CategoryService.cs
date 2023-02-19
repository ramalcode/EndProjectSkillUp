using SkillUp.DAL.UnitOfWorks;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;
using SkillUp.Service.Services.Abstractions;

namespace SkillUp.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoryAsync(CreateCategoryVM categoryVM)
        {
            Category category = new Category
            {
                Name = categoryVM.Name,
                Description = categoryVM.Description,
                IconUrl = categoryVM.IconUrl,
            };

            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
             await _unitOfWork.GetRepository<Category>().DeleteAsync(id);
             await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(null,x=>x.SubCategories, cc=>cc.CourseCategories, pc=>pc.ProductCategories);
            return categories;

        }

        public async Task<UpdateCategoryVM> UpdateCategoryById(int id)
        {
            var category =  _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            UpdateCategoryVM categoryVM = new UpdateCategoryVM
            {
                Name = category.Name,
                Description = category.Description,
                IconUrl = category.IconUrl,
            };
            return categoryVM;
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryVM categoryVM)
        {
            Category category = await _unitOfWork.GetRepository<Category>().GetAsync(c => c.Id == categoryVM.Id);
            
            category.Name = categoryVM.Name;
            category.Description = categoryVM.Description;
            category.IconUrl = categoryVM.IconUrl;

            _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category =  _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            return category;    
        }
    }
}
