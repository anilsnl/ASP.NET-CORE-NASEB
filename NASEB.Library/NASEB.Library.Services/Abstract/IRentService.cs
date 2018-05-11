using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NASEB.Library.Services.Abstract
{
    public interface IRentService : IBaseService<RentHistory>
    {
        Task<ServiceResult> ComplateRentByIDAsync(int rentid);
        Task<ServiceResult> GetRentableByUserIDAsync(int userid);
        IQueryable<RentStatuus> GetRentStatus();
        Task<ServiceResult> ExpandRentingEndDate(int rendID, int day);

        IQueryable<RentOverviewView> GetRentOverview(Expression<Func<RentOverviewView, bool>> expression);
        IQueryable<RentHistoryView> GetRentHistories(Expression<Func<RentHistoryView, bool>> expression);
    }
}
