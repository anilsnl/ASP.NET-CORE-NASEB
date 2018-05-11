using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFMemberDAL : EFBaseDAL<Member>,IMemberDAL
    {
        public EFMemberDAL(NASEBLibraryDbContext context) : base(context)
        {
        }
    }
}
