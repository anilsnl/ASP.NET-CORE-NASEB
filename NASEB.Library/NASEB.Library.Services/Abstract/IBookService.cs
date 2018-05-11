using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.Services.Abstract
{
    public interface IBookService : IBaseService<Book>
    {
        Task<ServiceResult> AddWithISBNAsync(string ISBN,int count,int UserID);
        IQueryable<Book> GetBooksByTypeID(int booktypeid);
        IQueryable<Book> GetBookByAuthorID(int authorid);
        IQueryable<Book> GetBooksByPublisherID(int publisherid);
        IQueryable<Book> GetBookByTypeName(string name);
        Task<ServiceResult> AddAsync(Book book, List<int> selectedAuthors);


        IQueryable<MainBookListView> GetBasicBookList(Expression<Func<MainBookListView, bool>> expression = null);
        IQueryable<MainBookListView> GetBasicBookListByAuthorID(int authorID,Expression<Func<MainBookListView, bool>> expression = null);

        IQueryable<BaseSelectModel> SearchForBooksForSelecting(string word);
        
    }
}
