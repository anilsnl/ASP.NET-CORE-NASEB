using Microsoft.EntityFrameworkCore;
using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFNASEBRoleDAL : EFBaseDAL<NASEBRole>, INASEBRoleDAL
    {
        private EFNASEBDBContext _context;
        public EFNASEBRoleDAL(EFNASEBDBContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<NASEBRole> GetRolesByUser(NASEBUser user)
        {
            return _context.Roles.Include(a => a.UserRoles).ThenInclude(q => q.User).Where(q => q.UserRoles.Any(a => a.UserID == user.UserID));
        }
    }
}
