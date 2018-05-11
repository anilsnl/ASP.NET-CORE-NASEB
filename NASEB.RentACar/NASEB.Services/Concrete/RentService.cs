using NASEB.DAL.Abstruck;
using NASEB.Entities.ComplexType;
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
    public class RentService : IRentService
    {
        private IUnitOfWork _work;
        public RentService(IUnitOfWork work)
        {
            _work = work;
        }
        public bool Add(Rent entity)
        {
            _work.Rents.Add(entity);
            return _work.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(Rent entity)
        {
            _work.Rents.Add(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public bool Delete(Rent entity)
        {
            _work.Rents.Delete(entity);
            return _work.Rents.SaveChanges() > 0;

        }

        public async Task<bool> DeleteAsync(Rent entity)
        {
            _work.Rents.Delete(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public Rent Get(Expression<Func<Rent, bool>> expression)
        {
            return _work.Rents.Get(expression);

        }

        public IQueryable<Rent> GetAll()
        {
            return _work.Rents.GetAll();
        }

        public Task<Rent> GetAsync(Expression<Func<Rent, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Rent> GetList(Expression<Func<Rent, bool>> expression = null)
        {
            return _work.Rents.GetList(expression);
        }

        public IQueryable<RentCustomerBranchUserView> GetRentInfos()
        {
            return _work.Rents.GetRentRelationalTablesInfo();
        }

        public bool Update(Rent entity)
        {
            _work.Rents.Update(entity);
            return _work.SaveChnages() > 0;
        }

        public Task<bool> UpdateAsync(Rent entity)
        {
            throw new NotImplementedException();
        }


    }
}
