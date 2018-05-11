using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFBranchDAL:EFBaseDAL<Branch>,IBranchDAL
    {
        private EFNASEBDBContext _context;
        public EFBranchDAL(EFNASEBDBContext ctx):base(ctx)
        {
            _context = ctx;
        }
    }
}
