using NASEB.Library.DAL.Abstract;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class EFPublisherDAL : EFBaseDAL<Publisher>,IPublisherDAL
    {
        public EFPublisherDAL(NASEBLibraryDbContext context) : base(context)
        {
        }
    }
}
