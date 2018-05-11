using Microsoft.EntityFrameworkCore;
using NASEB.Entities.ComplexType;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using NASEB.Library.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Concrete
{
    public class BookManager : IBookService
    {
        private IUnitOfWork UnitOfWork;

        public BookManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<ServiceResult> AddAsync(Book entity)
        {
            try
            {
                UnitOfWork.Books.Add(entity);
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

        public async Task<ServiceResult> DeleteAsync(Book entity)
        {
            try
            {
                if (await UnitOfWork.Books.AnyExistAsync(a=>a.BookID==entity.BookID))
                {
                    throw new NullReferenceException("Kitap bulunamadı!");
                }
                if (await UnitOfWork.Rents.AnyExistAsync(a=>a.BookID==entity.BookID))
                {
                    throw new Exception("Bu kitap kayıtlı kira bulundurduğu için silinemez!");
                }
                UnitOfWork.Books.Delete(entity);
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

        public async Task<ServiceResult> UpdateAsync(Book entity)
        {
            try
            {
                UnitOfWork.Books.Update(entity);
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



        public IQueryable<Book> GetList(Expression<Func<Book, bool>> expression)
        {
            return UnitOfWork.Books.GetList(expression);
        }

        public Book Get(Expression<Func<Book, bool>> expression)
        {
            return UnitOfWork.Books.Get(expression);
        }

        public IQueryable<Book> GetAll()
        {
            return UnitOfWork.Books.GetAll();
        }

        public async Task<ServiceResult> AddWithISBNAsync(string ISBN, int count, int UserID)
        {
            throw new NullReferenceException();
        }

        public IQueryable<Book> GetBooksByTypeID(int booktypeid)
        {
            return UnitOfWork.Books.GetList(a => a.BookTypeID == booktypeid);
        }

        public IQueryable<Book> GetBookByAuthorID(int authorid)
        {
            return UnitOfWork.Books.GetBooksByAuthorID(authorid);
        }

        public IQueryable<Book> GetBooksByPublisherID(int publisherid)
        {
            return UnitOfWork.Books.GetList(a => a.PublisherID == publisherid);
        }

        public IQueryable<Book> GetBookByTypeName(string name)
        {
            return UnitOfWork.Books.GetList(a => a.BookType.TypeName.ToLower().Equals(name.ToLower())).Include(a=>a.BookType);
        }

        public async Task<Book> GetAsync(Expression<Func<Book, bool>> expression)
        {
            return await UnitOfWork.Books.GetAsync(expression);
        }

        public async Task<ServiceResult> AddAsync(Book book, List<int> selectedAuthors)
        {
            var result = new ServiceResult(false);
            if (book == null || selectedAuthors == null)
                result.Errors.Add("Geçerli değer sağlanmado!");
            else
            {
                try
                {
                    UnitOfWork.Books.Add(book);
                    await UnitOfWork.SaveChangesAsync();
                    if (selectedAuthors.Count>0)
                    {
                        foreach (var item in selectedAuthors)
                        {
                            if (await UnitOfWork.Authors.AnyExistAsync(a=>a.AuthorID==item))
                            {
                                UnitOfWork.Books.AddBookAothor(book.BookID, item);
                            }
                        }
                        await UnitOfWork.SaveChangesAsync();
                        result.isSuccess = true;
                        result.Errors.Add("Kitap başarıyla eklendi!");
                    }
                }
                catch (Exception e)
                {
                    result.Errors.Add("Hata:" + e.Message);
                }
            }
            return result;
        }

        public IQueryable<MainBookListView> GetBasicBookList(Expression<Func<MainBookListView, bool>> expression)
        {
            return UnitOfWork.Books.GetMainBookListView(expression);
        }

        public IQueryable<BaseSelectModel> SearchForBooksForSelecting(string word)
        {
            if (String.IsNullOrEmpty(word))
                return null;
            word = word.ToLower();
            var listModel = UnitOfWork.Books.GetList(a => a.BookName.ToLower().Contains(word) || a.ISBN.ToLower().Contains(word))
                .Select(a => new BaseSelectModel()
                {
                    Key = a.BookID.ToString(),
                    Value = a.BookName
                }).OrderBy(a => a.Value);
            return listModel;
        }

        public IQueryable<MainBookListView> GetBasicBookListByAuthorID( int authorID = 0,Expression<Func<MainBookListView, bool>> expression = null)
        {
            var list = UnitOfWork.Books.GetMainBookListView(authorID);
            if (expression != null)
                return list.Where(expression);
            return list;
        }

        public async Task<int> CountAsync(Expression<Func<Book, bool>> expression = null)
        {
            return await UnitOfWork.Books.GetCountAsync(expression);
        }

        public int Count(Expression<Func<Book, bool>> expression = null)
        {
            return  UnitOfWork.Books.GetCount(expression);
        }
    }
}
