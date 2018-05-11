using NASEB.Entities.Abstruck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NASEB.Services.Abstruck
{
    public interface IBaseService<TEntity> where TEntity :class,IEntity,new()
    {
        bool Add(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> GetAll();
    }
}
