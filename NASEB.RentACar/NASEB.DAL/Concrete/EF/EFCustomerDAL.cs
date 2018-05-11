using NASEB.DAL.Abstruck.Entities;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASEB.DAL.Concrete.EF
{
    public class EFCustomerDAL:EFBaseDAL<Customer>,ICustomerDAL
    {
        private EFNASEBDBContext _context;
        public EFCustomerDAL(EFNASEBDBContext ctx):base(ctx)
        {
            _context = ctx;
        }
    }
}
