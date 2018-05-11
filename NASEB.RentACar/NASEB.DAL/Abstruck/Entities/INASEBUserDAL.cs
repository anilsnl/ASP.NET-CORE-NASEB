using NASEB.DAL.Concrete.EF;
using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Abstruck.Entities
{
    public interface INASEBUserDAL:IDALBase<NASEBUser>
    {
        List<NASEBRole> GetRolesByUserID(int id);
        IQueryable<UserBranchView> ReachtoBranchFromUser();
    }
}
