using ehandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task AddToDbAsync(T entity);
        Task<T> GetByIdAsync(int id);
		void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        Task AddRangeAsync(IEnumerable<T> entity);
    }
}
