using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SkillUp.Core.Entities;
using SkillUp.DAL.Context;
using SkillUp.DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace SkillUp.DAL.Repositories.Concretes.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly AppDbContext _context;
        readonly DbSet<T> _obj;


        public Repository(AppDbContext context)
        {
            _context = context;
            _obj = _context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await _obj.AddAsync(entity);    
        }


        public async Task DeleteAsync(int id)
        {
            T item = await _obj.FirstOrDefaultAsync(x => x.Id == id);
            if(item != null) _obj.Remove(item); 
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _obj;
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _obj;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.SingleAsync();
        }

        public  T GetByIdAsync(int id)
        {
            return _obj.Find(id);
            
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=>_obj.Update(entity));
            return entity;
        }

       
    }
}
