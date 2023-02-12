using Microsoft.Extensions.DependencyInjection;
using SkillUp.Service.Services.Abstractions;
using SkillUp.Service.Services.Concretes;

namespace SkillUp.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IParagraphService, ParagraphService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<ILectureService, LectureService>();
            services.AddScoped<IEnrollService, EnrollService>();

            return services;
        }
    }
}
