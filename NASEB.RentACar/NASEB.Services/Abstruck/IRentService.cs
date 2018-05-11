using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.Services.Abstruck
{
    public interface IRentService : IBaseService<Rent>
    {
        IQueryable<RentCustomerBranchUserView> GetRentInfos();

    }
}
