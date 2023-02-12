using SkillUp.Core.Entities;
using SkillUp.DAL.Repositories.Abstractions;

namespace SkillUp.DAL.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
        int Save();
    }
}
