using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NASEB.Library.DAL.Abstract
{
    public interface IBookDAL:IBaseDAL<Book>
    {
        void AddBookAothor(int bookid, int authorid);
        IQueryable<MainBookListView> GetMainBookListView(Expression<Func<MainBookListView, bool>> expression = null);
        IQueryable<MainBookListView> GetMainBookListView(int authorID);
        IQueryable<Book> GetBooksByAuthorID(int authorID);
    }
}
