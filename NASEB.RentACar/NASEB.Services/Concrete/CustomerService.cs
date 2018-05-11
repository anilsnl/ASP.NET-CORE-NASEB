using NASEB.DAL.Abstruck;
using NASEB.Entities.Concrete;
using NASEB.Services.Abstruck;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace NASEB.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _work;
        public CustomerService(IUnitOfWork work)
        {
            _work = work;
        }
        public bool Add(Customer entity)
        {
            _work.Customers.Add(entity);
            return _work.SaveChnages() > 0;
        }

        public async Task<bool> AddAsync(Customer entity)
        {
            try
            {
                var a = Convert.ToInt64(entity.TRIDNo);
                var tridcliend = new ServiceReference1.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
                var verificationresult = await tridcliend.TCKimlikNoDogrulaAsync(a, entity.Name.ToUpper(), entity.Surname.ToUpper(), entity.BirthDate);
                if (verificationresult.Body.TCKimlikNoDogrulaResult)
                {
                    _work.Customers.Add(entity);
                    
                }
                else
                {
                    throw new Exception("Girilen kişi için vatandaşlık doğrulanamadığı için kayıt başarısız oldu!");
                }

            }
            catch (Exception)
            {
                return false;
            }
            
            //_work.Customers.Add(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public bool Delete(Customer entity)
        {
            _work.Customers.Delete(entity);
            return _work.Customers.SaveChanges() > 0;

        }

        public async Task<bool> DeleteAsync(Customer entity)
        {
            _work.Customers.Delete(entity);
            return await _work.SaveChangesAsync() > 0;
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            return _work.Customers.Get(expression);

        }

        public IQueryable<Customer> GetAll()
        {
            return _work.Customers.GetAll();
        }

        public Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetList(Expression<Func<Customer, bool>> expression = null)
        {
            return _work.Customers.GetList(expression);
        }

        public bool Update(Customer entity)
        {
            _work.Customers.Update(entity);
            return _work.Customers.SaveChanges() > 0;
        }

        public Task<bool> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

    }
}
