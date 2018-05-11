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
    public class BookTypeManager : IBookTypeService
    {
        private IUnitOfWork UnitOfWork;

        public BookTypeManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<ServiceResult> AddAsync(BookType entity)
        {
            try
            {
                UnitOfWork.BookTypes.Add(entity);
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

        public async Task<ServiceResult> DeleteAsync(BookType entity)
        {
            try
            {
                UnitOfWork.BookTypes.Delete(entity);
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

        public async Task<ServiceResult> UpdateAsync(BookType entity)
        {
            try
            {
                UnitOfWork.BookTypes.Update(entity);
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

        public IQueryable<BookType> GetList(Expression<Func<BookType, bool>> expression)
        {
            return UnitOfWork.BookTypes.GetList(expression);
        }

        public BookType Get(Expression<Func<BookType, bool>> expression)
        {
            return UnitOfWork.BookTypes.Get(expression);
        }

        public IQueryable<BookType> GetAll()
        {
            return UnitOfWork.BookTypes.GetAll();
        }

        public async Task<BookType> GetAsync(Expression<Func<BookType, bool>> expression)
        {
            return await UnitOfWork.BookTypes.GetAsync(expression);
        }

        public Task<int> CountAsync(Expression<Func<BookType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<BookType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
