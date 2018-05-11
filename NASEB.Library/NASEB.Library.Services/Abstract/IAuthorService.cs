using System.Linq;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.Services.Abstract
{
    public interface IAuthorService : IBaseService<Author>
    {
        IQueryable<Author> GetAuthorsByBookID(int bookid);
    }
}
