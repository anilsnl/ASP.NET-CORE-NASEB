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
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork _work;
        public CompanyService(IUnitOfWork work)
        {
            _work = work;
        }
        public bool Add(Company entity)
        {
            _work.Compaines.Add(entity);
            return _work.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(Company entity)
        {
            _work.Compaines.Add(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public bool Delete(Company entity)
        {
            _work.Compaines.Delete(entity);
            return _work.Compaines.SaveChanges() > 0;

        }

        public async Task<bool> DeleteAsync(Company entity)
        {
            _work.Compaines.Delete(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public Company Get(Expression<Func<Company, bool>> expression)
        {
            return _work.Compaines.Get(expression);

        }

        public IQueryable<Company> GetAll()
        {
            return _work.Compaines.GetAll();
        }

        public Task<Company> GetAsync(Expression<Func<Company, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> GetList(Expression<Func<Company, bool>> expression = null)
        {
            return _work.Compaines.GetList(expression);
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
