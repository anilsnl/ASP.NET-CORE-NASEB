using System.Linq;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.Services.Abstract
{
    public interface IRoleService : IBaseService<Role>
    {
        IQueryable<User> GetUsersInTheRole(int roleid);
        IQueryable<User> GetUsersInTheRole(string rolename);
    }
}
