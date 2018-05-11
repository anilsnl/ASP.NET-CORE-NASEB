using System;
using System.Threading.Tasks;

namespace NASEB.Library.DAL.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IAuthorDAL Authors { get; }
        IBookDAL Books { get; }
        IBookTypeDAL BookTypes { get; }
        IMemberDAL Members { get; }
        IUserDAL Users { get; }
        IRentDAL Rents { get; }
        IPublisherDAL Publishers { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
