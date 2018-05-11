using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Abstract
{
    public interface IUserService:IBaseService<User>
    {
        Task<ServiceResult> CreateUserAsync(User user, string pasword);
        Task<LoginResult> CheckForLoginAsync(User user, string password);
        Task<ServiceResult> UpdateAsync(User user);
        Task<ServiceResult> ChangePasswordAsync(string email,string currentPassword, string password);
        Task<ServiceResult> ChangePasswordAsync(User user, string password);
        IQueryable<Role> GetRolesByUserID(int userid);
        Task<ServiceResult> ResetPasswordAsync(int userID, string newPassword);
    }
}
