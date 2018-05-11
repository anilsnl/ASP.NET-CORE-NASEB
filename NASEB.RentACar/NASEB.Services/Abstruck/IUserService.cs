using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.Services.Abstruck
{
    public interface IUserService:IBaseService<NASEBUser>
    {
        Task<bool> ChangePasswordAsync(NASEBUser user, string password);
        LoginResult VerifyForLogin(string email, string password);
        IQueryable<UserBranchView> UserBranchName();
       
    }
}
