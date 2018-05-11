using NASEB.DAL.Abstruck;
using NASEB.DAL.Abstruck.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASEB.DAL.Concrete.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private EFNASEBDBContext _context;
        private ICarDAL _cars;
        private ICompanyDAL _companies;
        private ICustomerDAL _customers;
        private IBranchDAL _branches;
        private IRentDAL _rents;
        private INASEBRoleDAL _roles;
        private INASEBUserDAL _users;
        private ILogDAL _logs;
        public EFUnitOfWork(EFNASEBDBContext ctx)
        {
            _context = ctx;
        }
        public IBranchDAL Branchs { get { return _branches ?? new EFBranchDAL(_context); } }
        //ef dal bizden işlemleri yapmak için db context beklediğinden oluşturduğumuz contexti gönderiyoruz
        public ICarDAL Cars { get { return _cars ??  new EFCarDAL(_context); } }

        public IRentDAL Rents { get { return _rents ?? new EFRentDAL(_context); } }

        public INASEBRoleDAL Roles { get { return _roles ?? new EFNASEBRoleDAL(_context); } }

        public INASEBUserDAL Users { get { return _users ?? new EFNASEBUserDAL(_context); } }

        public ICustomerDAL Customers { get { return _customers ?? new EFCustomerDAL(_context); } }

        public ICompanyDAL Compaines { get { return _companies ?? new EFCompanyDAL(_context); } }

        public ILogDAL Logs { get { return _logs ?? new EFLogDAL(_context); } }
       


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChnages()
        {
            return _context.SaveChanges();
        }
    }
}
