using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.Services.Abstruck
{
    public interface IRoleService:IBaseService<NASEBRole>
    {
        IQueryable<NASEBRole> GetUserRolesByUserID(int id);
    }
}
