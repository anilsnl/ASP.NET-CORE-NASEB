using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Abstract
{
    public interface IBaseService<T> where T : class, IEntity, new()
    {
        Task<ServiceResult> AddAsync(T entity);
        Task<ServiceResult> DeleteAsync(T entity);
        Task<ServiceResult> UpdateAsync(T entity);
        IQueryable<T> GetList(Expression<Func<T, bool>> expression);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        int Count(Expression<Func<T, bool>> expression = null);
        Task<int> CountAsync(Expression<Func<T, bool>> expression=null);
    }
}
