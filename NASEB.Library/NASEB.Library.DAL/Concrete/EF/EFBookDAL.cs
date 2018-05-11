using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFBookDAL : EFBaseDAL<Book>,IBookDAL
    {
        NASEBLibraryDbContext _context;
        public EFBookDAL(NASEBLibraryDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddBookAothor(int bookid, int authorid)
        {
            _context.Add(new AuthorBooks() { AuthorID = authorid, BookID = bookid });
        }

        public IQueryable<Book> GetBooksByAuthorID(int authorID)
        {
            return _context.Books.Include(a => a.AuthorBooks).ThenInclude(a => a.Author).Where(a => a.AuthorBooks.Any(s => s.AuthorID == authorID));
        }

        public IQueryable<MainBookListView> GetMainBookListView(Expression<Func<MainBookListView, bool>> expression=null)
        {
            var list = (from book in _context.Books
                        join bookType in _context.BookTypes
                        on book.BookTypeID equals bookType.BookTypeID
                        join publisher in _context.Publishers
                        on book.PublisherID equals publisher.PublisherID

                        select new MainBookListView()
                        {
                            AwailableQuantity = book.AvailableQuantity,
                            BookID = book.BookID,
                            BookName = book.BookName.ToUpper(),
                            BookTypeID = book.BookTypeID,
                            BookTypeNanme = bookType.TypeName,
                            ISBN = book.ISBN,
                            PublisherID = book.PublisherID,
                            Location = book.Location,
                            PublisherName = publisher.PublisherName,
                            TotalCount = book.TotalQuantity,
                            Creaded_UpdatedDate = book.CreatedDate.ToString("dd/MM/yyyy") + " - " + book.LastUpdatedDate.ToString("dd/MM/yyyy"),
                            Authors=" "
                        });
            if (expression!=null)
            {
                return list.Where(expression);
            }
            return list;
        }

        public IQueryable<MainBookListView> GetMainBookListView(int authorID)
        {
            var books = _context.Books.Include(a => a.AuthorBooks).ThenInclude(a => a.Author).Where(a => a.AuthorBooks.Any(s => s.AuthorID == authorID));

            var list = (from book in books
                             join bookType in _context.BookTypes
                             on book.BookTypeID equals bookType.BookTypeID
                             join publisher in _context.Publishers
                             on book.PublisherID equals publisher.PublisherID

                             select new MainBookListView()
                             {
                                 AwailableQuantity = book.AvailableQuantity,
                                 BookID = book.BookID,
                                 BookName = book.BookName.ToUpper(),
                                 BookTypeID = book.BookTypeID,
                                 BookTypeNanme = bookType.TypeName,
                                 ISBN = book.ISBN,
                                 PublisherID = book.PublisherID,
                                 Location = book.Location,
                                 PublisherName = publisher.PublisherName,
                                 TotalCount = book.TotalQuantity,
                                 Creaded_UpdatedDate = book.CreatedDate.ToString("dd/MM/yyyy") + " - " + book.LastUpdatedDate.ToString("dd/MM/yyyy")
                             });
            return list;
        }
    }
}
