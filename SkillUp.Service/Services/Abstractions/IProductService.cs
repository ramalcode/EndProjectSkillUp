﻿using SkillUp.Entity.Entities;
using SkillUp.Entity.Entities.Relations.CourseExtraProperities;
using SkillUp.Entity.ViewModels;

namespace SkillUp.Service.Services.Abstractions
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProductAsync();
        Task<UpdateProductVM> UpdateProductById(int id);
        Task<Product> GetProductById(int id);
        Task CreateProductAsync(CreateProductVM productVM);
        Task DeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(int id, UpdateProductVM productVM);
    }
}
