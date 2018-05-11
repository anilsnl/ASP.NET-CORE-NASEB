using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Abstract;

namespace NASEB.Library.DAL.Concrete.EF
{
    public abstract class EFBaseDAL<TEntitiy>:IBaseDAL<TEntitiy> where TEntitiy:class,IEntity,new()
    {
        private NASEBLibraryDbContext _ctx;

        public EFBaseDAL(NASEBLibraryDbContext context)
        {
            _ctx = context;
        }
       
        public void Add(TEntitiy entity)
        {
            _ctx.Set<TEntitiy>().Add(entity);

        }

       

        public async Task<bool> AnyExistAsync(Expression<Func<TEntitiy, bool>> expression)
        {
            return await _ctx.Set<TEntitiy>().AnyAsync(expression); 
        }

        public void Delete(TEntitiy entity)
        {
            _ctx.Set<TEntitiy>().Remove(entity);

        }

        public TEntitiy Get(Expression<Func<TEntitiy, bool>> expression)
        {
            return _ctx.Set<TEntitiy>().FirstOrDefault(expression);

        }

        public IQueryable<TEntitiy> GetAll()
        {
            return _ctx.Set<TEntitiy>();
        }

        public async Task<TEntitiy> GetAsync(Expression<Func<TEntitiy, bool>> expression)
        {
            return await _ctx.Set<TEntitiy>().FirstOrDefaultAsync(expression);
        }

        public int GetCount(Expression<Func<TEntitiy, bool>> expression = null)
        {
            if (expression == null)
                return _ctx.Set<TEntitiy>().Count();
            else
                return _ctx.Set<TEntitiy>().Count(expression);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntitiy, bool>> expression = null)
        {
            if (expression == null)
                return await _ctx.Set<TEntitiy>().CountAsync();
            else
                return await _ctx.Set<TEntitiy>().CountAsync(expression);
        }

        public IQueryable<TEntitiy> GetList(System.Linq.Expressions.Expression<Func<TEntitiy, bool>> expression)
        {
            return _ctx.Set<TEntitiy>().Where(expression);
        }

        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        public void Update(TEntitiy entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}
