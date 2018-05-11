using NASEB.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NASEB.Library.DAL.Abstract
{
    public interface IRentDAL : IBaseDAL<RentHistory>
    {
        IQueryable<RentOverviewView> GetRentOverviewView(Expression<Func<RentOverviewView, bool>> expression);
        IQueryable<RentHistoryView> GetRentHistoryView(Expression<Func<RentHistoryView, bool>> expression);
    }
}
