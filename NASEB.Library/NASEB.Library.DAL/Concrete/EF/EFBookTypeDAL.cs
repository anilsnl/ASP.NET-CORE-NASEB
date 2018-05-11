using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFBookTypeDAL : EFBaseDAL<BookType>,IBookTypeDAL
    {
        public EFBookTypeDAL(NASEBLibraryDbContext context) : base(context)
        {
        }
    }
}
