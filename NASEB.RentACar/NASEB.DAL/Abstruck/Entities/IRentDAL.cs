using NASEB.Entities.ComplexType;
using NASEB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASEB.DAL.Abstruck.Entities
{
    public interface IRentDAL:IDALBase<Rent>
    {
        IQueryable<RentCustomerBranchUserView> GetRentRelationalTablesInfo();
    }
}
