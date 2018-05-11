using NASEB.Entities.Abstruck;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.DAL.Abstruck
{
    public interface IDALBase<TEntity> where TEntity:class,IEntity,new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> GetAll();
        int SaveChanges();
        Task<int> SaveChangesAsync();
      
    }
}
