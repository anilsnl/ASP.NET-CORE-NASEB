using NASEB.DAL.Abstruck;
using NASEB.Entities.Abstruck;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.DAL.Concrete.EF
{
    public abstract class EFBaseDAL<T>: IDALBase<T> where T:class,IEntity,new()
    {
        private EFNASEBDBContext _context;
        public EFBaseDAL(EFNASEBDBContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> expression = null)
        {
           if(expression==null)
                return _context.Set<T>();
            return _context.Set<T>().Where(expression);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
