using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFRoleDAL : EFBaseDAL<Role>,IRoleDAL
    {
        public EFRoleDAL(NASEBLibraryDbContext context) : base(context)
        {
        }
    }
}
