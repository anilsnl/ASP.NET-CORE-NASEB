using Microsoft.EntityFrameworkCore;
using NASEB.Entities.ComplexType;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Services.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private IUnitOfWork UnitOfWork;

        public PublisherManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<ServiceResult> AddAsync(Publisher entity)
        {
            try
            {
                UnitOfWork.Publishers.Add(entity);
                await UnitOfWork.SaveChangesAsync();
                return new ServiceResult(true);
            }
            catch (Exception e)
            {
                var result= new ServiceResult(false);
                result.Errors.Add(e.Message);
                return result;
            }
        }

        public async Task<ServiceResult> DeleteAsync(Publisher entity)
        {
            try
            {
                var publisher = await UnitOfWork.Publishers.GetAsync(a => a.PublisherID == entity.PublisherID);
                if (publisher == null)
                    throw new NullReferenceException("Yayınevi bulunamadı");
                UnitOfWork.Publishers.Delete(publisher);
                await UnitOfWork.SaveChangesAsync();
                return new ServiceResult(true);
            }
            catch (Exception e)
            {
                var result = new ServiceResult(false);
                result.Errors.Add(e.Message);
                return result;
            }
        }

        public async Task<ServiceResult> UpdateAsync(Publisher entity)
        {
            try
            {
                UnitOfWork.Publishers.Update(entity);
                await UnitOfWork.SaveChangesAsync();
                return new ServiceResult(true);
            }
            catch (Exception e)
            {
                var result = new ServiceResult(false);
                result.Errors.Add(e.Message);
                return result;
            }
        }

        public IQueryable<Publisher> GetList(Expression<Func<Publisher, bool>> expression)
        {
            return UnitOfWork.Publishers.GetList(expression);
        }

        public Publisher Get(Expression<Func<Publisher, bool>> expression)
        {
            return UnitOfWork.Publishers.Get(expression);
        }

        public IQueryable<Publisher> GetAll()
        {
            return UnitOfWork.Publishers.GetAll();
        }

        public async Task<int> GetTotalBooksCountByPublisherIDAsync(int publisherid)
        {
            return await 
                UnitOfWork.Books.GetList(a => a.PublisherID == publisherid).CountAsync();
        }

        public async Task<int> GetPublisherCount()
        {
            return await UnitOfWork.Publishers.GetAll().CountAsync();
        }

        public async Task<Publisher> GetAsync(Expression<Func<Publisher, bool>> expression)
        {
            return await UnitOfWork.Publishers.GetAsync(expression);
        }

        public Task<int> CountAsync(Expression<Func<Publisher, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Publisher, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
