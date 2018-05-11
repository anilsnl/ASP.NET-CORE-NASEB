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
    public class AuthorManager : IAuthorService
    {
        private IUnitOfWork UnitOfWork;

        public AuthorManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<ServiceResult> AddAsync(Author entity)
        {
            try
            {
                UnitOfWork.Authors.Add(entity);
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

        public async Task<ServiceResult> DeleteAsync(Author entity)
        {
            try
            {
                var author = UnitOfWork.Authors.GetAsync(a => a.AuthorID == entity.AuthorID);
                if (author == null)
                    throw new NullReferenceException("Yazar bulanamadı");
                
                UnitOfWork.Authors.Delete(entity);
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

        public async Task<ServiceResult> UpdateAsync(Author entity)
        {
            try
            {
                UnitOfWork.Authors.Update(entity);
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

        

        public IQueryable<Author> GetList(Expression<Func<Author, bool>> expression)
        {
            return UnitOfWork.Authors.GetList(expression);
        }

        public Author Get(Expression<Func<Author, bool>> expression)
        {
            return UnitOfWork.Authors.Get(expression);
        }

        public IQueryable<Author> GetAll()
        {
            return UnitOfWork.Authors.GetAll();
        }

        public IQueryable<Author> GetAuthorsByBookID(int bookid)
        {
            throw new NullReferenceException();
        }

        public async Task<Author> GetAsync(Expression<Func<Author, bool>> expression)
        {
            return await UnitOfWork.Authors.GetAsync(expression);
        }

        public Task<int> CountAsync(Expression<Func<Author, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Author, bool>> expression = null)
        {
            throw new NotImplementedException();

        }
    }
}
