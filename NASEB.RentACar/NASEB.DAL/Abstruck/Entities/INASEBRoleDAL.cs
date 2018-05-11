using NASEB.DAL.Concrete.EF;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Abstruck.Entities
{
    public interface INASEBRoleDAL:IDALBase<NASEBRole>
    {
        IQueryable<NASEBRole> GetRolesByUser(NASEBUser user);
    }
}
