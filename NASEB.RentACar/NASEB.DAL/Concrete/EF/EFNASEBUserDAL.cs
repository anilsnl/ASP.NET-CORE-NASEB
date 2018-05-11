using Microsoft.EntityFrameworkCore;
using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFNASEBUserDAL : EFBaseDAL<NASEBUser>, INASEBUserDAL
    {
        private EFNASEBDBContext _context;
        public EFNASEBUserDAL(EFNASEBDBContext context) : base(context)
        {
            _context = context;
        }

        public List<NASEBRole> GetRolesByUserID(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == id);
         
            return _context.Roles.ToList();
        }

        public IQueryable<UserBranchView> ReachtoBranchFromUser()
        {
            var result = (from r in _context.Users
                          join b in _context.Branches on r.BranchID equals b.BranchID
                          select new UserBranchView()
                          {
                              BranchID = b.BranchID,
                              UserID = r.UserID,
                              Address = r.Address,
                              BirthDate = r.BirthDate,
                              BranchName = b.BranchName,
                              EMail=r.EMail,
                              Name=r.Name,
                              PasswordHash=r.PasswordHash,
                              PhoneNumber=r.PhoneNumber,
                              RegisterDate=r.RegisterDate,
                              Surname=r.Surname
                          });
            return result;

        }
    }
}
