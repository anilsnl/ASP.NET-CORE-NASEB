using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFLogDAL : EFBaseDAL<Log>, ILogDAL
    {
        private EFNASEBDBContext _context;
        public EFLogDAL(EFNASEBDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
