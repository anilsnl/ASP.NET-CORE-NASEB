using NASEB.DAL.Abstruck;
using NASEB.Entities.Concrete;
using NASEB.Services.Abstruck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NASEB.Services.Concrete
{
    public class BranchService : IBranchService
    {
        private IUnitOfWork _work;
        public BranchService(IUnitOfWork work)
        {
            _work = work;
        }
        public bool Add(Branch entity)
        {
            _work.Branchs.Add(entity);
            return _work.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(Branch entity)
        {
            _work.Branchs.Add(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public bool Delete(Branch entity)
        {
            _work.Branchs.Delete(entity);
            return _work.Branchs.SaveChanges() > 0;

        }

        public async Task<bool> DeleteAsync(Branch entity)
        {
            _work.Branchs.Delete(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public Branch Get(Expression<Func<Branch, bool>> expression)
        {
            return _work.Branchs.Get(expression);

        }

        public IQueryable<Branch> GetAll()
        {
            return _work.Branchs.GetAll();
        }

        public Task<Branch> GetAsync(Expression<Func<Branch, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Branch> GetList(Expression<Func<Branch, bool>> expression = null)
        {
            return _work.Branchs.GetList(expression);
        }

        public bool Update(Branch entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Branch entity)
        {
            throw new NotImplementedException();
        }
    }
}
