using SkillUp.Core.Entities;
using System.Linq.Expressions;

namespace SkillUp.DAL.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties);
        T GetByIdAsync(int id); 
        Task AddAsync(T entity);
        Task DeleteAsync(int id); 
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
