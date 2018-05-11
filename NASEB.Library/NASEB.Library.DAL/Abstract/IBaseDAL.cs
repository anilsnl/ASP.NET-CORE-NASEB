using NASEB.Library.Entities.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Library.DAL.Abstract
{
    public interface IBaseDAL<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetList(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        int GetCount(Expression<Func<T, bool>> expression = null);
        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<bool> AnyExistAsync(Expression<Func<T, bool>> expression);
        
    }
}
