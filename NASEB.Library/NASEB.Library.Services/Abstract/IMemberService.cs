using System.Linq;
using System.Threading.Tasks;
using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.Services.Abstract
{
    public interface IMemberService : IBaseService<Member>
    {
        Task<ServiceResult> AddMemberWithVerifingTRIDAsync(Member member);
        Task<IAuthorService> ChangeUserStatusAsync(int memberID, int status);
        IQueryable<RentHistory> GetUserRentsByMemberID(int memberID);
        double GetTotalDeptByMemberID(int memberID);

        Task<LoginResult> CheckForLoginAsync(string name, string surname, int birthYear, long TRIDNo, bool isTRCitizen);


        IQueryable<BaseSelectModel> SearchForMembers(string searchingWord);
    }
}
