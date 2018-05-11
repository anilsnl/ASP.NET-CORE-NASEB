using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFAuthorDAL : EFBaseDAL<Author>,IAuthorDAL
    {
        
        public EFAuthorDAL(NASEBLibraryDbContext context) : base(context)
        {
        }
    }
}
