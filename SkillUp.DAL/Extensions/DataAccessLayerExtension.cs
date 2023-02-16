using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillUp.DAL.Context;
using SkillUp.DAL.Repositories.Abstractions;
using SkillUp.DAL.Repositories.Concretes.GenericRepository;
using SkillUp.DAL.UnitOfWorks;

namespace SkillUp.DAL.Extension
{
    public static class DataAccessLayerExtension
    {
        public static IServiceCollection DataLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
            });

            

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
