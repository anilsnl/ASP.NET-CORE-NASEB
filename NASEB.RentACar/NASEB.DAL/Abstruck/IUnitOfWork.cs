using NASEB.DAL.Abstruck.Entities;
using System;
using System.Threading.Tasks;

namespace NASEB.DAL.Abstruck
{
    public interface IUnitOfWork:IDisposable
    {
        ICarDAL Cars { get; }
        IRentDAL Rents { get; }
        INASEBRoleDAL Roles { get; }
        INASEBUserDAL Users { get; }
        ICustomerDAL Customers { get;  }
        ICompanyDAL Compaines { get; }
        ILogDAL Logs { get; }
        IBranchDAL Branchs { get; }

        int SaveChnages();
        Task<int> SaveChangesAsync();
    }
}
