using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFCompanyDAL:EFBaseDAL<Company>,ICompanyDAL
    {
        private EFNASEBDBContext _context;
        public EFCompanyDAL(EFNASEBDBContext ctx):base(ctx)
        {
            _context = ctx;
        }
    }
}
