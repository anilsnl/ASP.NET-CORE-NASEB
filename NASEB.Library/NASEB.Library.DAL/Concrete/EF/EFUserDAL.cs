using Microsoft.EntityFrameworkCore.Update;
using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFUserDAL : EFBaseDAL<User>,IUserDAL
    {
        public EFUserDAL(NASEBLibraryDbContext context) : base(context)
        {
        }
    }
}
