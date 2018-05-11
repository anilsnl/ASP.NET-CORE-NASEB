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
    public class CarService : ICarService
    {
        private IUnitOfWork _work;
        public CarService(IUnitOfWork work)
        {
            _work = work;
        }
        public bool Add(Car entity)
        {
            _work.Cars.Add(entity);
            return _work.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(Car entity)
        {
            _work.Cars.Add(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public bool Delete(Car entity)
        {
            _work.Cars.Delete(entity);
            return _work.Cars.SaveChanges() > 0;

        }

        public async Task<bool> DeleteAsync(Car entity)
        {
            _work.Cars.Delete(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public Car Get(Expression<Func<Car, bool>> expression)
        {
            return _work.Cars.Get(expression);
            
        }

        public IQueryable<Car> GetAll()
        {
           return _work.Cars.GetAll();
        }

        public Task<Car> GetAsync(Expression<Func<Car, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CarBranchView> GetBranchOfCar()
        {
           return _work.Cars.GetBranchNameOfCars();
            
        }

        public IQueryable<Car> GetList(Expression<Func<Car, bool>> expression = null)
        {
            return _work.Cars.GetList(expression);
        }

        public bool Update(Car entity)
        {
            _work.Cars.Update(entity);
            return _work.SaveChnages() > 0;
        }

        public Task<bool> UpdateAsync(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
